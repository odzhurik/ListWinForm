using BooksWF.Models;
using BooksWF.Models.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProject.Models
{
   internal class Book:PolygraphicItem, IAuthoredItem
    {
        public List <string> Authors { get; set; }
        public Book()
        {
            Authors = new List<string>();
        }
       
    }
}
