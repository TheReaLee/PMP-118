using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    public class User
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }        
        public Company Company { get; set; }

        public Dictionary<string, object> GetAttributes()
        {
            Dictionary<string, object> userAttributes = new Dictionary<string, object>();
            userAttributes.Add(nameof(FirstName), FirstName);
            userAttributes.Add(nameof(Surname), Surname);
            userAttributes.Add(nameof(Email), Email);
            userAttributes.Add("CompanyName", Company.Name);
            userAttributes.Add("CompanyCode", Company.Code);
            userAttributes.Add("Tenant", Company.Tenant.Name);
            userAttributes.Add("TenantCode", Company.Tenant.Code);            
            return userAttributes;
        }
    }
}
