using MVP.Entities;
using MVP.Presenters.OutputInstance;
using System.Collections.Generic;

namespace MVP.Presenters.OutputList
{
    internal class MagazineListOutput
    {
        public string Output(List<Magazine> list)
        {
            MagazineStringOutput output = new MagazineStringOutput();
             return output.ListOutput(list).ToString();
        }
        public string XmlOutput(List<Magazine> list)
        {
             XmlSave xmlOutput = new XmlSave();
            return xmlOutput.SaveInXml(list);
        }
    }
}
