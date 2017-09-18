namespace BusDep.Web.BackOffice.Api
{
    using System;
    using System.Web.Http;
    using System.Web.Security;
    using BusDep.Common;
    using BusDep.IBusiness;
    using BusDep.UnityInject;
    using BusDep.ViewModel;
    using BusDep.Web.BackOffice.Class;
    public class AccountController : BaseController
    {

        #region Post Functions

        [HttpPost]
        public UsuarioViewModel LoginPost(UsuarioViewModel loginModel)
        {
            IBackOfficeLoginBusiness login = DependencyFactory.Resolve<IBackOfficeLoginBusiness>();
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
        

        #endregion

    }
}
