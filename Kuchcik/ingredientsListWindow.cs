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
        public ingredientsListWindow()
        {
            InitializeComponent();

            fillDataGrid();
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
                dataGridView1.Rows.Add(reader["name"], reader["unit"]);
            }
            DatabaseControl.DisonnectDB();
        }

        private void addNewButton_Click(object sender, EventArgs e)
        {
            IngredientForm IngredientForm = new IngredientForm();
            IngredientForm.FormClosed += new FormClosedEventHandler(updateData);
            IngredientForm.ShowDialog();
        }

        private void updateData(object sender, FormClosedEventArgs e)
        {
            this.Invoke(new Action(delegate ()
            {
                fillDataGrid();
            }));
        }
    }
}
