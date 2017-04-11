using MVP.Entities;
using System;
using System.Collections.Generic;

namespace MVP.Views
{
    public interface IEditNewspaperView
    {
        event EventHandler<EventArgs> EndEdit;
        event EventHandler<EventArgs> SelectItemToDelete;
        event EventHandler<EventArgs> ShowArticlesToEdit;
        event EventHandler<EventArgs> ShowArticlesToDelete;
        IEditBookView ArticleForm { get; }
        void ShowEditForm();
        void ShowDeleteForm();
        void InitDataTable(List<Newspaper> newspaperList);
        void InitDataGridView();
        void EndEditItem(Newspaper editedItem, EventArgs e);
        void ShowArticleListToEdit(List<Book> list);
        void ShowArticleListToDelete(List<Book> list);
        void SelectNewspaperToDelete(Newspaper item, EventArgs e);
        void CreateDeleteView();
        void RemoveFromDataGridView();
    }
}
