using OptimizelySDK.Entity;
using Provider.Common;
using Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.Optimizely
{
    public class OptimizelyProvider : IFeatureProvider
    {
        private string _cdnPath = "https://cdn.optimizely.com/datafiles/{0}.json";
        private OptimizelySDK.Optimizely _optimizelyClient = null;
        public string ApiKey
        {
            get
            {
                return "XiAi68Ci7BAkHqbig7LgEm";
            }
        }

        public async Task Initialize()
        {
            string datafile = string.Empty;
            var url = string.Format(_cdnPath, ApiKey);
            using (var webClient = new System.Net.WebClient())
            {

                // To refresh on every request
                webClient.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                datafile = webClient.DownloadString(url);
            }

            _optimizelyClient = new OptimizelySDK.Optimizely(datafile);
            await Task.FromResult(0);
        }

        public bool IsFeatureEnabled(string feature, User user)
        {
            UserAttributes userAtrributes = new UserAttributes();
            foreach(KeyValuePair<string, object> keyValuePair in user.GetAttributes())
            {
                userAtrributes.Add(keyValuePair.Key, keyValuePair.Value);
            }
            return _optimizelyClient.IsFeatureEnabled(feature.ToLower(), user.Email, userAtrributes);            
        }
    }
}
