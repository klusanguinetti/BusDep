namespace BusDep.Business
{
    using ViewModel;
    using IBusiness;
    using IDataAccess;
    using UnityInject;
    using System;
    using System.Text;

    public class LoginBusiness : ILoginBusiness
    {
        [AuditMethod]
        public virtual UsuarioViewModel LoginUser(string mail, string password)
        {
            var user = DependencyFactory.Resolve<IUsuarioDA>().LoginUser(mail, password);
            if (user == null)
                throw new ExceptionBusiness(2, "Usuario/Contraseña no encontrado");
            var userReturn = FillViewModel.FillUsuarioViewModel(user);
            user.UltimoLogin = DateTime.Now;
            DependencyFactory.Resolve<IUsuarioDA>().Save(user);
            userReturn.MenuUsuario = DependencyFactory.Resolve<IUsuarioDA>().ObtenerMenuTipoUsuario(user.TipoUsuario.Id);
            return userReturn;
        }
        [AuditMethod]
        public virtual UsuarioViewModel LoginUser(string mail, string aplicacion, string token)
        {
            var user = DependencyFactory.Resolve<IUsuarioDA>().LoginUser(mail, aplicacion, token);
            if(user==null)
                throw new ExceptionBusiness(2, "Usuario/Contraseña no encontrado");
            var userReturn = FillViewModel.FillUsuarioViewModel(user);
            user.UltimoLogin = DateTime.Now;
            DependencyFactory.Resolve<IUsuarioDA>().Save(user);
            userReturn.MenuUsuario = DependencyFactory.Resolve<IUsuarioDA>().ObtenerMenuTipoUsuario(user.TipoUsuario.Id);
            return userReturn;

        }
        [AuditMethod]
        public virtual UsuarioViewModel ActualizarPassword(UsuarioCambioPasswordViewModel usuarioCambioPassword)
        {
            var usuario = DependencyFactory.Resolve<IUsuarioDA>().LoginUser(usuarioCambioPassword.Mail, usuarioCambioPassword.OldPassword);
            if(usuario==null)
                throw new ExceptionBusiness(3, "Invalido usuario y password");
            byte[] data = Convert.FromBase64String(usuarioCambioPassword.NewPassword);
            string decodedPassword = Encoding.UTF8.GetString(data);
            usuario.Password = decodedPassword;
            var user = DependencyFactory.Resolve<IUsuarioDA>().ActualizarPassword(usuario);
            var userReturn = FillViewModel.FillUsuarioViewModel(user);
            userReturn.MenuUsuario = DependencyFactory.Resolve<IUsuarioDA>().ObtenerMenuTipoUsuario(user.TipoUsuario.Id);
            return userReturn;
        }

        
    }
}
