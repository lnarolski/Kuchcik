﻿namespace Kuchcik
{
    partial class recipesListWindow
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.addNewButton = new System.Windows.Forms.Button();
            this.ingredientsButton = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Difficulty_level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.Image,
            this.Time,
            this.Difficulty_level});
            this.dataGridView1.Location = new System.Drawing.Point(23, 108);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(765, 330);
            this.dataGridView1.TabIndex = 4;
            // 
            // addNewButton
            // 
            this.addNewButton.Location = new System.Drawing.Point(23, 12);
            this.addNewButton.Name = "addNewButton";
            this.addNewButton.Size = new System.Drawing.Size(216, 90);
            this.addNewButton.TabIndex = 5;
            this.addNewButton.Text = "Dodaj przepis";
            this.addNewButton.UseVisualStyleBackColor = true;
            this.addNewButton.Click += new System.EventHandler(this.addNewButton_Click);
            // 
            // ingredientsButton
            // 
            this.ingredientsButton.Location = new System.Drawing.Point(245, 12);
            this.ingredientsButton.Name = "ingredientsButton";
            this.ingredientsButton.Size = new System.Drawing.Size(216, 90);
            this.ingredientsButton.TabIndex = 6;
            this.ingredientsButton.Text = "Lista składników";
            this.ingredientsButton.UseVisualStyleBackColor = true;
            this.ingredientsButton.Click += new System.EventHandler(this.ingredientsButton_Click);
            // 
            // Title
            // 
            this.Title.HeaderText = "Tytuł";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Image
            // 
            this.Image.HeaderText = "Zdjęcie";
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            // 
            // Time
            // 
            this.Time.HeaderText = "Czas [min]";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            // 
            // Difficulty_level
            // 
            this.Difficulty_level.HeaderText = "Poziom trudności";
            this.Difficulty_level.Name = "Difficulty_level";
            this.Difficulty_level.ReadOnly = true;
            // 
            // recipesListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ingredientsButton);
            this.Controls.Add(this.addNewButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "recipesListWindow";
            this.Text = "Lista przepisów";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addNewButton;
        private System.Windows.Forms.Button ingredientsButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewImageColumn Image;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Difficulty_level;
    }
}