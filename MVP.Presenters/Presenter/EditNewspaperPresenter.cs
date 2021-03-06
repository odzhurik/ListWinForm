﻿using MVP.Models.ViewModel;
using MVP.Views;
using System;

namespace MVP.Presenters
{
    public class EditNewspaperPresenter
    {
        private NewspaperListModel _model;
        private IEditNewspaperView _view;
        public EditNewspaperPresenter(IEditNewspaperView view)
        {
            _model = new NewspaperListModel();
            _view = view;
        }
        public void CreateEditView()
        {
            _view.EndEdit += _view_EndEdit;
           _view.ShowArticlesToEdit += _view_ShowArticlesToEdit;
            LoadNewspapersList();
        }
        public void CreateDeleteView()
        {
            _view.ShowArticlesToDelete += _view_ShowArticlesToDelete;
            _view.SelectItemToDelete += _view_SelectItemToDelete;
            LoadNewspapersList();
            _view.CreateDeleteView();
        }
        private void _view_SelectItemToDelete(object sender, EventArgs e)
        {
            _view.SelectNewspaperToDelete(_model.EditedNewspaper, e);
        }
        public void RemoveNewspaper()
        {
            _view.RemoveFromDataGridView();
            _model.RemoveFromNewspaperList();
        }
        private void _view_ShowArticlesToDelete(object sender, EventArgs e)
        {
            _view.EndEditItem(_model.EditedNewspaper, e);
            _view.ArticleForm.SelectItemToDelete += ArticleForm_SelectItemToDelete;
            _view.ArticleForm.DeleteItem += ArticleForm_DeleteItem;
            _view.ShowArticleListToDelete(_model.GetArticles());
        }
        private void ArticleForm_DeleteItem(object sender, EventArgs e)
        {
            _view.ArticleForm.RemoveFromDataGridView();
            _model.RemoveArticleFromNewspaperList();
        }
        private void ArticleForm_SelectItemToDelete(object sender, EventArgs e)
        {
            _view.ArticleForm.SelectBookToDelete(_model.EditedAuthoredItem, e);
        }
        private void _view_ShowArticlesToEdit(object sender, EventArgs e)
        {
            _view.EndEditItem(_model.EditedNewspaper, e);
            _view.ArticleForm.EndEdit += ArticleForm_EndEdit;
            _view.ShowArticleListToEdit(_model.GetArticles());
        }
        private void ArticleForm_EndEdit(object sender, EventArgs e)
        {
            _view.ArticleForm.EndEditItem(_model.EditedAuthoredItem, e);
            _model.UpdateArticleModel(_model.EditedAuthoredItem);
        }
        private void _view_EndEdit(object sender, EventArgs e)
        {
            _view.EndEditItem(_model.EditedNewspaper, e);
            _model.UpdateNewspaperModel(_model.EditedNewspaper);
        }
        
        public void LoadNewspapersList()
        {
            _view.InitDataTable(_model.LoadNewspaperList());
            _view.InitDataGridView();
        }
    }
}
