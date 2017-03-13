using BooksWF.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.View
{
   public interface IMainView
    {
        MainPresenter Presenter { set; }
        string OutputText { get; set; }
        string EnteredAuthor { get; set; }
        void ShowForm();
    }
}
