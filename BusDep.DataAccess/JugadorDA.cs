using System.Collections.Generic;
using System.Linq;
using BusDep.Entity;
using BusDep.UnityInject;
using NHibernate.Linq;

namespace BusDep.DataAccess
{
    using BusDep.IDataAccess;
    public class JugadorDA : BaseDataAccess<Jugador>, IJugadorDA
    {
        public virtual Puesto ObtenerPuesto(long puestoId)
        {
            return DependencyFactory.Resolve<IBaseDA<Puesto>>().GetById(puestoId);
        }

        public virtual List<Jugador> BuscarJugador(long? puestoId, string pais, int? edadDesde, int? edadHasta, string fichaje, string perfil, string nombre)
        {
            
            var result = from ju in Session.Query<Jugador>()
                where (puestoId.HasValue ? ju.Puesto.Id.Equals(puestoId) : 1.Equals(1))
                && (string.IsNullOrWhiteSpace(pais) ? 1.Equals(1) : ju.Usuario.DatosPersona.Pais.Equals(pais))
                && (string.IsNullOrWhiteSpace(fichaje) ? 1.Equals(1) : ju.Fichaje.Equals(fichaje))
                && (string.IsNullOrWhiteSpace(perfil) ? 1.Equals(1) : ju.Perfil.Equals(perfil))
                && (string.IsNullOrWhiteSpace(nombre) ? 1.Equals(1) : 
                (nombre.ToUpper().Split(' ').Contains(ju.Usuario.DatosPersona.Nombre.ToUpper()) || 
                nombre.ToUpper().Split(' ').Contains(ju.Usuario.DatosPersona.Apellido.ToUpper())))
                         select ju;
            return result.ToList();

        }
    }
}
