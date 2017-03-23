using MVP.Entities;
using MVP.Forms.CreateControl;
using MVP.Presenters;
using MVP.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MVP.Forms
{
    public partial class AddMagazineForm : Form, IAddMagazineView
    {
        private AddMagazinesPresenter _presenter;
        private IAddBookView _form;
        public List<AuthoredItem> Articles { get; set; }
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
        public AddMagazineForm()
        {
            InitializeComponent();
            _presenter = new AddMagazinesPresenter(this);
        }
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
