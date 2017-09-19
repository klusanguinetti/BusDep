namespace BusDep.Web.Controllers.Api
{
    using BusDep.IBusiness;
    using BusDep.UnityInject;
    using BusDep.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    public class SearchCoachController : BaseController
    {
        #region Post functions 
        [HttpPost]
        public List<EntrenadorViewModel> SearchPost(BuscarEntrenadorViewModel buscar)
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
        public long SearchPostCount(BuscarEntrenadorViewModel searchValues)
        {
            var busqueda = DependencyFactory.Resolve<IBusquedaBusiness>();
            try
            {
                return busqueda.BuscarEntrenadorCount(searchValues);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet]
        public BuscarEntrenadorViewModel GetBuscarEntrenadorViewModel()
        {
            
            return new BuscarEntrenadorViewModel();
        }

        [HttpPost]
        public long SearchFiltersPostNewCount(BuscarEntrenadorViewModel buscar)
        {
            var busqueda = DependencyFactory.Resolve<IBusquedaBusiness>();
            try
            {
                return busqueda.BuscarEntrenadorCount(buscar);
            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpPost]
        public List<EntrenadorViewModel> SearchFiltersPostNew(BuscarEntrenadorViewModel searchValues)
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
        private List<EntrenadorViewModel> Buscar(BuscarEntrenadorViewModel buscar)
        {
            var busqueda = DependencyFactory.Resolve<IBusquedaBusiness>();
            var userView = busqueda.BuscarEntrenador(buscar);
            userView.ForEach(o => o.Link =
#if DEBUG
                "http://localhost:52771/#!/ProfilePublic/EntrenadorPublic/" + o.Id.ToString()
#else
            "http://allwiners.com/#!/ProfilePublic/EntrenadorPublic/"+ o.Id.ToString()
            
#endif

            );
            var id = this.GetAuthData().Id;
            userView.ForEach(o => o.Recomendar = (o.UsuarioId != id));
            return userView;
        }
        #endregion


    }
}
