using System.Collections.Generic;

namespace BusDep.IDataAccess
{
    using BusDep.Entity;
    using ViewModel;

    public interface IUsuarioDA : IBaseDA<Usuario>
    {
        Usuario LoginUser(string mail, string password);
        Usuario LoginUser(string mail, string aplicacion, string token);
        Usuario Registracion(Usuario usuario);
        //Evaluacion ObtenerEvaluacionDefault(long usuarioId, long deporteId);
        EvaluacionViewModel ObtenerEvaluacionViewModelDefault(long usuarioId, long deporteId);
        TipoEvaluacion ObtenerTipoEvaluacionDefault(long deporteId, string tipoUsuario);
        List<AntecedenteViewModel> ObtenerAntecedentes(long usuarioId);
        AntecedenteViewModel ObtenerAntecedenteViewModel(long antecedenteId, long usuarioId);
        Usuario ActualizarPassword(Usuario usuario);

        DatosPersonaViewModel ObtenerDatosPersonales(long datosPersonalesId);

        bool ExisteUsuario(string mail);
        Usuario ObtenerUsuarioPorMail(string mail);

        List<MenuViewModel> ObtenerMenuTipoUsuario(long tipoUsuarioId);
    }
}
