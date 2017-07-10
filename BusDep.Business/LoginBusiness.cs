namespace BusDep.Business
{
    using ViewModel;
    using IBusiness;
    using IDataAccess;
    using UnityInject;
    public class LoginBusiness : ILoginBusiness
    {
        public virtual UsuarioViewModel LoginUser(string mail, string password)
        {
            return FillViewModel.FillUsuarioViewModel(DependencyFactory.Resolve<IUsuarioDA>().LoginUser(mail, password));
        }
        public virtual UsuarioViewModel LoginUser(string mail, string aplicacion, string token)
        {
            return FillViewModel.FillUsuarioViewModel(DependencyFactory.Resolve<IUsuarioDA>().LoginUser(mail, aplicacion, token));

        }
        public virtual UsuarioViewModel ActualizarPassword(UsuarioCambioPasswordViewModel usuarioCambioPassword)
        {
            var usuario = DependencyFactory.Resolve<IUsuarioDA>().LoginUser(usuarioCambioPassword.Mail, usuarioCambioPassword.OldPassword);
            if(usuario==null)
                return null;
            else
            {
                usuario.Password = usuario.Password;
                return FillViewModel.FillUsuarioViewModel(DependencyFactory.Resolve<IUsuarioDA>().ActualizarPassword(usuario));
            }
        }
    }
}
