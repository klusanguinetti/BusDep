using BusDep.ViewModel;

namespace BusDep.IBusiness
{
    using System;
    using System.Collections.Generic;
    public interface IBusquedaBusiness
    {
        
        PerfilJugadorViewModel ObtenerPerfil(long jugadorId);
        
        List<JugadorBusquedaViewModel> BuscarJugador(long? puestoId, string pais, int? edadDesde, int? edadHasta,
            string fichaje, string perfil, string nombre);
        
        List<JugadorBusquedaViewModel> BuscarJugador(string puesto, int? edadDesde, int? edadHasta, string fichaje, string perfil, string nombre);
    }
}
