using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models
{
  abstract internal class OutputItem
    {
        public abstract StringBuilder ListOutput(List<PolygraphicItem> items);
       
    }
}
