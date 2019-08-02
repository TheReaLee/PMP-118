using LaunchDarkly.Client;
using Provider.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.LaunchDarkly
{
    public class LaunchDarklyProvider : IFeatureProvider
    {
        private LdClient _ldClient = null;
        public string ApiKey
        {
            get
            {
                return "sdk-59008116-df9e-4d08-9dd2-afad55bc26d2";
            }
        }

        public async Task Initialize()
        {
            _ldClient = new LdClient(ApiKey);
            await Task.FromResult(0);
        }

        public bool IsFeatureEnabled(string feature, Security.User user)
        {
            User ldUser = new User(user.Email);
            foreach(KeyValuePair<string, object> keyValuePair in user.GetAttributes())
            {
                ldUser.AndCustomAttribute(keyValuePair.Key, keyValuePair.Value.ToString());
            }

            bool value = _ldClient.BoolVariation("costings", ldUser, false);
            _ldClient.Flush();
            return value;
        }
    }
}
