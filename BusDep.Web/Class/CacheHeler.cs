

namespace BusDep.Web.Class
{
    using System.Collections.Generic;
    using System.Linq;
    using BusDep.IBusiness;
    using BusDep.UnityInject;
    using BusDep.ViewModel;
    public static class CacheHeler
    {

        private static IEnumerable<PuestoViewModel> puestosView = null;
        private static IEnumerable<ClubDetalleViewModel> clubes = null;

        public static IEnumerable<PuestoViewModel> ObtenerPuestos(long deporteId)
        {
            if (puestosView == null)
                puestosView = DependencyFactory.Resolve<ICommonBusiness>().ObtenerDeportesPuestos();
            return puestosView.Where(o => o.DeporteId.Equals(deporteId));
        }

        public static IEnumerable<ComboAgrupadoViewModel> ObtenerComboPuestosEspecifico(long deporteId)
        {
            if (puestosView == null)
                puestosView = DependencyFactory.Resolve<ICommonBusiness>().ObtenerDeportesPuestos();
            return puestosView.Select(item => new ComboAgrupadoViewModel
            {
                Id = item.Id,
                Agrupador = item.Descripcion,
                Descripcion = item.PuestoEspecifico
            }).ToList();
        }
        public static IEnumerable<ComboViewModel> PuestosBasicos(long deporteId)
        {
            if (puestosView == null)
                puestosView = DependencyFactory.Resolve<ICommonBusiness>().ObtenerDeportesPuestos();

            return
                puestosView.Where(o => o.DeporteId.Equals(deporteId)).Select(u=>u.Descripcion).Distinct()
                    .Select(item => new ComboViewModel
                    {
                        Id = item,
                        Descripcion = item
                    });
        }

        private static string[] pies = new[] { "Derecho", "Zurdo", "Ambidiestro" };
        public static IEnumerable<ComboViewModel> ObtenerComboPie()
        {
            return pies.Select(o => new ComboViewModel { Id = o, Descripcion = o });
        }
        private static string[] fichajes = new[] { "Libre", "Contratado" };
        public static IEnumerable<ComboViewModel> ObtenerComboFichajes()
        {
            return fichajes.Select(o => new ComboViewModel { Id = o, Descripcion = o });
        }
        private static string[] perfiles = new[] { "Amateur", "Profecional" };
        public static IEnumerable<ComboViewModel> ObtenerComboPerfiles()
        {
            return perfiles.Select(o => new ComboViewModel { Id = o, Descripcion = o });
        }

        public static IEnumerable<ClubDetalleViewModel> ObtenerClubes()
        {
            if(clubes==null)
                clubes = DependencyFactory.Resolve<ICommonBusiness>().ObtenerClubes();
            return clubes;
        }

    }
}