

namespace BusDep.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web.Security;
    using BusDep.Common;
    using BusDep.IBusiness;
    using BusDep.UnityInject;
    using BusDep.ViewModel;
    using BusDep.Web.Class;
    public class BaseController : Controller
    {
        private UsuarioViewModel loggedUser = new UsuarioViewModel();
        internal UsuarioViewModel GetAuthData()
        {

            FormsIdentity id = (FormsIdentity)System.Web.HttpContext.Current.User.Identity;

            if (id.IsAuthenticated)
            {
                try
                {
                    var user = StringCompressor.DecompressString(id.Name);
                    loggedUser = user.DeserializarToJson<UsuarioViewModel>();
                    if (loggedUser != null && loggedUser.Id != 0)
                    {
                        return loggedUser;
                    }
                }
                catch { }


                string[] substrings = id.Name.Split('|');

                loggedUser.Id = long.Parse(substrings[1]);

                loggedUser.DatosPersonaId = long.Parse(substrings[1]);

                loggedUser.Mail = substrings[0].ToString();

                return loggedUser;

            }
            else
            {
                return loggedUser;
            }

        }

        public JsonResult GetPerfilJugadorShort()
        {
            var perfil = GetAuthData();
            try
            {
                if (perfil.JugadorId.HasValue)
                {
                    IBusquedaBusiness business = DependencyFactory.Resolve<IBusquedaBusiness>();
                    var result = business.GetPerfilJugadorShort(perfil);
                    Response.StatusCode = 200;
                    return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    Response.StatusCode = 404;
                    return new JsonResult { Data = "Perfil no encontrado", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public JsonResult TopJugador()
        {

            try
            {
                IBusquedaBusiness business = DependencyFactory.Resolve<IBusquedaBusiness>();
                var result = business.TopJugador();
                Response.StatusCode = 200;
                return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
    }
}