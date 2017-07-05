using System;
using System.Collections.Generic;
using System.Linq;
using BusDep.Entity;
using BusDep.Entity.DTO;
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

        public virtual List<JugadorBusquedaDTO> BuscarJugador(long? puestoId, string pais, int? edadDesde, int? edadHasta, string fichaje, string perfil, string nombre)
        {
            
            var result = from ju in Session.Query<Jugador>()
                where (puestoId.HasValue ? ju.Puesto.Id.Equals(puestoId.Value) : 1.Equals(1))
                && (edadDesde.HasValue ? ju.Usuario.DatosPersona.FechaNacimiento < DateTime.Now.AddYears(-edadDesde.Value): 1.Equals(1))
                && (edadHasta.HasValue ? ju.Usuario.DatosPersona.FechaNacimiento > DateTime.Now.AddYears(-edadHasta.Value) : 1.Equals(1))
                && (string.IsNullOrWhiteSpace(pais) ? 1.Equals(1) : ju.Usuario.DatosPersona.Pais.Equals(pais))
                && (string.IsNullOrWhiteSpace(fichaje) ? 1.Equals(1) : ju.Fichaje.Equals(fichaje))
                && (string.IsNullOrWhiteSpace(perfil) ? 1.Equals(1) : ju.Perfil.Equals(perfil))
                && (string.IsNullOrWhiteSpace(nombre) ? 1.Equals(1) :
                 ju.Usuario.DatosPersona.Nombre.Contains(nombre) || ju.Usuario.DatosPersona.Apellido.Contains(nombre))
                         select new JugadorBusquedaDTO {
                             Apellido = ju.Usuario.DatosPersona.Apellido,
                             ClubActual =
                             ( from ant in Session.Query<Antecedente>()
                                 where ant.Usuario.Id.Equals(ju.Usuario.Id)
                                 orderby  ant.FechaInicio descending 
                                 select ant.InstitucionDescripcion).FirstOrDefault(),
                             Fichaje = ju.Fichaje,
                             FotoRostro = ju.FotoRostro,
                             Id = ju.Id,
                             Nacionalidad = ju.Usuario.DatosPersona.Nacionalidad,
                             Nacionalidades1 = ju.Usuario.DatosPersona.Nacionalidades1,
                             Nombre =  ju.Usuario.DatosPersona.Nombre,
                             Perfil = ju.Perfil,
                             Pie = ju.Pie,
                             PuestoDescripcion = ju.Puesto.PuestoEspecifico
                              };
            return result.ToList();
        }
    }
}
