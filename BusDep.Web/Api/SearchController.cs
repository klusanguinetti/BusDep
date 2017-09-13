using BusDep.Business;
using BusDep.IBusiness;
using BusDep.UnityInject;
using BusDep.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BusDep.Web.Controllers.Api
{
    public class SearchController : BaseController
    {
        #region Post functions 
        [HttpPost]
        public string SaveRecomendar(RecomendacionViewModel recomendacion)
        {

            var save = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();
            try
            {
                recomendacion.EmisorId = GetAuthData().Id;
                save.GuardarRecomendar(recomendacion);
                return "Ok";

            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public List<JugadorViewModel> SearchPost(BuscarJugadorViewModel buscar)
        {
            //BuscarJugadorViewModel buscar = new BuscarJugadorViewModel { Nombre = searchValues, Pagina = pagina, Cantidad = cantidad };
            var busqueda = DependencyFactory.Resolve<IBusquedaBusiness>();
            try
            {
                var userView = busqueda.BuscarJugador(buscar);
                userView.ForEach(o => o.Link =
#if DEBUG
            "http://localhost:52771/#!/ProfilePublic/JugadorPublic/" + o.Id.ToString()
#else
            "http://allwiners.com/#!/ProfilePublic/JugadorPublic/"+ o.Id.ToString()
            
#endif
            );
                return userView;

            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpPost]
        public long SearchPostCount(BuscarJugadorViewModel searchValues)
        {
            //BuscarJugadorViewModel buscar = new BuscarJugadorViewModel { Nombre = searchValues };
            var busqueda = DependencyFactory.Resolve<IBusquedaBusiness>();
            try
            {
                return busqueda.BuscarJugadorCount(searchValues);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet]
        public BuscarJugadorViewModel GetBuscarJugadorViewModel()
        {
            
            return new BuscarJugadorViewModel();
        }

        [HttpPost]
        public long SearchFiltersPostNewCount(BuscarJugadorViewModel buscar)
        {
            var busqueda = DependencyFactory.Resolve<IBusquedaBusiness>();
            try
            {
                return busqueda.BuscarJugadorCount(buscar);
            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpPost]
        public List<JugadorViewModel> SearchFiltersPostNew(BuscarJugadorViewModel searchValues)
        {

            var busqueda = DependencyFactory.Resolve<IBusquedaBusiness>();

            try
            {
                var userView = busqueda.BuscarJugador(searchValues);
                userView.ForEach(o => o.Link =
#if DEBUG
            "http://localhost:52771/#!/ProfilePublic/JugadorPublic/" + o.Id.ToString()
#else
            "http://allwiners.com/#!/ProfilePublic/JugadorPublic/"+ o.Id.ToString()
            
#endif
            );
                return userView;

            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion

    }
}
