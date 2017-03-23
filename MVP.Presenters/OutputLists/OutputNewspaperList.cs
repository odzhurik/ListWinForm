using MVP.Entities;
using MVP.Presenters.OutputInstance;
using System.Collections.Generic;

namespace MVP.Presenters.OutputList
{
    public class OutputNewspaperList
    {
        public string Output(List<PolygraphicItem>list)
        {
            StringOutputItem output = new StringOutputItem();
            return output.ListOutput(list).ToString();
        }
    }
}
