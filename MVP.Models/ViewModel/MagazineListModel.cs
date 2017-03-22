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
   public class MagazineListModel
    {
        public List<AuthoredItem> ArticlesList { get; private set; }
        public AuthoredItem EditedAuthoredItem { get; set; }
        public Magazine EditedMagazine { get; set; }
        private ISetItem _itemSetter;
        public MagazineListModel()
        {
            ArticlesList = new List<AuthoredItem>();
            EditedAuthoredItem = new AuthoredItem();
            EditedMagazine = new Magazine();
            _itemSetter = new SetItem();
        }
        public List<Magazine> LoadMagazineList()
        {
            return MagazineList.GetMagazineList(_itemSetter).GetList().ConvertAll(instance => instance as Magazine);
        }
        public Magazine GetEditedMagazine()
        {
            Magazine magazine = MagazineList.GetMagazineList(_itemSetter).GetList().FirstOrDefault(item => item.Title == EditedMagazine.Title) as Magazine;
            return magazine;
        }
        public AuthoredItem GetEditedArticleInMagazineList()
        {
            AuthoredItem article = GetEditedMagazine().Articles.FirstOrDefault(item => item.Title == EditedAuthoredItem.Title);
            return article;
        }
        public void RemoveFromMagazineList()
        {
            Magazine magazine = MagazineList.GetMagazineList(_itemSetter).GetList().FirstOrDefault(item => item.Title == EditedMagazine.Title) as Magazine;
            MagazineList.GetMagazineList(_itemSetter).GetList().Remove(magazine);
        }
        public void RemoveArticleFromMagazineList()
        {
            Magazine magazine = GetEditedMagazine();
            AuthoredItem article = magazine.Articles.FirstOrDefault(item => item.Title == EditedAuthoredItem.Title);
            magazine.Articles.Remove(article);
        }
        public void AddToMagazineList(PolygraphicItem magazine)
        {
            MagazineList.GetMagazineList(_itemSetter).GetList().Add(magazine);
        }
        public void AddToArticlesList(AuthoredItem article)
        {
            ArticlesList.Add(article);
        }
    }
}
