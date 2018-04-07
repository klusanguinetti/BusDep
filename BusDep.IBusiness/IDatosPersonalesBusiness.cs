using BusDep.ViewModel;

namespace BusDep.IBusiness
{
    public interface IDatosPersonalesBusiness
    {
        
        DatosPersonaViewModel ObtenerDatosPersonales(UsuarioViewModel userView);
        void RegistracionDatosPersonales(DatosPersonaViewModel datosPersona);
        
    }
}