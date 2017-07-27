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
        [HttpGet]
        public JsonResult SearchPost(string searchValues, int pagina, int cantidad)
        {
            BuscarJugadorViewModel buscar = new BuscarJugadorViewModel { Nombre = searchValues, Pagina = pagina, Cantidad = cantidad};
            var busqueda = DependencyFactory.Resolve<IBusquedaBusiness>();
            try
            {
                var userView = busqueda.BuscarJugador(buscar);

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

        [HttpGet]
        public JsonResult SearchPostCount(string searchValues)
        {
            BuscarJugadorViewModel buscar = new BuscarJugadorViewModel { Nombre = searchValues };
            var busqueda = DependencyFactory.Resolve<IBusquedaBusiness>();
            try
            {
                var userView = busqueda.BuscarJugadorCount(buscar);

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

        [HttpGet]
        public JsonResult GetBuscarJugadorViewModel()
        {
            Response.StatusCode = 200;
            return new JsonResult {Data = new BuscarJugadorViewModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        public JsonResult SearchFiltersPostNew(BuscarJugadorViewModel searchValues)
        {

            var busqueda = DependencyFactory.Resolve<IBusquedaBusiness>();

            try
            {
                var userView = busqueda.BuscarJugador(searchValues);

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

                return new JsonResult { Data = "Error del servidor: " + ex.Message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }
        
        #endregion

    }
}
