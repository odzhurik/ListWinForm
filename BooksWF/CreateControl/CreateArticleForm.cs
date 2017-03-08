using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksWF.CreateControl
{
   public class CreateArticleForm
    {
        public void Create(int countOfArticles,ref AddBookForm form, EventHandler ButtonAddArticles)
        {
            int count = Convert.ToInt32(countOfArticles);
            for (int i = 1; i <= count; i++)
            {
                form = new AddBookForm();
                form.buttonAddBook.Click += ButtonAddArticles;
                form.ShowDialog();
            }
        }
    }
}
