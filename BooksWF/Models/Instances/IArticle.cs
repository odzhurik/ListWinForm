using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.Instances
{
  public  interface IArticle
    {
        List<AuthoredItem> Articles { get; set; }
    }
}
