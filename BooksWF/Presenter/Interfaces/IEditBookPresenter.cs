using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Presenter.Interfaces
{
   public interface IEditBookPresenter
    {
        void LoadBooks();
        void ShowEditView();
        void ShowDeleteView();

    }
}
