using BooksWF.Model;
using BooksWF.Models;
using BooksWF.Models.OutputInstance;
using BooksWF.Models.OutputList;
using BooksWF.Models.OutputLists;
using BooksWF.View;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Presenter
{
   public class MainPresenter
    {
        private PolygraphicItemModel _model;
        private IMainView _view;
        public MainPresenter(PolygraphicItemModel model, IMainView view)
        {
            _model = model;
            _view = view;
            _view.Presenter = this;
        }
        public IMainView ReturnMainView()
        {
            return _view;
        }
        public void ShowMainView()
        {
            _view.ShowForm();
        }
        public void GetBookList()
        {
            OutputBookList outputBookList = new OutputBookList();
            _view.OutputText = outputBookList.Output(_model.GetBookList());
        }
        public void GetNewspaperList()
        {
            OutputNewspaperList outputNewspaperList = new OutputNewspaperList();
            _view.OutputText = outputNewspaperList.Output(_model.GetNewspaperList());
        }
        public void GetMagazineList()
        {
            MagazineListOutput magazineList = new MagazineListOutput();
            _view.OutputText = magazineList.Output(_model.GetMagazineList());
        }
        public void SearchByAuthor()
        {
            SearchOutput searchOutput = new SearchOutput();
           _view.OutputText = searchOutput.SearchResultsOutput(_view.EnteredAuthor,_model.GetAllPolygraphicItems());
        }
        public void SaveMagazinesInXml()
        {
            MagazineListOutput output = new MagazineListOutput();
            _view.OutputText = output.XmlOutput(_model.GetMagazineList());
        }
        public void SaveNewspapersInTextFile()
        {
            TextFileSave textFileSave = new TextFileSave( new StringOutputItem());
            _view.OutputText = textFileSave.SaveInTextFile(_model.GetNewspaperList());
        }
        public void SaveBooksInDB()
        {
            DBSave save = new DBSave();
            _view.OutputText = save.SaveInDB(_model.GetBookList());
        }
        public void ShowAddBookView()
        {
            AddBooksPresenter presenter = new AddBooksPresenter(new PolygraphicItemListModel(), new AddBookForm());
            presenter.ShowView();
        }
        public void ShowAddNewspaperView()
        {
            AddNewspapersPresenter presenter = new AddNewspapersPresenter(new PolygraphicItemListModel(), new AddNewspaperForm());
            presenter.ShowView();
        }
        public void ShowAddMagazineView()
        {
            AddMagazinesPresenter presenter = new AddMagazinesPresenter(new PolygraphicItemListModel(), new AddMagazineForm());
            presenter.ShowView();
        }
        public void ShowEditBookView()
        {
            EditBookPresenter presenter = new EditBookPresenter(new PolygraphicItemListModel(), new BookEditForm());
            presenter.ShowEditView();
        }
        public void ShowEditNewspaperView()
        {
            EditNewspaperPresenter presenter = new EditNewspaperPresenter(new PolygraphicItemListModel(), new NewspaperEditForm());
            presenter.ShowEditView();
        }
        public void ShowEditMagazineView()
        {
            EditMagazinePresenter presenter = new EditMagazinePresenter(new PolygraphicItemListModel(), new MagazineEditForm());
            presenter.ShowEditView();

        }
        public void ShowDeleteBookView()
        {
            EditBookPresenter presenter = new EditBookPresenter(new PolygraphicItemListModel(), new BookEditForm());
            presenter.ShowDeleteView();
        }
        public void ShowDeleteNewspaperView()
        {
            EditNewspaperPresenter presenter = new EditNewspaperPresenter(new PolygraphicItemListModel(), new NewspaperEditForm());
            presenter.ShowDeleteView();
        }
        public void ShowDeleteMagazineView()
        {
            EditMagazinePresenter presenter = new EditMagazinePresenter(new PolygraphicItemListModel(), new MagazineEditForm());
            presenter.ShowDeleteView();
        }
    }
}
