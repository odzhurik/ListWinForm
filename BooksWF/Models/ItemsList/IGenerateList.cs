using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.OutputList
{
    public interface IGenerateList
    {
        List<PolygraphicItem> GenerateList();
        List<PolygraphicItem> ReadFromFile(string path);
    }
}
