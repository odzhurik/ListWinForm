using MVP.Entities;
using System;
using System.Collections.Generic;

namespace MVP.Views
{
    public interface IEditBookView
    {
        void ShowEditForm();
        void ShowDeleteForm();
        void ShowForm();
        event EventHandler<EventArgs> BeginEdit;
        event EventHandler<EventArgs> EndEdit;
        event EventHandler<EventArgs> SelectItemToDelete;
        event EventHandler<EventArgs> DeleteItem;
        void BeginEditItem(AuthoredItem editedItem, EventArgs e);
        void InitDataTable(List<AuthoredItem> bookList);
        void InitDataGridView();
        void EndEditItem(AuthoredItem editedItem, EventArgs e);
        void SelectBookToDelete(AuthoredItem item, EventArgs e);
        void CreateDeleteView();
        void RemoveFromDataGridView();
    }
}
