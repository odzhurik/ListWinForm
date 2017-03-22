using MVP.Entities;
using MVP.Presenters.OutputInstance;
using System.Collections.Generic;

namespace MVP.Presenters.OutputList
{
    internal class OutputBookList
    {

        public string Output(List<PolygraphicItem> list)
        {
            StringOutputItem output = new StringOutputItem();
            return output.ListOutput(list).ToString();
        }

    }
}
