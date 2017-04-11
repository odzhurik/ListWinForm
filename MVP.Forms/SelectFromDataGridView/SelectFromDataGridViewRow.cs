using MVP.Entities;
using MVP.Forms.GetItem;
using System.Windows.Forms;

namespace MVP.Forms.SetDataGridView
{
    public class SelectFromDataGridViewRow
    {
        public void SelectBook(DataGridViewRowStateChangedEventArgs e, Book editedItem)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            DataGridViewRow row = e.Row;
            GetFromDataGridViewRow setter = new GetFromDataGridViewRow();
            setter.GetBook(editedItem, row);
        }
        public void SelectNewspaper(DataGridViewRowStateChangedEventArgs e, Newspaper editedItem)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            DataGridViewRow row = e.Row;
            GetFromDataGridViewRow setter = new GetFromDataGridViewRow();
            setter.GetNewspaper(editedItem, row);
        }
        public void SelectMagazine(DataGridViewRowStateChangedEventArgs e, Magazine editedItem)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            DataGridViewRow row = e.Row;
            GetFromDataGridViewRow setter = new GetFromDataGridViewRow();
            setter.GetMagazine(editedItem, row);
        }
    }
}
