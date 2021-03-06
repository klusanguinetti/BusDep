﻿

namespace BusDep.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using BusDep.IBusiness;
    using BusDep.UnityInject;
    using BusDep.ViewModel;
    using BusDep.Web.Class;
    [Authorize]
    public class EvaluationController : BaseController
    {

        #region Get functions 

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelfAppraisal()
        {
            return View();
        }


        #endregion

      
        #region Post Functions

        public JsonResult SaveEvaluacion(EvaluacionViewModel antecedenteViewModel)
        {
            try
            {
                DependencyFactory.Resolve<IEvaluacionrBusiness>().GuardarEvalucacion(antecedenteViewModel);
                Response.StatusCode = 200;
                return new JsonResult { Data = "Ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
       
        public JsonResult GetAutoEvaluacion()
        {
            try
            {
                var user = DependencyFactory.Resolve<IEvaluacionrBusiness>().ObtenerEvaluacionViewModel(GetAuthData());
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
        
        #endregion


    }
}
