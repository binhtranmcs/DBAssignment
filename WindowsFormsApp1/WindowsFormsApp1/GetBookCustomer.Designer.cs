namespace WindowsFormsApp1
{
    partial class GetBookCustomer
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
            this.genreBox = new System.Windows.Forms.ComboBox();
            this.Genre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameAuthorBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.keywordBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGetBook = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnBuyBook = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // genreBox
            // 
            this.genreBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genreBox.FormattingEnabled = true;
            this.genreBox.Location = new System.Drawing.Point(164, 56);
            this.genreBox.Name = "genreBox";
            this.genreBox.Size = new System.Drawing.Size(229, 24);
            this.genreBox.TabIndex = 1;
            this.genreBox.SelectedIndexChanged += new System.EventHandler(this.genreBox_SelectedIndexChanged);
            // 
            // Genre
            // 
            this.Genre.AutoSize = true;
            this.Genre.Location = new System.Drawing.Point(42, 56);
            this.Genre.Name = "Genre";
            this.Genre.Size = new System.Drawing.Size(48, 17);
            this.Genre.TabIndex = 2;
            this.Genre.Text = "Genre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name Author";
            // 
            // nameAuthorBox
            // 
            this.nameAuthorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nameAuthorBox.FormattingEnabled = true;
            this.nameAuthorBox.Location = new System.Drawing.Point(549, 56);
            this.nameAuthorBox.Name = "nameAuthorBox";
            this.nameAuthorBox.Size = new System.Drawing.Size(229, 24);
            this.nameAuthorBox.TabIndex = 3;
            this.nameAuthorBox.SelectedIndexChanged += new System.EventHandler(this.nameAuthorBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Keyword";
            // 
            // keywordBox
            // 
            this.keywordBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keywordBox.FormattingEnabled = true;
            this.keywordBox.Location = new System.Drawing.Point(164, 110);
            this.keywordBox.Name = "keywordBox";
            this.keywordBox.Size = new System.Drawing.Size(229, 24);
            this.keywordBox.TabIndex = 5;
            this.keywordBox.SelectedIndexChanged += new System.EventHandler(this.keywordBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(427, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Date Published";
            // 
            // btnGetBook
            // 
            this.btnGetBook.Location = new System.Drawing.Point(236, 150);
            this.btnGetBook.Name = "btnGetBook";
            this.btnGetBook.Size = new System.Drawing.Size(157, 23);
            this.btnGetBook.TabIndex = 9;
            this.btnGetBook.Text = "Get Book With Info";
            this.btnGetBook.UseVisualStyleBackColor = true;
            this.btnGetBook.Click += new System.EventHandler(this.btnGetBook_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(549, 113);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(229, 22);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(32, 191);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(746, 235);
            this.dataGridView1.TabIndex = 12;
            // 
            // btnBuyBook
            // 
            this.btnBuyBook.Location = new System.Drawing.Point(510, 150);
            this.btnBuyBook.Name = "btnBuyBook";
            this.btnBuyBook.Size = new System.Drawing.Size(153, 23);
            this.btnBuyBook.TabIndex = 13;
            this.btnBuyBook.Text = "Get All Buy Book";
            this.btnBuyBook.UseVisualStyleBackColor = true;
            this.btnBuyBook.Click += new System.EventHandler(this.btnBuyBook_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Please select null if you want to get all ";
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(323, 451);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(100, 23);
            this.btnBuy.TabIndex = 14;
            this.btnBuy.Text = "Buy Book";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // GetBookCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 504);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.btnBuyBook);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnGetBook);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.keywordBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameAuthorBox);
            this.Controls.Add(this.Genre);
            this.Controls.Add(this.genreBox);
            this.Name = "GetBookCustomer";
            this.Text = "Get Book Customer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox genreBox;
        private System.Windows.Forms.Label Genre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox nameAuthorBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox keywordBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGetBook;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnBuyBook;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuy;
    }
}