namespace BusDep.IBusiness
{
    using BusDep.ViewModel;
    public interface ILoginBusiness
    {
        UserViewModel LoginUser(string mail, string password);
        UserViewModel LoginUser(string mail, string aplicacion, string token);
    }
}
