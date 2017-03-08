using BooksWF.Models.AddItem;
using BooksWF.Models.OutputList;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksWF.Models.GetItem
{
    public class GetItemFromForm
    {
        public void GetAuthoredItem(Form form, Panel panel, TextBox textBoxTitle, TextBox textBoxPages, List<PolygraphicItem> list, List<AuthoredItem> articles)
        {
            SetPolygraphicItem addBook = new SetPolygraphicItem();
            List<string> authors = new List<string>();
            foreach (Control textBox in panel.Controls)
            {
                if (textBox is TextBox)
                {
                    authors.Add(textBox.Text);
                }
            }
            AuthoredItem item = addBook.SetAuthoredItem(textBoxTitle.Text, authors, Convert.ToInt32(textBoxPages.Text));
            if (list != null)
            {
                list.Add(item);
            }
            
            if (articles != null)
            {
                articles.Add(item);
            }
            MessageBox.Show("Successfully added!", "Adding");
            form.Close();
        }
        public void GetMagazine(Form form, TextBox textBoxTitle, TextBox textBoxIssue, List<AuthoredItem> articles, List<PolygraphicItem> list)
        {
            SetPolygraphicItem setMagazine = new SetPolygraphicItem();
            list.Add(setMagazine.SetMagazine(textBoxTitle.Text, textBoxIssue.Text, articles));
            MessageBox.Show("Successfully added!", "Adding");
            form.Close();
        }
        public void GetNewspaper(Form form, TextBox textBoxTitle, TextBox textBoxIssue, TextBox textBoxPeriodical, List<AuthoredItem> articles, List<PolygraphicItem> list)
        {
            SetPolygraphicItem setNewspaper = new SetPolygraphicItem();
            list.Add(setNewspaper.Add(textBoxTitle.Text, textBoxIssue.Text, textBoxPeriodical.Text, articles));
            MessageBox.Show("Successfully added!", "Adding");
            form.Close();
        }
    }
}
