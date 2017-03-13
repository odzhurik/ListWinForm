using BooksWF.Models;
using BooksWF.Models.ItemsList;
using BooksWF.Models.OutputList;
using System.Collections.Generic;

namespace BooksWF.Model
{
    public class PolygraphicItemModel
    {
        private ISetItem _setter;
        public PolygraphicItemModel()
        {
            _setter = new SetItem();
        }
        public List<PolygraphicItem> GetBookList()
        {
            return BookList.GetBookList(_setter).GetList();
        }
        public List<PolygraphicItem> GetNewspaperList()
        {
            return NewspaperList.GetNewspaperList(_setter).GetList();
        }
        public List<PolygraphicItem> GetMagazineList()
        {
            return MagazineList.GetMagazineList(_setter).GetList();
        }
        public List<PolygraphicItem> GetAllPolygraphicItems()
        {
            List<IGenerateList> listOfPolygraphicItems = new List<IGenerateList>();
            listOfPolygraphicItems.Add(BookList.GetBookList(_setter));
            listOfPolygraphicItems.Add(MagazineList.GetMagazineList(_setter));
            listOfPolygraphicItems.Add(NewspaperList.GetNewspaperList(_setter));
            PolygraphicItemsList.GetInstance().SetPolygraphicItemsList(listOfPolygraphicItems);
            return PolygraphicItemsList.GetInstance().GetPolygraphicItemsList();
        }
    }
}
