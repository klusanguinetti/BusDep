using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BusDep.Configuration;

namespace BusDep.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {

        #region constructor

        public MvcApplication()
        {
            start = new ConfigAll();
        }
        #endregion
        #region atributo
        private ConfigAll start;
        #endregion

        protected void Application_Start()
        {

            try
            {
                AreaRegistration.RegisterAllAreas();
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
                if (start == null)
                    start = new ConfigAll();
                start.Init();
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public override void Dispose()
        {
            if (start != null)
                start.Dispose();
            base.Dispose();
        }
    }
}
