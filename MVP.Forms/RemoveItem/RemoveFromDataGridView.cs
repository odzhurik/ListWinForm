using System.Windows.Forms;

namespace MVP.Forms.RemoveItem
{
    public class RemoveFromDataGrirdView
    {
        public void RemovePolygraphicItemFromDataViewGrid(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                dataGridView.Rows.RemoveAt(row.Index);
            }
        }
    }
}
