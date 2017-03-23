using MVP.Entities;
using MVP.Models.ViewModel;
using MVP.Views;
using System;

namespace MVP.Presenters
{
    public class AddNewspapersPresenter
    {
        private NewspaperListModel _model;
        private IAddNewspaperView _view;
        public AddNewspapersPresenter(IAddNewspaperView view)
        {
            _model = new NewspaperListModel();
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
        public void AddNewspaper()
        {
            Newspaper newspaper = new Newspaper();
            newspaper.Title = _view.Title;
            newspaper.IssueNumber = _view.Issue;
            newspaper.Periodical = _view.Periodical;
            newspaper.Articles = _model.ArticlesList;
            _model.AddToNewspaperList(newspaper);
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
