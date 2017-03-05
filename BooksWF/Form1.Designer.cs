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
            this.BtnSaveMagazines = new System.Windows.Forms.Button();
            this.btnNewspaperList = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMagazineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewspaperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.magazineToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newspaperToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.magazineToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.newspaperToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetBookList
            // 
            this.btnGetBookList.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGetBookList.Location = new System.Drawing.Point(13, 56);
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
            this.btnGetMagazineList.Location = new System.Drawing.Point(466, 55);
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
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(689, 225);
            this.textBox.TabIndex = 2;
            // 
            // BtnSaveMagazines
            // 
            this.BtnSaveMagazines.Location = new System.Drawing.Point(466, 90);
            this.BtnSaveMagazines.Name = "BtnSaveMagazines";
            this.BtnSaveMagazines.Size = new System.Drawing.Size(123, 23);
            this.BtnSaveMagazines.TabIndex = 5;
            this.BtnSaveMagazines.Text = "Save Magazine(Xml)";
            this.BtnSaveMagazines.UseVisualStyleBackColor = true;
            this.BtnSaveMagazines.Click += new System.EventHandler(this.BtnSaveMagazines_Click);
            // 
            // btnNewspaperList
            // 
            this.btnNewspaperList.Location = new System.Drawing.Point(240, 56);
            this.btnNewspaperList.Name = "btnNewspaperList";
            this.btnNewspaperList.Size = new System.Drawing.Size(97, 23);
            this.btnNewspaperList.TabIndex = 6;
            this.btnNewspaperList.Text = "Newspaper List";
            this.btnNewspaperList.UseVisualStyleBackColor = true;
            this.btnNewspaperList.Click += new System.EventHandler(this.btnNewspaperList_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(13, 371);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(100, 20);
            this.textBoxSearch.TabIndex = 7;
            this.textBoxSearch.Text = "enter author";
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(139, 371);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 8;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addItemToolStripMenuItem,
            this.editItemToolStripMenuItem,
            this.deleteItemToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(714, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addItemToolStripMenuItem
            // 
            this.addItemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBookToolStripMenuItem,
            this.addMagazineToolStripMenuItem,
            this.addNewspaperToolStripMenuItem});
            this.addItemToolStripMenuItem.Name = "addItemToolStripMenuItem";
            this.addItemToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.addItemToolStripMenuItem.Text = "Add item";
            // 
            // addBookToolStripMenuItem
            // 
            this.addBookToolStripMenuItem.Name = "addBookToolStripMenuItem";
            this.addBookToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.addBookToolStripMenuItem.Text = "Book";
            this.addBookToolStripMenuItem.Click += new System.EventHandler(this.addBookToolStripMenuItem_Click);
            // 
            // addMagazineToolStripMenuItem
            // 
            this.addMagazineToolStripMenuItem.Name = "addMagazineToolStripMenuItem";
            this.addMagazineToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.addMagazineToolStripMenuItem.Text = "Magazine";
            this.addMagazineToolStripMenuItem.Click += new System.EventHandler(this.addMagazineToolStripMenuItem_Click);
            // 
            // addNewspaperToolStripMenuItem
            // 
            this.addNewspaperToolStripMenuItem.Name = "addNewspaperToolStripMenuItem";
            this.addNewspaperToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.addNewspaperToolStripMenuItem.Text = "Newspaper";
            this.addNewspaperToolStripMenuItem.Click += new System.EventHandler(this.addNewspaperToolStripMenuItem_Click);
            // 
            // editItemToolStripMenuItem
            // 
            this.editItemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookToolStripMenuItem1,
            this.magazineToolStripMenuItem1,
            this.newspaperToolStripMenuItem1});
            this.editItemToolStripMenuItem.Name = "editItemToolStripMenuItem";
            this.editItemToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.editItemToolStripMenuItem.Text = "Edit item";
            // 
            // bookToolStripMenuItem1
            // 
            this.bookToolStripMenuItem1.Name = "bookToolStripMenuItem1";
            this.bookToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.bookToolStripMenuItem1.Text = "Book";
            this.bookToolStripMenuItem1.Click += new System.EventHandler(this.bookToolStripMenuItem1_Click);
            // 
            // magazineToolStripMenuItem1
            // 
            this.magazineToolStripMenuItem1.Name = "magazineToolStripMenuItem1";
            this.magazineToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.magazineToolStripMenuItem1.Text = "Magazine";
            this.magazineToolStripMenuItem1.Click += new System.EventHandler(this.magazineToolStripMenuItem1_Click);
            // 
            // newspaperToolStripMenuItem1
            // 
            this.newspaperToolStripMenuItem1.Name = "newspaperToolStripMenuItem1";
            this.newspaperToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.newspaperToolStripMenuItem1.Text = "Newspaper";
            this.newspaperToolStripMenuItem1.Click += new System.EventHandler(this.newspaperToolStripMenuItem1_Click);
            // 
            // deleteItemToolStripMenuItem
            // 
            this.deleteItemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookToolStripMenuItem2,
            this.magazineToolStripMenuItem2,
            this.newspaperToolStripMenuItem2});
            this.deleteItemToolStripMenuItem.Name = "deleteItemToolStripMenuItem";
            this.deleteItemToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.deleteItemToolStripMenuItem.Text = "Delete item";
            // 
            // bookToolStripMenuItem2
            // 
            this.bookToolStripMenuItem2.Name = "bookToolStripMenuItem2";
            this.bookToolStripMenuItem2.Size = new System.Drawing.Size(133, 22);
            this.bookToolStripMenuItem2.Text = "Book";
            // 
            // magazineToolStripMenuItem2
            // 
            this.magazineToolStripMenuItem2.Name = "magazineToolStripMenuItem2";
            this.magazineToolStripMenuItem2.Size = new System.Drawing.Size(133, 22);
            this.magazineToolStripMenuItem2.Text = "Magazine";
            // 
            // newspaperToolStripMenuItem2
            // 
            this.newspaperToolStripMenuItem2.Name = "newspaperToolStripMenuItem2";
            this.newspaperToolStripMenuItem2.Size = new System.Drawing.Size(133, 22);
            this.newspaperToolStripMenuItem2.Text = "Newspaper";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 433);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.btnNewspaperList);
            this.Controls.Add(this.BtnSaveMagazines);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.btnGetMagazineList);
            this.Controls.Add(this.btnGetBookList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetBookList;
        private System.Windows.Forms.Button btnGetMagazineList;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button BtnSaveMagazines;
        private System.Windows.Forms.Button btnNewspaperList;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMagazineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewspaperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem magazineToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newspaperToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem magazineToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem newspaperToolStripMenuItem2;
    }
}

