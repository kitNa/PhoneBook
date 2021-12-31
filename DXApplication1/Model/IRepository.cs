using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;

namespace DXApplication1.Model
{
    public interface IRepository
    {
        DataTable PhoneBook { get; set; }

        DataTable GetAllContacts();

        void ToRewritingXML();
    }
}
