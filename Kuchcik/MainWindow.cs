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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void recipesListButton_Click(object sender, EventArgs e)
        {
            recipesListWindow recipesListWindow = new recipesListWindow();
            recipesListWindow.ShowDialog();
        }

        private void groceriesButton_Click(object sender, EventArgs e)
        {
            MyIngredientsWindow myIngredientsWindow = new MyIngredientsWindow();
            myIngredientsWindow.ShowDialog();
        }
    }
}
