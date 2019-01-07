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
        private int id;
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
                string ingredient_name = reader["name"].ToString();
                string ingredient_unit = reader["unit"].ToString();

                ingredientNameTextBox.Text = ingredient_name;
                ingredientUnitTextBox.Text = ingredient_unit;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            DatabaseControl.ConnectDB();

            if (id != -1)
            {
                string sql = "UPDATE ingredients SET name = '" + ingredientNameTextBox.Text + "', unit = '" + ingredientUnitTextBox.Text + "' WHERE id = " + id;
                SQLiteCommand command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                command.ExecuteNonQuery();
            }
            else
            {
                string sql = "INSERT INTO ingredients (name, unit) VALUES ('" + ingredientNameTextBox.Text + "', '" + ingredientUnitTextBox.Text + "')";
                SQLiteCommand command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                command.ExecuteNonQuery();
                
                sql = "SELECT id FROM ingredients WHERE name = '" + ingredientNameTextBox.Text + "'";
                command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                reader.Read();
                string ingredient_id = reader["id"].ToString();
                
                sql = "ALTER TABLE recipes ADD COLUMN ingredient_" + ingredient_id + " REAL DEFAULT 0.0";
                command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                command.ExecuteNonQuery();
            }

            this.Close();
        }
    }
}
