using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Presenter.Interfaces
{
  public interface IEditNewspaperPresenter
    {
        void ShowEditView();
        void ShowDeleteView();
        void RemoveNewspaper();
        void LoadNewspapersList();
    }
}
