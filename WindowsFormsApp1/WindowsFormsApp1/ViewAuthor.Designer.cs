
namespace WindowsFormsApp1
{
    partial class ViewAuthor
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetAuthor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.keywordBox = new System.Windows.Forms.ComboBox();
            this.Genre = new System.Windows.Forms.Label();
            this.genreBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 199);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(746, 235);
            this.dataGridView1.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Please select null if you want to get all ";
            // 
            // btnGetAuthor
            // 
            this.btnGetAuthor.Location = new System.Drawing.Point(339, 125);
            this.btnGetAuthor.Name = "btnGetAuthor";
            this.btnGetAuthor.Size = new System.Drawing.Size(68, 23);
            this.btnGetAuthor.TabIndex = 20;
            this.btnGetAuthor.Text = "Get Author";
            this.btnGetAuthor.UseVisualStyleBackColor = true;
            this.btnGetAuthor.Click += new System.EventHandler(this.btnGetAuthor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(432, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Keyword";
            // 
            // keywordBox
            // 
            this.keywordBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keywordBox.FormattingEnabled = true;
            this.keywordBox.Location = new System.Drawing.Point(500, 64);
            this.keywordBox.Name = "keywordBox";
            this.keywordBox.Size = new System.Drawing.Size(229, 24);
            this.keywordBox.TabIndex = 15;
            this.keywordBox.SelectedIndexChanged += new System.EventHandler(this.keywordBox_SelectedIndexChanged);
            // 
            // Genre
            // 
            this.Genre.AutoSize = true;
            this.Genre.Location = new System.Drawing.Point(37, 64);
            this.Genre.Name = "Genre";
            this.Genre.Size = new System.Drawing.Size(48, 17);
            this.Genre.TabIndex = 14;
            this.Genre.Text = "Genre";
            // 
            // genreBox
            // 
            this.genreBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genreBox.FormattingEnabled = true;
            this.genreBox.Location = new System.Drawing.Point(103, 64);
            this.genreBox.Name = "genreBox";
            this.genreBox.Size = new System.Drawing.Size(229, 24);
            this.genreBox.TabIndex = 13;
            this.genreBox.SelectedIndexChanged += new System.EventHandler(this.genreBox_SelectedIndexChanged);
            // 
            // ViewAuthor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetAuthor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.keywordBox);
            this.Controls.Add(this.Genre);
            this.Controls.Add(this.genreBox);
            this.Name = "ViewAuthor";
            this.Text = "View Author Customer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetAuthor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox keywordBox;
        private System.Windows.Forms.Label Genre;
        private System.Windows.Forms.ComboBox genreBox;
    }
}