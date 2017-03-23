using MVP.Entities;
using MVP.Forms.GetItem;
using System.Windows.Forms;

namespace MVP.Forms.SetDataGridView
{
    public class SelectFromDataGridViewRow
    {
        public void SelectPolygraphicItem(DataGridViewRowStateChangedEventArgs e, PolygraphicItem editedItem)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            DataGridViewRow row = e.Row;
            GetFromDataGridViewRow setter = new GetFromDataGridViewRow();
            setter.GetItem(editedItem, row);
        }
    }
}
