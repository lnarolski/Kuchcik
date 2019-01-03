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
                dataGridView1.Rows.Add(reader["id"], reader["name"], reader["unit"]);
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

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            delButton.Enabled = true;
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            delButton.Enabled = false;
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czy na pewno usunąć składnik?\nZOSTANĄ USUNIĘTE RÓWNIEŻ PRZEPISY ZAWIERAJĄCE TEN SKŁADNIK!!!", "Usuń składnik", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DataGridViewSelectedRowCollection row = dataGridView1.SelectedRows;
                string id = row[0].Cells["id"].Value.ToString();
                
                DatabaseControl.ConnectDB();
                string sql = "DELETE FROM ingredients WHERE id = " + id.ToString();
                SQLiteCommand command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                command.ExecuteNonQuery();

                DatabaseControl.DisonnectDB();

                fillDataGrid();
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
    }
}
