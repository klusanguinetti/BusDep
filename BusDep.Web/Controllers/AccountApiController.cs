using BusDep.Business;
using BusDep.IBusiness;
using BusDep.UnityInject;
using BusDep.ViewModel;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BusDep.Web.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountApiController : ApiController
    {

        private ILoginBusiness login => DependencyFactory.Resolve<ILoginBusiness>();

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public IHttpActionResult Register(UsuarioViewModel userModel)
        {
            var registracion = DependencyFactory.Resolve<IUsuarioBusiness>();

            var userView = registracion.Registracion(userModel);

            return Ok();
        }

        // POST api/Account/Login
        [AllowAnonymous]
        [Route("Login")]
        public HttpResponseMessage Login(UsuarioViewModel loginModel)
        {

            var user = this.login.LoginUser(loginModel.Mail, loginModel.Password);

            if (user != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "NotFound");
            }


        }

    }
}
