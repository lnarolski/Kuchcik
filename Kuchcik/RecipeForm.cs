using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuchcik
{
    struct Ingredient
    {
        public string id;
        public string name;
        public string unit;

        public Ingredient(string id, string name, string unit)
        {
            this.id = id;
            this.name = name;
            this.unit = unit;
        }
    }
    public partial class RecipeForm : Form
    {
        private int id;
        Dictionary<string, Ingredient> IngredientsList;
        Dictionary<string, Ingredient> usedIngredientsList;
        public RecipeForm(int id = -1)
        {
            InitializeComponent();

            IngredientsList = new Dictionary<string, Ingredient>();
            DatabaseControl.ConnectDB();
            string sql = "SELECT * FROM ingredients ORDER BY name ASC";
            SQLiteCommand command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //dataGridView1.Rows.Add(reader["id"], reader["name"], reader["unit"]);
                IngredientsList.Add(reader["name"].ToString(), new Ingredient(reader["id"].ToString(), reader["name"].ToString(), reader["unit"].ToString()));
            }

            this.id = id;

            if (id != -1)
            {

            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setCellComboBoxItems(DataGridView dataGrid, int rowIndex, int colIndex, Dictionary<string, Ingredient> itemsToAdd)
        {
            if (rowIndex >= 0 && colIndex >= 0 && dataGridView1.Rows[rowIndex].Cells[colIndex].Value == null)
            {
                DataGridViewComboBoxCell dgvcbc = (DataGridViewComboBoxCell)dataGrid.Rows[rowIndex].Cells[colIndex];
                // You might pass a boolean to determine whether to clear or not.
                dgvcbc.Items.Clear();
                foreach (KeyValuePair<string, Ingredient> itemToAdd in itemsToAdd)
                {
                    dgvcbc.Items.Add(itemToAdd.Key);
                }
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            DatabaseControl.ConnectDB();

            if (id != -1)
            {
                //string sql = "UPDATE recipes SET name = '" + ingredientNameTextBox.Text + "', unit = '" + ingredientUnitTextBox.Text + "' WHERE id = " + id;
                //SQLiteCommand command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                //command.ExecuteNonQuery();
            }
            else
            {
                //string sql = "INSERT INTO recipes (name, unit) VALUES ('" + ingredientNameTextBox.Text + "', '" + ingredientUnitTextBox.Text + "')";
                //SQLiteCommand command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                //command.ExecuteNonQuery();

                //sql = "SELECT id FROM ingredients WHERE name = '" + ingredientNameTextBox.Text + "'";
                //command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                //SQLiteDataReader reader = command.ExecuteReader();
                //reader.Read();
                //string ingredient_id = reader["id"].ToString();

                //sql = "ALTER TABLE recipes ADD COLUMN ingredient_" + ingredient_id + " REAL DEFAULT 0.0";
                //command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                //command.ExecuteNonQuery();
            }

            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                setCellComboBoxItems(dataGridView1, e.RowIndex, e.ColumnIndex, IngredientsList);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                string ingredientName;
                if ((ingredientName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) != null)
                {
                    Ingredient ingredient = IngredientsList[ingredientName];

                    dataGridView1.Rows[e.RowIndex].Cells[0].Value = ingredient.id;
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = ingredient.unit;
                }
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //MessageBox.Show("Error happened " + e.Context.ToString());

            //if (e.Context == DataGridViewDataErrorContexts.Commit)
            //{
            //    MessageBox.Show("Commit error");
            //}
            //if (e.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            //{
            //    MessageBox.Show("Cell change");
            //}
            //if (e.Context == DataGridViewDataErrorContexts.Parsing)
            //{
            //    MessageBox.Show("parsing error");
            //}
            //if (e.Context == DataGridViewDataErrorContexts.LeaveControl)
            //{
            //    MessageBox.Show("leave control error");
            //}

            //if ((e.Exception) is ConstraintException)
            //{
            //    DataGridView view = (DataGridView)sender;
            //    view.Rows[e.RowIndex].ErrorText = "an error";
            //    view.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";

            //    e.ThrowException = false;
            //}
        }
    }
}
