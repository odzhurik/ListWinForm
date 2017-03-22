using MVP.Entities;
using System.Collections.Generic;
using System.Text;

namespace MVP.Presenters.OutputInstance
{
    public interface IStringOutputItem
    {
        StringBuilder ListOutput(List<PolygraphicItem> items);
    }
}
