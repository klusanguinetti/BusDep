namespace BusDep.Web.Api
{
    using System;
    using System.Web.Http;
    using System.Web.Security;
    using BusDep.Common;
    using BusDep.IBusiness;
    using BusDep.UnityInject;
    using BusDep.ViewModel;
    using BusDep.Web.Class;
    public class AnalystController : BaseController
    {

        #region Post Functions

        [HttpPost]
        public DatosPersonaViewModel GetDatosPersona()
        {

            var business = DependencyFactory.Resolve<IDatosPersonalesBusiness>();
            try
            {
                var user = business.ObtenerDatosPersonales(GetAuthData());
                user.UltimoLogin = GetAuthData().UltimoLogin;
                return user;

            }
            catch (Exception ex)
            {
                throw new Exception("Error de servidor", ex);
            }

        }
        [HttpPost]
        public void Save(DatosPersonaViewModel datosPersonaModel)
        {
            var business = DependencyFactory.Resolve<IDatosPersonalesBusiness>();
            try
            {
                business.RegistracionDatosPersonales(datosPersonaModel);
            }
            catch (Exception ex)
            {
                throw new Exception("Error de servidor", ex);
            }
        }
        #endregion

    }
}