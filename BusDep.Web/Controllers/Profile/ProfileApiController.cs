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
        [Route("Password/Save")]
        public HttpResponseMessage PasswordSave(UsuarioCambioPasswordViewModel password)
        {

            ILoginBusiness changePassword = DependencyFactory.Resolve<ILoginBusiness>();

            try
            {
                var result = changePassword.ActualizarPassword(password);

                if (result == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "NotFound");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Contraseña cambiada");
                }

            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un grave error");
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
