using System;
using System.Collections.Generic;
using System.Linq;
using BusDep.Entity;
using BusDep.UnityInject;
using NHibernate.Linq;

namespace BusDep.DataAccess
{
    using BusDep.IDataAccess;
    using ViewModel;

    public class JugadorDA : BaseDataAccess<Jugador>, IJugadorDA
    {
        public virtual Puesto ObtenerPuesto(long puestoId)
        {
            return DependencyFactory.Resolve<IBaseDA<Puesto>>().GetById(puestoId);
        }


        public virtual List<Antecedente> ObtenerAntecedentes(long usuarioId)
        {
            return Session.Query<Antecedente>().Where(o => o.Usuario.Id.Equals(usuarioId)).ToList();
        }

        public List<JugadorViewModel> BuscarJugador(string[] puesto, int? edadDesde, int? edadHasta, string[] fichaje, string[] perfil, string[] pie, string nombre,
            int? pagina = null, int? cantidad = null)
        {
            if (pagina.HasValue && cantidad.HasValue && cantidad.GetValueOrDefault() > 0)
            {
                var inicio = pagina.GetValueOrDefault().Equals(1) ? 0 : (pagina.GetValueOrDefault() - 1) * cantidad;

                return (from item in Session.Query<Jugador>()
                        where ((edadDesde.HasValue) ? item.Usuario.DatosPersona.FechaNacimiento < DateTime.Now.AddYears(-edadDesde.Value) : 1.Equals(1))
                            && ((edadHasta.HasValue) ? item.Usuario.DatosPersona.FechaNacimiento > DateTime.Now.AddYears(-edadHasta.Value) : 1.Equals(1))
                            && ((puesto != null && puesto.Length > 0) ? (puesto.Length.Equals(1)? item.Puesto.Descripcion.Equals(puesto[0]) : puesto.Contains(item.Puesto.Descripcion)) : 1.Equals(1))
                            && ((fichaje != null && fichaje.Length > 0) ? (fichaje.Length.Equals(1)? item.Fichaje.Equals(fichaje[0]) : fichaje.Contains(item.Fichaje)) : 1.Equals(1))
                            && ((perfil != null && perfil.Length > 0) ? (perfil.Length.Equals(1) ? item.Perfil.Equals(perfil[0]) : perfil.Contains(item.Perfil)) : 1.Equals(1))
                            && ((pie != null && pie.Length > 0) ? (pie.Length.Equals(1)? item.Pie.Equals(pie[0]): pie.Contains(item.Pie)) : 1.Equals(1))
                            && ((!string.IsNullOrWhiteSpace(nombre)) ? item.Usuario.DatosPersona.Nombre.ToUpper().Contains(nombre.ToUpper()) ||
                                                                      item.Usuario.DatosPersona.Apellido.ToUpper().Contains(nombre.ToUpper())
                                                                    : 1.Equals(1))
                        select new JugadorViewModel
                        {
                            Apellido = item.Usuario.DatosPersona.Apellido,
                            ClubActual = item.ClubDescripcion,
                            LogClubActual = item.ClubLogo,
                            Fichaje = item.Fichaje,
                            FotoRostro = item.FotoRostro,
                            Id = item.Id,
                            Nacionalidad = item.Usuario.DatosPersona.Nacionalidad,
                            Nacionalidad1 = item.Usuario.DatosPersona.Nacionalidad1,
                            NacionalidadIso = item.Usuario.DatosPersona.NacionalidadIso,
                            NacionalidadIso1 = item.Usuario.DatosPersona.NacionalidadIso1,
                            FechaNacimiento = item.Usuario.DatosPersona.FechaNacimiento,
                            Informacion = item.Usuario.DatosPersona.Informacion,
                            Pais = item.Usuario.DatosPersona.Pais,
                            PaisIso = item.Usuario.DatosPersona.PaisIso,
                            Nombre = item.Usuario.DatosPersona.Nombre,
                            Perfil = item.Perfil,
                            Pie = item.Pie,
                            PuestoDescripcion = item.Puesto.PuestoEspecifico,
                            Altura = item.Altura,
                            Peso = item.Peso,
                            FotoCuertoEntero = item.FotoCuertoEntero,
                            PuestoId = item.Puesto != null ? item.Puesto.Id : (long?)null,
                            UsuarioId = item.Usuario.Id
                        }).Skip(inicio.GetValueOrDefault()).Take(cantidad.GetValueOrDefault()).ToList();
            }
            else
            {
                return (from item in Session.Query<Jugador>()
                        where ((edadDesde.HasValue) ? item.Usuario.DatosPersona.FechaNacimiento < DateTime.Now.AddYears(-edadDesde.Value) : 1.Equals(1))
                                   && ((edadHasta.HasValue) ? item.Usuario.DatosPersona.FechaNacimiento > DateTime.Now.AddYears(-edadHasta.Value) : 1.Equals(1))
                                   && ((puesto != null && puesto.Length > 0) ? (puesto.Length.Equals(1) ? item.Puesto.Descripcion.Equals(puesto[0]) : puesto.Contains(item.Puesto.Descripcion)) : 1.Equals(1))
                                   && ((fichaje != null && fichaje.Length > 0) ? (fichaje.Length.Equals(1) ? item.Fichaje.Equals(fichaje[0]) : fichaje.Contains(item.Fichaje)) : 1.Equals(1))
                                   && ((perfil != null && perfil.Length > 0) ? (perfil.Length.Equals(1) ? item.Perfil.Equals(perfil[0]) : perfil.Contains(item.Perfil)) : 1.Equals(1))
                                   && ((pie != null && pie.Length > 0) ? (pie.Length.Equals(1) ? item.Pie.Equals(pie[0]) : pie.Contains(item.Pie)) : 1.Equals(1))
                                   && ((!string.IsNullOrWhiteSpace(nombre)) ? item.Usuario.DatosPersona.Nombre.ToUpper().Contains(nombre.ToUpper()) ||
                                                                             item.Usuario.DatosPersona.Apellido.ToUpper().Contains(nombre.ToUpper())
                                                                           : 1.Equals(1))
                        select new JugadorViewModel
                 {
                     Apellido = item.Usuario.DatosPersona.Apellido,
                     ClubActual = item.ClubDescripcion,
                     LogClubActual = item.ClubLogo,
                     Fichaje = item.Fichaje,
                     FotoRostro = item.FotoRostro,
                     Id = item.Id,
                     Nacionalidad = item.Usuario.DatosPersona.Nacionalidad,
                     Nacionalidad1 = item.Usuario.DatosPersona.Nacionalidad1,
                     NacionalidadIso = item.Usuario.DatosPersona.NacionalidadIso,
                     NacionalidadIso1 = item.Usuario.DatosPersona.NacionalidadIso1,
                     FechaNacimiento = item.Usuario.DatosPersona.FechaNacimiento,
                     Informacion = item.Usuario.DatosPersona.Informacion,
                     Pais = item.Usuario.DatosPersona.Pais,
                     PaisIso = item.Usuario.DatosPersona.PaisIso,
                     Nombre = item.Usuario.DatosPersona.Nombre,
                     Perfil = item.Perfil,
                     Pie = item.Pie,
                     PuestoDescripcion = item.Puesto.PuestoEspecifico,
                     Altura = item.Altura,
                     Peso = item.Peso,
                     FotoCuertoEntero = item.FotoCuertoEntero,
                     PuestoId = item.Puesto != null ? item.Puesto.Id : (long?)null,
                     UsuarioId = item.Usuario.Id
                 }).ToList();

            }

        }
        public JugadorViewModel ObtenerJugador(long id)
        {
            return (from item in Session.Query<Jugador>()
                    where item.Id.Equals(id)
                    select new JugadorViewModel
                    {
                        Apellido = item.Usuario.DatosPersona.Apellido,
                        ClubActual = item.ClubDescripcion,
                        LogClubActual = item.ClubLogo,
                        Fichaje = item.Fichaje,
                        FotoRostro = item.FotoRostro,
                        Id = item.Id,
                        Nacionalidad = item.Usuario.DatosPersona.Nacionalidad,
                        Nacionalidad1 = item.Usuario.DatosPersona.Nacionalidad1,
                        NacionalidadIso = item.Usuario.DatosPersona.NacionalidadIso,
                        NacionalidadIso1 = item.Usuario.DatosPersona.NacionalidadIso1,
                        FechaNacimiento = item.Usuario.DatosPersona.FechaNacimiento,
                        Informacion = item.Usuario.DatosPersona.Informacion,
                        Pais = item.Usuario.DatosPersona.Pais,
                        PaisIso = item.Usuario.DatosPersona.PaisIso,
                        Nombre = item.Usuario.DatosPersona.Nombre,
                        Perfil = item.Perfil,
                        Pie = item.Pie,
                        PuestoDescripcion = item.Puesto.PuestoEspecifico,
                        Altura = item.Altura,
                        Peso = item.Peso,
                        FotoCuertoEntero = item.FotoCuertoEntero,
                        PuestoId = item.Puesto!=null? item.Puesto.Id : (long?)null,
                        UsuarioId = item.Usuario.Id
                    }).FirstOrDefault();

        }

        public long BuscarJugadorCount(string[] puesto, int? edadDesde, int? edadHasta, string[] fichaje, string[] perfil, string[] pie, string nombre,
            int? pagina = null, int? cantidad = null)
        {

            return  (from item in Session.Query<Jugador>()
                where
                    ((edadDesde.HasValue)
                        ? item.Usuario.DatosPersona.FechaNacimiento < DateTime.Now.AddYears(-edadDesde.Value)
                        : 1.Equals(1))
                    &&
                    ((edadHasta.HasValue)
                        ? item.Usuario.DatosPersona.FechaNacimiento > DateTime.Now.AddYears(-edadHasta.Value)
                        : 1.Equals(1))
                    && ((puesto != null && puesto.Length > 0) ? puesto.Contains(item.Puesto.Descripcion) : 1.Equals(1))
                    && ((fichaje != null && fichaje.Length > 0) ? fichaje.Contains(item.Fichaje) : 1.Equals(1))
                    && ((perfil != null && perfil.Length > 0) ? perfil.Contains(item.Perfil) : 1.Equals(1))
                    && ((pie != null && pie.Length > 0) ? pie.Contains(item.Pie) : 1.Equals(1))
                    &&
                    ((!string.IsNullOrWhiteSpace(nombre))
                        ? item.Usuario.DatosPersona.Nombre.ToUpper().Contains(nombre.ToUpper()) ||
                          item.Usuario.DatosPersona.Apellido.ToUpper().Contains(nombre.ToUpper())
                        : 1.Equals(1))
                select item).Count();


        }
    }
}
