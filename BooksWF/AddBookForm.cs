using BooksWF.CreateControl;
using BooksWF.Models.AddItem;
using BooksWF.Models.GetItem;
using BooksWF.Models.OutputList;
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
    public partial class AddBookForm : Form
    {
        private IGenerateList _list;
        public AddBookForm(IGenerateList list)
        {
            InitializeComponent();
            _list = list;
            buttonAddBook.Click += buttonAddBook_Click;
        }
        public AddBookForm()
        {
            InitializeComponent();
        }
        private void linkLabelAddAuthor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddTextBoxToForm addTextBox = new AddTextBoxToForm();
            addTextBox.Add(numericUpDownAuthors, panelAuthors, textBoxAuthor0, linkLabelAddAuthor);
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            GetItemFromForm getItem = new GetItemFromForm();
            getItem.GetAuthoredItem(this, panelAuthors, textBoxTitle, textBoxPages, _list.GetList(),null);
        }
    }
}
