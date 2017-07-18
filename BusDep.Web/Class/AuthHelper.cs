using BusDep.ViewModel;
using System;
using System.Web.Security;

namespace BusDep.Web.Class
{
    public class AuthHelper
    {

        private UsuarioViewModel LoggedUser = new UsuarioViewModel();

        public AuthHelper() { }

        public UsuarioViewModel GetAuthData()
        {

            FormsIdentity id = (FormsIdentity)System.Web.HttpContext.Current.User.Identity;

            if (id.IsAuthenticated)
            {

                string[] substrings = id.Name.Split('|');

                LoggedUser.Id = long.Parse(substrings[1]);

                LoggedUser.DatosPersonaId = long.Parse(substrings[1]);

                LoggedUser.Mail = substrings[0].ToString();

                return LoggedUser;

            }
            else
            {
                return LoggedUser;
            }

        }

    }
}