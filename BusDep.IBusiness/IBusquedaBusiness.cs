using BusDep.ViewModel;

namespace BusDep.IBusiness
{
    using System;
    using System.Collections.Generic;
    public interface IBusquedaBusiness
    {
        
        PerfilJugadorViewModel ObtenerPerfil(long jugadorId);

        List<JugadorBusquedaViewModel> BuscarJugador(BuscarJugadorViewModel buscar);

        long BuscarJugadorCount(BuscarJugadorViewModel buscar);
    }
}
