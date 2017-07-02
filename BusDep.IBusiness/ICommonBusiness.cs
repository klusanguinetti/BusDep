using System.Collections.Generic;
using BusDep.ViewModel;

namespace BusDep.IBusiness
{
    public interface ICommonBusiness
    {
        JugadorView ObtenerJugador(UserViewModel usuario);
        IEnumerable<PuestoView> ObtenerPuestos(long deporteId);
        IEnumerable<DeporteView> ObtenerDeportes();
    }
}