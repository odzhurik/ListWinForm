using System.Collections.Generic;

namespace MVP.Entities
{
    public class Book:PolygraphicItem
    {
        public List <string> Authors { get; set; }
        public int Pages { get; set; }
        public Book()
        {
            Authors = new List<string>();
        }
       
    }
}
