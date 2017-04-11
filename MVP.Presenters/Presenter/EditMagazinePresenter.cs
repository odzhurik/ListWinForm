using MVP.Models.ViewModel;
using MVP.Views;
using System;

namespace MVP.Presenters
{
    public class EditMagazinePresenter
    {
        private MagazineListModel _model;
        private IEditMagazineView _view;
        public EditMagazinePresenter(IEditMagazineView view)
        {
            _model = new MagazineListModel();
            _view = view;
        }
        public void CreateEditView()
        {
            _view.EndEdit += _view_EndEdit;
            _view.ShowArticlesToEdit += _view_ShowArticlesToEdit;
            LoadMagazines();
        }
        public void CreateDeleteView()
        {
            _view.ShowArticlesToDelete += _view_ShowArticlesToDelete; ;
            _view.SelectItemToDelete += _view_SelectItemToDelete; ;
            LoadMagazines();
            _view.CreateDeleteView();
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
            _view.ShowArticleListToDelete(_model.GetArticles());
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
            _view.EndEditItem(_model.EditedMagazine, e);
            _model.UpdateMagazineModel(_model.EditedMagazine);
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
