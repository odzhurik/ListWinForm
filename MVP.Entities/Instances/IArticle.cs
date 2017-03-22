using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Entities
{
  public  interface IArticle
    {
        List<AuthoredItem> Articles { get; set; }
    }
}
