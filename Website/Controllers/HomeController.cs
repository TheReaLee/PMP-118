using Provider.Common;
using Provider.Core;
using Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private async Task<IFeatureProvider> _getProvider()
        {
            string providerName = "";
            providerName = ConfigurationManager.AppSettings["Provider"];
            return await ProviderFactory.GetProvider(providerName);
        }
        private User _getTestUser()
        {
            User user = new User();
            user.Email = "test@joescoffeecompany.com";
            user.FirstName = "Joe";
            user.Surname = "Borg";
            user.Company = new Company();
            user.Company.Code = "00002";
            user.Company.Name = "Joe's Coffee Company";
            user.Company.Tenant = new Tenant();
            user.Company.Tenant.Name = "Joe";
            user.Company.Tenant.Code = "00001";
            return user;
        }

        public ActionResult Index()
        {
            IFeatureProvider featureProvider = Task.Run(() =>
            {
                return this._getProvider();
            }).ConfigureAwait(false).GetAwaiter().GetResult();


            if (featureProvider.IsFeatureEnabled("Costings", _getTestUser()))
            {
                ViewBag.Costings = true;
            }
            else
            {
                ViewBag.Costings = false;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}