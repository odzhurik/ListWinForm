using MVP.Entities;
using MVP.Presenters.OutputInstance;
using System.Collections.Generic;

namespace MVP.Presenters.OutputList
{
    internal class MagazineListOutput
    {
        public string Output(List<PolygraphicItem> list)
        {
            StringOutputItem output = new StringOutputItem();
             return output.ListOutput(list).ToString();
        }
        public string XmlOutput(List<PolygraphicItem> list)
        {
             XmlSave xmlOutput = new XmlSave();
            return xmlOutput.SaveInXml(list);
        }
    }
}
