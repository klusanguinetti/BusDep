using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BusDep.IBusiness;
using BusDep.UnityInject;
using BusDep.ViewModel;

namespace BusDep.Web.Controllers
{
    public class CoachController : BaseController
    {
        #region Get functions 
        public ActionResult PrivateProfileEntrenador()
        {
            return View();
        }
        public ActionResult SportsHistory()
        {
            return View();
        }

        public ActionResult Antecedente()
        {
            return View();
        }
        public ActionResult SelfAppraisal()
        {
            return View();
        }
        #endregion

        #region metodos
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
        #endregion
    }
}
