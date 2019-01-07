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
    public partial class recipesListWindow : Form
    {
        public recipesListWindow()
        {
            InitializeComponent();

            fillDataGrid();
        }

        private void fillDataGrid()
        {
            DatabaseControl.ConnectDB();
            string sql = "SELECT * FROM recipes ORDER BY title ASC";
            SQLiteCommand command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            while (reader.Read())
            {
                //dataGridView1.Rows.Add(reader["id"], reader["name"], reader["unit"]);
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["id"].Value = reader["id"];
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Title"].Value = reader["title"];

                System.Net.WebRequest request = System.Net.WebRequest.Create(reader["img"].ToString());
                System.Net.WebResponse response = request.GetResponse();
                System.IO.Stream responseStream = response.GetResponseStream();
                Bitmap img = new Bitmap(responseStream);

                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Image"].Value = img;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Time"].Value = reader["time"];
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Difficulty_level"].Value = reader["difficulty_level"];
            }
        }

        private void addNewButton_Click(object sender, EventArgs e)
        {
            RecipeForm recipeForm = new RecipeForm();
            recipeForm.FormClosed += RecipeForm_FormClosed;
            recipeForm.ShowDialog();
        }

        private void RecipeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            fillDataGrid();
        }

        private void ingredientsButton_Click(object sender, EventArgs e)
        {
            ingredientsListWindow ingredientsListWindow = new ingredientsListWindow();
            ingredientsListWindow.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
