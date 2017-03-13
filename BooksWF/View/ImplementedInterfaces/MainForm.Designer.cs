namespace BooksWF
{
    partial class MainForm
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
            this.textBoxOutput = new System.Windows.Forms.TextBox();
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
            this.bookEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.magazineEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newspaperEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.magazineDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newspaperDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSaveBooksInDB = new System.Windows.Forms.Button();
            this.buttonSaveNewspaperInTxtFile = new System.Windows.Forms.Button();
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
            // textBoxOutput
            // 
            this.textBoxOutput.AllowDrop = true;
            this.textBoxOutput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxOutput.Location = new System.Drawing.Point(13, 119);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(689, 225);
            this.textBoxOutput.TabIndex = 2;
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
            this.btnNewspaperList.Size = new System.Drawing.Size(137, 23);
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
            this.bookEditToolStripMenuItem,
            this.magazineEditToolStripMenuItem,
            this.newspaperEditToolStripMenuItem});
            this.editItemToolStripMenuItem.Name = "editItemToolStripMenuItem";
            this.editItemToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.editItemToolStripMenuItem.Text = "Edit item";
            // 
            // bookEditToolStripMenuItem
            // 
            this.bookEditToolStripMenuItem.Name = "bookEditToolStripMenuItem";
            this.bookEditToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.bookEditToolStripMenuItem.Text = "Book";
            this.bookEditToolStripMenuItem.Click += new System.EventHandler(this.bookEditToolStripMenuItem_Click);
            // 
            // magazineEditToolStripMenuItem
            // 
            this.magazineEditToolStripMenuItem.Name = "magazineEditToolStripMenuItem";
            this.magazineEditToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.magazineEditToolStripMenuItem.Text = "Magazine";
            this.magazineEditToolStripMenuItem.Click += new System.EventHandler(this.magazineEditToolStripMenuItem_Click);
            // 
            // newspaperEditToolStripMenuItem
            // 
            this.newspaperEditToolStripMenuItem.Name = "newspaperEditToolStripMenuItem";
            this.newspaperEditToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.newspaperEditToolStripMenuItem.Text = "Newspaper";
            this.newspaperEditToolStripMenuItem.Click += new System.EventHandler(this.newspaperEditToolStripMenuItem_Click);
            // 
            // deleteItemToolStripMenuItem
            // 
            this.deleteItemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookDeleteToolStripMenuItem,
            this.magazineDeleteToolStripMenuItem,
            this.newspaperDeleteToolStripMenuItem});
            this.deleteItemToolStripMenuItem.Name = "deleteItemToolStripMenuItem";
            this.deleteItemToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.deleteItemToolStripMenuItem.Text = "Delete item";
            // 
            // bookDeleteToolStripMenuItem
            // 
            this.bookDeleteToolStripMenuItem.Name = "bookDeleteToolStripMenuItem";
            this.bookDeleteToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.bookDeleteToolStripMenuItem.Text = "Book";
            this.bookDeleteToolStripMenuItem.Click += new System.EventHandler(this.bookDeleteToolStripMenuItem_Click);
            // 
            // magazineDeleteToolStripMenuItem
            // 
            this.magazineDeleteToolStripMenuItem.Name = "magazineDeleteToolStripMenuItem";
            this.magazineDeleteToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.magazineDeleteToolStripMenuItem.Text = "Magazine";
            this.magazineDeleteToolStripMenuItem.Click += new System.EventHandler(this.magazineDeleteToolStripMenuItem_Click);
            // 
            // newspaperDeleteToolStripMenuItem
            // 
            this.newspaperDeleteToolStripMenuItem.Name = "newspaperDeleteToolStripMenuItem";
            this.newspaperDeleteToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.newspaperDeleteToolStripMenuItem.Text = "Newspaper";
            this.newspaperDeleteToolStripMenuItem.Click += new System.EventHandler(this.newspaperDeleteToolStripMenuItem_Click);
            // 
            // buttonSaveBooksInDB
            // 
            this.buttonSaveBooksInDB.Location = new System.Drawing.Point(13, 90);
            this.buttonSaveBooksInDB.Name = "buttonSaveBooksInDB";
            this.buttonSaveBooksInDB.Size = new System.Drawing.Size(111, 23);
            this.buttonSaveBooksInDB.TabIndex = 10;
            this.buttonSaveBooksInDB.Text = "Save Books (DB)";
            this.buttonSaveBooksInDB.UseVisualStyleBackColor = true;
            this.buttonSaveBooksInDB.Click += new System.EventHandler(this.buttonSaveBooksInDB_Click);
            // 
            // buttonSaveNewspaperInTxtFile
            // 
            this.buttonSaveNewspaperInTxtFile.Location = new System.Drawing.Point(240, 90);
            this.buttonSaveNewspaperInTxtFile.Name = "buttonSaveNewspaperInTxtFile";
            this.buttonSaveNewspaperInTxtFile.Size = new System.Drawing.Size(137, 23);
            this.buttonSaveNewspaperInTxtFile.TabIndex = 11;
            this.buttonSaveNewspaperInTxtFile.Text = "Save Newspaper(txt file)";
            this.buttonSaveNewspaperInTxtFile.UseVisualStyleBackColor = true;
            this.buttonSaveNewspaperInTxtFile.Click += new System.EventHandler(this.buttonSaveNewspaperInTxtFile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 433);
            this.Controls.Add(this.buttonSaveNewspaperInTxtFile);
            this.Controls.Add(this.buttonSaveBooksInDB);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.btnNewspaperList);
            this.Controls.Add(this.BtnSaveMagazines);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.btnGetMagazineList);
            this.Controls.Add(this.btnGetBookList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetBookList;
        private System.Windows.Forms.Button btnGetMagazineList;
        private System.Windows.Forms.TextBox textBoxOutput;
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
        private System.Windows.Forms.ToolStripMenuItem bookEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem magazineEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newspaperEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookDeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem magazineDeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newspaperDeleteToolStripMenuItem;
        private System.Windows.Forms.Button buttonSaveBooksInDB;
        private System.Windows.Forms.Button buttonSaveNewspaperInTxtFile;
    }
}

