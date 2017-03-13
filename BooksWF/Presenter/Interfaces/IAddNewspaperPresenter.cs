using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Presenter
{
   public interface IAddNewspaperPresenter
    {
        void ShowView();
        void AddNewspaper();
        void ShowArticleForm();
        void CloseView();
    }
}
