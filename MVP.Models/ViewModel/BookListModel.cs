using MVP.Entities;
using MVP.Models.ItemSetter;
using MVP.Models.ItemsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Models.ViewModel
{
   public class BookListModel
    {
        public AuthoredItem EditedAuthoredItem { get; set; }
        private ISetItem _itemSetter;
        public BookListModel()
        {
            EditedAuthoredItem = new AuthoredItem();
            _itemSetter = new SetItem();
        }
        public List<AuthoredItem> LoadBookList()
        {
            return BookList.GetBookList(_itemSetter).GetList().ConvertAll(instance => instance as AuthoredItem);
        }
        public AuthoredItem GetEditedBook()
        {
            AuthoredItem bookItem = BookList.GetBookList(_itemSetter).GetList().FirstOrDefault(book => book.Title == EditedAuthoredItem.Title) as AuthoredItem;
            return bookItem;
        }
        public void RemoveFromBookList()
        {
            AuthoredItem book = BookList.GetBookList(_itemSetter).GetList().FirstOrDefault(item => item.Title == EditedAuthoredItem.Title) as AuthoredItem;
            BookList.GetBookList(_itemSetter).GetList().Remove(book);
        }
        public void AddToBookList(PolygraphicItem book)
        {
            BookList.GetBookList(_itemSetter).GetList().Add(book);
        }
    }
}
