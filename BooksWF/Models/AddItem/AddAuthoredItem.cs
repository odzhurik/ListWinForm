using BooksWF.Models.OutputList;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.AddItem
{
   public class AddAuthoredItem
    {
        public void Add(string title, List<string> authors, int pages)
        {
            AuthoredItem book = new AuthoredItem();
            SetItem itemSetter = new SetItem();
            book.Title = title;
            book.Authors.AddRange(authors);
            book.Pages = pages;
            BookList.GetBookList(itemSetter).AddBookToList(book);

        }
    }
}
