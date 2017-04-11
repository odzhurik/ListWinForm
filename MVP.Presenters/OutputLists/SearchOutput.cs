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
            string result = "";
            SearchByAuthor search = new SearchByAuthor();
            
            List<PolygraphicItem> resultList = search.Search(enteredAuthor,list);
            if(resultList.Count==0)
            {
                return "No items!";
            }
            List<Book> books = new List<Book>();
            List<Magazine> magazines = new List<Magazine>();
            List<Newspaper> newspapers = new List<Newspaper>();
                        resultList.ForEach(x =>
            {
                if(x is Book)
                {
                    books.Add(x as Book);                    
                }
                if(x is Magazine)
                {
                    magazines.Add(x as Magazine);
                }
                if(x is Newspaper)
                {
                    newspapers.Add(x as Newspaper);
                }
            } 
            );
                       if(books.Count!=0)
            {
                BookStringOutput resultOutput = new BookStringOutput();
                result = resultOutput.ListOutput(books).ToString();
            }
            if(magazines.Count!=0)
            {
                MagazineStringOutput resultOutput = new MagazineStringOutput();
                result += resultOutput.ListOutput(magazines).ToString();
            }
            if(newspapers.Count!=0)
            {
                NewspaperStringOutput resultOutput = new NewspaperStringOutput();
                result += resultOutput.ListOutput(newspapers).ToString();
            }
            return result;
        }
    }
}
