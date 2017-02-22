using BooksWF.Models;
using BooksWF.Models.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProject.Models
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
