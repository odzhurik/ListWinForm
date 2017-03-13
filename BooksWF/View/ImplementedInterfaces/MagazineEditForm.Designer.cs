namespace BooksWF
{
    partial class MagazineEditForm
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
            this.dataGridViewMagazines = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMagazines)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMagazines
            // 
            this.dataGridViewMagazines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMagazines.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewMagazines.Name = "dataGridViewMagazines";
            this.dataGridViewMagazines.Size = new System.Drawing.Size(433, 300);
            this.dataGridViewMagazines.TabIndex = 0;
            this.dataGridViewMagazines.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewMagazines_CellBeginEdit);
           
            this.dataGridViewMagazines.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMagazines_CellEndEdit);
            this.dataGridViewMagazines.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridViewMagazines_RowStateChanged);
            // 
            // MagazineEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 375);
            this.Controls.Add(this.dataGridViewMagazines);
            this.Name = "MagazineEditForm";
            this.Text = "MagazineEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMagazines)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMagazines;
    }
}