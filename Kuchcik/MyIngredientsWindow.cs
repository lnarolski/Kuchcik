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
    public partial class MyIngredientsWindow : Form
    {
        Dictionary<string, Ingredient> IngredientsListName;
        Dictionary<string, Ingredient> IngredientsListId;
        Dictionary<string, Ingredient> usedIngredientsList;
        private string TempIngredientName;
        public MyIngredientsWindow()
        {
            InitializeComponent();

            ToolTip toolTip1 = new ToolTip();
            ToolTip toolTip2 = new ToolTip();

            toolTip1.SetToolTip(this.addIngredientButton, "Dodaj wiersz do listy");
            toolTip1.SetToolTip(this.delIngredientButton, "Usuń wiersz z listy");

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            IngredientsListName = new Dictionary<string, Ingredient>();
            IngredientsListId = new Dictionary<string, Ingredient>();
            usedIngredientsList = new Dictionary<string, Ingredient>();
            DatabaseControl.ConnectDB();
            string sql = "SELECT * FROM ingredients ORDER BY name ASC";
            SQLiteCommand command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                IngredientsListName.Add(reader["name"].ToString(), new Ingredient(reader["id"].ToString(), reader["name"].ToString(), reader["unit"].ToString()));
                IngredientsListId.Add(reader["id"].ToString(), new Ingredient(reader["id"].ToString(), reader["name"].ToString(), reader["unit"].ToString()));
            }
            
            sql = "SELECT * FROM my_ingredients";
            command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
            reader = command.ExecuteReader();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            while (reader.Read())
            {
                Debug.WriteLine("Liczba wierszy: " + dataGridView1.RowCount);


                dataGridView1.Rows.Add(reader["id"], new DataGridViewComboBoxCell(), reader["count"], IngredientsListId[reader["id"].ToString()].unit);

                DataGridViewComboBoxCell TempComboCell = (DataGridViewComboBoxCell)dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["IngridientName"];
                TempComboCell.Items.Add(IngredientsListId[reader["id"].ToString()].name);
                TempComboCell.Value = IngredientsListId[reader["id"].ToString()].name;

                usedIngredientsList.Add(IngredientsListId[reader["id"].ToString()].name, IngredientsListId[reader["id"].ToString()]);

            }

            DatabaseControl.DisonnectDB();
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
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                setCellComboBoxItems(dataGridView1, e.RowIndex, e.ColumnIndex, IngredientsListName);
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
                    Ingredient ingredient = IngredientsListName[ingredientName];

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

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            bool isAllIngredientsFilled = true;
            DataGridViewRow Row;
            for (int i = 0; i < dataGridView1.RowCount - 1; ++i)
            {
                Row = dataGridView1.Rows[i];
                if (Row.Cells[1].Value == null || Row.Cells[2].Value == null)
                {
                    isAllIngredientsFilled = false;
                    break;
                }
            }
            if (!isAllIngredientsFilled)
            {
                MessageBox.Show("UZUPEŁNIJ WSZYSTKIE WARTOŚCI DLA SKŁADNIKÓW!!!");
                return;
            }

            DatabaseControl.ConnectDB();

            SQLiteCommand command = new SQLiteCommand("DROP TABLE my_ingredients", DatabaseControl.m_dbConnection);
            command.ExecuteNonQuery();

            command = new SQLiteCommand("CREATE TABLE my_ingredients (id INTEGER NOT NULL," +
                    "count REAL DEFAULT 0.0)", DatabaseControl.m_dbConnection);
            command.ExecuteNonQuery();

            if (dataGridView1.RowCount > 1)
            {

                for (int i = 0; i < dataGridView1.RowCount - 1; ++i)
                {
                    Row = dataGridView1.Rows[i];

                    command = new SQLiteCommand("INSERT INTO my_ingredients (id, count) VALUES (@id, @count)", DatabaseControl.m_dbConnection);
                    command.Parameters.AddWithValue("@id", Row.Cells[0].Value.ToString());
                    command.Parameters.AddWithValue("@count", Row.Cells[2].Value.ToString().Replace(',', '.'));
                    command.ExecuteNonQuery();
                }
            }

            DatabaseControl.DisonnectDB();

            this.Close();
        }

        private void addIngredientButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void delIngredientButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                if (dataGridView1.CurrentCell.RowIndex >= 0 && dataGridView1.CurrentCell.RowIndex < dataGridView1.Rows.Count - 1)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                }
            }
        }
    }
}
