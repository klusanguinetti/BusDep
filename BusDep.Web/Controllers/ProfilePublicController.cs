using System;
using System.Web.Mvc;
using BusDep.IBusiness;
using BusDep.UnityInject;

namespace BusDep.Web.Controllers
{
    public class ProfilePublicController : BaseController
    {

        #region Get functions 

        //[AllowAnonymous]
        public ActionResult JugadorPublic()
        {
            return View();
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
        
        #endregion

    }
}