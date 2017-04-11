using MVP.Entities;
using MVP.Models.DAL;
using System.Collections.Generic;
using System.Configuration;

namespace MVP.Models.ViewModel
{
    public class MagazineListModel
    {
        public List<Book> ArticlesList { get; private set; }
        public Book EditedAuthoredItem { get; set; }
        public Magazine EditedMagazine { get; set; }
        private readonly string _connectionString;
        private DatabaseOperation _databaseOperation;
        public MagazineListModel()
        {
            ArticlesList = new List<Book>();
            EditedAuthoredItem = new Book();
            EditedMagazine = new Magazine();
            _connectionString = ConfigurationManager.ConnectionStrings["BookConnection"].ConnectionString;
            _databaseOperation = new DatabaseOperation();
        }
        public List<Magazine> LoadMagazineList()
        {
            List<Magazine> magazines = _databaseOperation.GetMagazines(_connectionString, "Magazines","MagazineArticles");
            return magazines;
        }
        public void UpdateMagazineModel(Magazine magazine)
        {
            _databaseOperation.UpdateMagazineModel(_connectionString, "Magazines", magazine);
        }
        public void UpdateArticleModel(Book article)
        {
            _databaseOperation.UpdateBookModel(_connectionString, "MagazineArticles", article, "MagazineId", EditedMagazine.ID);
        }
        public List<Book> GetArticles()
        {
            List<Book> articles = new List<Book>();
            articles = _databaseOperation.GetBooks(_connectionString, "MagazineArticles", "MagazineId", EditedMagazine.ID);
            return articles;
        }

        public void RemoveFromMagazineList()
        {
            _databaseOperation.RemoveFromDb(_connectionString, "MagazineArticles", "MagazineId", EditedMagazine.ID);
            _databaseOperation.RemoveFromDb(_connectionString, "Magazines", "Id", EditedMagazine.ID);
        }
        public void RemoveArticleFromMagazineList()
        {
            _databaseOperation.RemoveFromDb(_connectionString, "MagazineArticles", "Id", EditedAuthoredItem.ID);
        }
        public void AddToMagazineList(Magazine magazine)
        {
            int magazineId = _databaseOperation.AddMagazineToDb(_connectionString, "Magazines", magazine);
            foreach (Book article in magazine.Articles)
            {
                _databaseOperation.AddBookToDb(_connectionString, "MagazineArticles", article, magazineId, "MagazineId");
            }
        }
        public void AddToArticlesList(Book article)
        {
            ArticlesList.Add(article);
        }
    }
}
