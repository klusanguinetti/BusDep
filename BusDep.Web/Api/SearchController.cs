namespace BusDep.Web.Api
{
    using BusDep.IBusiness;
    using BusDep.UnityInject;
    using BusDep.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
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
            try
            {
                return this.Buscar(buscar);
            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpPost]
        public long SearchPostCount(BuscarJugadorViewModel searchValues)
        {
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
            try
            {
              return  this.Buscar(searchValues);
            }
            catch (Exception)
            {
                throw;
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
