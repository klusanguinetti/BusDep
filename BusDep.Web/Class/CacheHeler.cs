

namespace BusDep.Web.Class
{
    using System.Collections.Generic;
    using System.Linq;
    using BusDep.ViewModel;
    public static class CacheHeler
    {

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

        
    }
}