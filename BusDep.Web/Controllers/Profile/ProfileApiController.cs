using BusDep.IBusiness;
using BusDep.UnityInject;
using BusDep.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BusDep.Web.Controllers.Profile
{
    [RoutePrefix("api/Profile")]
    public class ProfileApiController : ApiController
    {

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Save")]
        public IHttpActionResult Save(DatosPersonaViewModel datosPersonaModel)
        {

            IUsuarioBusiness usuario = DependencyFactory.Resolve<IUsuarioBusiness>();

            try
            {
                usuario.RegistracionDatosPersonales(datosPersonaModel);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
                throw;
            }

     
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Get")]
        [HttpPost]
        public IHttpActionResult GetDatosPersona(UsuarioViewModel usuarioViewModel)
        {

            var usuario = DependencyFactory.Resolve<IUsuarioBusiness>();

            try
            {
                var user = usuario.ObtenerDatosPersonales(usuarioViewModel);
                return Ok(user);
            }
            catch (Exception)
            {
                return InternalServerError();
                throw;
            }

        }

    }
}
