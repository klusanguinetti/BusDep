
namespace BusDep.Business
{
    using BusDep.IDataAccess;
    using ViewModel;
    using Entity;
    using IBusiness;
    using UnityInject;
    public class Login : ILogin
    {

        public virtual UserViewModel LoginUser(string mail, string password)
        {
            return FillUser(DependencyFactory.Resolve<IUsuarioDA>().LoginUser(mail, password));
        }
        public virtual UserViewModel LoginUser(string mail, string aplicacion, string token)
        {
            return FillUser(DependencyFactory.Resolve<IUsuarioDA>().LoginUser(mail, aplicacion, token));
           
        }

        private UserViewModel FillUser(Usuario user)
        {
            if (user != null)
                return new UserViewModel
                {
                    Id = user.Id,
                    Mail = user.Mail,
                    TipoUsuario = user.TipoUsuario.Descripcion
                };
            else
            {
                return null;
            }
        }
    }

    
}
