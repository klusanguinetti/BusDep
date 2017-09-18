using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BusDep.Configuration;

namespace BusDep.Web.BackOffice
{
    public class MvcApplication : System.Web.HttpApplication
    {
        #region constructor

        public MvcApplication()
        {
            this.BeginRequest += MvcApplication_BeginRequest;
        }


        #endregion
        #region eventos
        private void MvcApplication_BeginRequest(object sender, EventArgs e)
        {
            if (ConfigAll.Instance.IsClearContainer)
                ConfigAll.Instance.Init();

        }
        protected void Application_Start()
        {
            try
            {
                ConfigAll.Instance.Init();
                AreaRegistration.RegisterAllAreas();
                System.Web.Http.GlobalConfiguration.Configure(WebApiConfig.Register);//WEB API 1st
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);

            }
            catch (Exception)
            {
                throw;
            }

        }
        public override void Dispose()
        {
            //ConfigAll.Instance.Dispose();
            //base.Dispose();
        }
        #endregion
    }
}
