using Io.Rollout.Rox.Server;
using Provider.Common;
using Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.Rollout
{
    public class RolloutProvider : IFeatureProvider
    {
        public string ApiKey { get { return "5d42f5e3bcc466413a106297"; } }
        private RoxContainer _roxContainer;
        public async Task Initialize()
        {
            await Rox.Setup(ApiKey);
            _roxContainer = new RoxContainer();
            Rox.Register("Joe", _roxContainer);
            await Rox.Setup(ApiKey);
        }

        public bool IsFeatureEnabled(string feature, User user)
        {
            if (feature.ToLower() == "costings")
            {
                return _roxContainer.Costings.IsEnabled();                
            }
            else
            {
                return false;
            }
        }
    }
}
