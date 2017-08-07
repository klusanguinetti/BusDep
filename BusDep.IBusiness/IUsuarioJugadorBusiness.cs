using System.Collections.Generic;
using BusDep.ViewModel;

namespace BusDep.IBusiness
{
    public interface IUsuarioJugadorBusiness
    {
        EvaluacionViewModel ObtenerEvaluacionViewModel(UsuarioViewModel userView);
        void GuardarEvalucacion(EvaluacionViewModel evaluacion);
        void ActualizarDatosJugador(JugadorViewModel jugadorView);
        JugadorViewModel ObtenerJugador(UsuarioViewModel userView);
        List<AntecedenteViewModel> ObtenerAntecedentes(UsuarioViewModel userView);
        AntecedenteViewModel ObtenerAntecedenteViewModel(long antecedenteId, long userId);
        AntecedenteViewModel NuevoAntecedenteViewModel(UsuarioViewModel userView);
        AntecedenteViewModel GuardarAntecedenteViewModel(AntecedenteViewModel antecedente);
        void BorrarAntecedentes(AntecedenteViewModel antecedenteViewModel);
    }
}