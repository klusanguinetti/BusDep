namespace BusDep.Business
{
    using Common;
    using ViewModel;
    using Entity;
    using IBusiness;
    using IDataAccess;
    using UnityInject;
    public class LoginBusiness : ILoginBusiness
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
            {
                var userView = user.MapperClass<UserViewModel>(TypeMapper.IgnoreCaseSensitive);
                userView.TipoUsuario = user.TipoUsuario.Descripcion;
                return userView;
            }
            else
            {
                return null;
            }
        }
    }

    
}
