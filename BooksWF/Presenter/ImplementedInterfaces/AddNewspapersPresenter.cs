using BooksWF.Model;
using BooksWF.Models.AddItem;
using BooksWF.Models.Instances;
using BooksWF.View;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Presenter
{
   public class AddNewspapersPresenter:IAddNewspaperPresenter
    { 
        private INewspaperListModel _model;
        private IAddNewspaperView _view;
        public AddNewspapersPresenter(INewspaperListModel model,IAddNewspaperView view)
        {
            _model = model;
            _view = view;
            _view.NewspaperPresenter = this;
        }
        public void ShowView()
        {
            _view.ShowForm();
        }
        private void Form_AddAuthors(object sender, EventArgs e)
        {
            _view.Form.AddTextBoxAuthors();
        }

        private void Form_AddAuthoredItem(object sender, EventArgs e)
        {
            _view.Form.GetAuthorsFromTextBox();
            SetPolygraphicItem setArticle = new SetPolygraphicItem();
            AuthoredItem article = setArticle.SetAuthoredItem(_view.Form.Title, _view.Form.Authors, Convert.ToInt32(_view.Form.Pages));
            _model.AddToArticlesList(article);
            _view.Form.CloseForm();
        }
        public void AddNewspaper()
        {
            SetPolygraphicItem setNewspaper = new SetPolygraphicItem();
            Newspaper newspaper = setNewspaper.SetNewspaper(_view.Title, _view.Issue,_view.Periodical, _model.ArticlesList);
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
