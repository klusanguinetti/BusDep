using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Web.UI.WebControls;
using BusDep.IBusiness;
using BusDep.UnityInject;
using BusDep.ViewModel;

namespace BusDep.Web.Api
{
    public class CoachController : BaseController
    {
        #region metodos
        [HttpPost]
        public DatosPersonaViewModel GetDatosPersona()
        {

            var business = DependencyFactory.Resolve<IUsuarioEntrenadorBusiness>();
            try
            {
                var user = business.ObtenerDatosPersonales(GetAuthData());
                user.UltimoLogin = GetAuthData().UltimoLogin;
                return user;

            }
            catch (Exception ex)
            {
                throw new Exception("Error de servidor", ex);
            }

        }
        [HttpPost]
        public void Save(DatosPersonaViewModel datosPersonaModel)
        {
            var business = DependencyFactory.Resolve<IUsuarioEntrenadorBusiness>();
            try
            {
                business.RegistracionDatosPersonales(datosPersonaModel);
            }
            catch (Exception ex)
            {
                throw new Exception("Error de servidor", ex);
            }
        }
        [HttpPost]
        public EntrenadorViewModel GetPerfilEntrenador()
        {
            var business = DependencyFactory.Resolve<IUsuarioEntrenadorBusiness>();
            try
            {
               return business.ObtenerEntrenador(this.GetAuthData());
            }
            catch (Exception ex)
            {
                throw new Exception("Error de servidor", ex);
            }
        }
        [HttpPost]
        public List<AntecedenteViewModel> SaveAntecedente(AntecedenteViewModel antecedenteViewModel)
        {
            antecedenteViewModel.UsuarioId = this.GetAuthData().Id;
            var business = DependencyFactory.Resolve<IUsuarioEntrenadorBusiness>();
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
        public AntecedenteViewModel DeleteAntecedente(long id)
        {

            var business = DependencyFactory.Resolve<IUsuarioEntrenadorBusiness>();
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
        public List<AntecedenteViewModel> GetAntecedentes()
        {
            var business = DependencyFactory.Resolve<IUsuarioEntrenadorBusiness>();
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
            var business = DependencyFactory.Resolve<IUsuarioEntrenadorBusiness>();
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
