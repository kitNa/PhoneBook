using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1.Model
{
    public class Contact
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public override bool Equals(object obj)
        {
            Contact other = obj as Contact;
            return Equals(other);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode()
                ^ Phone.GetHashCode();
        }

        public bool Equals(Contact other)
        {
            if (other == null)
                return false;

            return this.Name == other.Name
                && this.Phone == other.Phone;
        }
    }
}
