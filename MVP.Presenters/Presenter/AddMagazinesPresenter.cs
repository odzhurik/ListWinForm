using MVP.Entities;
using MVP.Models.ViewModel;
using MVP.Views;
using System;

namespace MVP.Presenters
{
    public class AddMagazinesPresenter
    {
        private MagazineListModel _model;
        private IAddMagazineView _view;
        public AddMagazinesPresenter(IAddMagazineView view)
        {
            _model = new MagazineListModel();
            _view = view;
        }
        private void Form_AddAuthors(object sender, EventArgs e)
        {
            _view.Form.AddTextBoxAuthors();
        }
        private void Form_AddAuthoredItem(object sender, EventArgs e)
        {
            _view.Form.GetAuthorsFromTextBox();
            AuthoredItem article = new AuthoredItem();
            article.Title = _view.Form.Title;
            article.Authors = _view.Form.Authors;
            article.Pages = Convert.ToInt32(_view.Form.Pages);
            _model.AddToArticlesList(article);
            _view.Form.CloseForm();
        }
        public void AddMagazine()
        {
            Magazine magazine = new Magazine();
            magazine.Title = _view.Title;
            magazine.IssueNumber = _view.Issue;
            magazine.Articles = _model.ArticlesList;
            _model.AddToMagazineList(magazine);
            CloseView();
        }
        public void ShowArticleForm()
        {
            _view.CreateArticlesForm(Form_AddAuthors, Form_AddAuthoredItem);
        }
        public void CloseView()
        {
            _view.CloseForm();
        }
    }
}
