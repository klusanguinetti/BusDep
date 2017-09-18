

namespace BusDep.Web.BackOffice.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web.Security;
    using BusDep.Common;
    using BusDep.IBusiness;
    using BusDep.UnityInject;
    using BusDep.ViewModel;
    using System.Security.Claims;
    using BusDep.Web.BackOffice.Class;

    public class BaseController : Controller
    {
        private UsuarioViewModel loggedUser = new UsuarioViewModel();
        internal UsuarioViewModel GetAuthData()
        {

            var id = (ClaimsIdentity)System.Web.HttpContext.Current.User.Identity;

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
                else if (perfil.EntrenadorId.HasValue)
                {
                    //TODO
                    Response.StatusCode = 200;
                    return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
                result.ForEach(o=> o.Link =
#if DEBUG
            "http://localhost:52771/#!/ProfilePublic/JugadorPublic/"+ o.Id.ToString()
#else
            "http://allwiners.com/#!/ProfilePublic/JugadorPublic/"+ o.Id.ToString()
            
#endif
            );

                Response.StatusCode = 200;
                return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return new JsonResult { Data = "Error de servidor", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public JsonResult GetMenu()
        {
            var perfil = GetAuthData();
            try
            {
                if (perfil != null)
                {

                    Response.StatusCode = 200;
                    return new JsonResult { Data = perfil.MenuUsuario, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    Response.StatusCode = 512;
                    return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (Exception)
            {
                Response.StatusCode = 512;
                return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

    }
}