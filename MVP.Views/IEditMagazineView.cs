using MVP.Entities;
using System;
using System.Collections.Generic;

namespace MVP.Views
{
    public interface IEditMagazineView
    {
        event EventHandler<EventArgs> BeginEdit;
        event EventHandler<EventArgs> EndEdit;
        event EventHandler<EventArgs> SelectItemToDelete;
        event EventHandler<EventArgs> ShowArticlesToEdit;
        event EventHandler<EventArgs> ShowArticlesToDelete;
        IEditBookView ArticleForm { get; }
        void ShowEditForm();
        void ShowDeleteForm();
        void BeginEditItem(Magazine editedItem, EventArgs e);
        void InitDataTable(List<Magazine> magazineList);
        void InitDataGridView();
        void EndEditItem(Magazine editedItem, EventArgs e);
        void ShowArticleListToEdit(List<AuthoredItem> list);
        void ShowArticleListToDelete(List<AuthoredItem> list);
        void SelectMagazineToDelete(Magazine item, EventArgs e);
        void CreateDeleteView();
        void RemoveFromDataGridView();
    }
}
