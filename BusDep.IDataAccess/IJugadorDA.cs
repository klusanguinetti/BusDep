using System.Collections.Generic;
using BusDep.Entity;
using BusDep.Entity.DTO;

namespace BusDep.IDataAccess
{
    public interface IJugadorDA : IBaseDA<Jugador>
    {
        Puesto ObtenerPuesto(long puestoId);

        List<JugadorBusquedaDTO> BuscarJugador(long? puestoId, string pais, int? edadDesde, int? edadHasta, string fichaje, string perfil, string nombre);

        List<Antecedente> ObtenerAntecedentes(long usuarioId);

        List<JugadorBusquedaDTO> BuscarJugador(string puesto, int? edadDesde, int? edadHasta, string fichaje, string perfil, string pie, string nombre);

        List<JugadorBusquedaDTO> BuscarJugador(string[] puesto, int? edadDesde, int? edadHasta, string[] fichaje, string[] perfil, string[] pie, string nombre);

        List<JugadorBusquedaDTO> BuscarJugador(string[] puesto, int? edadDesde, int? edadHasta, string[] fichaje, string[] perfil, string[] pie, string nombre, int pagina, int cantidad);
    }
}