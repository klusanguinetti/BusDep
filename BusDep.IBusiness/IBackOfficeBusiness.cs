using System.Collections.Generic;
using BusDep.ViewModel;

namespace BusDep.IBusiness
{
    public interface IBackOfficeBusiness
    {

        void SavePublicidad(PublicidadViewModel publicidadViewModel);

        void DeletePublicidad(PublicidadViewModel publicidadViewModel);

        List<PublicidadViewModel> GetPublicidadAll();
        PublicidadViewModel GetPublicidadById(long id);

    }
}