using BusDep.ViewModel;
using BusDep.Web.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace BusDep.Web.Controllers
{
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

        public ActionResult Terms()
        {

            return View();

        }

        public ActionResult HomeContent()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult Privacy()
        {

            return View();

        }
    }
}