using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    public class Company
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Tenant Tenant { get; set; }
    }
}
