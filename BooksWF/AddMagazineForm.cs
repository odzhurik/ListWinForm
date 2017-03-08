using BooksWF.CreateControl;
using BooksWF.Models;
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
    public partial class AddMagazineForm : Form
    {
        private List<AuthoredItem> _articles;
        private AddBookForm _form;
        private IGenerateList _list;
        //public AddMagazineForm()
        //{
        //    InitializeComponent();
        //    _articles = new List<AuthoredItem>();
        //}
        public AddMagazineForm(IGenerateList list)
        {
            InitializeComponent();
            _list = list;
            _articles = new List<AuthoredItem>();
        }

        private void buttonGetArticlesForm_Click(object sender, EventArgs e)
        {
            CreateArticleForm createForm = new CreateArticleForm();
            createForm.Create(Convert.ToInt32(numericUpDownArticles.Value), ref _form, ButtonAddArticles_Click);
        }

        private void ButtonAddArticles_Click(object sender, EventArgs e)
        {
            GetItemFromForm getArticle = new GetItemFromForm();
            getArticle.GetAuthoredItem(_form, _form.panelAuthors, _form.textBoxTitle, _form.textBoxPages,null,_articles);
            //Button button = sender as Button;
            //AddBookForm form = button.FindForm() as AddBookForm;
            //AuthoredItem article = new AuthoredItem();
            //article.Title = form.textBoxTitle.Text;
            //article.Pages = Convert.ToInt32(form.textBoxPages.Text);
            //foreach (Control textBox in form.panelAuthors.Controls)
            //{
            //    if (textBox is TextBox)
            //    {
            //        article.Authors.Add(textBox.Text);
            //    }
            //}
            //_articles.Add(article);
            //MessageBox.Show("Successfully added!", "Adding");
            //form.Close();
        }

        private void buttonAddMagazine_Click(object sender, EventArgs e)
        {
            GetItemFromForm getMagazine = new GetItemFromForm();
            getMagazine.GetMagazine(this, textBoxTitle, textBoxIssue, _articles, _list.GetList());
        }
    }
}
