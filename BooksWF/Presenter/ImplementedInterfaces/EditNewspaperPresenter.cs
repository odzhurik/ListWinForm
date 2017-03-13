using BooksWF.Model;
using BooksWF.Presenter.Interfaces;
using BooksWF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Presenter
{
    public class EditNewspaperPresenter:IEditNewspaperPresenter 
    {
        private INewspaperListModel _model;
        private IEditNewspaperView _view;
        public EditNewspaperPresenter(INewspaperListModel model, IEditNewspaperView view)
        {
            _model = model;
            _view = view;
            _view.NewspaperPresenter = this;
        }
        public void ShowEditView()
        {
            _view.BeginEdit += _view_BeginEdit;
            _view.EndEdit += _view_EndEdit;
            _view.ShowArticlesToEdit += _view_ShowArticlesToEdit;
            LoadNewspapersList();
            _view.ShowForm();
        }
        public void ShowDeleteView()
        {
            _view.ShowArticlesToDelete += _view_ShowArticlesToDelete;
            _view.SelectItemToDelete += _view_SelectItemToDelete;
            LoadNewspapersList();
            _view.CreateDeleteView();
            _view.ShowForm();
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
            _view.ShowArticleListToDelete(_model.GetEditedNewspaper().Articles);
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
            _view.ArticleForm.BeginEdit += ArticleForm_BeginEdit;
            _view.ArticleForm.EndEdit += ArticleForm_EndEdit;
            _view.ShowArticleListToEdit(_model.GetEditedNewspaper().Articles);
        }

        private void ArticleForm_EndEdit(object sender, EventArgs e)
        {
            _view.ArticleForm.EndEditItem(_model.GetEditedArticleInNewspaperList(), e);
        }
        private void ArticleForm_BeginEdit(object sender, EventArgs e)
        {
            _view.ArticleForm.BeginEditItem(_model.EditedAuthoredItem, e);
        }

        private void _view_EndEdit(object sender, EventArgs e)
        {
            _view.EndEditItem(_model.GetEditedNewspaper(), e);
        }

        private void _view_BeginEdit(object sender, EventArgs e)
        {
            _view.BeginEditItem(_model.EditedNewspaper, e);
        }
        public void LoadNewspapersList()
        {
            _view.InitDataTable(_model.LoadNewspaperList());
            _view.InitDataGridView();
        }
    }
}
