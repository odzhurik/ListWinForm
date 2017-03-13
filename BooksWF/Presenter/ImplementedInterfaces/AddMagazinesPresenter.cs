using BooksWF.Model;
using BooksWF.Models;
using BooksWF.Models.AddItem;
using BooksWF.View;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Presenter
{
   public class AddMagazinesPresenter:IAddMagazinePresenter
    {
        private IMagazineListModel _model;
        private IAddMagazineView _view;
        public AddMagazinesPresenter(IMagazineListModel model,IAddMagazineView view)
        {
            _model = model;
            _view = view;
            _view.MagazinePresenter = this;
           
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
        public void AddMagazine()
        {
            SetPolygraphicItem setMagazine = new SetPolygraphicItem();
            Magazine magazine = setMagazine.SetMagazine(_view.Title, _view.Issue, _model.ArticlesList);
            _model.AddToMagazineList(magazine);
            CloseView();

        }
        public void ShowView()
        {
            _view.ShowForm();
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
