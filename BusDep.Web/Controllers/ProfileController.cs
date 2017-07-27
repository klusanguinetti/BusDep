using BusDep.IBusiness;
using BusDep.UnityInject;
using BusDep.ViewModel;
using BusDep.Web.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BusDep.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {

        private AuthHelper authHelper = new AuthHelper();

        #region Get functions 

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PrivateProfile()
        {
            return View();
        }
        public ActionResult PrivateJugardor()
        {
            return View();
        }
        public ActionResult SportsHistory()
        {
            return View();
        }
        

        #endregion

        #region Post Functions

        public JsonResult Save(DatosPersonaViewModel datosPersonaModel)
        {

            IUsuarioBusiness usuario = DependencyFactory.Resolve<IUsuarioBusiness>();

            try
            {

                usuario.RegistracionDatosPersonales(datosPersonaModel);

                Response.StatusCode = 200;
                return new JsonResult { Data = "", JsonRequestBehavior = JsonRequestBehavior.AllowGet };


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

        public JsonResult GetDatosPersona()
        {

            var usuario = DependencyFactory.Resolve<IUsuarioBusiness>();

            UsuarioViewModel LoggedUser = new UsuarioViewModel();
            try
            {

                var user = usuario.ObtenerDatosPersonales(authHelper.GetAuthData());

                Response.StatusCode = 200;

                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }
        [HttpGet]
        public JsonResult GetJugador()
        {
            var business = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();
            try
            {
                var user = business.ObtenerJugador(authHelper.GetAuthData());
                Response.StatusCode = 200;
                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpGet]
        public JsonResult GetFichajes()
        {
            var business = DependencyFactory.Resolve<ICommonBusiness>();
            try
            {
                var user = business.ObtenerComboFichajes();
                Response.StatusCode = 200;
                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        [HttpGet]
        public JsonResult GetPerfiles()
        {
            var business = DependencyFactory.Resolve<ICommonBusiness>();
            try
            {
                var user = business.ObtenerComboPerfiles();
                Response.StatusCode = 200;
                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        [HttpGet]
        public JsonResult GetPies()
        {
            var business = DependencyFactory.Resolve<ICommonBusiness>();
            try
            {
                var user = business.ObtenerComboPie();
                Response.StatusCode = 200;
                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        [HttpGet]
        public JsonResult GetPuestos()
        {
            var business = DependencyFactory.Resolve<ICommonBusiness>();
            try
            {
                
                var user = business.ObtenerComboPuestosEspecifico(authHelper.GetAuthData().DeporteId.GetValueOrDefault());
                Response.StatusCode = 200;
                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public JsonResult SaveJugador(JugadorViewModel jugadorViewModel)
        {
            var business = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();
            try
            {
                business.ActualizarDatosJugador(jugadorViewModel);
                Response.StatusCode = 200;
                return new JsonResult { Data = "OK", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpGet]
        public JsonResult GetPuestosBasicos()
        {
            var business = DependencyFactory.Resolve<ICommonBusiness>();
            try
            {

                var user = business.ObtenerComboPuestosEspecifico(authHelper.GetAuthData().DeporteId.GetValueOrDefault());
                //IEnumerable<ComboViewModel>
                var user1 = user.Select(o => o.Agrupador).Distinct().Select(i => new ComboViewModel {Descripcion = i, Id = i});

                Response.StatusCode = 200;
                return new JsonResult { Data = user1, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
