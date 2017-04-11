using MVP.Entities;
using System;
using System.Collections.Generic;

namespace MVP.Views
{
    public interface IEditBookView
    {
        event EventHandler<EventArgs> EndEdit;
        event EventHandler<EventArgs> SelectItemToDelete;
        event EventHandler<EventArgs> DeleteItem;
        void ShowEditForm();
        void ShowDeleteForm();
        void ShowForm();
        void InitDataTable(List<Book> bookList);
        void InitDataGridView();
        void EndEditItem(Book editedItem, EventArgs e);
        void SelectBookToDelete(Book item, EventArgs e);
        void CreateDeleteView();
        void RemoveFromDataGridView();
    }
}
