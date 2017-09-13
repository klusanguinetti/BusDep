using BusDep.IBusiness;
using BusDep.UnityInject;
using BusDep.ViewModel;
using BusDep.Web.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace BusDep.Web.Controllers.Api
{
    [Authorize]
    public class HistoryController : BaseController
    {

        //private AuthHelper authHelper = new AuthHelper();

        #region Get Functions

        [HttpGet]
        public AntecedenteViewModel GetNewAntecedente()
        {
            var business = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();
            try
            {
                return business.NuevoAntecedenteViewModel(this.GetAuthData());
            }
            catch (Exception)
            {
                throw new Exception("Error de servidor");
            }
        }

        #endregion

        #region Post Functions
        [HttpPost]
        public List<AntecedenteViewModel> SaveAntecedente(AntecedenteViewModel antecedenteViewModel)
        {
            antecedenteViewModel.UsuarioId = this.GetAuthData().Id;
            var business = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();
            try
            {
                business.GuardarAntecedenteViewModel(antecedenteViewModel);
                return business.ObtenerAntecedentes(this.GetAuthData());
            }
            catch (Exception)
            {
                throw new Exception("Error de servidor");
            }
        }
        [HttpPost]
        public IEnumerable<ComboAgrupadoViewModel> GetPuestosCode()
        {
            try
            {
                return DependencyFactory.Resolve<ICommonBusiness>().ObtenerComboPuestosEspecificoCode(this.GetAuthData().DeporteId.GetValueOrDefault());
            }
            catch (Exception)
            {
                throw new Exception("Error de servidor");
            }
        }
        [HttpPost]
        public AntecedenteViewModel DeleteAntecedente(long id)
        {

            var business = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();
            try
            {
                AntecedenteViewModel antecedentes = business.ObtenerAntecedenteViewModel(id, this.GetAuthData().Id);

                if (antecedentes != null)
                {
                    business.BorrarAntecedentes(antecedentes);
                }

                return antecedentes;

            }
            catch (Exception)
            {
                throw new Exception("Error de servidor");
            }
        }
        [HttpPost]
        public IEnumerable<ClubDetalleViewModel> GetClubes()
        {
            try
            {
                return DependencyFactory.Resolve<ICommonBusiness>().ObtenerClubes();
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
                return business.ObtenerJugador(this.GetAuthData());
            }
            catch (Exception)
            {
                throw new Exception("Error de servidor");
            }
        }
        [HttpPost]
        public List<AntecedenteViewModel> GetAntecedentes()
        {
            var business = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();
            try
            {
                return business.ObtenerAntecedentes(this.GetAuthData());
            }
            catch (Exception)
            {
                throw new Exception("Error de servidor");
            }
        }

        [HttpPost]
        public AntecedenteViewModel GetAntecedentesById(long Id)
        {
            var business = DependencyFactory.Resolve<IUsuarioJugadorBusiness>();
            try
            {
                return business.ObtenerAntecedenteViewModel(Id, this.GetAuthData().Id);
            }
            catch (Exception)
            {
                throw new Exception("Error de servidor");
            }
        }

        #endregion


    }
}
