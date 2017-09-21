using System.Collections.Generic;

namespace BusDep.IDataAccess
{
    using BusDep.Entity;
    using ViewModel;

    public interface IEventoPublicidadDA : IBaseDA<EventoPublicidad>
    {
        long EventoPublicidadActivaCount();
        List<EventoPublicidadViewModel> GetEventoPublicidadActivaAll();
    }
}
