using BooksWF.Models.OutputInstance;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BooksWF.Models.OutputList
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
