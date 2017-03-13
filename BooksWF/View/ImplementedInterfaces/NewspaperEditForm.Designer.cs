namespace BooksWF
{
    partial class NewspaperEditForm
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
            this.dataGridViewNewspapers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNewspapers)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewNewspapers
            // 
            this.dataGridViewNewspapers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNewspapers.Location = new System.Drawing.Point(2, 12);
            this.dataGridViewNewspapers.Name = "dataGridViewNewspapers";
            this.dataGridViewNewspapers.Size = new System.Drawing.Size(463, 316);
            this.dataGridViewNewspapers.TabIndex = 0;
            this.dataGridViewNewspapers.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewNewspapers_CellBeginEdit);
            this.dataGridViewNewspapers.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewNewspapers_CellEndEdit);
            this.dataGridViewNewspapers.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridViewNewspapers_RowStateChanged);
            // 
            // NewspaperEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 377);
            this.Controls.Add(this.dataGridViewNewspapers);
            this.Name = "NewspaperEditForm";
            this.Text = "NewspaperEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNewspapers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewNewspapers;
    }
}