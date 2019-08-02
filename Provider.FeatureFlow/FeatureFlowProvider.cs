using Featureflow.Client;
using Provider.Common;
using Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = Security.User;

namespace Provider.FeatureFlow
{
    public class FeatureFlowProvider : IFeatureProvider
    {
        private IFeatureflowClient _featureFlowClient = null;
        public string ApiKey
        {
            get
            {
                return "sdk-srv-env-834fc55402384422a6ab57bc069674b8";
            }
        }

        public async Task Initialize()
        {
            _featureFlowClient = await FeatureflowClientFactory.CreateAsync(ApiKey);
            
        }

        public bool IsFeatureEnabled(string feature, User user)
        {
            return _featureFlowClient.Evaluate("costings").Is("on");            
        }
    }
}
