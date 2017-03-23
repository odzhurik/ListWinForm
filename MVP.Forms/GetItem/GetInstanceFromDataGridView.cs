using MVP.Entities;
using System.Windows.Forms;

namespace MVP.Forms.GetItem
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
