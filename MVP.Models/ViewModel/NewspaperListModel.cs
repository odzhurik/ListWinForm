using MVP.Entities;
using MVP.Models.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace MVP.Models.ViewModel
{
    public class NewspaperListModel
    {
        public List<Book> ArticlesList { get; private set; }
        public Newspaper EditedNewspaper { get; set; }
        public Book EditedAuthoredItem { get; set; }
        private readonly string _connectionString;
        private DatabaseOperation _databaseOperation;
        public NewspaperListModel()
        {
            ArticlesList = new List<Book>();
            EditedNewspaper = new Newspaper();
            EditedAuthoredItem = new Book();
            _connectionString = ConfigurationManager.ConnectionStrings["BookConnection"].ConnectionString;
            _databaseOperation = new DatabaseOperation();
        }
        public List<Newspaper> LoadNewspaperList()
        {
            List<Newspaper> newspapers = _databaseOperation.GetNewspapers(_connectionString, "Newspapers","NewspaperArticles");
            return newspapers;
        }
        public List<Book> GetArticles()
        {
            List<Book> articles = new List<Book>();
            articles = _databaseOperation.GetBooks(_connectionString, "NewspaperArticles", "NewspaperId", EditedNewspaper.ID);
            return articles;
        }
        public void UpdateArticleModel(Book article)
        {

            _databaseOperation.UpdateBookModel(_connectionString, "NewspaperArticles", article, "NewspaperId", EditedNewspaper.ID);

        }
        public void UpdateNewspaperModel(Newspaper newspaper)
        {
            _databaseOperation.UpdateNewspaperModel(_connectionString, "Newspapers", newspaper);
        }
        public void RemoveFromNewspaperList()
        {
            _databaseOperation.RemoveFromDb(_connectionString, "NewspaperArticles", "NewspaperId", EditedNewspaper.ID);
            _databaseOperation.RemoveFromDb(_connectionString, "Newspapers", "Id", EditedNewspaper.ID);
        }
        public void RemoveArticleFromNewspaperList()
        {
            _databaseOperation.RemoveFromDb(_connectionString, "NewspaperArticles", "Id", EditedAuthoredItem.ID);
        }
        public void AddToNewspaperList(Newspaper newspaper)
        {
            int newspaperId = _databaseOperation.AddNewspaperToDb(_connectionString, "Newspapers", newspaper);
            foreach (Book article in newspaper.Articles)
            {
                _databaseOperation.AddBookToDb(_connectionString, "NewspaperArticles", article, newspaperId, "NewspaperId");
            }
        }
        public void AddToArticlesList(Book article)
        {
            ArticlesList.Add(article);
        }
    }
}
