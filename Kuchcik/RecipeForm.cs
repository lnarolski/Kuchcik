using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
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
        private string TempIngredientName;
        public RecipeForm(int id = -1)
        {
            InitializeComponent();

            IngredientsList = new Dictionary<string, Ingredient>();
            usedIngredientsList = new Dictionary<string, Ingredient>();
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
            if (rowIndex >= 0 && colIndex >= 0)
            {
                DataGridViewComboBoxCell dgvcbc = (DataGridViewComboBoxCell)dataGrid.Rows[rowIndex].Cells[colIndex];
                // You might pass a boolean to determine whether to clear or not.
                if (dgvcbc.Value != null)
                {
                    if (usedIngredientsList.ContainsKey(dgvcbc.Value.ToString()))
                    {
                        usedIngredientsList.Remove(dgvcbc.Value.ToString());
                    }
                }
                dgvcbc.Items.Clear();
                foreach (KeyValuePair<string, Ingredient> itemToAdd in itemsToAdd)
                {
                    if (!usedIngredientsList.ContainsKey(itemToAdd.Key))
                    {
                        dgvcbc.Items.Add(itemToAdd.Key);
                    }
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
                SQLiteCommand command = new SQLiteCommand("INSERT INTO recipes (title, description, img, time, difficulty_level) VALUES (@title, @description, @img, @time, @difficulty_level)", DatabaseControl.m_dbConnection);
                command.Parameters.AddWithValue("@title", TitleBox.Text);
                command.Parameters.AddWithValue("@description", DescriptionBox.Text);
                command.Parameters.AddWithValue("@img", ImgBox.Text);
                command.Parameters.AddWithValue("@time", TimeBox.Text);
                command.Parameters.AddWithValue("@difficulty_level", DifficultyLevelBox.Text);
                command.ExecuteNonQuery();

                Debug.WriteLine("ID: " + DatabaseControl.m_dbConnection.LastInsertRowId);

                if (dataGridView1.RowCount > 1)
                {
                    string sql = "UPDATE recipes SET ";

                    DataGridViewRow Row = dataGridView1.Rows[0];
                    sql += "ingredient_" + Row.Cells[0].Value.ToString() + " = " + Row.Cells[2].Value.ToString();

                    for (int i = 1; i < dataGridView1.RowCount - 1; ++i)
                    {
                        Row = dataGridView1.Rows[i];
                        sql += ", ingredient_" + Row.Cells[0].Value.ToString() + " = " + Row.Cells[2].Value.ToString();
                    }

                    sql += " WHERE id = " + DatabaseControl.m_dbConnection.LastInsertRowId;

                    command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                    command.ExecuteNonQuery();
                }
            }

            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 1)
            //{
            //    setCellComboBoxItems(dataGridView1, e.RowIndex, e.ColumnIndex, IngredientsList);
            //}
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            //{
            //    string ingredientName;
            //    if ((ingredientName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) != null)
            //    {
            //        Ingredient ingredient = IngredientsList[ingredientName];

            //        dataGridView1.Rows[e.RowIndex].Cells[0].Value = ingredient.id;
            //        dataGridView1.Rows[e.RowIndex].Cells[3].Value = ingredient.unit;

            //        if (TempIngredientName != null && !string.Equals(TempIngredientName, ingredientName))
            //        {
            //            usedIngredientsList.Remove(TempIngredientName);
            //        }

            //        usedIngredientsList.Add(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), new Ingredient(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()));
            //    }
            //}
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

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                setCellComboBoxItems(dataGridView1, e.RowIndex, e.ColumnIndex, IngredientsList);
            }

            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    TempIngredientName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[2].Value != null)
            {
                try
                {
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = double.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString().Replace(',', '.'), NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Nieprawidłowa ilość", MessageBoxButtons.OK);
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = 0;
                }
                
            }

            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    string ingredientName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    Ingredient ingredient = IngredientsList[ingredientName];

                    dataGridView1.Rows[e.RowIndex].Cells[0].Value = ingredient.id;
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = ingredient.unit;

                    if (TempIngredientName != null && !string.Equals(TempIngredientName, ingredientName))
                    {
                        usedIngredientsList.Remove(TempIngredientName);
                    }

                    usedIngredientsList.Add(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), new Ingredient(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()));
                }
            }

            Debug.WriteLine("Ilość wierszy: " + dataGridView1.RowCount);
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow TempRow = e.Row;
            if (TempRow.Cells[1].Value != null)
                {
                if (usedIngredientsList.ContainsKey(TempRow.Cells[1].Value.ToString()))
                {
                    usedIngredientsList.Remove(TempRow.Cells[1].Value.ToString());
                }
            }
        }
    }
}
