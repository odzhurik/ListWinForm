using BooksWF.Models.OutputList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models
{
   public class BookList:GenerateAuthoredItemList
    {
        private static BookList _bookList;
        protected  BookList()
        {

        }
        public static BookList GetBookList()
        {
            if (_bookList == null)
                _bookList = new BookList();
            return _bookList;
        }
        public override List<PolygraphicItem> GenerateList()
        {
            return ReadFromFile("Books.txt");
        }
    }
}
