namespace BusDep.Web.Controllers.Api
{
    using BusDep.IBusiness;
    using BusDep.UnityInject;
    using BusDep.ViewModel;
    using BusDep.Web.Class;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    public class ProfileController : BaseController
    {

        #region Post Functions
        [HttpPost]
        public string Save(DatosPersonaViewModel datosPersonaModel)
        {

            IUsuarioBusiness usuario = DependencyFactory.Resolve<IUsuarioBusiness>();

            try
            {

                usuario.RegistracionDatosPersonales(datosPersonaModel);
                return "";


            }
            catch (Exception)
            {
                return "Error de servidor";
            }


        }
        [HttpPost]
        public UsuarioViewModel PasswordSave(UsuarioCambioPasswordViewModel password)
        {

            ILoginBusiness changePassword = DependencyFactory.Resolve<ILoginBusiness>();

            try
            {

                var authInfo = GetAuthData();

                password.Id = authInfo.Id;

                password.Mail = authInfo.Mail;

                var result = changePassword.ActualizarPassword(password);
                return result;
  
            }
            catch (ExceptionBusiness ex)
            {
                
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }


        }
        [HttpPost]
        public DatosPersonaViewModel GetDatosPersona()
        {

            var usuario = DependencyFactory.Resolve<IUsuarioBusiness>();
            try
            {

                var user = usuario.ObtenerDatosPersonales(GetAuthData());
                user.UltimoLogin = GetAuthData().UltimoLogin;
                return user;

            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpPost]
        public JugadorViewModel GetJugador()
        {
            var business = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();
            try
            {
                return business.ObtenerJugador(GetAuthData());
            }
            catch (Exception ex)
            {
                throw new Exception("Error de servidor", ex);
            }
        }
        [HttpPost]
        public IEnumerable<ComboAgrupadoViewModel> GetPuestos()
        {
            try
            {
                return
                    DependencyFactory.Resolve<ICommonBusiness>()
                        .ObtenerComboPuestosEspecifico(GetAuthData().DeporteId.GetValueOrDefault());
            }
            catch (Exception ex)
            {
                throw new Exception("Error de servidor",ex);
            }
        }
        [HttpPost]
        public void SaveJugador(JugadorViewModel jugadorViewModel)
        {
            var business = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();
            try
            {
                business.ActualizarDatosJugador(jugadorViewModel);
               
            }
            catch (Exception ex)
            {
                throw new Exception("Error de servidor", ex);
            }
        }

        #endregion

        #region HttpGet

        [HttpGet]
        public PerfilJugadorViewModel GetPublicProfile([System.Web.Http.FromUri] int jugadorId)
        {

            var business = DependencyFactory.Resolve<IBusquedaBusiness>();
            try
            {
                return business.ObtenerPerfil(jugadorId);
            }
            catch (ExceptionBusiness ex)
            {
                throw new Exception("Perfil no encontrado: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error de servidor: " + ex.Message, ex);
            }
        }
        [HttpGet]
        public EvaluacionViewModel GetAutoEvaluacionDefault([System.Web.Http.FromUri] int jugadorId)
        {
            var business = DependencyFactory.Resolve<IBusquedaBusiness>();
            try
            {
                return business.GetAutoEvaluacionDefault(jugadorId);

            }
            catch (ExceptionBusiness ex)
            {
                throw new Exception("Perfil no encontrado: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error de servidor: " + ex.Message, ex);
            }
        }
        [HttpGet]
        public List<AntecedenteViewModel> GetAntecedentes([System.Web.Http.FromUri] int jugadorId)
        {
            var business = DependencyFactory.Resolve<IBusquedaBusiness>();
            try
            {
                return business.GetAntecedentes(jugadorId);
            }
            catch (ExceptionBusiness ex)
            {
                throw new Exception("Perfil no encontrado: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error de servidor: " + ex.Message, ex);
            }

        }

        [HttpGet]
        public List<RecomendacionViewModel> GetRecomendaciones([System.Web.Http.FromUri] int jugadorId)
        {

            var business = DependencyFactory.Resolve<IBusquedaBusiness>();

            try
            {
                return business.GetRecomendaciones(jugadorId);
            }
            catch (ExceptionBusiness ex)
            {
                throw new Exception("Perfil no encontrado: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error de servidor: " + ex.Message, ex);
            }

        }

        [HttpGet]
        public IEnumerable<ComboViewModel> GetFichajes()
        {
            try
            {
                return CacheHelper.ObtenerComboFichajes();
            }
            catch (Exception ex)
            {
                throw new Exception("Error de servidor: " + ex.Message, ex);
            }
        }

        [HttpGet]
        public IEnumerable<ComboViewModel> GetPerfiles()
        {
            try
            {
                return CacheHelper.ObtenerComboPerfiles();
            }
            catch (Exception ex)
            {
                throw new Exception("Error de servidor: " + ex.Message, ex);
            }
        }

        [HttpGet]
        public IEnumerable<ComboViewModel> GetPies()
        {
            try
            {
                return CacheHelper.ObtenerComboPie();
            }
            catch (Exception ex)
            {
                throw new Exception("Error de servidor: " + ex.Message, ex);
            }
        }
        [HttpPost]
        public static IEnumerable<ComboViewModel> PuestosBasicos(long deporteId)
        {
            

            return DependencyFactory.Resolve<ICommonBusiness>().ObtenerPuestos(deporteId)
                .Where(o => o.DeporteId.Equals(deporteId)).Select(u => u.Descripcion).Distinct()
                    .Select(item => new ComboViewModel
                    {
                        Id = item,
                        Descripcion = item
                    });
        }
        [HttpPost]
        public IEnumerable<ComboViewModel> GetPuestosBasicos()
        {
            try
            {
                return DependencyFactory.Resolve<ICommonBusiness>().ObtenerPuestos(GetAuthData().DeporteId.GetValueOrDefault())
                    .Select(u => u.Descripcion).Distinct()
                    .Select(item => new ComboViewModel
                    {
                        Id = item,
                        Descripcion = item
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("Error de servidor: " + ex.Message, ex);
            }
        }

        #endregion

    }
}
