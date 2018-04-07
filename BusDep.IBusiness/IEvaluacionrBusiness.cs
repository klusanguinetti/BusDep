using BusDep.ViewModel;

namespace BusDep.IBusiness
{
    public interface IEvaluacionrBusiness
    {
        EvaluacionViewModel ObtenerEvaluacionViewModel(UsuarioViewModel userView);
        void GuardarEvalucacion(EvaluacionViewModel evaluacion);
    }
}