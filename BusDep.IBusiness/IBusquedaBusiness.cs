using BusDep.ViewModel;

namespace BusDep.IBusiness
{
    using System;
    using System.Collections.Generic;
    public interface IBusquedaBusiness
    {
        
        PerfilJugadorViewModel ObtenerPerfil(long jugadorId);

        List<JugadorViewModel> BuscarJugador(BuscarJugadorViewModel buscar);

        long BuscarJugadorCount(BuscarJugadorViewModel buscar);

        PerfilJugadorShortViewModel GetPerfilJugadorShort(UsuarioViewModel usuario);

        List<JugadorViewModel> TopJugador();
    }
}
