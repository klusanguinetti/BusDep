using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BusDep.Web.Controllers
{
    public class AccountController : Controller
    {

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

    }
}
