using System.Collections.Generic;
using BusDep.Entity;

namespace BusDep.IDataAccess
{
    public interface IJugadorDA : IBaseDA<Jugador>
    {
        Puesto ObtenerPuesto(long puestoId);

        List<Jugador> BuscarJugador(long? puestoId, string pais, int? edadDesde, int? edadHasta, string fichaje, string perfil, string nombre);
    }
}