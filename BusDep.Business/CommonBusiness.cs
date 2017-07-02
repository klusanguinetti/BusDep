using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusDep.Common;
using BusDep.Entity;
using BusDep.IBusiness;
using BusDep.IDataAccess;
using BusDep.UnityInject;
using BusDep.ViewModel;

namespace BusDep.Business
{
    public class CommonBusiness : ICommonBusiness
    {
        public virtual JugadorView ObtenerJugador(UserViewModel usuario)
        {
            var user = DependencyFactory.Resolve<IUsuarioDA>().GetById(usuario.Id);
            if (user.Jugador != null)
            {
                var jugadorView = user.Jugador.MapperClass<JugadorView>();
                jugadorView.UsuarioId = user.Id;
                if (user.Jugador.Puesto != null)
                {
                    jugadorView.PuestoId = user.Jugador.Puesto.Id;
                    jugadorView.PuestoDescripcion = user.Jugador.Puesto.Descripcion;
                }
                return jugadorView;
            }
            return null;
        }
        public virtual IEnumerable<PuestoView> ObtenerPuestos(long deporteId)
        {
            var deporte = DependencyFactory.Resolve<IBaseDA<Deporte>>().GetById(deporteId);
            var lista = deporte.Puestos.MapperEnumerable<PuestoView>();
            foreach (var o in lista)
            {
                o.DeporteId = deporteId;
            }
            return lista;
        }
        public virtual IEnumerable<DeporteView> ObtenerDeportes()
        {
            return DependencyFactory.Resolve<IBaseDA<Deporte>>().GetAll().MapperEnumerable<DeporteView>();
        }
        
    }
}
