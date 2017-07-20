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
                         && (edadDesde.HasValue ? ju.Usuario.DatosPersona.FechaNacimiento < DateTime.Now.AddYears(-edadDesde.Value) : 1.Equals(1))
                         && (edadHasta.HasValue ? ju.Usuario.DatosPersona.FechaNacimiento > DateTime.Now.AddYears(-edadHasta.Value) : 1.Equals(1))
                         && (string.IsNullOrWhiteSpace(pais) ? 1.Equals(1) : ju.Usuario.DatosPersona.Pais.Equals(pais))
                         && (string.IsNullOrWhiteSpace(fichaje) ? 1.Equals(1) : ju.Fichaje.ToUpper().Equals(fichaje.ToUpper()))
                         && (string.IsNullOrWhiteSpace(perfil) ? 1.Equals(1) : ju.Perfil.ToUpper().Equals(perfil.ToUpper()))
                         && (string.IsNullOrWhiteSpace(nombre) ? 1.Equals(1) :
                          ju.Usuario.DatosPersona.Nombre.ToUpper().Contains(nombre.ToUpper()) || ju.Usuario.DatosPersona.Apellido.ToUpper().Contains(nombre.ToUpper()))
                         select new JugadorBusquedaDTO
                         {
                             Apellido = ju.Usuario.DatosPersona.Apellido,
                             ClubActual = ju.ClubDescripcion,
                             LogClubActual = ju.ClubLogo,
                             Fichaje = ju.Fichaje,
                             FotoRostro = ju.FotoRostro,
                             Id = ju.Id,
                             Nacionalidad = ju.Usuario.DatosPersona.Nacionalidad,
                             Nacionalidad1 = ju.Usuario.DatosPersona.Nacionalidad1,
                             NacionalidadIso = ju.Usuario.DatosPersona.NacionalidadIso,
                             NacionalidadIso1 = ju.Usuario.DatosPersona.NacionalidadIso1,
                             Pais = ju.Usuario.DatosPersona.Pais,
                             PaisIso = ju.Usuario.DatosPersona.PaisIso,
                             Nombre = ju.Usuario.DatosPersona.Nombre,
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


        public virtual List<JugadorBusquedaDTO> BuscarJugador(string puesto, int? edadDesde, int? edadHasta, string fichaje, string perfil, string pie, string nombre)
        {

            var result = from ju in Session.Query<Jugador>()
                         where
                         (string.IsNullOrWhiteSpace(puesto) ? 1.Equals(1) : ju.Puesto.Descripcion.Equals(puesto))
                         && (edadDesde.HasValue ? ju.Usuario.DatosPersona.FechaNacimiento < DateTime.Now.AddYears(-edadDesde.Value) : 1.Equals(1))
                         && (edadHasta.HasValue ? ju.Usuario.DatosPersona.FechaNacimiento > DateTime.Now.AddYears(-edadHasta.Value) : 1.Equals(1))
                         && (string.IsNullOrWhiteSpace(fichaje) ? 1.Equals(1) : ju.Fichaje.ToUpper().Equals(fichaje.ToUpper()))
                         && (string.IsNullOrWhiteSpace(perfil) ? 1.Equals(1) : ju.Perfil.ToUpper().Equals(perfil.ToUpper()))
                         && (string.IsNullOrWhiteSpace(pie) ? 1.Equals(1) : ju.Pie.ToUpper().Equals(pie.ToUpper()))
                         && (string.IsNullOrWhiteSpace(nombre) ? 1.Equals(1) :
                          ju.Usuario.DatosPersona.Nombre.ToUpper().Contains(nombre.ToUpper()) || ju.Usuario.DatosPersona.Apellido.ToUpper().Contains(nombre.ToUpper()))
                         select new JugadorBusquedaDTO
                         {
                             Apellido = ju.Usuario.DatosPersona.Apellido,
                             ClubActual = ju.ClubDescripcion,
                             LogClubActual = ju.ClubLogo,
                             Fichaje = ju.Fichaje,
                             FotoRostro = ju.FotoRostro,
                             Id = ju.Id,
                             Nacionalidad = ju.Usuario.DatosPersona.Nacionalidad,
                             Nacionalidad1 = ju.Usuario.DatosPersona.Nacionalidad1,
                             NacionalidadIso = ju.Usuario.DatosPersona.NacionalidadIso,
                             NacionalidadIso1 = ju.Usuario.DatosPersona.NacionalidadIso1,
                             Pais = ju.Usuario.DatosPersona.Pais,
                             PaisIso = ju.Usuario.DatosPersona.PaisIso,
                             Nombre = ju.Usuario.DatosPersona.Nombre,
                             Perfil = ju.Perfil,
                             Pie = ju.Pie,
                             PuestoDescripcion = ju.Puesto.PuestoEspecifico
                         };
            return result.ToList();
        }

        public List<JugadorBusquedaDTO> BuscarJugador(string[] puesto, int? edadDesde, int? edadHasta, string[] fichaje,
            string[] perfil, string[] pie, string nombre)
        {

            var result = from ju in Session.Query<Jugador>()
                         where
                         (puesto.Length.Equals(0) ? 1.Equals(1) : puesto.Contains(ju.Puesto.Descripcion))
                         && (edadDesde.HasValue ? ju.Usuario.DatosPersona.FechaNacimiento < DateTime.Now.AddYears(-edadDesde.Value) : 1.Equals(1))
                         && (edadHasta.HasValue ? ju.Usuario.DatosPersona.FechaNacimiento > DateTime.Now.AddYears(-edadHasta.Value) : 1.Equals(1))
                          && ((fichaje == null || fichaje.Length.Equals(0)) ? 1.Equals(1) : fichaje.Contains(ju.Fichaje))
                         && ((perfil == null || perfil.Length.Equals(0)) ? 1.Equals(1) : perfil.Contains(ju.Perfil))
                         && ((pie == null || pie.Length.Equals(0)) ? 1.Equals(1) : pie.Contains(ju.Pie))
                         && (string.IsNullOrWhiteSpace(nombre) ? 1.Equals(1) :
                          ju.Usuario.DatosPersona.Nombre.ToUpper().Contains(nombre.ToUpper()) || ju.Usuario.DatosPersona.Apellido.ToUpper().Contains(nombre.ToUpper()))
                         select new JugadorBusquedaDTO
                         {
                             Apellido = ju.Usuario.DatosPersona.Apellido,
                             ClubActual = ju.ClubDescripcion,
                             LogClubActual = ju.ClubLogo,
                             Fichaje = ju.Fichaje,
                             FotoRostro = ju.FotoRostro,
                             Id = ju.Id,
                             Nacionalidad = ju.Usuario.DatosPersona.Nacionalidad,
                             Nacionalidad1 = ju.Usuario.DatosPersona.Nacionalidad1,
                             NacionalidadIso = ju.Usuario.DatosPersona.NacionalidadIso,
                             NacionalidadIso1 = ju.Usuario.DatosPersona.NacionalidadIso1,
                             Pais = ju.Usuario.DatosPersona.Pais,
                             PaisIso = ju.Usuario.DatosPersona.PaisIso,
                             Nombre = ju.Usuario.DatosPersona.Nombre,
                             Perfil = ju.Perfil,
                             Pie = ju.Pie,
                             PuestoDescripcion = ju.Puesto.PuestoEspecifico
                         };
            return result.ToList();
        }


        public List<JugadorBusquedaDTO> BuscarJugador(string[] puesto, int? edadDesde, int? edadHasta, string[] fichaje,
            string[] perfil, string[] pie, string nombre, int pagina, int cantidad)
        {
            var inicio = pagina.Equals(1) ? 0 : (pagina - 1) * cantidad;
            //var fin = inicio + cantidad;
            var result = from ju in Session.Query<Jugador>()
                         where
                         (puesto.Length.Equals(0) ? 1.Equals(1) : puesto.Contains(ju.Puesto.Descripcion))
                         && (edadDesde.HasValue ? ju.Usuario.DatosPersona.FechaNacimiento < DateTime.Now.AddYears(-edadDesde.Value) : 1.Equals(1))
                         && (edadHasta.HasValue ? ju.Usuario.DatosPersona.FechaNacimiento > DateTime.Now.AddYears(-edadHasta.Value) : 1.Equals(1))
                         && ((fichaje == null || fichaje.Length.Equals(0)) ? 1.Equals(1) : fichaje.Contains(ju.Fichaje))
                         && ((perfil == null || perfil.Length.Equals(0)) ? 1.Equals(1) : perfil.Contains(ju.Perfil))
                         && ((pie == null || pie.Length.Equals(0)) ? 1.Equals(1) : pie.Contains(ju.Pie))
                         && (string.IsNullOrWhiteSpace(nombre) ? 1.Equals(1) :
                          ju.Usuario.DatosPersona.Nombre.ToUpper().Contains(nombre.ToUpper()) || ju.Usuario.DatosPersona.Apellido.ToUpper().Contains(nombre.ToUpper()))
                         select new JugadorBusquedaDTO
                         {
                             Apellido = ju.Usuario.DatosPersona.Apellido,
                             ClubActual = ju.ClubDescripcion,
                             LogClubActual = ju.ClubLogo,
                             Fichaje = ju.Fichaje,
                             FotoRostro = ju.FotoRostro,
                             Id = ju.Id,
                             Nacionalidad = ju.Usuario.DatosPersona.Nacionalidad,
                             Nacionalidad1 = ju.Usuario.DatosPersona.Nacionalidad1,
                             NacionalidadIso = ju.Usuario.DatosPersona.NacionalidadIso,
                             NacionalidadIso1 = ju.Usuario.DatosPersona.NacionalidadIso1,
                             Pais = ju.Usuario.DatosPersona.Pais,
                             PaisIso = ju.Usuario.DatosPersona.PaisIso,
                             Nombre = ju.Usuario.DatosPersona.Nombre,
                             Perfil = ju.Perfil,
                             Pie = ju.Pie,
                             PuestoDescripcion = ju.Puesto.PuestoEspecifico
                         }

                         ;

            return result.Skip(inicio).Take(cantidad).ToList();

        }
    }
}
