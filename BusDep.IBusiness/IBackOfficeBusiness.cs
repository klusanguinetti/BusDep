using System.Collections.Generic;
using BusDep.ViewModel;

namespace BusDep.IBusiness
{
    public interface IBackOfficeBusiness
    {

        void SavePublicidad(PublicidadViewModel publicidadViewModel);
        void DeletePublicidad(PublicidadViewModel publicidadViewModel);
        List<PublicidadViewModel> GetPublicidadAll();
        PublicidadViewModel GetPublicidadId(long id);

        List<EventoPublicidadViewModel> GetEventoPublicidadAll();
        void DeleteEventoPublicidad(EventoPublicidadViewModel eventoPublicidadViewModel);
        EventoPublicidadViewModel GetEventoPublicidadId(long id);
        void SaveEventoPublicidad(EventoPublicidadViewModel publicidadViewModel);
        List<EventoPublicidadViewModel> GetEventoPublicidadActivaAll();
        long EventoPublicidadActivaCount();

        

    }
}