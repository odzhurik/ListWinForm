using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.OutputList
{
   internal abstract class OutputList
    {
        protected List<PolygraphicItem> _list;
        protected abstract List<PolygraphicItem> GenerateList();
        protected abstract void ReadFromFile(string path);
        public  string Output()
        {
           OutputItem output = new OutputItem();
            return output.ListOutput(GenerateList()).ToString();
        }
    }
}
