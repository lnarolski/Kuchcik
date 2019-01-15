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
    public partial class IngredientForm : Form
    {
        public event Action<bool> edited;
        private int id;
        string ingredient_name;
        public IngredientForm(int id = -1)
        {
            InitializeComponent();

            this.id = id;

            if (id != -1)
            {
                DatabaseControl.ConnectDB();

                string sql = "SELECT * FROM ingredients WHERE id = " + id;
                SQLiteCommand command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                reader.Read();
                ingredient_name = reader["name"].ToString();
                string ingredient_unit = reader["unit"].ToString();

                ingredientNameTextBox.Text = ingredient_name;
                ingredientUnitTextBox.Text = ingredient_unit;

                DatabaseControl.DisonnectDB();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsinDB(string name)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            DatabaseControl.ConnectDB();

            SQLiteCommand command = new SQLiteCommand("SELECT * FROM ingredients WHERE name = @name", DatabaseControl.m_dbConnection);
            command.Parameters.AddWithValue("@name", name);
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                DatabaseControl.DisonnectDB();
                return true;
            }
            else
            {
                DatabaseControl.DisonnectDB();
                return false;
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                if (ingredient_name != ingredientNameTextBox.Text && IsinDB(ingredientNameTextBox.Text))
                {
                    MessageBox.Show("Podany składnik już istnieje!");
                    return;
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                DatabaseControl.ConnectDB();

                string sql = "UPDATE ingredients SET name = '" + ingredientNameTextBox.Text + "', unit = '" + ingredientUnitTextBox.Text + "' WHERE id = " + id;
                SQLiteCommand command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                command.ExecuteNonQuery();

                DatabaseControl.DisonnectDB();
            }
            else
            {
                if (IsinDB(ingredientNameTextBox.Text))
                {
                    MessageBox.Show("Podany składnik już istnieje!");
                    return;
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                DatabaseControl.ConnectDB();

                string sql = "INSERT INTO ingredients (name, unit) VALUES ('" + ingredientNameTextBox.Text + "', '" + ingredientUnitTextBox.Text + "')";
                SQLiteCommand command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                command.ExecuteNonQuery();

                string ingredient_id = DatabaseControl.m_dbConnection.LastInsertRowId.ToString();

                sql = "ALTER TABLE recipes ADD COLUMN ingredient_" + ingredient_id + " REAL DEFAULT 0.0";
                command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                command.ExecuteNonQuery();

                DatabaseControl.DisonnectDB();
            }

            edited(true);

            this.Close();
        }
    }
}
