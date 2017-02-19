using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.Instances
{
   public interface IAuthoredItem
    {
        List<string> Authors { get; set; }
    }
}
