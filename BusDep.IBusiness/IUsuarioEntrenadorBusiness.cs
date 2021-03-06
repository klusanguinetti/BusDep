using System.Collections.Generic;
using BusDep.ViewModel;

namespace BusDep.IBusiness
{
    public interface IUsuarioEntrenadorBusiness
    {
        EvaluacionViewModel ObtenerEvaluacionViewModel(UsuarioViewModel userView);
        void GuardarEvalucacion(EvaluacionViewModel evaluacion);
        void GuardarRecomendar(RecomendacionViewModel recomendacion);
        void ActualizarDatosEntrenador(EntrenadorViewModel entrenadorView);
        //EntrenadorViewModel GetPerfilEntrenador(UsuarioViewModel userView);


        List<AntecedenteViewModel> ObtenerAntecedentes(UsuarioViewModel userView);
        AntecedenteViewModel ObtenerAntecedenteViewModel(long antecedenteId, long userId);
        AntecedenteViewModel NuevoAntecedenteViewModel(UsuarioViewModel userView);
        AntecedenteViewModel GuardarAntecedenteViewModel(AntecedenteViewModel antecedente);
        void BorrarAntecedentes(AntecedenteViewModel antecedenteViewModel);
    }
}