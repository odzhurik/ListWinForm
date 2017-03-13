using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Presenter
{
  public interface IAddMagazinePresenter
    {
        void AddMagazine();
        void ShowView();
        void ShowArticleForm();
        void CloseView();
    }
}
