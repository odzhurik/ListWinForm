using BooksWF.Models.ItemsList;
using BooksWF.Models.OutputList;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models
{
    public class BookList : IGenerateList
    {
        private static BookList _bookList;
        private List<PolygraphicItem> _list;
        private static ISetItem _bookSetter;
        protected BookList()
        {

        }
        public static BookList GetBookList(ISetItem bookSetter)
        {
            _bookSetter = bookSetter;
            if (_bookList == null)
                _bookList = new BookList();
            return _bookList;
        }
        public List<PolygraphicItem> GenerateList()
        {
            return ReadFromFile("Books.txt");
        }
        public List<PolygraphicItem> ReadFromFile(string path)
        {
            _list = new List<PolygraphicItem>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    AuthoredItem authoredItem = new AuthoredItem();
                    _bookSetter.SetPolygraphicItem(line, authoredItem);
                    _list.Add(authoredItem);
                }
            }
            return _list;
        }
    }
}
