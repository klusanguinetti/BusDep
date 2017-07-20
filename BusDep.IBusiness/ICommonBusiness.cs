using System.Collections.Generic;
using BusDep.ViewModel;

namespace BusDep.IBusiness
{
    public interface ICommonBusiness
    {
        IEnumerable<PuestoViewModel> ObtenerPuestos(long deporteId);
        IEnumerable<DeporteViewModel> ObtenerDeportes();
        IEnumerable<ComboAgrupadoViewModel> ObtenerComboPuestosEspecifico(long deporteId);
        IEnumerable<ComboViewModel> ObtenerComboPuestos(long deporteId);
        IEnumerable<ComboViewModel> ObtenerComboPie();
        IEnumerable<ComboViewModel> ObtenerComboFichajes();
        IEnumerable<ComboViewModel> ObtenerComboPerfiles();
    }
}