using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyak3Zh1
{
    class EmailCreateAttribute : Attribute
    {
        public int First { get; set; }
        public int Second { get; set; }
        public char Sep { get; set; }
        public string Domain { get; set; }

        public EmailCreateAttribute(int first, int second, char sep, string domain)
        {
            this.First = first;
            this.Second = second;
            this.Sep = sep;
            this.Domain = domain;
        }
    }
}
