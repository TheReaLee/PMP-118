using Provider.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Splitio.Services.Client.Classes;
using Splitio.Services.Client.Interfaces;
using Security;

namespace Provider.Split
{
    public class SplitProvider : IFeatureProvider
    {
        public string ApiKey { get { return "kkj5vtu3vten1e220on16dkrj5d4u291nm0p"; } }
        private ISplitClient _splitClient = null;

        public async Task Initialize()
        {
            ConfigurationOptions config = new ConfigurationOptions();
            SplitFactory factory = new SplitFactory(ApiKey, config);
            _splitClient = factory.Client();
            _splitClient.BlockUntilReady(100000);
            await Task.FromResult(0);
        }

        public bool IsFeatureEnabled(string feature, User user)
        {
            var treatment = _splitClient.GetTreatment("123456", feature, user.GetAttributes());
            _splitClient.Destroy();
            if (treatment == "on")
            {
                return true;
            }
            else if (treatment == "off")
            {
                return false;
            }
            else
            {
                throw new Exception("An error occured, make sure that the api key is valid...");
            }
        }
    }
}
