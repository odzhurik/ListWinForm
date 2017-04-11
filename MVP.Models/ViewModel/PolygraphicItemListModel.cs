using MVP.Entities;
using MVP.Models.DAL;
using System.Collections.Generic;
using System.Configuration;

namespace MVP.Models.ViewModel
{
    public class PolygraphicItemListModel
    {
        private DatabaseOperation _databaseOperation;
        private readonly string _connectionString;
        public PolygraphicItemListModel()
        {
            _databaseOperation = new DatabaseOperation();
            _connectionString = ConfigurationManager.ConnectionStrings["BookConnection"].ConnectionString;
        }
        public List<Book> GetBookList()
        {
            return _databaseOperation.GetBooks(_connectionString, "Books");
        }
        public List<Newspaper> GetNewspaperList()
        {
            return _databaseOperation.GetNewspapers(_connectionString, "Newspapers","NewspaperArticles");
        }
        public List<Magazine> GetMagazineList()
        {
            return _databaseOperation.GetMagazines(_connectionString, "Magazines","MagazineArticles");
        }
        public List<PolygraphicItem> GetAllPolygraphicItems()
        {
            List<PolygraphicItem> list = new List<PolygraphicItem>();
            list.AddRange(_databaseOperation.GetBooks(_connectionString, "Books").ConvertAll(instance => instance as PolygraphicItem));
            list.AddRange(_databaseOperation.GetMagazines(_connectionString, "Magazines", "MagazineArticles").ConvertAll(instance => instance as PolygraphicItem));
            list.AddRange(_databaseOperation.GetNewspapers(_connectionString, "Newspapers", "NewspaperArticles").ConvertAll(instance => instance as PolygraphicItem));
            return list;
        }
    }
}
