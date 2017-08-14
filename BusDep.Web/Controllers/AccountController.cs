using BusDep.IBusiness;
using BusDep.UnityInject;
using BusDep.ViewModel;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Security;
using BusDep.Common;
using BusDep.Web.Class;

namespace BusDep.Web.Controllers
{
    public class AccountController : Controller
    {
        private AuthHelper authHelper = new AuthHelper();

        #region Get functions 

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult PasswordChange()
        {
            return View();
        }

        public ActionResult PasswordRecovery()
        {
            return View();
        }
        public ActionResult UpdatePasswordRecovery()
        {
            return View();
        }

        #endregion

        #region Post Functions

        [HttpPost]
        public ActionResult LoginPost(UsuarioViewModel loginModel)
        {
            ILoginBusiness login = DependencyFactory.Resolve<ILoginBusiness>();
            try
            {
                var user = login.LoginUser(loginModel.Mail, loginModel.Password);
                var keyToken = StringCompressor.CompressString(user.SerializarToJson());
                FormsAuthentication.SetAuthCookie(keyToken, true);
                Response.StatusCode = 200;
                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (ExceptionBusiness ex)
            {

                Response.StatusCode = 404;
                return new JsonResult { Data = ex.Message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error del servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
            catch (ExceptionBusiness ex)
            {
                Response.StatusCode = 422; //Unprocessable entity
                return new JsonResult { Data = ex.Message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

        public JsonResult PasswordRecoveryPost(SolicitudRecuperoUsuarioViewModel recuperarUsuario)
        {
            var passwordRecovery = DependencyFactory.Resolve<IUsuarioBusiness>();

            try
            {

                var userView = passwordRecovery.SolicitudRecuperoUsuario(recuperarUsuario);

                MailHelper.RecuperarUsuarioEmail(userView);

                Response.StatusCode = 200;
                return new JsonResult { Data = userView, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            catch (ExceptionBusiness ex)
            {
                Response.StatusCode = 422; //Unprocessable entity
                return new JsonResult { Data = ex.Message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

        public JsonResult UpdatePasswordRecoveryPost(RecuperarUsuarioViewModel recuperarUsuario)
        {
            var passwordRecovery = DependencyFactory.Resolve<IUsuarioBusiness>();

            try
            {

                if(recuperarUsuario.Password != recuperarUsuario.VerificacionPassword)
                {
                    Response.StatusCode = 422;
                    return new JsonResult { Data = "Las contraseñas no coinciden", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }

                var userView = passwordRecovery.RecuperarUsuario(recuperarUsuario);

                Response.StatusCode = 200;
                return new JsonResult { Data = userView, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            catch (ExceptionBusiness ex)
            {
                Response.StatusCode = 422; //Unprocessable entity
                return new JsonResult { Data = ex.Message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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

        public JsonResult GetDatosPersona()
        {

            var usuario = DependencyFactory.Resolve<IUsuarioBusiness>();
            try
            {

                var user = usuario.ObtenerDatosPersonales(authHelper.GetAuthData());
                user.UltimoLogin = authHelper.GetAuthData().UltimoLogin;
                Response.StatusCode = 200;

                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

        public JsonResult PasswordSave(UsuarioCambioPasswordViewModel password)
        {

            ILoginBusiness changePassword = DependencyFactory.Resolve<ILoginBusiness>();

            try
            {

                var authInfo = authHelper.GetAuthData();

                password.Id = authInfo.Id;

                password.Mail = authInfo.Mail;

                var result = changePassword.ActualizarPassword(password);

                Response.StatusCode = 200;

                return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            catch (ExceptionBusiness ex)
            {
                Response.StatusCode = 404;
                return new JsonResult { Data = ex.Message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }

        #endregion

    }
}
