using BooksWF.Models;
using BooksWF.Models.ItemsList;
using System.Windows.Forms;

namespace BooksWF.ChooseInstance
{
    public class GetInstanceFromDataGridView
    {
        public void GetPolygraphicInstance(DataGridView dataGridView, int rowIndex, int columnIndex, PolygraphicItem item)
        {
            if (dataGridView.Rows[rowIndex].Cells[columnIndex] is DataGridViewTextBoxCell)
            {
                DataGridViewRow row = dataGridView.Rows[rowIndex];
                GetFromDataGridViewRow get = new GetFromDataGridViewRow();
                get.GetItem(item, row);
            }

        }
    }
}
