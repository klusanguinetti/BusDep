using System.Collections.Generic;
using BusDep.Entity;
using BusDep.ViewModel;

namespace BusDep.IDataAccess
{
    public interface IEntrenadorDA : IBaseDA<Entrenador>
    {
        EntrenadorViewModel ObtenerEntrenador(long id);
        List<EntrenadorViewModel> BuscarEntrenador(BuscarEntrenadorViewModel buscar);
        long BuscarEntrenadorCount(BuscarEntrenadorViewModel buscar);
    }
}