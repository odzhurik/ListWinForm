namespace MVP.Views
{
    public interface IMainView
    {
        string OutputText { get; set; }
        string EnteredAuthor { get; set; }
        void ShowForm();
        IAddBookView GetAddBookView();
        IAddMagazineView GetAddMagazineView();
        IAddNewspaperView GetAddNewspaperView();
        IEditBookView GetEditBookView();
        IEditMagazineView GetEditMagazineView();
        IEditNewspaperView GetEditNewspaperView();
        
    }
}
