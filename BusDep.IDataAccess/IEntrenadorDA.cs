using System.Collections.Generic;
using BusDep.Entity;
using BusDep.ViewModel;

namespace BusDep.IDataAccess
{
    public interface IEntrenadorDA : IBaseDA<Entrenador>
    {
        


        //List<Antecedente> ObtenerAntecedentes(long usuarioId);


        //List<JugadorViewModel> BuscarJugador(string[] puesto, int? edadDesde, int? edadHasta, string[] fichaje, string[] perfil, string[] pie, string nombre,
        //    int? pagina = null, int? cantidad = null);

        //long BuscarJugadorCount(string[] puesto, int? edadDesde, int? edadHasta, string[] fichaje, string[] perfil,
        //    string[] pie, string nombre,
        //    int? pagina = null, int? cantidad = null);

        EntrenadorViewModel ObtenerEntrenador(long id);
        List<EntrenadorViewModel> BuscarEntrenador(BuscarEntrenadorViewModel buscar);

        long BuscarEntrenadorCount(BuscarEntrenadorViewModel buscar);

        //bool ExisteJugador(long id);


        //PerfilJugadorShortViewModel GetPerfilJugadorShort(long jugadorId);

        //List<JugadorViewModel> TopJugador();

        //EvaluacionViewModel ObtenerEvaluacionViewModelDefault(long jugadorId);

        //List<AntecedenteViewModel> GetAntecedentes(long jugadorId);

        //PerfilJugadorViewModel ObtenerPerfil(long jugadorId);

        //List<RecomendacionViewModel> GetRecomendaciones(int jugadorId);
    }
}