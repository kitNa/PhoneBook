using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.ComponentModel;

namespace DXApplication1.Model
{
    public interface IRepository
    {
        BindingList<Contact> contacts { get; set; }

        BindingList<Contact> GetAllContacts();

        void RewriteXML();
    }
}

