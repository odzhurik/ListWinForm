using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Entities
{
   public interface IAuthoredItem
    {
        List<string> Authors { get; set; }
    }
}
