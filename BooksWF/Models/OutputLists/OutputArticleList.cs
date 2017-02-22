using BooksWF.Models.OutputList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.OutputList
{
   internal class OutputArticleList:IWinFormOutput
    {
        public string Output()
        {
            WinFormOutputItem output = new WinFormOutputItem();
             return output.ListOutput(ArticleList.GetArticleList().GenerateList()).ToString();
        }
    }
}
