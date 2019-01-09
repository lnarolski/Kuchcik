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
    public partial class ViewRecipeWindow : Form
    {
        private int id;
        Dictionary<string, Ingredient> IngredientsList;
        public ViewRecipeWindow(int id = -1)
        {
            InitializeComponent();

            this.id = id;

            DatabaseControl.ConnectDB();

            IngredientsList = new Dictionary<string, Ingredient>();

            Dictionary<string, double> MyIngredientsList = new Dictionary<string, double>();
            string sql = "SELECT * FROM my_ingredients";
            SQLiteCommand command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                MyIngredientsList.Add(reader["id"].ToString(), double.Parse(reader["Count"].ToString()));
            }

            sql = "SELECT * FROM ingredients ORDER BY name ASC";
            command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                IngredientsList.Add(reader["id"].ToString(), new Ingredient(reader["id"].ToString(), reader["name"].ToString(), reader["unit"].ToString()));
            }

            sql = "SELECT * FROM recipes WHERE id = " + id;
            command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
            reader = command.ExecuteReader();
            reader.Read();

            TitleBox.Text = reader["title"].ToString();
            DescriptionBox.Text = reader["description"].ToString();
            TimeLabel.Text = "Czas przygotowania: " + reader["time"] + " min";
            DifficultyLevelLabel.Text = "Poziom trudności: " + reader["difficulty_level"];

            for (int i = 6; i < reader.FieldCount; ++i)
            {
                if (!string.Equals(reader[i].ToString(), "0.0") && !string.Equals(reader[i].ToString(), "0"))
                {
                    string tempId = ColumnNameToId(reader.GetName(i));
                    Ingredient tempIngredient = IngredientsList[tempId];

                    dataGridView1.Rows.Add(tempIngredient.name, reader[i].ToString(), tempIngredient.unit);
                    if (MyIngredientsList.ContainsKey(tempId))
                    {
                        if (double.Parse(reader[i].ToString()) > MyIngredientsList[tempId])
                        {
                            dataGridView1.Rows[dataGridView1.RowCount - 1].DefaultCellStyle.BackColor = Color.Red;
                        }
                    }
                }
            }

            Bitmap img;

            try
            {
                System.Net.WebRequest request = System.Net.WebRequest.Create(reader["img"].ToString());
                request.Timeout = 2000;
                System.Net.WebResponse response = request.GetResponse();
                System.IO.Stream responseStream = response.GetResponseStream();
                img = new Bitmap(responseStream);
            }
            catch (Exception ex)
            {
                img = null;
            }

            ImgBox.Image = img;

            DatabaseControl.DisonnectDB();
        }

        private string ColumnNameToId(string ColumnName)
        {
            return ColumnName.Substring("ingredient_".Count());
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
