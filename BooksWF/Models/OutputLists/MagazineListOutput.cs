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
        public string Output()
        {
            StringOutputItem output = new StringOutputItem();
            SetItem itemSetter = new SetItem();
            return output.ListOutput(MagazineList.GetMagazineList(itemSetter).GetList()).ToString();
        }
        public string XmlOutput()
        {
            SetItem itemSetter = new SetItem();
            XmlSave xmlOutput = new XmlSave(MagazineList.GetMagazineList(itemSetter));
            return xmlOutput.SaveInXml();
        }
    }
}
