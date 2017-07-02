using BusDep.Entity;

namespace BusDep.IDataAccess
{
    public interface IJugadorDA : IBaseDA<Jugador>
    {
        Puesto ObtenerPuesto(long puestoId);
    }
}