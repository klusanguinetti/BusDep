using System.Collections.Generic;
using System.Linq;
using BusDep.Common;
using BusDep.Entity;
using BusDep.IBusiness;
using BusDep.IDataAccess;
using BusDep.UnityInject;
using BusDep.ViewModel;

namespace BusDep.Business
{
    public class CommonBusiness : ICommonBusiness
    {
        public virtual JugadorViewModel ObtenerJugador(UsuarioViewModel usuario)
        {
            if (usuario.JugadorId.HasValue)
            {
                return FillViewModel.FillJugadorViewModel(DependencyFactory.Resolve<IJugadorDA>().GetById(usuario.JugadorId));
            }
            return null;
        }
        public virtual IEnumerable<PuestoViewModel> ObtenerPuestos(long deporteId)
        {
            var deporte = DependencyFactory.Resolve<IBaseDA<Deporte>>().GetById(deporteId);
            return (from p in deporte.Puestos select FillViewModel.FillPuestoViewModel(p));
        }
        public virtual IEnumerable<DeporteViewModel> ObtenerDeportes()
        {
            return DependencyFactory.Resolve<IBaseDA<Deporte>>().GetAll().MapperEnumerable<DeporteViewModel>();
        }
        


    }
}
