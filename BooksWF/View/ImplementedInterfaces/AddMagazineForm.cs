using BooksWF.CreateControl;
using BooksWF.Models;
using BooksWF.Models.AddItem;
using BooksWF.Models.OutputList;
using BooksWF.Presenter;
using BooksWF.View;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksWF
{
    public partial class AddMagazineForm : Form, IAddMagazineView
    {
        private IAddMagazinePresenter _presenter;
        private IAddBookView _form;
        public AddMagazineForm()
        {
            InitializeComponent();
        }
        public IAddMagazinePresenter MagazinePresenter
        {
            set
            {
                _presenter = value;
            }
        }
        public IAddBookView Form
        {
            get
            {
                return _form;
            }
            set
            {
                _form = value;
            }
        }
        public string Title
        {
            get
            {
                return textBoxTitle.Text;
            }
            set
            {
                textBoxTitle.Text = value;
            }
        }
        public string Issue
        {
            get
            {
                return textBoxIssue.Text;
            }
            set
            {
                textBoxIssue.Text = value;
            }
        }
        public List<AuthoredItem> Articles { get; set; }
        public void ShowForm()
        {
            this.ShowDialog();
        }
        public void CloseForm()
        {
            MessageBox.Show("Successfully added!", "Adding");
            this.Close();
        }
        private void buttonGetArticlesForm_Click(object sender, EventArgs e)
        {
            _presenter.ShowArticleForm();
        }

        private void buttonAddMagazine_Click(object sender, EventArgs e)
        {
            _presenter.AddMagazine();
        }
        public void CreateArticlesForm(EventHandler AddAuthors, EventHandler AddArticles)
        {
            CreateArticleForm createForm = new CreateArticleForm();
            createForm.Create(Convert.ToInt32(numericUpDownArticles.Value), ref _form, AddArticles, AddAuthors);
        }

    }
}
