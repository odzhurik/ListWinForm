using BooksWF.Models;
using BooksWF.Models.Instances;
using BooksWF.Models.ItemsList;
using BooksWF.Models.OutputList;
using CardProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace BooksWF.Model
{
    public class PolygraphicItemListModel : IBookListModel, IMagazineListModel, INewspaperListModel
    {
        public List<AuthoredItem> ArticlesList { get; private set; }
        public AuthoredItem EditedAuthoredItem { get; set; }
        public Newspaper EditedNewspaper { get; set; }
        public Magazine EditedMagazine { get; set; }
        private ISetItem _itemSetter;
        public PolygraphicItemListModel()
        {
            ArticlesList = new List<AuthoredItem>();
            EditedAuthoredItem = new AuthoredItem();
            EditedNewspaper = new Newspaper();
            EditedMagazine = new Magazine();
            _itemSetter = new SetItem();
        }
        public List<AuthoredItem> LoadBookList()
        {
            return BookList.GetBookList(_itemSetter).GetList().ConvertAll(instance => instance as AuthoredItem);
        }
        public List<Newspaper> LoadNewspaperList()
        {
            return NewspaperList.GetNewspaperList(_itemSetter).GetList().ConvertAll(instance => instance as Newspaper);
        }
        public List<Magazine> LoadMagazineList()
        {
            return MagazineList.GetMagazineList(_itemSetter).GetList().ConvertAll(instance => instance as Magazine);
        }
        public Newspaper GetEditedNewspaper()
        {
            Newspaper newspaper = NewspaperList.GetNewspaperList(_itemSetter).GetList().FirstOrDefault(item => item.Title == EditedNewspaper.Title) as Newspaper;
            return newspaper;
        }
        public Magazine GetEditedMagazine()
        {
            Magazine magazine = MagazineList.GetMagazineList(_itemSetter).GetList().FirstOrDefault(item => item.Title == EditedMagazine.Title) as Magazine;
            return magazine;
        }
        public AuthoredItem GetEditedArticleInNewspaperList()
        {
            AuthoredItem article = GetEditedNewspaper().Articles.FirstOrDefault(item => item.Title == EditedAuthoredItem.Title);
            return article;
        }
        public AuthoredItem GetEditedArticleInMagazineList()
        {
            AuthoredItem article = GetEditedMagazine().Articles.FirstOrDefault(item => item.Title == EditedAuthoredItem.Title);
            return article;
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
        public void RemoveFromNewspaperList()
        {
            Newspaper newspaper = NewspaperList.GetNewspaperList(_itemSetter).GetList().FirstOrDefault(item => item.Title == EditedNewspaper.Title) as Newspaper;
            NewspaperList.GetNewspaperList(_itemSetter).GetList().Remove(newspaper);
        }
        public void RemoveFromMagazineList()
        {
            Magazine magazine = MagazineList.GetMagazineList(_itemSetter).GetList().FirstOrDefault(item => item.Title == EditedMagazine.Title) as Magazine;
            MagazineList.GetMagazineList(_itemSetter).GetList().Remove(magazine);
        }
        public void RemoveArticleFromNewspaperList()
        {
            Newspaper newspaper = GetEditedNewspaper();
            AuthoredItem article = newspaper.Articles.FirstOrDefault(item => item.Title == EditedAuthoredItem.Title);
            newspaper.Articles.Remove(article);
        }
        public void RemoveArticleFromMagazineList()
        {
            Magazine magazine = GetEditedMagazine();
            AuthoredItem article = magazine.Articles.FirstOrDefault(item => item.Title == EditedAuthoredItem.Title);
            magazine.Articles.Remove(article);
        }
        public void AddToBookList(PolygraphicItem book)
        {
            BookList.GetBookList(_itemSetter).GetList().Add(book);
        }
        public void AddToMagazineList(PolygraphicItem magazine)
        {
            MagazineList.GetMagazineList(_itemSetter).GetList().Add(magazine);
        }
        public void AddToNewspaperList(PolygraphicItem newspaper)
        {
            NewspaperList.GetNewspaperList(_itemSetter).GetList().Add(newspaper);
        }
        public void AddToArticlesList(AuthoredItem article)
        {
            ArticlesList.Add(article);
        }
    }
}
