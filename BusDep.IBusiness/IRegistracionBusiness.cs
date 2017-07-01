using BusDep.ViewModel;

namespace BusDep.IBusiness
{
    public interface IRegistracionBusiness
    {
        UserViewModel Registracion(UserViewModel userView);
        DatosPersonaView ObtenerDatosPersonales(long userId);
        void RegistracionDatosPersonales(DatosPersonaView datosPersona);
    }
}