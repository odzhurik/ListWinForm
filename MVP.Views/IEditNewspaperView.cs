using MVP.Entities;
using System;
using System.Collections.Generic;

namespace MVP.Views
{
    public interface IEditNewspaperView
    {
        void ShowEditForm();
        void ShowDeleteForm();
        event EventHandler<EventArgs> BeginEdit;
        event EventHandler<EventArgs> EndEdit;
        event EventHandler<EventArgs> SelectItemToDelete;
        event EventHandler<EventArgs> ShowArticlesToEdit;
        event EventHandler<EventArgs> ShowArticlesToDelete;
        void BeginEditItem(Newspaper editedItem, EventArgs e);
        void InitDataTable(List<Newspaper> newspaperList);
        void InitDataGridView();
        void EndEditItem(Newspaper editedItem, EventArgs e);
        void ShowArticleListToEdit(List<AuthoredItem> list);
        void ShowArticleListToDelete(List<AuthoredItem> list);
        IEditBookView ArticleForm { get; }
        void SelectNewspaperToDelete(Newspaper item, EventArgs e);
        void CreateDeleteView();
        void RemoveFromDataGridView();
    }
}
