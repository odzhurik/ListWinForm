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
        public string SearchResultsOutput(string enteredAuthor, List<PolygraphicItem> list)
        {
                                               
            SearchByAuthor search = new SearchByAuthor(list);
            StringOutputItem resultOutput = new StringOutputItem();
            List<PolygraphicItem> resultList = search.Search(enteredAuthor);
            return resultOutput.ListOutput(resultList).ToString();
        }
    }
}
