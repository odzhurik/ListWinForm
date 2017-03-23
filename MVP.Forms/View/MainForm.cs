using MVP.Presenters;
using MVP.Views;
using System;
using System.Windows.Forms;

namespace MVP.Forms
{
    public partial class MainForm : Form, IMainView
    {
        private MainPresenter _presenter;

        public MainForm()
        {
            InitializeComponent();
            _presenter = new MainPresenter(this);

        }
        public string EnteredAuthor
        {
            get
            {
                return textBoxSearch.Text;
            }
            set
            {
                textBoxSearch.Text = value;
            }
        }
        public string OutputText
        {
            get
            {
                return textBoxOutput.Text;
            }
            set
            {
                textBoxOutput.Text = value;
            }
        }
        public IAddBookView GetAddBookView()
        {
            return new AddBookForm();
        }
        public IAddMagazineView GetAddMagazineView()
        {
            return new AddMagazineForm();
        }
        public IAddNewspaperView GetAddNewspaperView()
        {
            return new AddNewspaperForm();
        }
        public IEditBookView GetEditBookView()
        {
            return new BookEditForm();
        }
        public IEditMagazineView GetEditMagazineView()
        {
            return new MagazineEditForm();
        }
        public IEditNewspaperView GetEditNewspaperView()
        {
            return new NewspaperEditForm();
        }
       
        public void ShowForm()
        {
            this.ShowDialog();
        }
        private void btnGetBookList_Click(object sender, EventArgs e)
        {
            _presenter.GetBookList();
        }

        private void btnGetMagazineList_Click(object sender, EventArgs e)
        {
            _presenter.GetMagazineList();
        }
        private void BtnSaveMagazines_Click(object sender, EventArgs e)
        {
            _presenter.SaveMagazinesInXml();
        }

        private void btnNewspaperList_Click(object sender, EventArgs e)
        {
            _presenter.GetNewspaperList();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            _presenter.SearchByAuthor();
        }

        private void addBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.ShowAddBookView();
        }

        private void addNewspaperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.ShowAddNewspaperView();
        }

        private void addMagazineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.ShowAddMagazineView();
        }
        private void bookEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.ShowEditBookView();
        }
        private void magazineEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.ShowEditMagazineView();
        }
        private void newspaperEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.ShowEditNewspaperView();
        }
        private void magazineDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.ShowDeleteMagazineView();
        }
        private void bookDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.ShowDeleteBookView();
        }
        private void newspaperDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.ShowDeleteNewspaperView();
        }
        private void buttonSaveBooksInDB_Click(object sender, EventArgs e)
        {
            _presenter.SaveBooksInDB();
        }
        private void buttonSaveNewspaperInTxtFile_Click(object sender, EventArgs e)
        {
            _presenter.SaveNewspapersInTextFile();
        }
    }
}
