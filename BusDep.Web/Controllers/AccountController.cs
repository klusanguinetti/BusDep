using BusDep.IBusiness;
using BusDep.UnityInject;
using BusDep.ViewModel;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Security;

namespace BusDep.Web.Controllers
{
    public class AccountController : Controller
    {

        #region Get functions 

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        #endregion


        #region Post Functions

        [HttpPost]
        public ActionResult LoginPost(UsuarioViewModel loginModel)
        {

            ILoginBusiness login = DependencyFactory.Resolve<ILoginBusiness>();

            var user = login.LoginUser(loginModel.Mail, loginModel.Password);

            if (user != null)
            {

                FormsAuthentication.SetAuthCookie(user.Mail + "|" + user.Id, true);

                Response.StatusCode = 200;

                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            else
            {
                Response.StatusCode = 404;
                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

        public JsonResult RegisterPost(UsuarioViewModel userModel)
        {
            var registracion = DependencyFactory.Resolve<IUsuarioBusiness>();

            try
            {

                var userView = registracion.Registracion(userModel);

                Response.StatusCode = 200;
                return new JsonResult { Data = userView, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            catch (Exception)
            {

                Response.StatusCode = 500;
                return new JsonResult { Data = "", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

        public JsonResult SignOut()
        {
            try
            {
                Response.StatusCode = 201;
                FormsAuthentication.SignOut();
                return new JsonResult { Data = "", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error del servidor: " + ex.Message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

        #endregion

    }
}
