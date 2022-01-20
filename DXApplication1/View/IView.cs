using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Windows.Forms;

namespace DXApplication1.View
{
    public interface IView
    {
        BindingSource bindingSource { get; set; }
        CheckedListBox checkedListBox { get; set; }

        void ChangeContact();

        void AddContact();

        void DeleteContact();

        Presenter.PhoneBookPresenter Presenter { set; }
    }
}
