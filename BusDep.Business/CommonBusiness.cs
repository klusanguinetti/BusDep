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
            return deporte.Puestos.Select(item => new ComboAgrupadoViewModel
            {
                Id = item.Id, Agrupador = item.Descripcion, Descripcion = item.PuestoEspecifico
            }).ToList();
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

        public IEnumerable<ClubDetalleViewModel> ObtenerClubes()
        {
            var clubes = DependencyFactory.Resolve<IBaseDA<ClubDetalle>>().GetAll();
            return clubes.MapperEnumerable<ClubDetalleViewModel>(TypeMapper.IgnoreCaseSensitive);

        }
    }
}
