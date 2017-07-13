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
                             ClubActual = ju.ClubDescripcion,
                             LogClubActual = ju.ClubLogo,
                             Fichaje = ju.Fichaje,
                             FotoRostro = ju.FotoRostro,
                             Id = ju.Id,
                             Nacionalidad = ju.Usuario.DatosPersona.Nacionalidad,
                             Nacionalidad1 = ju.Usuario.DatosPersona.Nacionalidad1,
                             NacionalidadIso= ju.Usuario.DatosPersona.NacionalidadIso,
                             NacionalidadIso1 = ju.Usuario.DatosPersona.NacionalidadIso1,
                             Pais = ju.Usuario.DatosPersona.Pais,
                             PaisIso = ju.Usuario.DatosPersona.PaisIso,
                             Nombre =  ju.Usuario.DatosPersona.Nombre,
                             Perfil = ju.Perfil,
                             Pie = ju.Pie,
                             PuestoDescripcion = ju.Puesto.PuestoEspecifico
                              };
            return result.ToList();
        }

        public virtual List<Antecedente> ObtenerAntecedentes(long usuarioId)
        {
            return Session.Query<Antecedente>().Where(o => o.Usuario.Id.Equals(usuarioId)).ToList();
        }

    }
}
