namespace BusDep.IDataAccess
{
    using System.Collections.Generic;
    using BusDep.ViewModel;
    public interface ICommnDA
    {
        IEnumerable<PuestoViewModel> ObtenerPuestos(long deporteId);

        IEnumerable<DeporteViewModel> ObtenerDeportes();

        IEnumerable<ComboViewModel> ObtenerComboPuestos(long deporteId);

        IEnumerable<ClubDetalleViewModel> ObtenerClubes();

        IEnumerable<PuestoViewModel> ObtenerDeportesPuestos();
    }
}
