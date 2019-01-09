namespace Kuchcik
{
    partial class ViewRecipeWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DifficultyLevelLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.ImgBox = new System.Windows.Forms.PictureBox();
            this.DescriptionBox = new System.Windows.Forms.RichTextBox();
            this.TitleBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Ingredient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ImgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // DifficultyLevelLabel
            // 
            this.DifficultyLevelLabel.AutoSize = true;
            this.DifficultyLevelLabel.Location = new System.Drawing.Point(421, 82);
            this.DifficultyLevelLabel.Name = "DifficultyLevelLabel";
            this.DifficultyLevelLabel.Size = new System.Drawing.Size(73, 13);
            this.DifficultyLevelLabel.TabIndex = 2;
            this.DifficultyLevelLabel.Text = "DifficultyLevel";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(18, 82);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(30, 13);
            this.TimeLabel.TabIndex = 3;
            this.TimeLabel.Text = "Time";
            // 
            // ImgBox
            // 
            this.ImgBox.Location = new System.Drawing.Point(424, 110);
            this.ImgBox.Name = "ImgBox";
            this.ImgBox.Size = new System.Drawing.Size(364, 240);
            this.ImgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImgBox.TabIndex = 4;
            this.ImgBox.TabStop = false;
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(21, 110);
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.ReadOnly = true;
            this.DescriptionBox.Size = new System.Drawing.Size(397, 415);
            this.DescriptionBox.TabIndex = 5;
            this.DescriptionBox.Text = "";
            // 
            // TitleBox
            // 
            this.TitleBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TitleBox.Location = new System.Drawing.Point(21, 12);
            this.TitleBox.Multiline = true;
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.ReadOnly = true;
            this.TitleBox.Size = new System.Drawing.Size(767, 57);
            this.TitleBox.TabIndex = 6;
            this.TitleBox.Text = "Title";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ingredient,
            this.Count,
            this.Unit});
            this.dataGridView1.Location = new System.Drawing.Point(424, 357);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(364, 168);
            this.dataGridView1.TabIndex = 7;
            // 
            // Ingredient
            // 
            this.Ingredient.HeaderText = "Składnik";
            this.Ingredient.Name = "Ingredient";
            this.Ingredient.ReadOnly = true;
            // 
            // Count
            // 
            this.Count.HeaderText = "Ilość";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Jednostka";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // ViewRecipeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 537);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.TitleBox);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.ImgBox);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.DifficultyLevelLabel);
            this.Name = "ViewRecipeWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Przepis";
            ((System.ComponentModel.ISupportInitialize)(this.ImgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label DifficultyLevelLabel;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.PictureBox ImgBox;
        private System.Windows.Forms.RichTextBox DescriptionBox;
        private System.Windows.Forms.TextBox TitleBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ingredient;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
    }
}