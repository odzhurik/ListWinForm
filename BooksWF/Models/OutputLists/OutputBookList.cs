using BooksWF.Models;
using BooksWF.Models.OutputList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardProject.Models
{
    internal class OutputBookList:IWinFormOutput
    {

        public string Output()
        {
            WinFormOutputItem output = new WinFormOutputItem();
            return output.ListOutput(BookList.GetBookList().GenerateList()).ToString();
        }

    }
}
