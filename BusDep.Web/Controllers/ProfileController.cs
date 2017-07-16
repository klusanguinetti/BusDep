using BusDep.IBusiness;
using BusDep.UnityInject;
using BusDep.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusDep.Web.Controllers
{
    public class ProfileController : Controller
    {

        #region Get functions 

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PrivateProfile()
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
                var result = changePassword.ActualizarPassword(password);

                if (result == null)
                {
                    Response.StatusCode = 404;
                    return new JsonResult { Data = "Objecto no encontrado", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    Response.StatusCode = 200;
                    return new JsonResult { Data = "Contraseña cambiada", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }

            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }

        public JsonResult GetDatosPersona(UsuarioViewModel usuarioViewModel)
        {

            var usuario = DependencyFactory.Resolve<IUsuarioBusiness>();

            try
            {
                var user = usuario.ObtenerDatosPersonales(usuarioViewModel);

                Response.StatusCode = 200;

                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

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
