using BooksWF.View;
using System;

namespace BooksWF.CreateControl
{
    public class CreateArticleForm
    {
        public void Create(int countOfArticles, ref IAddBookView form, EventHandler ButtonAddArticles, EventHandler AddAuthorsToForm )
        {
            int count = Convert.ToInt32(countOfArticles);
            for (int i = 1; i <= count; i++)
            {
                form = new AddBookForm();
                form.AddAuthoredItem += new EventHandler<EventArgs>(ButtonAddArticles);
                form.AddAuthors+= new EventHandler<EventArgs>(AddAuthorsToForm);
                form.ShowForm();
            }
        }
    }
}
