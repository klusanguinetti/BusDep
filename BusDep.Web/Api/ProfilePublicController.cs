using System;
using System.Collections.Generic;
using System.Web.Http;
using BusDep.IBusiness;
using BusDep.UnityInject;
using BusDep.ViewModel;

namespace BusDep.Web.Controllers.Api
{
    public class ProfilePublicController : BaseController
    {
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
        #endregion

    }
}