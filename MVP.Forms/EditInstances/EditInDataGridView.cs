using MVP.Entities;
using MVP.Forms.GetItem;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MVP.Forms.EditInstances
{
    public class EditInDataGridView
    {
        public void EditMagazine(DataGridView dataGridView, int rowIndex, int columnIndex, Magazine editedItem)
        {
            if (dataGridView.Rows[rowIndex].Cells[columnIndex] is DataGridViewTextBoxCell || dataGridView.Rows[rowIndex].Cells[columnIndex] is DataGridViewCheckBoxCell)
            {
                DataGridViewRow row = dataGridView.Rows[rowIndex];
                GetFromDataGridViewRow setter = new GetFromDataGridViewRow();
                setter.GetMagazine(editedItem, row);
            }
        }
        public void EditNewspaper(DataGridView dataGridView, int rowIndex, int columnIndex, Newspaper editedItem)
        {
            if (dataGridView.Rows[rowIndex].Cells[columnIndex] is DataGridViewTextBoxCell || dataGridView.Rows[rowIndex].Cells[columnIndex] is DataGridViewCheckBoxCell)
            {
                DataGridViewRow row = dataGridView.Rows[rowIndex];
                GetFromDataGridViewRow setter = new GetFromDataGridViewRow();
                setter.GetNewspaper(editedItem, row);
            }
        }
        public void EditBook(DataGridView dataGridView, int rowIndex, int columnIndex, Book editedItem)
        {
            if (dataGridView.Rows[rowIndex].Cells[columnIndex] is DataGridViewTextBoxCell || dataGridView.Rows[rowIndex].Cells[columnIndex] is DataGridViewCheckBoxCell)
            {
                DataGridViewRow row = dataGridView.Rows[rowIndex];
                GetFromDataGridViewRow setter = new GetFromDataGridViewRow();
                setter.GetBook(editedItem, row);
            }
        }
    }
}
