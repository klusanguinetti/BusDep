using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Web.UI.WebControls;
using BusDep.IBusiness;
using BusDep.UnityInject;
using BusDep.ViewModel;

namespace BusDep.Web.Controllers.Api
{
    public class CoachController : BaseController
    {
        #region metodos
        [HttpPost]
        public DatosPersonaViewModel GetDatosPersona()
        {

            var usuario = DependencyFactory.Resolve<IUsuarioBusiness>();
            try
            {

                var user = usuario.ObtenerDatosPersonales(GetAuthData());
                user.UltimoLogin = GetAuthData().UltimoLogin;
                return user;

            }
            catch (Exception ex)
            {
                throw new Exception("Error de servidor", ex);
            }

        }
        public void Save(DatosPersonaViewModel datosPersonaModel)
        {
            IUsuarioBusiness usuario = DependencyFactory.Resolve<IUsuarioBusiness>();
            try
            {
                usuario.RegistracionDatosPersonales(datosPersonaModel);
            }
            catch (Exception ex)
            {
                throw new Exception("Error de servidor", ex);
            }
        }
        #endregion
    }
}
