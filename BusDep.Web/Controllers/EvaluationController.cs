

namespace BusDep.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using BusDep.IBusiness;
    using BusDep.UnityInject;
    using BusDep.ViewModel;
    using BusDep.Web.Class;
    [Authorize]
    public class EvaluationController : Controller
    {

        private AuthHelper authHelper => new AuthHelper();

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
                DependencyFactory.Resolve<IUsuarioJugadorBusiness>().GuardarEvalucacion(antecedenteViewModel);
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
                var user = DependencyFactory.Resolve<IUsuarioJugadorBusiness>().ObtenerEvaluacionViewModel(authHelper.GetAuthData());
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
        
        #endregion


    }
}
