using BooksWF.CreateControl;
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
    public partial class AddBookForm : Form, IAddBookView
    {
        private IAddBookPresenter _presenter;
        public AddBookForm()
        {
            InitializeComponent();
            buttonAddBook.Click += buttonAddBook_Click;
            Authors = new List<string>();
        }
        public event EventHandler<EventArgs> AddAuthoredItem;
        public event EventHandler<EventArgs> AddAuthors;
        public IAddBookPresenter BookPresenter
        {
            set
            {
                _presenter = value;
            }
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
        public List<string> Authors { get; set; }
        public string Pages
        {
            get
            {
                return textBoxPages.Text;
            }
            set
            {
                textBoxPages.Text = value;
            }
        }
        private void linkLabelAddAuthor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (AddAuthors != null)
            {
                AddAuthors(this, e);
            }
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            if (AddAuthoredItem != null)
            {
                AddAuthoredItem(this, e);
            }
        }
        public void AddTextBoxAuthors()
        {
            AddTextBoxToForm addTextBox = new AddTextBoxToForm();
            addTextBox.Add(this.numericUpDownAuthors, panelAuthors, this.textBoxAuthor0, this.linkLabelAddAuthor);
        }
        public void GetAuthorsFromTextBox()
        {
            foreach (Control textBox in panelAuthors.Controls)
            {
                if (textBox is TextBox)
                {
                    Authors.Add(textBox.Text);
                }
            }
        }
    }
}
