using BusDep.Entity;
using BusDep.UnityInject;

namespace BusDep.DataAccess
{
    using BusDep.IDataAccess;
    public class JugadorDA : BaseDataAccess<Jugador>, IJugadorDA
    {
        public virtual Puesto ObtenerPuesto(long puestoId)
        {
            return DependencyFactory.Resolve<IBaseDA<Puesto>>().GetById(puestoId);
        }
    }
}
