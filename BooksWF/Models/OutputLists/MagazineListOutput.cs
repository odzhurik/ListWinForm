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
            WinFormOutputMagazine output = new WinFormOutputMagazine();
            return output.ListOutput(MagazineList.GetMagazineList().GenerateList()).ToString();
        }
        public string XmlOutput()
        {
            XmlSave xmlOutput = new XmlSave();
            return xmlOutput.SaveInXml();
        }
    }
}
