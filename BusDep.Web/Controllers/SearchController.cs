using System.Collections.Generic;

namespace BusDep.Web.Controllers
{
    using BusDep.IBusiness;
    using BusDep.UnityInject;
    using BusDep.ViewModel;
    using System;
    using System.Web.Mvc;
    
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
        

        public JsonResult SearchPost(BuscarJugadorViewModel buscar)
        {
            //BuscarJugadorViewModel buscar = new BuscarJugadorViewModel { Nombre = searchValues, Pagina = pagina, Cantidad = cantidad};
            try
            {
                Response.StatusCode = 200;
                return new JsonResult { Data = this.Buscar(buscar), JsonRequestBehavior = JsonRequestBehavior.AllowGet };

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

            try
            {
                Response.StatusCode = 200;
                return new JsonResult { Data = this.Buscar(searchValues), JsonRequestBehavior = JsonRequestBehavior.AllowGet };

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

        private List<JugadorViewModel> Buscar(BuscarJugadorViewModel buscar)
        {
            var busqueda = DependencyFactory.Resolve<IBusquedaBusiness>();
            var userView = busqueda.BuscarJugador(buscar);
            userView.ForEach(o => o.Link =
#if DEBUG
                "http://localhost:52771/#!/ProfilePublic/JugadorPublic/" + o.Id.ToString()
#else
            "http://allwiners.com/#!/ProfilePublic/JugadorPublic/"+ o.Id.ToString()
            
#endif
                
            );
            var id = this.GetAuthData().Id;
            userView.ForEach(o => o.Recomendar = (o.UsuarioId != id));
            return userView;
        }
        #endregion

    }
}
