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
        public virtual IEnumerable<PuestoViewModel> ObtenerPuestos(long deporteId)
        {
            return DependencyFactory.Resolve<ICommnDA>().ObtenerPuestos(deporteId);
        }
        public virtual IEnumerable<DeporteViewModel> ObtenerDeportes()
        {
            return DependencyFactory.Resolve<ICommnDA>().ObtenerDeportes();
        }

        public virtual IEnumerable<ComboAgrupadoViewModel> ObtenerComboPuestosEspecifico(long deporteId)
        {
            var deporte = DependencyFactory.Resolve<IBaseDA<Deporte>>().GetById(deporteId);
            return deporte.Puestos.Select(item => new ComboAgrupadoViewModel
            {
                Id = item.Id, Agrupador = item.Descripcion, Descripcion = item.PuestoEspecifico
            }).ToList();
        }

        public virtual IEnumerable<ComboViewModel> ObtenerComboPuestos(long deporteId)
        {
            return DependencyFactory.Resolve<ICommnDA>().ObtenerComboPuestos(deporteId);
        }
        public virtual IEnumerable<ComboViewModel> ObtenerComboPie()
        {
            return new[] { "Derecho", "Zurdo", "Ambidiestro" }.Select(o => new ComboViewModel { Id = o, Descripcion = o });
        }
        public virtual IEnumerable<ComboViewModel> ObtenerComboFichajes()
        {
            return new[] { "Libre", "Contratado" }.Select(o => new ComboViewModel { Id = o, Descripcion = o });
        }
        public IEnumerable<ComboViewModel> ObtenerComboPerfiles()
        {
            return new[] { "Amateur", "Profecional" }.Select(o => new ComboViewModel { Id = o, Descripcion = o });
        }

        public virtual IEnumerable<ClubDetalleViewModel> ObtenerClubes()
        {
            return DependencyFactory.Resolve<ICommnDA>().ObtenerClubes();
        }
    }
}
