using BusDep.ViewModel;

namespace BusDep.IBusiness
{
    public interface IUsuarioBusiness
    {
        UsuarioViewModel Registracion(UsuarioViewModel userView);
        DatosPersonaViewModel ObtenerDatosPersonales(UsuarioViewModel userView);
        void RegistracionDatosPersonales(DatosPersonaViewModel datosPersona);
        JugadorViewModel ObtenerJugador(UsuarioViewModel userView);
        void ActualizarDatosJugador(JugadorViewModel jugadorView);
        EvaluacionViewModel ObtenerEvaluacionViewModel(UsuarioViewModel userView);
        void GuardarEvalucacion(EvaluacionViewModel evaluacion);
    }
}