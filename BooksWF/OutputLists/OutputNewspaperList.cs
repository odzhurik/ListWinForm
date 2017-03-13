using BooksWF.Models.Instances;
using BooksWF.Models.OutputInstance;
using BooksWF.Models.OutputList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.OutputList
{
    internal class OutputNewspaperList
    {
        public string Output(List<PolygraphicItem>list)
        {
            StringOutputItem output = new StringOutputItem();
            return output.ListOutput(list).ToString();
        }

    }
}
