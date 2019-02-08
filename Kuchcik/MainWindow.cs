using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuchcik
{
    public partial class MainWindow : Form
    {
        RecipesListWindow recipesListWindow;
        private bool recipesListEdited;
        public MainWindow()
        {
            InitializeComponent();

            recipesListButton = null;

            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void recipesListButton_Click(object sender, EventArgs e)
        {
            if (recipesListWindow == null)
            {
                recipesListWindow = new RecipesListWindow();
                recipesListWindow.FormClosed += RecipesListWindow_FormClosed;
                recipesListWindow.editedRecipesList += value => recipesListEdited = value;
            }
            recipesListWindow.ShowDialog();
        }

        private void RecipesListWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (recipesListEdited)
            {
                dataGridView1.Rows.Clear();
                recipesListEdited = false;
            }
        }

        private void groceriesButton_Click(object sender, EventArgs e)
        {
            MyIngredientsWindow myIngredientsWindow = new MyIngredientsWindow();
            myIngredientsWindow.ShowDialog();
        }

        private string ColumnNameToId(string ColumnName)
        {
            return ColumnName.Substring("ingredient_".Count());
        }

        private void runAlgorithmButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> MyIngredientsList = new Dictionary<string, string>();

            this.Enabled = false;

            LoadingWindow loadingWindow = new LoadingWindow();
            loadingWindow.Show();

            Application.DoEvents();

            DatabaseControl.ConnectDB();
            string sql = "SELECT * FROM my_ingredients";
            SQLiteCommand command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    MyIngredientsList.Add(reader["id"].ToString(), reader["count"].ToString());
                }

                DatabaseControl.DisonnectDB();
                DatabaseControl.ConnectDB();

                string ColumnNames = "pragma table_info(recipes)";
                command = new SQLiteCommand(ColumnNames, DatabaseControl.m_dbConnection);
                reader = command.ExecuteReader();
                sql = "SELECT * FROM recipes WHERE ";
                for (int i = 0; i < 7; ++i)
                    reader.Read();
                if (reader.HasRows)
                {
                    string IngredientColumn = reader["name"].ToString();
                    if (MyIngredientsList.ContainsKey(ColumnNameToId(IngredientColumn)))
                    {
                        sql += IngredientColumn + " <= " + MyIngredientsList[ColumnNameToId(IngredientColumn)].Replace(',', '.');
                    }
                    else
                    {
                        sql += IngredientColumn + " = 0.0";
                    }
                    while (reader.Read())
                    {
                        IngredientColumn = reader["name"].ToString();
                        if (MyIngredientsList.ContainsKey(ColumnNameToId(IngredientColumn)))
                        {
                            sql += " AND " + IngredientColumn + " <= " + MyIngredientsList[ColumnNameToId(IngredientColumn)].Replace(',', '.');
                        }
                        else
                        {
                            sql += " AND " + IngredientColumn + " = 0.0";
                        }
                    }
                    sql += " ORDER BY title ASC";
                    command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                    reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        dataGridView1.Rows.Clear();
                        while (reader.Read())
                        {
                            Bitmap img;

                            try
                            {
                                System.Net.WebRequest request = System.Net.WebRequest.Create(reader["img"].ToString());
                                request.Timeout = 500;
                                System.Net.WebResponse response = request.GetResponse();
                                System.IO.Stream responseStream = response.GetResponseStream();
                                img = new Bitmap(responseStream);
                            }
                            catch (Exception ex)
                            {
                                img = null;
                            }

                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["id"].Value = reader["id"];
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Title"].Value = reader["title"];


                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Image"].Value = img;
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Time"].Value = reader["time"];
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Difficulty_level"].Value = reader["difficulty_level"];
                        }
                        ((DataGridViewImageColumn)dataGridView1.Columns[2]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                        dataGridView1.Refresh();

                        this.Enabled = true;
                        loadingWindow.Close();
                    }
                    else
                    {
                        this.Enabled = true;
                        loadingWindow.Close();
                        dataGridView1.Rows.Clear();
                        MessageBox.Show("Nie znaleziono żadnych przepisów!", "Brak przepisów", MessageBoxButtons.OK);
                    }
                    
                    DatabaseControl.DisonnectDB();

                }
                else
                {
                    this.Enabled = true;
                    loadingWindow.Close();
                    dataGridView1.Rows.Clear();
                    this.Show();
                    MessageBox.Show("Nie znaleziono żadnych przepisów!", "Brak przepisów", MessageBoxButtons.OK);
                }
            }
            else
            {
                DatabaseControl.DisonnectDB();
                DatabaseControl.ConnectDB();
                this.Enabled = true;
                loadingWindow.Close();
                dataGridView1.Rows.Clear();
                MessageBox.Show("Nie posiadasz żadnych składników!", "Brak składników", MessageBoxButtons.OK);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewSelectedRowCollection row = dataGridView1.SelectedRows;
                string id = row[0].Cells["id"].Value.ToString();

                ViewRecipeWindow viewRecipeWindow = new ViewRecipeWindow(Int32.Parse(id));
                viewRecipeWindow.ShowDialog();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
                if (rows.Count > 0)
                {
                    if (dataGridView1.CurrentCell.RowIndex >= 0 && dataGridView1.CurrentCell.RowIndex < dataGridView1.Rows.Count)
                    {
                        DataGridViewSelectedRowCollection row = dataGridView1.SelectedRows;
                        string id = row[0].Cells["id"].Value.ToString();

                        ViewRecipeWindow viewRecipeWindow = new ViewRecipeWindow(Int32.Parse(id));
                        viewRecipeWindow.ShowDialog();
                    }
                }
            }
        }
    }
}
