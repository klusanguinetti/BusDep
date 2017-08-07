using System.Collections.Generic;
using BusDep.Entity;
using BusDep.ViewModel;

namespace BusDep.IDataAccess
{
    public interface IJugadorDA : IBaseDA<Jugador>
    {
        Puesto ObtenerPuesto(long puestoId);


        List<Antecedente> ObtenerAntecedentes(long usuarioId);


        List<JugadorViewModel> BuscarJugador(string[] puesto, int? edadDesde, int? edadHasta, string[] fichaje, string[] perfil, string[] pie, string nombre,
            int? pagina = null, int? cantidad = null);

        long BuscarJugadorCount(string[] puesto, int? edadDesde, int? edadHasta, string[] fichaje, string[] perfil,
            string[] pie, string nombre,
            int? pagina = null, int? cantidad = null);

        JugadorViewModel ObtenerJugador(long id);

        bool ExisteJugador(long id);
    }
}