namespace BusDep.IBusiness
{
    using BusDep.ViewModel;
    public interface ILogin
    {
        UserViewModel LoginUser(string mail, string password);
        UserViewModel LoginUser(string mail, string aplicacion, string token);
    }
}
