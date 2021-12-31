using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;

namespace DXApplication1.View
{
    public interface IView
    {
        DataTable PhoneBook { get; set; }

        void ChangeContact();

        void AddContact();

        void DeleteContact();

        Presenter.PhoneBookPresenter Presenter { set; }
    }
}
