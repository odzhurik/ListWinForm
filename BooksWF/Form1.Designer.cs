namespace BooksWF
{
    partial class Form1
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
            this.btnGetBookList = new System.Windows.Forms.Button();
            this.btnGetMagazineList = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.btnNewspaperList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetBookList
            // 
            this.btnGetBookList.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGetBookList.Location = new System.Drawing.Point(13, 77);
            this.btnGetBookList.Name = "btnGetBookList";
            this.btnGetBookList.Size = new System.Drawing.Size(111, 23);
            this.btnGetBookList.TabIndex = 0;
            this.btnGetBookList.Text = "Book List";
            this.btnGetBookList.UseVisualStyleBackColor = true;
            this.btnGetBookList.Click += new System.EventHandler(this.btnGetBookList_Click);
            // 
            // btnGetMagazineList
            // 
            this.btnGetMagazineList.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGetMagazineList.Location = new System.Drawing.Point(512, 77);
            this.btnGetMagazineList.Name = "btnGetMagazineList";
            this.btnGetMagazineList.Size = new System.Drawing.Size(123, 23);
            this.btnGetMagazineList.TabIndex = 1;
            this.btnGetMagazineList.Text = "Magazine List";
            this.btnGetMagazineList.UseVisualStyleBackColor = true;
            this.btnGetMagazineList.Click += new System.EventHandler(this.btnGetMagazineList_Click);
            // 
            // textBox
            // 
            this.textBox.AllowDrop = true;
            this.textBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox.Location = new System.Drawing.Point(13, 119);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(622, 302);
            this.textBox.TabIndex = 2;
            // 
            // btnNewspaperList
            // 
            this.btnNewspaperList.Location = new System.Drawing.Point(285, 76);
            this.btnNewspaperList.Name = "btnNewspaperList";
            this.btnNewspaperList.Size = new System.Drawing.Size(104, 23);
            this.btnNewspaperList.TabIndex = 3;
            this.btnNewspaperList.Text = "Newspaper List";
            this.btnNewspaperList.UseVisualStyleBackColor = true;
            this.btnNewspaperList.Click += new System.EventHandler(this.btnNewspaperList_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 433);
            this.Controls.Add(this.btnNewspaperList);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.btnGetMagazineList);
            this.Controls.Add(this.btnGetBookList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetBookList;
        private System.Windows.Forms.Button btnGetMagazineList;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button btnNewspaperList;
    }
}

