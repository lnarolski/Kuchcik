namespace Kuchcik
{
    partial class MainWindow
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
            this.groceriesButton = new System.Windows.Forms.Button();
            this.recipesListButton = new System.Windows.Forms.Button();
            this.runAlgorithmButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Difficulty_level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groceriesButton
            // 
            this.groceriesButton.Location = new System.Drawing.Point(23, 12);
            this.groceriesButton.Name = "groceriesButton";
            this.groceriesButton.Size = new System.Drawing.Size(216, 90);
            this.groceriesButton.TabIndex = 0;
            this.groceriesButton.Text = "Posiadane artykuły";
            this.groceriesButton.UseVisualStyleBackColor = true;
            this.groceriesButton.Click += new System.EventHandler(this.groceriesButton_Click);
            // 
            // recipesListButton
            // 
            this.recipesListButton.Location = new System.Drawing.Point(245, 12);
            this.recipesListButton.Name = "recipesListButton";
            this.recipesListButton.Size = new System.Drawing.Size(215, 90);
            this.recipesListButton.TabIndex = 1;
            this.recipesListButton.Text = "Lista przepisów";
            this.recipesListButton.UseVisualStyleBackColor = true;
            this.recipesListButton.Click += new System.EventHandler(this.recipesListButton_Click);
            // 
            // runAlgorithmButton
            // 
            this.runAlgorithmButton.Location = new System.Drawing.Point(636, 12);
            this.runAlgorithmButton.Name = "runAlgorithmButton";
            this.runAlgorithmButton.Size = new System.Drawing.Size(152, 90);
            this.runAlgorithmButton.TabIndex = 2;
            this.runAlgorithmButton.Text = "GENERUJ PRZEPISY";
            this.runAlgorithmButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Title,
            this.Image,
            this.Time,
            this.Difficulty_level});
            this.dataGridView1.Location = new System.Drawing.Point(23, 108);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(765, 330);
            this.dataGridView1.TabIndex = 5;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
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
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.runAlgorithmButton);
            this.Controls.Add(this.recipesListButton);
            this.Controls.Add(this.groceriesButton);
            this.Name = "MainWindow";
            this.Text = "Kuchcik";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button groceriesButton;
        private System.Windows.Forms.Button recipesListButton;
        private System.Windows.Forms.Button runAlgorithmButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewImageColumn Image;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Difficulty_level;
    }
}

