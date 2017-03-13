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
   public class EditMagazinePresenter:IEditMagazinePresenter 
    {
       private IMagazineListModel _model;
       private IEditMagazineView _view;
        public EditMagazinePresenter(IMagazineListModel model,IEditMagazineView view)
        {
            _model = model;
            _view = view;
            _view.MagazinePresenter = this;
        }
        public void ShowEditView()
        {
            _view.BeginEdit += _view_BeginEdit;
            _view.EndEdit += _view_EndEdit;
            _view.ShowArticlesToEdit += _view_ShowArticlesToEdit;
            LoadMagazines();
            _view.ShowForm();
        }
        public void ShowDeleteView()
        {
            _view.ShowArticlesToDelete += _view_ShowArticlesToDelete; ;
            _view.SelectItemToDelete += _view_SelectItemToDelete; ;
            LoadMagazines();
            _view.CreateDeleteView();
            _view.ShowForm();
        }

        private void _view_SelectItemToDelete(object sender, EventArgs e)
        {
            _view.SelectMagazineToDelete(_model.EditedMagazine, e);
        }

        private void _view_ShowArticlesToDelete(object sender, EventArgs e)
        {
            _view.EndEditItem(_model.EditedMagazine, e);
            _view.ArticleForm.SelectItemToDelete += ArticleForm_SelectItemToDelete; ;
            _view.ArticleForm.DeleteItem += ArticleForm_DeleteItem; ;
            _view.ShowArticleListToDelete(_model.GetEditedMagazine().Articles);
        }

        private void ArticleForm_DeleteItem(object sender, EventArgs e)
        {
            _view.ArticleForm.RemoveFromDataGridView();
            _model.RemoveArticleFromMagazineList();
        }

        private void ArticleForm_SelectItemToDelete(object sender, EventArgs e)
        {
            _view.ArticleForm.SelectBookToDelete(_model.EditedAuthoredItem, e);
        }

        private void _view_ShowArticlesToEdit(object sender, EventArgs e)
        {
            _view.EndEditItem(_model.EditedMagazine, e);
            _view.ArticleForm.BeginEdit += ArticleForm_BeginEdit;
            _view.ArticleForm.EndEdit += ArticleForm_EndEdit;
            _view.ShowArticleListToEdit(_model.GetEditedMagazine().Articles);
        }

        private void ArticleForm_EndEdit(object sender, EventArgs e)
        {
            _view.ArticleForm.EndEditItem(_model.GetEditedArticleInMagazineList(), e);
        }

        private void ArticleForm_BeginEdit(object sender, EventArgs e)
        {
            _view.ArticleForm.BeginEditItem(_model.EditedAuthoredItem, e);
        }

        private void _view_EndEdit(object sender, EventArgs e)
        {
            _view.EndEditItem(_model.GetEditedMagazine(), e);
        }

        private void _view_BeginEdit(object sender, EventArgs e)
        {
            _view.BeginEditItem(_model.EditedMagazine, e);
        }
        public void RemoveMagazine()
        {
            _view.RemoveFromDataGridView();
            _model.RemoveFromMagazineList();
        }
        public void LoadMagazines()
        {
            _view.InitDataTable(_model.LoadMagazineList());
            _view.InitDataGridView();
        }
    }
}
