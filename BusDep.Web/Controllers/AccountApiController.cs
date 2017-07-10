using BusDep.Business;
using BusDep.IBusiness;
using BusDep.UnityInject;
using BusDep.ViewModel;
using System.Net;
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
        public IHttpActionResult Login(UsuarioViewModel loginModel)
        {

            var user = this.login.LoginUser(loginModel.Mail, loginModel.Password);

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();

        }

    }
}
