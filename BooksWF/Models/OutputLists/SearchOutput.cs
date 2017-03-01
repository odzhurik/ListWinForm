using BooksWF.Models.ItemsList;
using BooksWF.Models.OutputList;
using BooksWF.Models.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.OutputLists
{
   public class SearchOutput
    {
        public string SearchResultsOutput(string enteredAuthor)
        {
            SetItem itemSetter = new SetItem();
            List<IGenerateList> listOfPolygraphicItems = new List<IGenerateList>();
            listOfPolygraphicItems.Add(BookList.GetBookList(itemSetter));
            listOfPolygraphicItems.Add(MagazineList.GetMagazineList(itemSetter));
            listOfPolygraphicItems.Add(NewspaperList.GetNewspaperList(itemSetter));
            PolygraphicItemsList.GetInstance().SetPolygraphicItemsList(listOfPolygraphicItems);                                     
            SearchByAuthor search = new SearchByAuthor(PolygraphicItemsList.GetInstance().GetPolygraphicItemsList());
            WinFormOutputItem resultOutput = new WinFormOutputItem();
            List<PolygraphicItem> resultList = search.Search(enteredAuthor);
            return resultOutput.ListOutput(resultList).ToString();
        }
    }
}
