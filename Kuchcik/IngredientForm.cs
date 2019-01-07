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
        public IngredientForm(int id = -1)
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            DatabaseControl.ConnectDB();

            string sql = "INSERT INTO ingredients (name, unit) VALUES ('" + ingredientNameTextBox.Text + "', '" + ingredientUnitTextBox.Text + "')";
            SQLiteCommand command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
            command.ExecuteNonQuery();

            command.Cancel();
            sql = "SELECT id FROM ingredients WHERE name = '" + ingredientNameTextBox.Text + "'";
            command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            string ingredient_id = reader["id"].ToString();

            command.Cancel();
            sql = "ALTER TABLE recipes ADD COLUMN ingredient_" + ingredient_id + " REAL DEFAULT 0.0";
            command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
            command.ExecuteNonQuery();

            command.Cancel();
            this.Close();
        }
    }
}
