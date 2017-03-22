namespace MVP.Forms
{
    partial class AddBookForm
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
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxAuthor0 = new System.Windows.Forms.TextBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.labelTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabelAddAuthor = new System.Windows.Forms.LinkLabel();
            this.panelAuthors = new System.Windows.Forms.Panel();
            this.numericUpDownAuthors = new System.Windows.Forms.NumericUpDown();
            this.labelPages = new System.Windows.Forms.Label();
            this.textBoxPages = new System.Windows.Forms.TextBox();
            this.buttonAddBook = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panelAuthors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAuthors)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(67, 36);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(100, 20);
            this.textBoxTitle.TabIndex = 0;
            // 
            // textBoxAuthor0
            // 
            this.textBoxAuthor0.Location = new System.Drawing.Point(51, 26);
            this.textBoxAuthor0.Name = "textBoxAuthor0";
            this.textBoxAuthor0.Size = new System.Drawing.Size(100, 20);
            this.textBoxAuthor0.TabIndex = 1;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(13, 36);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(27, 13);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Authors";
            // 
            // linkLabelAddAuthor
            // 
            this.linkLabelAddAuthor.AutoSize = true;
            this.linkLabelAddAuthor.Location = new System.Drawing.Point(48, 69);
            this.linkLabelAddAuthor.Name = "linkLabelAddAuthor";
            this.linkLabelAddAuthor.Size = new System.Drawing.Size(67, 13);
            this.linkLabelAddAuthor.TabIndex = 5;
            this.linkLabelAddAuthor.TabStop = true;
            this.linkLabelAddAuthor.Text = "Add  authors";
            this.linkLabelAddAuthor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAddAuthor_LinkClicked);
            // 
            // panelAuthors
            // 
            this.panelAuthors.Controls.Add(this.numericUpDownAuthors);
            this.panelAuthors.Controls.Add(this.label1);
            this.panelAuthors.Controls.Add(this.textBoxAuthor0);
            this.panelAuthors.Controls.Add(this.linkLabelAddAuthor);
            this.panelAuthors.Location = new System.Drawing.Point(16, 62);
            this.panelAuthors.Name = "panelAuthors";
            this.panelAuthors.Size = new System.Drawing.Size(220, 256);
            this.panelAuthors.TabIndex = 8;
            // 
            // numericUpDownAuthors
            // 
            this.numericUpDownAuthors.Location = new System.Drawing.Point(131, 67);
            this.numericUpDownAuthors.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownAuthors.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownAuthors.Name = "numericUpDownAuthors";
            this.numericUpDownAuthors.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownAuthors.TabIndex = 6;
            this.numericUpDownAuthors.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelPages
            // 
            this.labelPages.AutoSize = true;
            this.labelPages.Location = new System.Drawing.Point(219, 36);
            this.labelPages.Name = "labelPages";
            this.labelPages.Size = new System.Drawing.Size(37, 13);
            this.labelPages.TabIndex = 9;
            this.labelPages.Text = "Pages";
            // 
            // textBoxPages
            // 
            this.textBoxPages.Location = new System.Drawing.Point(262, 33);
            this.textBoxPages.Name = "textBoxPages";
            this.textBoxPages.Size = new System.Drawing.Size(100, 20);
            this.textBoxPages.TabIndex = 10;
            // 
            // buttonAddBook
            // 
            this.buttonAddBook.Location = new System.Drawing.Point(262, 295);
            this.buttonAddBook.Name = "buttonAddBook";
            this.buttonAddBook.Size = new System.Drawing.Size(75, 23);
            this.buttonAddBook.TabIndex = 11;
            this.buttonAddBook.Text = "Add";
            this.buttonAddBook.UseVisualStyleBackColor = true;
            // 
            // AddBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 330);
            this.Controls.Add(this.buttonAddBook);
            this.Controls.Add(this.textBoxPages);
            this.Controls.Add(this.labelPages);
            this.Controls.Add(this.panelAuthors);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.textBoxTitle);
            this.Name = "AddBookForm";
            this.Text = "Add";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panelAuthors.ResumeLayout(false);
            this.panelAuthors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAuthors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBoxTitle;
        public System.Windows.Forms.TextBox textBoxAuthor0;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        public System.Windows.Forms.LinkLabel linkLabelAddAuthor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTitle;
        public System.Windows.Forms.Panel panelAuthors;
        public System.Windows.Forms.TextBox textBoxPages;
        private System.Windows.Forms.Label labelPages;
        public System.Windows.Forms.Button buttonAddBook;
        public System.Windows.Forms.NumericUpDown numericUpDownAuthors;
    }
}