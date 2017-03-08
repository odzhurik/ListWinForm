using BooksWF.Models.ItemsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.OutputList
{
    public interface IGenerateList
    {
        void SetList(ISetItem itemSetter);
        List<PolygraphicItem> GetList();
        List<PolygraphicItem> ReadFromFile(string path);
        
    }
}
