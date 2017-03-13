using BooksWF.Models.ItemsList;
using BooksWF.Models.OutputList;
using CardProject.Models;
using System.Collections.Generic;
using System.IO;

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

            if (_bookList == null)
            {
                _bookList = new BookList();
                _bookList.SetList(bookSetter);
            }
            return _bookList;
        }
        public void SetList(ISetItem bookSetter)
        {
            _bookSetter = bookSetter;
            _list = ReadFromFile("Books.txt");
        }
        public List<PolygraphicItem> GetList()
        {
            return _list;
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
