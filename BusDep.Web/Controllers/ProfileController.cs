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
    public class ProfileController : BaseController
    {

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
        public ActionResult PrivateProfileEntrenador()
        {
            return View();
        }

        public ActionResult SportDataProfile()
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
                var authInfo = GetAuthData();
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
            try
            {

                var user = usuario.ObtenerDatosPersonales(GetAuthData());
                user.UltimoLogin = GetAuthData().UltimoLogin;
                Response.StatusCode = 200;

                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

        public JsonResult GetJugador()
        {
            var business = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();
            try
            {
                var user = business.ObtenerJugador(GetAuthData());
                Response.StatusCode = 200;
                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public JsonResult GetPuestos()
        {
            try
            {
                var user =
                    DependencyFactory.Resolve<ICommonBusiness>()
                        .ObtenerComboPuestosEspecifico(GetAuthData().DeporteId.GetValueOrDefault());

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

        #endregion

        #region HttpGet

        [HttpGet]
        public JsonResult GetPublicProfile([System.Web.Http.FromUri] int jugadorId)
        {

            var business = DependencyFactory.Resolve<IBusquedaBusiness>();

            try
            {
                var user = business.ObtenerPerfil(jugadorId);

                Response.StatusCode = 200;
                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            catch (ExceptionBusiness ex)
            {
                Response.StatusCode = 404;
                return new JsonResult { Data = "Perfil no encontrado: " + ex.Message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor: " + ex.Message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        [HttpGet]
        public JsonResult GetAutoEvaluacionDefault([System.Web.Http.FromUri] int jugadorId)
        {

            var business = DependencyFactory.Resolve<IBusquedaBusiness>();

            try
            {
                var user = business.GetAutoEvaluacionDefault(jugadorId);

                Response.StatusCode = 200;
                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            catch (ExceptionBusiness ex)
            {
                Response.StatusCode = 404;
                return new JsonResult { Data = "Perfil no encontrado: " + ex.Message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor: " + ex.Message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }
        [HttpGet]
        public JsonResult GetAntecedentes([System.Web.Http.FromUri] int jugadorId)
        {

            var business = DependencyFactory.Resolve<IBusquedaBusiness>();

            try
            {
                var user = business.GetAntecedentes(jugadorId);

                Response.StatusCode = 200;
                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            catch (ExceptionBusiness ex)
            {
                Response.StatusCode = 404;
                return new JsonResult { Data = "Perfil no encontrado: " + ex.Message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor: " + ex.Message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

        [HttpGet]
        public JsonResult GetRecomendaciones([System.Web.Http.FromUri] int jugadorId)
        {

            var business = DependencyFactory.Resolve<IBusquedaBusiness>();

            try
            {
                var user = business.GetRecomendaciones(jugadorId);

                Response.StatusCode = 200;
                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            catch (ExceptionBusiness ex)
            {
                Response.StatusCode = 404;
                return new JsonResult { Data = "Perfil no encontrado: " + ex.Message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor: " + ex.Message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

        [HttpGet]
        public JsonResult GetFichajes()
        {
            try
            {
                var user = CacheHelper.ObtenerComboFichajes();
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
            try
            {
                var user = CacheHelper.ObtenerComboPerfiles();
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
            try
            {
                var user = CacheHelper.ObtenerComboPie();
                Response.StatusCode = 200;
                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        public static IEnumerable<ComboViewModel> PuestosBasicos(long deporteId)
        {


            return DependencyFactory.Resolve<ICommonBusiness>().ObtenerPuestos(deporteId)
                .Where(o => o.DeporteId.Equals(deporteId)).Select(u => u.Descripcion).Distinct()
                    .Select(item => new ComboViewModel
                    {
                        Id = item,
                        Descripcion = item
                    });
        }
        public JsonResult GetPuestosBasicos()
        {
            try
            {
                var user1 = DependencyFactory.Resolve<ICommonBusiness>().ObtenerPuestos(GetAuthData().DeporteId.GetValueOrDefault())
                    .Select(u => u.Descripcion).Distinct()
                    .Select(item => new ComboViewModel
                    {
                        Id = item,
                        Descripcion = item
                    });
                Response.StatusCode = 200;
                return new JsonResult { Data = user1, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        [HttpGet]
        public JsonResult GetPeso()
        {
            try
            {
                Response.StatusCode = 200;
                return new JsonResult { Data = CacheHelper.ObtenerComboPeso(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult
                {
                    Data = "Error de servidor",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }
        [HttpGet]
        public JsonResult GetAltura()
        {
            try
            {
                Response.StatusCode = 200;
                return new JsonResult { Data = CacheHelper.ObtenerComboAltura(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult
                {
                    Data = "Error de servidor",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }
        #endregion

    }
}
