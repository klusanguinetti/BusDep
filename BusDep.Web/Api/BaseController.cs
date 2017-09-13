

namespace BusDep.Web.Controllers.Api
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Web.Http;
    using BusDep.Common;
    using BusDep.IBusiness;
    using BusDep.UnityInject;
    using BusDep.ViewModel;
    using BusDep.Web.Class;
    

    public class BaseController : ApiController
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
        [HttpPost]
        public PerfilJugadorShortViewModel GetPerfilJugadorShort()
        {
            var perfil = GetAuthData();
            try
            {
                if (perfil.JugadorId.HasValue)
                {
                    IBusquedaBusiness business = DependencyFactory.Resolve<IBusquedaBusiness>();
                    return business.GetPerfilJugadorShort(perfil);
                }
                else if (perfil.EntrenadorId.HasValue)
                {
                    //TODO
                    return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error de servidor");
            }
        }
        [HttpPost]
        public List<JugadorViewModel> TopJugador()
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
                return result;
            }
            catch (Exception)
            {
                throw new Exception("Error de servidor");
            }
        }
        [HttpPost]
        public List<MenuViewModel> GetMenu()
        {
            var perfil = GetAuthData();
            try
            {
                if (perfil != null)
                {

                    return perfil.MenuUsuario;
                }
                else
                {                    
                    return  null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}