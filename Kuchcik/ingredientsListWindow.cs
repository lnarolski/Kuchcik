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
    public partial class ingredientsListWindow : Form
    {
        public event Action<bool> editedRecipesWindow;
        private bool edited;
        public ingredientsListWindow()
        {
            InitializeComponent();

            fillDataGrid();

            edited = false;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void fillDataGrid()
        {
            DatabaseControl.ConnectDB();
            string sql = "SELECT * FROM ingredients ORDER BY name ASC";
            SQLiteCommand command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["id"], reader["name"], reader["unit"]);
            }
            DatabaseControl.DisonnectDB();
        }

        private void addNewButton_Click(object sender, EventArgs e)
        {
            IngredientForm IngredientForm = new IngredientForm();
            IngredientForm.FormClosed += new FormClosedEventHandler(updateData);
            IngredientForm.edited += value => edited = value;
            IngredientForm.ShowDialog();
        }

        private void updateData(object sender, FormClosedEventArgs e)
        {
            if (edited)
                fillDataGrid();
            edited = false;
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czy na pewno usunąć składnik?\nZOSTANĄ USUNIĘTE RÓWNIEŻ PRZEPISY ZAWIERAJĄCE TEN SKŁADNIK ORAZ ELEMENTY Z TWOJEJ LISTY SKŁADNIKÓW!!!", "Usuń składnik", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DataGridViewSelectedRowCollection row = dataGridView1.SelectedRows;
                string id = row[0].Cells["id"].Value.ToString();
                
                DatabaseControl.ConnectDB();

                string sql = "DELETE FROM ingredients WHERE id = " + id.ToString();
                SQLiteCommand command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                command.ExecuteNonQuery();

                sql = "DELETE FROM recipes WHERE ingredient_" + id + " <> 0.0";
                command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                command.ExecuteNonQuery();

                sql = "DELETE FROM my_ingredients WHERE id = " + id;
                command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                command.ExecuteNonQuery();

                string ColumnNames = "pragma table_info(recipes)";
                command = new SQLiteCommand(ColumnNames, DatabaseControl.m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                sql = "CREATE TABLE recipes_backup (id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "title TEXT NOT NULL, " +
                    "description TEXT NOT NULL," +
                    "img TEXT, " +
                    "time INTEGER NOT NULL, ";
                for (int i = 0; i < 6; ++i)
                    reader.Read();
                sql += reader["name"].ToString() + " INTEGER NOT NULL";
                reader.Read();
                do
                {
                    if (String.Compare(reader["name"].ToString(), "ingredient_" + id) != 0)
                    {
                        sql += ", " + reader["name"].ToString() + " REAL DEFAULT 0.0";
                    }
                } while (reader.Read());
                sql += ")";
                command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                command.ExecuteNonQuery();

                command = new SQLiteCommand(ColumnNames, DatabaseControl.m_dbConnection);
                reader = command.ExecuteReader();
                sql = "INSERT INTO recipes_backup SELECT ";
                reader.Read();
                sql += reader["name"].ToString();
                reader.Read();
                do
                {
                    if (String.Compare(reader["name"].ToString(), "ingredient_" + id) != 0)
                    {
                        sql += ", " + reader["name"].ToString();
                    }
                } while (reader.Read());
                sql += " FROM recipes";
                command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                command.ExecuteNonQuery();

                DatabaseControl.DisonnectDB();
                DatabaseControl.ConnectDB();

                sql = "DROP TABLE recipes";
                command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                command.ExecuteNonQuery();

                sql = "ALTER TABLE recipes_backup RENAME TO recipes";
                command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                command.ExecuteNonQuery();

                DatabaseControl.DisonnectDB();

                //fillDataGrid();

                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);

                editedRecipesWindow(true);
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            delButton.Enabled = true;
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            delButton.Enabled = false;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewSelectedRowCollection row = dataGridView1.SelectedRows;
                string id = row[0].Cells["id"].Value.ToString();

                IngredientForm ingredientForm = new IngredientForm(Int32.Parse(id));
                ingredientForm.FormClosed += new FormClosedEventHandler(updateData);
                ingredientForm.edited += value => edited = value;
                ingredientForm.ShowDialog();
            }
        }
    }
}
