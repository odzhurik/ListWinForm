using BooksWF.Models;
using BooksWF.Models.ItemsList;
using System.Windows.Forms;

namespace BooksWF.SetDataGridView
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
