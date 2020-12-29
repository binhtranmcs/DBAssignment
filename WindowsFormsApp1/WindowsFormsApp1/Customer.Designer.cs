namespace WindowsFormsApp1
{
    partial class Customer
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
            this.btnView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bookView = new System.Windows.Forms.DataGridView();
            this.btnGetBook = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bookView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(63, 345);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(71, 23);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "view";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(312, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hi Thanh";
            // 
            // bookView
            // 
            this.bookView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bookView.Location = new System.Drawing.Point(21, 29);
            this.bookView.Name = "bookView";
            this.bookView.ReadOnly = true;
            this.bookView.RowHeadersWidth = 51;
            this.bookView.RowTemplate.Height = 24;
            this.bookView.Size = new System.Drawing.Size(739, 291);
            this.bookView.TabIndex = 2;
            // 
            // btnGetBook
            // 
            this.btnGetBook.Location = new System.Drawing.Point(196, 345);
            this.btnGetBook.Name = "btnGetBook";
            this.btnGetBook.Size = new System.Drawing.Size(112, 23);
            this.btnGetBook.TabIndex = 3;
            this.btnGetBook.Text = "Get Book";
            this.btnGetBook.UseVisualStyleBackColor = true;
            this.btnGetBook.Click += new System.EventHandler(this.btnGetBook_Click);
            // 
            // Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGetBook);
            this.Controls.Add(this.bookView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnView);
            this.Name = "Customer";
            this.Text = "Customer";
            ((System.ComponentModel.ISupportInitialize)(this.bookView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView bookView;
        private System.Windows.Forms.Button btnGetBook;
    }
}