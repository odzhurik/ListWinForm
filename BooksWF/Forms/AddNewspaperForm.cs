using BooksWF.CreateControl;
using BooksWF.Models.AddItem;
using BooksWF.Models.GetItem;
using BooksWF.Models.Instances;
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
    public partial class AddNewspaperForm : Form
    {
        private List<AuthoredItem> _articles;
        private IGenerateList _list;
        private AddBookForm _form;
        public AddNewspaperForm(IGenerateList list)
        {
            InitializeComponent();
            _articles = new List<AuthoredItem>();
            _list = list;
        }

        private void buttonAddArticles_Click(object sender, EventArgs e)
        {
            CreateArticleForm createForm = new CreateArticleForm();
            createForm.Create(Convert.ToInt32(numericUpDownArticles.Value), ref _form, buttonAddArticle_Click);
        }

        private void buttonAddArticle_Click(object sender, EventArgs e)
        {
            GetItemFromForm getArticle = new GetItemFromForm();
            getArticle.GetAuthoredItem(_form, _form.panelAuthors, _form.textBoxTitle, _form.textBoxPages, null, _articles);
        }

        private void buttonAddNewspaper_Click(object sender, EventArgs e)
        {
            GetItemFromForm getNewspaper = new GetItemFromForm();
            getNewspaper.GetNewspaper(this, textBoxTitle, textBoxIssue, textBoxPeriodical, _articles, _list.GetList());

        }
    }
}
