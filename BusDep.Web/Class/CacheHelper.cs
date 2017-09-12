

using System.Globalization;

namespace BusDep.Web.Class
{
    using System.Collections.Generic;
    using System.Linq;
    using BusDep.ViewModel;
    public static class CacheHelper
    {

        private static string[] pies = new[] { "Derecho", "Zurdo", "Ambidiestro" };
        public static IEnumerable<ComboViewModel> ObtenerComboPie()
        {
            return pies.Select(o => new ComboViewModel { Id = o, Descripcion = o, Selected = false});
        }
        private static string[] fichajes = new[] { "Libre", "Contratado" };
        public static IEnumerable<ComboViewModel> ObtenerComboFichajes()
        {
            return fichajes.Select(o => new ComboViewModel { Id = o, Descripcion = o, Selected = false });
        }
        private static string[] perfiles = new[] { "Amateur", "Profesional" };
        public static IEnumerable<ComboViewModel> ObtenerComboPerfiles()
        {
            return perfiles.Select(o => new ComboViewModel { Id = o, Descripcion = o, Selected = false });
        }
        
        public static IEnumerable<ComboViewModel> ObtenerComboAltura()
        {
            List< ComboViewModel > il = new List<ComboViewModel>();
            NumberFormatInfo nfi = new NumberFormatInfo { NumberDecimalSeparator = "."};
            for (decimal i = 1.40M; i <= 2.20M; i = i + 0.01M)
                il.Add(new ComboViewModel {Descripcion = i.ToString(nfi) + " mts", Id = i });
            return il;
        }
        public static IEnumerable<ComboViewModel> ObtenerComboPeso()
        {
            List<ComboViewModel> il = new List<ComboViewModel>();

            for (int i = 40; i <= 160; i++)
                il.Add(new ComboViewModel { Descripcion = i + " Kg", Id = i });
            return il;
        }
    }
}