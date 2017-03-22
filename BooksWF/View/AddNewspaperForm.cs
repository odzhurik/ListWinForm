using MVP.Entities;
using MVP.Forms.CreateControl;
using MVP.Presenters;
using MVP.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MVP.Forms
{
    public partial class AddNewspaperForm : Form, IAddNewspaperView
    {
        private IAddBookView _form;
        private AddNewspapersPresenter _presenter;
        public AddNewspaperForm()
        {
            InitializeComponent();
            _presenter = new AddNewspapersPresenter(this);
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
        public string Periodical
        {
            get
            {
                return textBoxPeriodical.Text;
            }
            set
            {
                textBoxPeriodical.Text = value;
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
        public void CreateArticlesForm(EventHandler AddAuthors, EventHandler AddArticles)
        {
            CreateArticleForm createForm = new CreateArticleForm();
            createForm.Create(Convert.ToInt32(numericUpDownArticles.Value), ref _form, AddArticles, AddAuthors);
        }
        private void buttonAddArticles_Click(object sender, EventArgs e)
        {
            _presenter.ShowArticleForm();
        }
        private void buttonAddNewspaper_Click(object sender, EventArgs e)
        {
            _presenter.AddNewspaper();
        }
    }
}
