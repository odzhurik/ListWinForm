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
   public class NewspaperListModel
    {
        public List<AuthoredItem> ArticlesList { get; private set; }
        public Newspaper EditedNewspaper { get; set; }
        public AuthoredItem EditedAuthoredItem { get; set; }
        private ISetItem _itemSetter;
        public NewspaperListModel()
        {
            ArticlesList = new List<AuthoredItem>();
            EditedNewspaper = new Newspaper();
            EditedAuthoredItem = new AuthoredItem();
            _itemSetter = new SetItem();
        }
        public List<Newspaper> LoadNewspaperList()
        {
            return NewspaperList.GetNewspaperList(_itemSetter).GetList().ConvertAll(instance => instance as Newspaper);
        }
        public Newspaper GetEditedNewspaper()
        {
            Newspaper newspaper = NewspaperList.GetNewspaperList(_itemSetter).GetList().FirstOrDefault(item => item.Title == EditedNewspaper.Title) as Newspaper;
            return newspaper;
        }
        public AuthoredItem GetEditedArticleInNewspaperList()
        {
            AuthoredItem article = GetEditedNewspaper().Articles.FirstOrDefault(item => item.Title == EditedAuthoredItem.Title);
            return article;
        }
        public void RemoveFromNewspaperList()
        {
            Newspaper newspaper = NewspaperList.GetNewspaperList(_itemSetter).GetList().FirstOrDefault(item => item.Title == EditedNewspaper.Title) as Newspaper;
            NewspaperList.GetNewspaperList(_itemSetter).GetList().Remove(newspaper);
        }
        public void RemoveArticleFromNewspaperList()
        {
            Newspaper newspaper = GetEditedNewspaper();
            AuthoredItem article = newspaper.Articles.FirstOrDefault(item => item.Title == EditedAuthoredItem.Title);
            newspaper.Articles.Remove(article);
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
