using BooksWF.Models;
using BooksWF.Models.AddItem;
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
        public AddMagazineForm()
        {
            InitializeComponent();
            _articles = new List<AuthoredItem>();
        }

        private void buttonAddArticles_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(numericUpDownArticles.Value);
            for (int i = 1; i <= count; i++)
            {
                AddBookForm form = new AddBookForm();
                form.buttonAddBook.Click -= form.buttonAddBook_Click;
                form.buttonAddBook.Click += ButtonAddBook_ClickMagazine;
                form.ShowDialog();
            }
        }

        private void ButtonAddBook_ClickMagazine(object sender, EventArgs e)
        {
            Button button = sender as Button;
            AddBookForm form = button.FindForm() as AddBookForm;
            AuthoredItem article = new AuthoredItem();
            article.Title = form.textBoxTitle.Text;
            article.Pages = Convert.ToInt32(form.textBoxPages.Text);
            foreach (Control textBox in form.panelAuthors.Controls)
            {
                if (textBox is TextBox)
                {
                    article.Authors.Add(textBox.Text);
                }
            }
            _articles.Add(article);
            MessageBox.Show("Successfully added!", "Adding");
            form.Close();
        }

        private void buttonAddMagazine_Click(object sender, EventArgs e)
        {
            AddMagazine addMagazine = new AddMagazine();
            addMagazine.Add(textBoxTitle.Text, textBoxIssue.Text, _articles);
            MessageBox.Show("Successfully added!", "Adding");
            this.Close();
        }
    }
}
