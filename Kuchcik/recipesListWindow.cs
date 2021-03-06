﻿using System;
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
    public partial class RecipesListWindow : Form
    {
        private bool edited;
        public event Action<bool> editedRecipesList;
        public RecipesListWindow()
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
            this.Enabled = false;

            LoadingWindow loadingWindow = new LoadingWindow();
            loadingWindow.Show();

            Application.DoEvents();

            DatabaseControl.ConnectDB();

            string sql = "SELECT * FROM recipes ORDER BY title ASC";
            SQLiteCommand command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            while (reader.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["id"].Value = reader["id"];
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Title"].Value = reader["title"];

                Bitmap img;

                try
                {
                    System.Net.WebRequest request = System.Net.WebRequest.Create(reader["img"].ToString());
                    request.Timeout = 500;
                    System.Net.WebResponse response = request.GetResponse();
                    System.IO.Stream responseStream = response.GetResponseStream();
                    img = new Bitmap(responseStream);
                }
                catch (Exception ex)
                {
                    img = null;
                }

                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Image"].Value = img;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Time"].Value = reader["time"];
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Difficulty_level"].Value = reader["difficulty_level"];
            }

            ((DataGridViewImageColumn)dataGridView1.Columns[2]).ImageLayout = DataGridViewImageCellLayout.Stretch;

            DatabaseControl.DisonnectDB();

            this.Enabled = true;
            loadingWindow.Close();
        }

        private void addNewButton_Click(object sender, EventArgs e)
        {
            RecipeForm recipeForm = new RecipeForm();
            recipeForm.FormClosed += RecipeForm_FormClosed;
            recipeForm.edited += value => edited = value;
            recipeForm.ShowDialog();
        }

        private void RecipeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (edited)
                fillDataGrid();
            edited = false;
        }

        private void ingredientsButton_Click(object sender, EventArgs e)
        {
            IngredientsListWindow ingredientsListWindow = new IngredientsListWindow();
            ingredientsListWindow.FormClosed += IngredientsListWindow_FormClosed;
            ingredientsListWindow.editedRecipesWindow += value => edited = value;
            ingredientsListWindow.ShowDialog();
        }

        private void IngredientsListWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (edited)
                fillDataGrid();
            edited = false;
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czy na pewno usunąć przepis?", "Usuń przepis", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                DataGridViewSelectedRowCollection row = dataGridView1.SelectedRows;
                string id = row[0].Cells["id"].Value.ToString();

                GC.Collect();
                GC.WaitForPendingFinalizers();
                DatabaseControl.ConnectDB();

                string sql = "DELETE FROM recipes WHERE id = " + id.ToString();
                SQLiteCommand command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
                command.ExecuteNonQuery();

                DatabaseControl.DisonnectDB();

                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);

                editedRecipesList(true);
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewSelectedRowCollection row = dataGridView1.SelectedRows;
                string id = row[0].Cells["id"].Value.ToString();

                ViewRecipeWindow viewRecipeWindow = new ViewRecipeWindow(Int32.Parse(id));
                viewRecipeWindow.ShowDialog();
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

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataGridViewSelectedRowCollection row = dataGridView1.SelectedRows;
                if (row.Count > 0)
                {
                    if (dataGridView1.CurrentCell.RowIndex >= 0 && dataGridView1.CurrentCell.RowIndex < dataGridView1.Rows.Count)
                    {
                        string id = row[0].Cells["id"].Value.ToString();

                        ViewRecipeWindow viewRecipeWindow = new ViewRecipeWindow(Int32.Parse(id));
                        viewRecipeWindow.ShowDialog();
                    }
                }
            }
        }
    }
}
