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
            return BuscarJugador(new[] { puesto }, edadDesde, edadHasta, new[] { fichaje }, new[] { perfil }, new[] { pie }, nombre, null, null);
        }



        public List<JugadorBusquedaDTO> BuscarJugador(string[] puesto, int? edadDesde, int? edadHasta, string[] fichaje, string[] perfil, string[] pie, string nombre,
            int? pagina = null, int? cantidad = null)
        {

            var session = Session.Query<Jugador>();
            if (edadDesde.HasValue)
                session.Where(ju => ju.Usuario.DatosPersona.FechaNacimiento < DateTime.Now.AddYears(-edadDesde.Value));
            if (edadHasta.HasValue)
                session.Where(ju => ju.Usuario.DatosPersona.FechaNacimiento > DateTime.Now.AddYears(-edadHasta.Value));
            if (puesto != null && puesto.Length > 0)
                session.Where(ju => puesto.Contains(ju.Puesto.Descripcion));
            if (fichaje != null && fichaje.Length > 0)
                session.Where(ju => fichaje.Contains(ju.Fichaje));
            if (perfil != null && perfil.Length > 0)
                session.Where(ju => perfil.Contains(ju.Perfil));
            if (pie != null && pie.Length > 0)
                session.Where(ju => pie.Contains(ju.Pie));
            if (!string.IsNullOrWhiteSpace(nombre))
                session.Where(ju => ju.Usuario.DatosPersona.Nombre.ToUpper().Contains(nombre.ToUpper()) ||
                ju.Usuario.DatosPersona.Apellido.ToUpper().Contains(nombre.ToUpper()));
            ;
            if (pagina.HasValue && cantidad.HasValue)
            {
                var inicio = pagina.GetValueOrDefault().Equals(1) ? 0 : (pagina.GetValueOrDefault() - 1) * cantidad;

                return session.Select(ju =>
                    new JugadorBusquedaDTO
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
                        FechaNacimiento = ju.Usuario.DatosPersona.FechaNacimiento,
                        Informacion = ju.Usuario.DatosPersona.Informacion,
                        Pais = ju.Usuario.DatosPersona.Pais,
                        PaisIso = ju.Usuario.DatosPersona.PaisIso,
                        Nombre = ju.Usuario.DatosPersona.Nombre,
                        Perfil = ju.Perfil,
                        Pie = ju.Pie,
                        PuestoDescripcion = ju.Puesto.PuestoEspecifico,
                        Altura = ju.Altura,
                        Peso = ju.Peso
                    }).Skip(inicio.GetValueOrDefault()).Take(cantidad.GetValueOrDefault()).ToList();
            }
            else
            {
                return session.Select(ju =>
                    new JugadorBusquedaDTO
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
                        FechaNacimiento = ju.Usuario.DatosPersona.FechaNacimiento,
                        Informacion = ju.Usuario.DatosPersona.Informacion,
                        Pais = ju.Usuario.DatosPersona.Pais,
                        PaisIso = ju.Usuario.DatosPersona.PaisIso,
                        Nombre = ju.Usuario.DatosPersona.Nombre,
                        Perfil = ju.Perfil,
                        Pie = ju.Pie,
                        PuestoDescripcion = ju.Puesto.PuestoEspecifico,
                        Altura = ju.Altura,
                        Peso = ju.Peso
                    }).ToList();

            }

        }
    }
}
