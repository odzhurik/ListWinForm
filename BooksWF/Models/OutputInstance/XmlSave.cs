using BooksWF.Models.OutputList;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BooksWF.Models.OutputInstance
{
  public  class XmlSave
    {
        private IGenerateList _magazineList;
        public XmlSave(IGenerateList magazineList)
        {
            _magazineList = magazineList;
        }
        public string SaveInXml()
        {
            List<PolygraphicItem> list = _magazineList.GetList();
            XDocument xdoc = new XDocument();
            XElement magazines = new XElement("Magazines");
            foreach (Magazine magazine in list)
            {
                XElement magazineElement = new XElement("Magazine");
                XElement magazineTitle = new XElement("Title", magazine.Title);
                XElement magazineIssue = new XElement("IssueNumber", magazine.IssueNumber);
                XElement articles = new XElement("Articles");
                foreach (AuthoredItem article in magazine.Articles)
                {
                    XElement articleElement = new XElement("Article");
                    XElement articleTitle = new XElement("Title", article.Title);
                    articleElement.Add(articleTitle);
                    foreach (string author in article.Authors)
                    {
                        XElement articleAuthor = new XElement("Author", author);
                        articleElement.Add(articleAuthor);
                    }
                    XElement articlePage = new XElement("Pages", article.Pages);
                    articleElement.Add(articlePage);
                    articles.Add(articleElement);
                }
                magazineElement.Add(magazineTitle);
                magazineElement.Add(magazineIssue);
                magazineElement.Add(articles);
                magazines.Add(magazineElement);
            }
            xdoc.Add(magazines);
            xdoc.Save("magazines.xml");
            if (XDocument.Load("magazines.xml") != null)
            {
                return "Successfully saved";
            }
            return "Not saved";
        }
    }
}
