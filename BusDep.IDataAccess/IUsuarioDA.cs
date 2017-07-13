﻿using System.Collections.Generic;

namespace BusDep.IDataAccess
{
    using BusDep.Entity;
    public interface IUsuarioDA : IBaseDA<Usuario>
    {
        Usuario LoginUser(string mail, string password);
        Usuario LoginUser(string mail, string aplicacion, string token);
        Usuario Registracion(Usuario usuario);
        Evaluacion ObtenerEvaluacionDefault(long jugadorId, long deporteId);

        TipoEvaluacion ObtenerTipoEvaluacionDefault(long deporteId, string tipoUsuario);

        List<Antecedente> ObtenerAntecedentes(long usuarioId);

        Usuario ActualizarPassword(Usuario usuario);

        bool ExisteUsuario(string mail);
    }
}
