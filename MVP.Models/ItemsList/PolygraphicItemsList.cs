using MVP.Entities;
using System.Collections.Generic;

namespace MVP.Models.ItemsList
{
    public class PolygraphicItemsList
    {
        private static PolygraphicItemsList _instance;
        private static List<PolygraphicItem> _list;
        protected PolygraphicItemsList()
        {

        }
        public static PolygraphicItemsList GetInstance()
        {
            if (_instance == null)
                _instance = new PolygraphicItemsList();
            return _instance;
        }
        public  void SetPolygraphicItemsList(List<IGenerateList> list)
        {
            _list = new List<PolygraphicItem>();
            foreach (IGenerateList listItem in list)
            {
                _list.AddRange(listItem.GetList());
            }
        }
        public List<PolygraphicItem> GetPolygraphicItemsList()
        {
            return _list;
        }
    }
}
