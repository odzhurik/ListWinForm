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
            PolygraphicItemsList.GetInstance().SetPolygraphicItemsList(new List<IGenerateList>
            {
                BookList.GetBookList(itemSetter),MagazineList.GetMagazineList(itemSetter),
                NewspaperList.GetNewspaperList(itemSetter)
                
            });
            SearchByAuthor search = new SearchByAuthor(PolygraphicItemsList.GetInstance().GetPolygraphicItemsList());
            WinFormOutputItem resultOutput = new WinFormOutputItem();
            return resultOutput.ListOutput(search.Search(enteredAuthor)).ToString();
        }
    }
}
