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
            throw new ExceptionBusiness(1, "No existe Jugador");
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

        public virtual IEnumerable<ComboAgrupadoViewModel> ObtenerComboPuestosEspecifico(long deporteId)
        {
            var deporte = DependencyFactory.Resolve<IBaseDA<Deporte>>().GetById(deporteId);
            var ilOrigen = deporte.Puestos.Select(o => o.Descripcion).Distinct().Select(o => new ComboAgrupadoViewModel { Id = null, Agrupador = o });
            List<ComboAgrupadoViewModel> ilResult = new List<ComboAgrupadoViewModel>();
            foreach (var item in ilOrigen)
            {
                ilResult.Add(item);
                ilResult.AddRange(deporte.Puestos.Where(o => o.Descripcion.Equals(item.Agrupador)).Select(o => new ComboAgrupadoViewModel
                {
                    Id = o.Id, Agrupador = o.Descripcion, Descripcion = o.PuestoEspecifico
                }));
            }
            return ilResult;
        }

        public IEnumerable<ComboViewModel> ObtenerComboPuestos(long deporteId)
        {
            var deporte = DependencyFactory.Resolve<IBaseDA<Deporte>>().GetById(deporteId);
            return deporte.Puestos.Select(o => o.Descripcion).Distinct().Select(o => new ComboViewModel { Id = o, Descripcion = o });
        }
        public IEnumerable<ComboViewModel> ObtenerComboPie()
        {
            return new[] { "Derecho", "Zurdo", "Ambidiestro" }.Select(o => new ComboViewModel { Id = o, Descripcion = o });
        }
        public IEnumerable<ComboViewModel> ObtenerComboFichajes()
        {
            return new[] { "Libre", "Contratado" }.Select(o => new ComboViewModel { Id = o, Descripcion = o });
        }
        public IEnumerable<ComboViewModel> ObtenerComboPerfiles()
        {
            return new[] { "Amateur", "Profecional" }.Select(o => new ComboViewModel { Id = o, Descripcion = o });
        }
        
    }
}
