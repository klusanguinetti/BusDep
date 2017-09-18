

namespace BusDep.Web.BackOffice.Controllers
{
    using BusDep.ViewModel;
    using BusDep.Web.BackOffice.Class;
    using System.Web.Mvc;
    public class HomeController : Controller
    {

        private AuthHelper authHelper = new AuthHelper();
        public ActionResult Index()
        {

            var datamodel = new BootStrapperDataModel
            {
                Authenticated = Request.IsAuthenticated ? "true" : "false"
            };

            if (Request.IsAuthenticated)
            {
                datamodel.UserName = authHelper.GetAuthData().Mail;
            }

            return View(datamodel);

        }
        public ActionResult HomeContent()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}