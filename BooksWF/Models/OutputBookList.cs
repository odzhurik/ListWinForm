using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardProject.Models
{
    internal class OutputBookList
    {
        private List<Book> _bookList;
        private List<Book> GenerateBookList()
        {

            _bookList = new List<Book>();
            
            using (StreamReader sr = new StreamReader("Books.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Book book = new Book();
                    int index = line.IndexOf('-');
                    book.Author = line.Substring(0, index);
                    book.Title = line.Substring(index + 1);
                    _bookList.Add(book);
                }
            }
            return _bookList;
        }
        public string  Output()
        {
            
            return BookOutput.ListOutput(GenerateBookList()).ToString();
        }
    }
}
