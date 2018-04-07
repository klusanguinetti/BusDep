using System;
using System.Collections.Generic;
using System.Web.Http;
using BusDep.IBusiness;
using BusDep.UnityInject;
using BusDep.ViewModel;

namespace BusDep.Web.Api.BackOffice
{
    public class SearchJugadorController : BaseController
    {


        #region metodos
        [HttpPost]
        public List<JugadorBackOfficeViewModel> GetJugadoresAll()
        {
            IBusquedaBusiness business = DependencyFactory.Resolve<IBusquedaBusiness>();
            try
            {
                return business.SearchJugadorAll();
            }
            catch (ExceptionBusiness)
            {
                throw;

            }
            catch (Exception ex)
            {
                throw new Exception("Error del servidor", ex);
            }


        }

        
        #endregion

    }
}