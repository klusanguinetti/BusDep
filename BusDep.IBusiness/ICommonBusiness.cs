using System.Collections.Generic;
using BusDep.ViewModel;

namespace BusDep.IBusiness
{
    public interface ICommonBusiness
    {
        JugadorViewModel ObtenerJugador(UsuarioViewModel usuario);
        IEnumerable<PuestoViewModel> ObtenerPuestos(long deporteId);
        IEnumerable<DeporteViewModel> ObtenerDeportes();
    }
}