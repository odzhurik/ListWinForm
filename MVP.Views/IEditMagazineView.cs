using MVP.Entities;
using System;
using System.Collections.Generic;

namespace MVP.Views
{
    public interface IEditMagazineView
    {
        void ShowEditForm();
        void ShowDeleteForm();
        event EventHandler<EventArgs> BeginEdit;
        event EventHandler<EventArgs> EndEdit;
        event EventHandler<EventArgs> SelectItemToDelete;
        event EventHandler<EventArgs> ShowArticlesToEdit;
        event EventHandler<EventArgs> ShowArticlesToDelete;
        void BeginEditItem(Magazine editedItem, EventArgs e);
        void InitDataTable(List<Magazine> magazineList);
        void InitDataGridView();
        void EndEditItem(Magazine editedItem, EventArgs e);
        void ShowArticleListToEdit(List<AuthoredItem> list);
        void ShowArticleListToDelete(List<AuthoredItem> list);
        IEditBookView ArticleForm { get; }
        void SelectMagazineToDelete(Magazine item, EventArgs e);
        void CreateDeleteView();
        void RemoveFromDataGridView();
    }
}
