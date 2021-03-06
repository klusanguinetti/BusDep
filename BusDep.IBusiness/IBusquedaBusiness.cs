﻿using BusDep.ViewModel;

namespace BusDep.IBusiness
{
    using System;
    using System.Collections.Generic;
    public interface IBusquedaBusiness
    {
        
        PerfilJugadorViewModel ObtenerPerfil(long jugadorId);

        EvaluacionViewModel GetAutoEvaluacionDefault(long jugadorId);
        List<AntecedenteViewModel> GetAntecedentes(long jugadorId); 

        List<JugadorViewModel> BuscarJugador(BuscarJugadorViewModel buscar);

        long BuscarJugadorCount(BuscarJugadorViewModel buscar);

        PerfilJugadorShortViewModel GetPerfilJugadorShort(UsuarioViewModel usuario);

        List<JugadorViewModel> TopJugador();

        List<RecomendacionViewModel> GetRecomendaciones(int jugadorId);


        List<EntrenadorViewModel> BuscarEntrenador(BuscarEntrenadorViewModel buscar);
        long BuscarEntrenadorCount(BuscarEntrenadorViewModel buscar);


        List<JugadorBackOfficeViewModel> SearchJugadorAll();

        VideoAnalistaViewModel GetPerfilVideoAnalista(UsuarioViewModel usuario);

        EntrenadorViewModel GetPerfilEntrenador(UsuarioViewModel userView);

    }
}
