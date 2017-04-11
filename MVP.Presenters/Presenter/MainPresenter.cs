using MVP.Models.DAL;
using MVP.Models.ViewModel;
using MVP.Presenters.OutputInstance;
using MVP.Presenters.OutputList;
using MVP.Views;

namespace MVP.Presenters
{
    public class MainPresenter
    {
        private PolygraphicItemListModel _model;
        private IMainView _view;
        public MainPresenter(IMainView view)
        {
            _model = new PolygraphicItemListModel();
            _view = view;
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
            _view.OutputText = searchOutput.SearchResultsOutput(_view.EnteredAuthor, _model.GetAllPolygraphicItems());
        }
        public void SaveMagazinesInXml()
        {
            MagazineListOutput output = new MagazineListOutput();
            _view.OutputText = output.XmlOutput(_model.GetMagazineList());
        }
        public void SaveNewspapersInTextFile()
        {
            TextFileSave textFileSave = new TextFileSave(new NewspaperStringOutput());
            _view.OutputText = textFileSave.SaveInTextFile(_model.GetNewspaperList());
        }
        public void SaveBooksInDB()
        {
            DBSave save = new DBSave(new DatabaseOperation());
            _view.OutputText = save.SaveInDB(_model.GetBookList());
        }
        public void ShowAddBookView()
        {
            _view.GetAddBookView().ShowBookForm();
        }
        public void ShowAddNewspaperView()
        {
            _view.GetAddNewspaperView().ShowForm();
        }
        public void ShowAddMagazineView()
        {
            _view.GetAddMagazineView().ShowForm();
        }
        public void ShowEditBookView()
        {
            _view.GetEditBookView().ShowEditForm();
        }
        public void ShowEditNewspaperView()
        {
            _view.GetEditNewspaperView().ShowEditForm();
        }
        public void ShowEditMagazineView()
        {
            _view.GetEditMagazineView().ShowEditForm();
        }
        public void ShowDeleteBookView()
        {
            _view.GetEditBookView().ShowDeleteForm();
        }
        public void ShowDeleteNewspaperView()
        {
            _view.GetEditNewspaperView().ShowDeleteForm();
        }
        public void ShowDeleteMagazineView()
        {
            _view.GetEditMagazineView().ShowDeleteForm();
        }
    }
}
