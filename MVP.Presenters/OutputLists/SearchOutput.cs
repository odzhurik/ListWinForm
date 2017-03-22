using MVP.Entities;
using MVP.Presenters.OutputInstance;
using MVP.Presenters.Search;
using System.Collections.Generic;

namespace MVP.Presenters.OutputList
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
