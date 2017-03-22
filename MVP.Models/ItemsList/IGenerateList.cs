using MVP.Entities;
using MVP.Models.ItemSetter;
using System.Collections.Generic;

namespace MVP.Models.ItemsList
{
    public interface IGenerateList
    {
        void SetList(ISetItem itemSetter);
        List<PolygraphicItem> GetList();
        List<PolygraphicItem> ReadFromFile(string path);
        
    }
}
