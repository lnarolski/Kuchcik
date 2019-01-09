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
            DatabaseControl.ConnectDB();
            string sql = "SELECT * FROM ingredients ORDER BY name ASC";
            SQLiteCommand command = new SQLiteCommand(sql, DatabaseControl.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
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
                }
            }

            Bitmap img;

            try
            {
                System.Net.WebRequest request = System.Net.WebRequest.Create(reader["img"].ToString());
                System.Net.WebResponse response = request.GetResponse();
                System.IO.Stream responseStream = response.GetResponseStream();
                img = new Bitmap(responseStream);
            }
            catch (Exception ex)
            {
                img = null;
            }

            ImgBox.Image = img;
        }

        private string ColumnNameToId(string ColumnName)
        {
            return ColumnName.Substring("ingredient_".Count());
        }
    }
}
