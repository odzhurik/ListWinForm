using BooksWF.Models.SaveInstance;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BooksWF.Models.OutputList
{
    internal class MagazineListOutput :IOutputXml,IWinFormOutput
    {

        public string Output()
        {
            WinFormOutputItem output = new WinFormOutputItem();
            return output.ListOutput(MagazineList.GetMagazineList().GenerateList()).ToString();
        }
        public void SaveInXml()
        {
            List<PolygraphicItem> list = MagazineList.GetMagazineList().GenerateList();
            XDocument xdoc = new XDocument();
            XElement magazines = new XElement("Magazines");
            foreach (Magazine magazine in list)
            {
                XElement magazineElement = new XElement("Magazine");
                XElement magazineTitle = new XElement("Title", magazine.Title);
                XElement magazineIssue = new XElement("IssueNumber", magazine.IssueNumber);
                magazineElement.Add(magazineTitle);
                magazineElement.Add(magazineIssue);
                magazines.Add(magazineElement);
            }
            xdoc.Add(magazines);
            xdoc.Save("magazines.xml");
        }
    }
}
