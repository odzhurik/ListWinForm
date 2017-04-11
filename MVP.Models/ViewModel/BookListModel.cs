using MVP.Entities;
using MVP.Models.DAL;
using System.Collections.Generic;
using System.Configuration;

namespace MVP.Models.ViewModel
{
    public class BookListModel
    {
        public Book EditedAuthoredItem { get; set; }
        private readonly string _connectionString;
        private DatabaseOperation _databaseOperation;
        public BookListModel()
        {
            EditedAuthoredItem = new Book();
            _connectionString= ConfigurationManager.ConnectionStrings["BookConnection"].ConnectionString;
            _databaseOperation = new DatabaseOperation();

        }
        public List<Book> LoadBookList()
        {
           List<Book> books = _databaseOperation.GetBooks(_connectionString, "Books");
            return books;
        }
        public void UpdateBookModel(Book book)
        {
              _databaseOperation.UpdateBookModel(_connectionString, "Books", book);
        }
        public void RemoveFromBookList()
        {
         _databaseOperation.RemoveFromDb(_connectionString, "Books", "Id", EditedAuthoredItem.ID);
        }
        public void AddToBookList(Book book)
        {
            _databaseOperation.AddBookToDb(_connectionString, "Books", book);
        }
    }
}
