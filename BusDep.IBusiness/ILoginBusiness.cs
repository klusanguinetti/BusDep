namespace BusDep.IBusiness
{
    using BusDep.ViewModel;
    public interface ILoginBusiness
    {
        UsuarioViewModel LoginUser(string mail, string password);
        UsuarioViewModel LoginUser(string mail, string aplicacion, string token);

        UsuarioViewModel ActualizarPassword(UsuarioCambioPasswordViewModel usuarioCambioPassword);
    }
}
