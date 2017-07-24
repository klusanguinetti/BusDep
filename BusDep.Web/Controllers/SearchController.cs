using BusDep.Business;
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
    [Authorize]
    public class SearchController : Controller
    {
        #region Get functions 

        public ActionResult Search()
        {
            return View();
        }

        #endregion

        #region Post functions 

        public JsonResult SearchPost(JugadorBusquedaViewModel searchValues)
        {

            var busqueda = DependencyFactory.Resolve<IBusquedaBusiness>();

            try
            {

                var userView = busqueda.BuscarJugador(null,"",null,null,"","", searchValues.Nombre);

                Response.StatusCode = 200;
                return new JsonResult { Data = userView, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            catch (ExceptionBusiness ex)
            {
                Response.StatusCode = 422; //Unprocessable entity
                return new JsonResult { Data = ex.Message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

        #endregion

    }
}
