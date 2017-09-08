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
    public class SearchController : BaseController
    {
        #region Get functions 

        public ActionResult Search()
        {
            return View();
        }

        #endregion

        #region Post functions 

        public JsonResult SaveRecomendar(RecomendacionViewModel recomendacion)
        {
            
            var save = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();
            try
            {
                
               // var userView = busqueda.BuscarJugadorCount(buscar);
                recomendacion.EmisorId = GetAuthData().Id;
                save.GuardarRecomendar(recomendacion);
                Response.StatusCode = 200;
                return new JsonResult { Data = "Ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            catch (ExceptionBusiness ex)
            {
                Response.StatusCode = 422; //Unprocessable entity
                return new JsonResult { Data = ex.Message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }
        

        public JsonResult SearchPost(string searchValues, int pagina, int cantidad)
        {
            BuscarJugadorViewModel buscar = new BuscarJugadorViewModel { Nombre = searchValues, Pagina = pagina, Cantidad = cantidad};
            var busqueda = DependencyFactory.Resolve<IBusquedaBusiness>();
            try
            {
                var userView = busqueda.BuscarJugador(buscar);
                userView.ForEach(o => o.Link =
#if DEBUG
            "http://localhost:52771/#!/ProfilePublic/JugadorPublic/" + o.Id.ToString()
#else
            "http://allwiners.azurewebsites.net/#!/ProfilePublic/JugadorPublic/"+ o.Id.ToString()
            
#endif
            );
                Response.StatusCode = 200;
                return new JsonResult { Data = userView, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            catch (ExceptionBusiness ex)
            {
                Response.StatusCode = 422; //Unprocessable entity
                return new JsonResult { Data = ex.Message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch 
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

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
            catch 
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


        public JsonResult SearchFiltersPostNewCount(BuscarJugadorViewModel buscar)
        {
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
            catch 
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

        public JsonResult SearchFiltersPostNew(BuscarJugadorViewModel searchValues)
        {

            var busqueda = DependencyFactory.Resolve<IBusquedaBusiness>();

            try
            {
                var userView = busqueda.BuscarJugador(searchValues);
                userView.ForEach(o => o.Link =
#if DEBUG
            "http://localhost:52771/#!/ProfilePublic/JugadorPublic/" + o.Id.ToString()
#else
            "http://allwiners.azurewebsites.net/#!/ProfilePublic/JugadorPublic/"+ o.Id.ToString()
            
#endif
            );
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
