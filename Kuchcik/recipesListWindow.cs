using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        private void addNewButton_Click(object sender, EventArgs e)
        {
            RecipeForm recipeForm = new RecipeForm();
            recipeForm.ShowDialog();
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
