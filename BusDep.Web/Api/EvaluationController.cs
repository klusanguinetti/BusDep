namespace BusDep.Web.Api
{
    using System;
    using System.Web.Http;
    using BusDep.IBusiness;
    using BusDep.UnityInject;
    using BusDep.ViewModel;
    using BusDep.Web.Class;
    [Authorize]
    public class EvaluationController : BaseController
    {
        #region Post Functions

        public string SaveEvaluacion(EvaluacionViewModel antecedenteViewModel)
        {
            try
            {
                DependencyFactory.Resolve<IEvaluacionrBusiness>().GuardarEvalucacion(antecedenteViewModel);
                return "Ok";
            }
            catch (Exception)
            {
                throw new Exception("Error de servidor");
            }
        }
        [HttpPost]
        public EvaluacionViewModel GetAutoEvaluacion()
        {
            try
            {
                return DependencyFactory.Resolve<IEvaluacionrBusiness>().ObtenerEvaluacionViewModel(GetAuthData());
                
            }
            catch (Exception)
            {
                throw new Exception("Error de servidor");
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
            catch (Exception)
            {
                throw new Exception("Error de servidor");
            }
        }

        #endregion
    }
}
