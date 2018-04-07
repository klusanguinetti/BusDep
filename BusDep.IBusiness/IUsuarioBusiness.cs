using BusDep.ViewModel;

namespace BusDep.IBusiness
{
    public interface IUsuarioBusiness
    {

        UsuarioViewModel Registracion(UsuarioViewModel userView);

        RecuperoCodigoViewModel SolicitudRecuperoUsuario(SolicitudRecuperoUsuarioViewModel solicitud);

        UsuarioViewModel RecuperarUsuario(RecuperarUsuarioViewModel recuperarUsuario);
    }
}