using MVP.Entities;
using System.Windows.Forms;

namespace MVP.Forms.GetItem
{
    public class GetInstanceFromDataGridView
    {
        public void GetBook(DataGridView dataGridView, int rowIndex, int columnIndex, Book item)
        {
            if (dataGridView.Rows[rowIndex].Cells[columnIndex] is DataGridViewTextBoxCell)
            {
                DataGridViewRow row = dataGridView.Rows[rowIndex];
                GetFromDataGridViewRow get = new GetFromDataGridViewRow();
                get.GetBook(item, row);
            }
        }
        public void GetNewspaper(DataGridView dataGridView, int rowIndex, int columnIndex, Newspaper item)
        {
            if (dataGridView.Rows[rowIndex].Cells[columnIndex] is DataGridViewTextBoxCell)
            {
                DataGridViewRow row = dataGridView.Rows[rowIndex];
                GetFromDataGridViewRow get = new GetFromDataGridViewRow();
                get.GetNewspaper(item, row);
            }
        }
        public void GetMagazine(DataGridView dataGridView, int rowIndex, int columnIndex, Magazine item)
        {
            if (dataGridView.Rows[rowIndex].Cells[columnIndex] is DataGridViewTextBoxCell)
            {
                DataGridViewRow row = dataGridView.Rows[rowIndex];
                GetFromDataGridViewRow get = new GetFromDataGridViewRow();
                get.GetMagazine(item, row);
            }
        }

    }
}
