namespace BusDep.Web.Controllers.Api
{
    using System;
    using System.Web.Http;
    using System.Web.Security;
    using BusDep.Common;
    using BusDep.Web.Class;
    using BusDep.IBusiness;
    using BusDep.UnityInject;
    using BusDep.ViewModel;
    public class AccountController : BaseController
    {

        #region Post Functions

        [HttpPost]
        public UsuarioViewModel LoginPost(UsuarioViewModel loginModel)
        {
            ILoginBusiness login = DependencyFactory.Resolve<ILoginBusiness>();
            try
            {
                var user = login.LoginUser(loginModel.Mail, loginModel.Password);
                var keyToken = StringCompressor.CompressString(user.SerializarToJson());
                FormsAuthentication.SetAuthCookie(keyToken, true);
                return user;
            }
            catch (ExceptionBusiness)
            {
                throw;

            }
            catch (Exception ex)
            {
                throw new Exception("Error del servidor", ex);
            }


        }

        public UsuarioViewModel RegisterPost(UsuarioViewModel userModel)
        {
            var registracion = DependencyFactory.Resolve<IUsuarioBusiness>();

            try
            {
                return registracion.Registracion(userModel);

            }
            catch (ExceptionBusiness)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public RecuperoCodigoViewModel PasswordRecoveryPost(SolicitudRecuperoUsuarioViewModel recuperarUsuario)
        {
            var passwordRecovery = DependencyFactory.Resolve<IUsuarioBusiness>();

            try
            {
                var userView = passwordRecovery.SolicitudRecuperoUsuario(recuperarUsuario);
                MailHelper.RecuperarUsuarioEmail(userView);
                return userView;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public UsuarioViewModel UpdatePasswordRecoveryPost(RecuperarUsuarioViewModel recuperarUsuario)
        {
            var passwordRecovery = DependencyFactory.Resolve<IUsuarioBusiness>();

            try
            {

                if (recuperarUsuario.Password != recuperarUsuario.VerificacionPassword)
                {
                    throw new Exception("Las contraseñas no coinciden");
                }

                return passwordRecovery.RecuperarUsuario(recuperarUsuario);



            }
            catch (Exception)
            {
                throw;
            }

        }

        public void SignOut()
        {
            try
            {
                FormsAuthentication.SignOut();
            }
            catch (Exception ex)
            {
                throw new Exception("Error del servidor: " + ex.Message);
            }


        }

        public DatosPersonaViewModel GetDatosPersona()
        {

            var usuario = DependencyFactory.Resolve<IUsuarioBusiness>();
            try
            {
                var user = usuario.ObtenerDatosPersonales(GetAuthData());
                user.UltimoLogin = GetAuthData().UltimoLogin;
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Error del servidor", ex);
            }

        }

        public UsuarioViewModel PasswordSave(UsuarioCambioPasswordViewModel password)
        {

            ILoginBusiness changePassword = DependencyFactory.Resolve<ILoginBusiness>();

            try
            {

                var authInfo = GetAuthData();

                password.Id = authInfo.Id;

                password.Mail = authInfo.Mail;

                return changePassword.ActualizarPassword(password);

            }
            catch (ExceptionBusiness ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error del servidor", ex);
            }


        }

        #endregion

    }
}
