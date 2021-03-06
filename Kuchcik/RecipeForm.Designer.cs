﻿namespace Kuchcik
{
    partial class RecipeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.TitleBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ImgBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DifficultyLevelBox = new System.Windows.Forms.ComboBox();
            this.DescriptionBox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TimeBox = new System.Windows.Forms.MaskedTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.identifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngridientName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.IngridientValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngridentUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addIngredientButton = new System.Windows.Forms.Button();
            this.delIngredientButton = new System.Windows.Forms.Button();
            this.addNewIngredientButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tytuł:";
            // 
            // TitleBox
            // 
            this.TitleBox.Location = new System.Drawing.Point(12, 29);
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new System.Drawing.Size(776, 20);
            this.TitleBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Link do zdjęcia:";
            // 
            // ImgBox
            // 
            this.ImgBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.ImgBox.Location = new System.Drawing.Point(12, 68);
            this.ImgBox.Name = "ImgBox";
            this.ImgBox.Size = new System.Drawing.Size(776, 20);
            this.ImgBox.TabIndex = 2;
            this.ImgBox.Enter += new System.EventHandler(this.ImgBox_Enter);
            this.ImgBox.Leave += new System.EventHandler(this.ImgBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Poziom trudności:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Czas przygotowania [min]:";
            // 
            // DifficultyLevelBox
            // 
            this.DifficultyLevelBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DifficultyLevelBox.FormattingEnabled = true;
            this.DifficultyLevelBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.DifficultyLevelBox.Location = new System.Drawing.Point(12, 147);
            this.DifficultyLevelBox.Name = "DifficultyLevelBox";
            this.DifficultyLevelBox.Size = new System.Drawing.Size(121, 21);
            this.DifficultyLevelBox.TabIndex = 4;
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(12, 187);
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(388, 251);
            this.DescriptionBox.TabIndex = 5;
            this.DescriptionBox.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Opis:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(404, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Składniki:";
            // 
            // TimeBox
            // 
            this.TimeBox.Location = new System.Drawing.Point(12, 107);
            this.TimeBox.Mask = "9999";
            this.TimeBox.Name = "TimeBox";
            this.TimeBox.Size = new System.Drawing.Size(776, 20);
            this.TimeBox.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.identifier,
            this.IngridientName,
            this.IngridientValue,
            this.IngridentUnit});
            this.dataGridView1.Location = new System.Drawing.Point(406, 187);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(382, 251);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // identifier
            // 
            this.identifier.HeaderText = "Id";
            this.identifier.Name = "identifier";
            this.identifier.Visible = false;
            this.identifier.Width = 50;
            // 
            // IngridientName
            // 
            this.IngridientName.HeaderText = "Składnik";
            this.IngridientName.Name = "IngridientName";
            this.IngridientName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IngridientName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IngridientValue
            // 
            this.IngridientValue.HeaderText = "Ilość";
            this.IngridientValue.Name = "IngridientValue";
            // 
            // IngridentUnit
            // 
            this.IngridentUnit.HeaderText = "Jednostka";
            this.IngridentUnit.Name = "IngridentUnit";
            this.IngridentUnit.ReadOnly = true;
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(701, 444);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(87, 28);
            this.acceptButton.TabIndex = 13;
            this.acceptButton.Text = "OK";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(608, 444);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 28);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // addIngredientButton
            // 
            this.addIngredientButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addIngredientButton.Location = new System.Drawing.Point(722, 154);
            this.addIngredientButton.Name = "addIngredientButton";
            this.addIngredientButton.Size = new System.Drawing.Size(30, 30);
            this.addIngredientButton.TabIndex = 16;
            this.addIngredientButton.Text = "+";
            this.addIngredientButton.UseVisualStyleBackColor = true;
            this.addIngredientButton.Click += new System.EventHandler(this.addIngredientButton_Click);
            // 
            // delIngredientButton
            // 
            this.delIngredientButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.delIngredientButton.Location = new System.Drawing.Point(758, 154);
            this.delIngredientButton.Name = "delIngredientButton";
            this.delIngredientButton.Size = new System.Drawing.Size(30, 30);
            this.delIngredientButton.TabIndex = 17;
            this.delIngredientButton.Text = "-";
            this.delIngredientButton.UseVisualStyleBackColor = true;
            this.delIngredientButton.Click += new System.EventHandler(this.delIngredientButton_Click);
            // 
            // addNewIngredientButton
            // 
            this.addNewIngredientButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addNewIngredientButton.Location = new System.Drawing.Point(626, 154);
            this.addNewIngredientButton.Name = "addNewIngredientButton";
            this.addNewIngredientButton.Size = new System.Drawing.Size(90, 30);
            this.addNewIngredientButton.TabIndex = 15;
            this.addNewIngredientButton.Text = "Nowy składnik";
            this.addNewIngredientButton.UseVisualStyleBackColor = true;
            this.addNewIngredientButton.Click += new System.EventHandler(this.addNewIngredientButton_Click);
            // 
            // RecipeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 484);
            this.Controls.Add(this.addNewIngredientButton);
            this.Controls.Add(this.delIngredientButton);
            this.Controls.Add(this.addIngredientButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.TimeBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.DifficultyLevelBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ImgBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TitleBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RecipeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Okno przepisu";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TitleBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ImgBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox DifficultyLevelBox;
        private System.Windows.Forms.RichTextBox DescriptionBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox TimeBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn identifier;
        private System.Windows.Forms.DataGridViewComboBoxColumn IngridientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IngridientValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn IngridentUnit;
        private System.Windows.Forms.Button addIngredientButton;
        private System.Windows.Forms.Button delIngredientButton;
        private System.Windows.Forms.Button addNewIngredientButton;
    }
}