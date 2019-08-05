using Provider.Common;
using Provider.FeatureFlow;
using Provider.LaunchDarkly;
using Provider.Optimizely;
using Provider.Rollout;
using Provider.Split;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.Core
{
    public static class ProviderFactory
    {
        internal enum Provider
        {
            None,
            split,
            launchdarkly,
            featureflow,
            rollout,
            optimizely
        }

        public static async Task<IFeatureProvider> GetProvider(string providerName)
        {
            IFeatureProvider provider = null;
            Provider providerEnum = Provider.None;
            if (Enum.TryParse<Provider>(providerName.ToLower(), out providerEnum))
            {
                switch(providerEnum)
                {
                    case Provider.split:
                        provider = new SplitProvider();
                        break;
                    case Provider.rollout:
                        provider = new RolloutProvider();
                        break;
                    case Provider.featureflow:
                        provider = new FeatureFlowProvider();
                        break;
                    case Provider.optimizely:
                        provider = new OptimizelyProvider();
                        break;
                    case Provider.launchdarkly:
                        provider = new LaunchDarklyProvider();
                        break;
                }
            }
            else
            {
                throw new Exception($"[{providerName}] is not a valid provider. Kindly select one of the available Providers: [{Enum.GetValues(typeof(Provider))}]");
            }
            await provider.Initialize();
            return provider;
        }
    }
}
