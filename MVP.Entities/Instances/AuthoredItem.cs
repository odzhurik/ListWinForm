using System.Collections.Generic;

namespace MVP.Entities
{
    public class AuthoredItem:PolygraphicItem, IAuthoredItem, IPage
    {
        public List <string> Authors { get; set; }
        public int Pages { get; set; }
        public AuthoredItem()
        {
            Authors = new List<string>();
        }
       
    }
}
