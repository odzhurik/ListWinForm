namespace BooksWF
{
    partial class AddNewspaperForm
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelIssue = new System.Windows.Forms.Label();
            this.textBoxIssue = new System.Windows.Forms.TextBox();
            this.labelPeriodical = new System.Windows.Forms.Label();
            this.textBoxPeriodical = new System.Windows.Forms.TextBox();
            this.buttonAddArticles = new System.Windows.Forms.Button();
            this.numericUpDownArticles = new System.Windows.Forms.NumericUpDown();
            this.buttonAddNewspaper = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownArticles)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(13, 30);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(27, 13);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Title";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(67, 30);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(100, 20);
            this.textBoxTitle.TabIndex = 1;
            // 
            // labelIssue
            // 
            this.labelIssue.AutoSize = true;
            this.labelIssue.Location = new System.Drawing.Point(16, 59);
            this.labelIssue.Name = "labelIssue";
            this.labelIssue.Size = new System.Drawing.Size(32, 13);
            this.labelIssue.TabIndex = 2;
            this.labelIssue.Text = "Issue";
            // 
            // textBoxIssue
            // 
            this.textBoxIssue.Location = new System.Drawing.Point(67, 59);
            this.textBoxIssue.Name = "textBoxIssue";
            this.textBoxIssue.Size = new System.Drawing.Size(100, 20);
            this.textBoxIssue.TabIndex = 3;
            // 
            // labelPeriodical
            // 
            this.labelPeriodical.AutoSize = true;
            this.labelPeriodical.Location = new System.Drawing.Point(16, 95);
            this.labelPeriodical.Name = "labelPeriodical";
            this.labelPeriodical.Size = new System.Drawing.Size(53, 13);
            this.labelPeriodical.TabIndex = 4;
            this.labelPeriodical.Text = "Periodical";
            // 
            // textBoxPeriodical
            // 
            this.textBoxPeriodical.Location = new System.Drawing.Point(67, 92);
            this.textBoxPeriodical.Name = "textBoxPeriodical";
            this.textBoxPeriodical.Size = new System.Drawing.Size(100, 20);
            this.textBoxPeriodical.TabIndex = 5;
            // 
            // buttonAddArticles
            // 
            this.buttonAddArticles.Location = new System.Drawing.Point(16, 139);
            this.buttonAddArticles.Name = "buttonAddArticles";
            this.buttonAddArticles.Size = new System.Drawing.Size(75, 23);
            this.buttonAddArticles.TabIndex = 6;
            this.buttonAddArticles.Text = "Add articles";
            this.buttonAddArticles.UseVisualStyleBackColor = true;
            this.buttonAddArticles.Click += new System.EventHandler(this.buttonAddArticles_Click);
            // 
            // numericUpDownArticles
            // 
            this.numericUpDownArticles.Location = new System.Drawing.Point(98, 141);
            this.numericUpDownArticles.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownArticles.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownArticles.Name = "numericUpDownArticles";
            this.numericUpDownArticles.Size = new System.Drawing.Size(35, 20);
            this.numericUpDownArticles.TabIndex = 7;
            this.numericUpDownArticles.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonAddNewspaper
            // 
            this.buttonAddNewspaper.Location = new System.Drawing.Point(171, 217);
            this.buttonAddNewspaper.Name = "buttonAddNewspaper";
            this.buttonAddNewspaper.Size = new System.Drawing.Size(75, 23);
            this.buttonAddNewspaper.TabIndex = 8;
            this.buttonAddNewspaper.Text = "Add";
            this.buttonAddNewspaper.UseVisualStyleBackColor = true;
            this.buttonAddNewspaper.Click += new System.EventHandler(this.buttonAddNewspaper_Click);
            // 
            // AddNewspaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonAddNewspaper);
            this.Controls.Add(this.numericUpDownArticles);
            this.Controls.Add(this.buttonAddArticles);
            this.Controls.Add(this.textBoxPeriodical);
            this.Controls.Add(this.labelPeriodical);
            this.Controls.Add(this.textBoxIssue);
            this.Controls.Add(this.labelIssue);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.labelTitle);
            this.Name = "AddNewspaper";
            this.Text = "AddNewspaper";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownArticles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelIssue;
        private System.Windows.Forms.TextBox textBoxIssue;
        private System.Windows.Forms.Label labelPeriodical;
        private System.Windows.Forms.TextBox textBoxPeriodical;
        private System.Windows.Forms.Button buttonAddArticles;
        private System.Windows.Forms.NumericUpDown numericUpDownArticles;
        private System.Windows.Forms.Button buttonAddNewspaper;
    }
}