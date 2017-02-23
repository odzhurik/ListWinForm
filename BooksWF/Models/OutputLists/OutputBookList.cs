using BooksWF.Models;
using BooksWF.Models.OutputInstance;
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
    internal class OutputBookList
    {

        public string Output()
        {
            WinFormOutputAuthoredItem output = new WinFormOutputAuthoredItem();
            SetItem bookSetter = new SetItem();
            return output.ListOutput(BookList.GetBookList(bookSetter).GenerateList()).ToString();
        }

    }
}
