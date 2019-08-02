using Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.Common
{
    public interface IFeatureProvider
    {
        string ApiKey { get; }
        Task Initialize();
        bool IsFeatureEnabled(string feature, User user);
    }
}
