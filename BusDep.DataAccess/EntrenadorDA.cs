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

    public class EntrenadorDA : BaseDataAccess<Entrenador>, IEntrenadorDA
    {
        


        //public virtual List<Antecedente> ObtenerAntecedentes(long usuarioId)
        //{
        //    return Session.Query<Antecedente>().Where(o => o.Usuario.Id.Equals(usuarioId)).ToList();
        //}

        //public virtual List<JugadorViewModel> BuscarJugador(string[] puesto, int? edadDesde, int? edadHasta, string[] fichaje, string[] perfil, string[] pie, string nombre,
        //    int? pagina = null, int? cantidad = null)
        //{
        //    return SearchJugador(null, puesto, edadDesde, edadHasta, fichaje, perfil, pie, nombre, pagina, cantidad);
        //}
        public virtual EntrenadorViewModel ObtenerEntrenador(long id)
        {
            var il = (from item in Session.Query<Usuario>()
                    where item.Entrenador != null && item.Entrenador.Id.Equals(id)
                    && item.Estado == "A"
                    select new EntrenadorViewModel
                    {
                        Apellido = item.DatosPersona.Apellido,
                        FotoRostro = item.Entrenador.FotoRostro,
                        Id = item.Entrenador.Id,
                        Nacionalidad = item.DatosPersona.Nacionalidad,
                        Nacionalidad1 = item.DatosPersona.Nacionalidad1,
                        NacionalidadIso = item.DatosPersona.NacionalidadIso,
                        NacionalidadIso1 = item.DatosPersona.NacionalidadIso1,
                        FechaNacimiento = item.DatosPersona.FechaNacimiento,
                        Informacion = item.DatosPersona.Informacion,
                        Pais = item.DatosPersona.Pais,
                        PaisIso = item.DatosPersona.PaisIso,
                        Nombre = item.DatosPersona.Nombre,
                        Perfil = item.Entrenador.Perfil,
                        UsuarioId = item.Id
                    }).ToList();
            return il.FirstOrDefault();

        }

        //private List<JugadorViewModel> SearchJugador(long? jugadorId, string[] puesto = null, int? edadDesde = null, int? edadHasta = null, string[] fichaje = null, string[] perfil = null, string[] pie = null, string nombre = null,
        //    int? pagina = null, int? cantidad = null)
        //{

        //    if (jugadorId.HasValue)
        //    {
        //        return (from item in Session.Query<Usuario>()
        //                where item.Jugador != null && item.Jugador.Id.Equals(jugadorId.Value)
        //                //&& item.Jugador.Perfil != null && item.Jugador.Fichaje != null && item.Jugador.Perfil != "" && item.Jugador.Fichaje != ""
        //                && item.Estado == "A"
        //                select new JugadorViewModel
        //                {
        //                    Apellido = item.DatosPersona.Apellido,
        //                    ClubActual = item.Jugador.ClubDescripcion,
        //                    ClubCode = item.Jugador.ClubLogo,
        //                    Fichaje = item.Jugador.Fichaje,
        //                    FotoRostro = item.Jugador.FotoRostro,
        //                    VideoUrl = item.Jugador.VideoUrl,
        //                    Id = item.Jugador.Id,
        //                    Nacionalidad = item.DatosPersona.Nacionalidad,
        //                    Nacionalidad1 = item.DatosPersona.Nacionalidad1,
        //                    NacionalidadIso = item.DatosPersona.NacionalidadIso,
        //                    NacionalidadIso1 = item.DatosPersona.NacionalidadIso1,
        //                    FechaNacimiento = item.DatosPersona.FechaNacimiento,
        //                    Informacion = item.DatosPersona.Informacion,
        //                    Pais = item.DatosPersona.Pais,
        //                    PaisIso = item.DatosPersona.PaisIso,
        //                    Nombre = item.DatosPersona.Nombre,
        //                    Perfil = item.Jugador.Perfil,
        //                    Pie = item.Jugador.Pie,
        //                    Altura = item.Jugador.Altura,
        //                    Peso = item.Jugador.Peso,
        //                    FotoCuertoEntero = item.Jugador.FotoCuertoEntero,
        //                    PuestoId = item.Jugador.Puesto != null ? item.Jugador.Puesto.Id : (long?)null,
        //                    PuestoCodigo = item.Jugador.Puesto != null ? item.Jugador.Puesto.Codigo : null,
        //                    PuestoDescripcion = item.Jugador.Puesto != null ? item.Jugador.Puesto.PuestoEspecifico : null,
        //                    PuestoAltId = item.Jugador.PuestoAlternativo != null ? item.Jugador.PuestoAlternativo.Id : (long?)null,
        //                    PuestoAltCodigo = item.Jugador.PuestoAlternativo != null ? item.Jugador.PuestoAlternativo.Codigo : null,
        //                    PuestoAltDescripcion = item.Jugador.PuestoAlternativo != null ? item.Jugador.PuestoAlternativo.PuestoEspecifico : null,
        //                    UsuarioId = item.Id
        //                }).ToList();
        //    }
        //    if (pagina.HasValue && cantidad.HasValue && cantidad.GetValueOrDefault() > 0)
        //    {
        //        var inicio = pagina.GetValueOrDefault().Equals(1) ? 0 : (pagina.GetValueOrDefault() - 1) * cantidad;

        //        return (from item in Session.Query<Usuario>()
        //                where item.Jugador != null
        //                && item.Jugador.Perfil != null && item.Jugador.Fichaje != null && item.Jugador.Perfil != "" && item.Jugador.Fichaje != ""
        //                && item.Estado == "A" 
        //                && item.DatosPersona.Pais!=null && item.Jugador.Puesto.Codigo!=null && item.DatosPersona.FechaNacimiento!=null
        //                    && ((edadDesde.HasValue) ? item.DatosPersona.FechaNacimiento < DateTime.Now.AddYears(-edadDesde.Value) : 1.Equals(1))
        //                    && ((edadHasta.HasValue) ? item.DatosPersona.FechaNacimiento > DateTime.Now.AddYears(-edadHasta.Value) : 1.Equals(1))
        //                    && ((puesto != null && puesto.Length > 0) ? (puesto.Length.Equals(1) ? item.Jugador.Puesto.Descripcion.Equals(puesto[0]) : puesto.Contains(item.Jugador.Puesto.Descripcion)) : 1.Equals(1))
        //                    && ((fichaje != null && fichaje.Length > 0) ? (fichaje.Length.Equals(1) ? item.Jugador.Fichaje.Equals(fichaje[0]) : fichaje.Contains(item.Jugador.Fichaje)) : 1.Equals(1))
        //                    && ((perfil != null && perfil.Length > 0) ? (perfil.Length.Equals(1) ? item.Jugador.Perfil.Equals(perfil[0]) : perfil.Contains(item.Jugador.Perfil)) : 1.Equals(1))
        //                    && ((pie != null && pie.Length > 0) ? (pie.Length.Equals(1) ? item.Jugador.Pie.Equals(pie[0]) : pie.Contains(item.Jugador.Pie)) : 1.Equals(1))
        //                    && ((!string.IsNullOrEmpty(nombre)) ? item.DatosPersona.Nombre.ToUpper().Contains(nombre.ToUpper()) ||
        //                                                              item.DatosPersona.Apellido.ToUpper().Contains(nombre.ToUpper())
        //                                                            : 1.Equals(1))
        //                orderby item.Jugador.Id descending
        //                select new JugadorViewModel
        //                {
        //                    Apellido = item.DatosPersona.Apellido,
        //                    ClubActual = item.Jugador.ClubDescripcion,
        //                    ClubCode = item.Jugador.ClubLogo,
        //                    Fichaje = item.Jugador.Fichaje,
        //                    FotoRostro = item.Jugador.FotoRostro,
        //                    Id = item.Jugador.Id,
        //                    Nacionalidad = item.DatosPersona.Nacionalidad,
        //                    Nacionalidad1 = item.DatosPersona.Nacionalidad1,
        //                    NacionalidadIso = item.DatosPersona.NacionalidadIso,
        //                    NacionalidadIso1 = item.DatosPersona.NacionalidadIso1,
        //                    FechaNacimiento = item.DatosPersona.FechaNacimiento,
        //                    Informacion = item.DatosPersona.Informacion,
        //                    Pais = item.DatosPersona.Pais,
        //                    PaisIso = item.DatosPersona.PaisIso,
        //                    Nombre = item.DatosPersona.Nombre,
        //                    Perfil = item.Jugador.Perfil,
        //                    Pie = item.Jugador.Pie,
        //                    Altura = item.Jugador.Altura,
        //                    Peso = item.Jugador.Peso,
        //                    FotoCuertoEntero = item.Jugador.FotoCuertoEntero,
        //                    PuestoId = item.Jugador.Puesto != null ? item.Jugador.Puesto.Id : (long?)null,
        //                    PuestoCodigo = item.Jugador.Puesto != null ? item.Jugador.Puesto.Codigo : null,
        //                    PuestoDescripcion = item.Jugador.Puesto != null ? item.Jugador.Puesto.PuestoEspecifico : null,
        //                    PuestoAltId = item.Jugador.PuestoAlternativo != null ? item.Jugador.PuestoAlternativo.Id : (long?)null,
        //                    PuestoAltCodigo = item.Jugador.PuestoAlternativo != null ? item.Jugador.PuestoAlternativo.Codigo : null,
        //                    PuestoAltDescripcion = item.Jugador.PuestoAlternativo != null ? item.Jugador.PuestoAlternativo.PuestoEspecifico : null,
        //                    UsuarioId = item.Id
        //                }).Skip(inicio.GetValueOrDefault()).Take(cantidad.GetValueOrDefault()).ToList();
        //    }
        //    else
        //    {
        //        return (from item in Session.Query<Usuario>()
        //                where item.Jugador != null
        //                && item.Jugador.Perfil != null && item.Jugador.Fichaje != null && item.Jugador.Perfil != "" && item.Jugador.Fichaje != ""
        //                && item.Estado == "A"
        //                && item.DatosPersona.Pais != null && item.Jugador.Puesto.Codigo != null && item.DatosPersona.FechaNacimiento != null
        //                    && ((edadDesde.HasValue) ? item.DatosPersona.FechaNacimiento < DateTime.Now.AddYears(-edadDesde.Value) : 1.Equals(1))
        //                    && ((edadHasta.HasValue) ? item.DatosPersona.FechaNacimiento > DateTime.Now.AddYears(-edadHasta.Value) : 1.Equals(1))
        //                    && ((puesto != null && puesto.Length > 0) ? (puesto.Length.Equals(1) ? item.Jugador.Puesto.Descripcion.Equals(puesto[0]) : puesto.Contains(item.Jugador.Puesto.Descripcion)) : 1.Equals(1))
        //                    && ((fichaje != null && fichaje.Length > 0) ? (fichaje.Length.Equals(1) ? item.Jugador.Fichaje.Equals(fichaje[0]) : fichaje.Contains(item.Jugador.Fichaje)) : 1.Equals(1))
        //                    && ((perfil != null && perfil.Length > 0) ? (perfil.Length.Equals(1) ? item.Jugador.Perfil.Equals(perfil[0]) : perfil.Contains(item.Jugador.Perfil)) : 1.Equals(1))
        //                    && ((pie != null && pie.Length > 0) ? (pie.Length.Equals(1) ? item.Jugador.Pie.Equals(pie[0]) : pie.Contains(item.Jugador.Pie)) : 1.Equals(1))
        //                    && ((!string.IsNullOrEmpty(nombre)) ? item.DatosPersona.Nombre.ToUpper().Contains(nombre.ToUpper()) ||
        //                                                              item.DatosPersona.Apellido.ToUpper().Contains(nombre.ToUpper())
        //                                                            : 1.Equals(1))
        //                orderby item.Jugador.Id descending
        //                select new JugadorViewModel
        //                {
        //                    Apellido = item.DatosPersona.Apellido,
        //                    ClubActual = item.Jugador.ClubDescripcion,
        //                    ClubCode = item.Jugador.ClubLogo,
        //                    Fichaje = item.Jugador.Fichaje,
        //                    FotoRostro = item.Jugador.FotoRostro,
        //                    Id = item.Jugador.Id,
        //                    Nacionalidad = item.DatosPersona.Nacionalidad,
        //                    Nacionalidad1 = item.DatosPersona.Nacionalidad1,
        //                    NacionalidadIso = item.DatosPersona.NacionalidadIso,
        //                    NacionalidadIso1 = item.DatosPersona.NacionalidadIso1,
        //                    FechaNacimiento = item.DatosPersona.FechaNacimiento,
        //                    Informacion = item.DatosPersona.Informacion,
        //                    Pais = item.DatosPersona.Pais,
        //                    PaisIso = item.DatosPersona.PaisIso,
        //                    Nombre = item.DatosPersona.Nombre,
        //                    Perfil = item.Jugador.Perfil,
        //                    Pie = item.Jugador.Pie,
        //                    Altura = item.Jugador.Altura,
        //                    Peso = item.Jugador.Peso,
        //                    FotoCuertoEntero = item.Jugador.FotoCuertoEntero,
        //                    PuestoId = item.Jugador.Puesto != null ? item.Jugador.Puesto.Id : (long?)null,
        //                    PuestoCodigo = item.Jugador.Puesto != null ? item.Jugador.Puesto.Codigo : null,
        //                    PuestoDescripcion = item.Jugador.Puesto != null ? item.Jugador.Puesto.PuestoEspecifico : null,
        //                    PuestoAltId = item.Jugador.PuestoAlternativo != null ? item.Jugador.PuestoAlternativo.Id : (long?)null,
        //                    PuestoAltCodigo = item.Jugador.PuestoAlternativo != null ? item.Jugador.PuestoAlternativo.Codigo : null,
        //                    PuestoAltDescripcion = item.Jugador.PuestoAlternativo != null ? item.Jugador.PuestoAlternativo.PuestoEspecifico : null,
        //                    UsuarioId = item.Id
        //                }).ToList();

        //    }

        //}

        //public virtual long BuscarJugadorCount(string[] puesto, int? edadDesde, int? edadHasta, string[] fichaje, string[] perfil, string[] pie, string nombre,
        //    int? pagina = null, int? cantidad = null)
        //{

        //    return (from item in Session.Query<Usuario>()
        //            where item.Jugador != null
        //            && item.Jugador.Perfil != null && item.Jugador.Fichaje != null && item.Jugador.Perfil != "" && item.Jugador.Fichaje != ""
        //            && item.Estado == "A"
        //            && item.DatosPersona.Pais != null && item.Jugador.Puesto.Codigo != null && item.DatosPersona.FechaNacimiento != null
        //            && ((edadDesde.HasValue)
        //                    ? item.DatosPersona.FechaNacimiento < DateTime.Now.AddYears(-edadDesde.Value)
        //                    : 1.Equals(1))
        //                &&
        //                ((edadHasta.HasValue)
        //                    ? item.DatosPersona.FechaNacimiento > DateTime.Now.AddYears(-edadHasta.Value)
        //                    : 1.Equals(1))
        //                && ((puesto != null && puesto.Length > 0) ? puesto.Contains(item.Jugador.Puesto.Descripcion) : 1.Equals(1))
        //                && ((fichaje != null && fichaje.Length > 0) ? fichaje.Contains(item.Jugador.Fichaje) : 1.Equals(1))
        //                && ((perfil != null && perfil.Length > 0) ? perfil.Contains(item.Jugador.Perfil) : 1.Equals(1))
        //                && ((pie != null && pie.Length > 0) ? pie.Contains(item.Jugador.Pie) : 1.Equals(1))
        //                &&
        //                ((!string.IsNullOrEmpty(nombre))
        //                    ? item.DatosPersona.Nombre.ToUpper().Contains(nombre.ToUpper()) ||
        //                      item.DatosPersona.Apellido.ToUpper().Contains(nombre.ToUpper())
        //                    : 1.Equals(1))
        //            select item).Count();
        //}

        //public virtual bool ExisteJugador(long id)
        //{
        //    return !Session.Query<Jugador>().Count(o => o.Id.Equals(id)).Equals(0);
        //}

        //public virtual PerfilJugadorShortViewModel GetPerfilJugadorShort(long jugadorId)
        //{
        //    return (from item in Session.Query<Usuario>()
        //            where item.Jugador.Id.Equals(jugadorId)
        //            //&& item.Jugador.Perfil != null && item.Jugador.Fichaje != null && item.Jugador.Perfil != "" && item.Jugador.Fichaje != ""
        //            && item.Estado == "A"
        //            select new PerfilJugadorShortViewModel
        //            {
        //                Id = item.Jugador.Id,
        //                Altura = item.Jugador.Altura,
        //                Apellido = item.DatosPersona.Apellido,
        //                Pais = item.DatosPersona.Pais,
        //                PaisIso = item.DatosPersona.PaisIso,
        //                FotoRostro = item.Jugador.FotoRostro,
        //                ClubActual = item.Jugador.ClubDescripcion,
        //                FechaNacimiento = item.DatosPersona.FechaNacimiento,
        //                Peso = item.Jugador.Peso,
        //                Nombre = item.DatosPersona.Nombre,
        //                NacionalidadIso = item.DatosPersona.NacionalidadIso,
        //                Nacionalidad = item.DatosPersona.Nacionalidad,
        //                NacionalidadIso1 = item.DatosPersona.NacionalidadIso1,
        //                Nacionalidad1 = item.DatosPersona.Nacionalidad1,
        //                Perfil = item.Jugador.Perfil,
        //                ClubCode = item.Jugador.ClubLogo,
        //                Pie = item.Jugador.Pie,
        //                Provincia = item.DatosPersona.Provincia,
        //                Ciudad = item.DatosPersona.Ciudad,
        //                Puesto = item.Jugador.Puesto != null ? item.Jugador.Puesto.PuestoEspecifico : null,
        //                PuestoCode = item.Jugador.Puesto != null ? item.Jugador.Puesto.Codigo : null,
        //                PuestoAlt = item.Jugador.Puesto != null ? item.Jugador.PuestoAlternativo.PuestoEspecifico : null,
        //                PuestoAltCode = item.Jugador.Puesto != null ? item.Jugador.PuestoAlternativo.Codigo : null
        //            }).FirstOrDefault();
        //}

        //public virtual List<JugadorViewModel> TopJugador()
        //{

        //    return (from item in Session.Query<Usuario>()
        //            where item.Jugador != null
        //            && item.Jugador.Perfil != null && item.Jugador.Fichaje != null && item.Jugador.Perfil != "" && item.Jugador.Fichaje != ""
        //            && item.Estado == "A"
        //            && item.DatosPersona.Pais != null && item.Jugador.Puesto.Codigo != null
        //            orderby item.Jugador.Id descending
        //            select new JugadorViewModel
        //            {
        //                Apellido = item.DatosPersona.Apellido,
        //                ClubActual = item.Jugador.ClubDescripcion,
        //                ClubCode = item.Jugador.ClubLogo,
        //                Fichaje = item.Jugador.Fichaje,
        //                FotoRostro = item.Jugador.FotoRostro,
        //                Id = item.Jugador.Id,
        //                Nacionalidad = item.DatosPersona.Nacionalidad,
        //                Nacionalidad1 = item.DatosPersona.Nacionalidad1,
        //                NacionalidadIso = item.DatosPersona.NacionalidadIso,
        //                NacionalidadIso1 = item.DatosPersona.NacionalidadIso1,
        //                FechaNacimiento = item.DatosPersona.FechaNacimiento,
        //                Informacion = item.DatosPersona.Informacion,
        //                Pais = item.DatosPersona.Pais,
        //                PaisIso = item.DatosPersona.PaisIso,
        //                Nombre = item.DatosPersona.Nombre,
        //                Perfil = item.Jugador.Perfil,
        //                Pie = item.Jugador.Pie,
        //                Altura = item.Jugador.Altura,
        //                Peso = item.Jugador.Peso,
        //                FotoCuertoEntero = item.Jugador.FotoCuertoEntero,
        //                PuestoId = item.Jugador.Puesto != null ? item.Jugador.Puesto.Id : (long?)null,
        //                PuestoCodigo = item.Jugador.Puesto != null ? item.Jugador.Puesto.Codigo : null,
        //                PuestoDescripcion = item.Jugador.Puesto != null ? item.Jugador.Puesto.PuestoEspecifico : null,
        //                PuestoAltId = item.Jugador.PuestoAlternativo != null ? item.Jugador.PuestoAlternativo.Id : (long?)null,
        //                PuestoAltCodigo = item.Jugador.PuestoAlternativo != null ? item.Jugador.PuestoAlternativo.Codigo : null,
        //                PuestoAltDescripcion = item.Jugador.PuestoAlternativo != null ? item.Jugador.PuestoAlternativo.PuestoEspecifico : null,
        //                UsuarioId = item.Id
        //            }).Take(10).ToList();
        //}

        //public virtual List<AntecedenteViewModel> GetAntecedentes(long jugadorId)
        //{
        //    return (from ant in Session.Query<Antecedente>()
        //            where ant.Usuario.Jugador.Id.Equals(jugadorId)
        //            orderby ant.FechaInicio descending
        //            select
        //            new AntecedenteViewModel
        //            {
        //                Asistencias = ant.Asistencias,
        //                ClubDescripcion = ant.ClubDescripcion,
        //                ClubLogo = ant.ClubLogo,
        //                FechaFin = ant.FechaFin,
        //                FechaInicio = ant.FechaInicio,
        //                Goles = ant.Goles,
        //                Id = ant.Id,
        //                InformacionAdicional = ant.InformacionAdicional,
        //                Partidos = ant.Partidos,
        //                UsuarioId = ant.Usuario.Id,
        //                Video = ant.Video,
        //                Puesto = ant.Puesto,
        //                PuestoAlt = ant.PuestoAlt,
        //                TecnicoMail = ant.TecnicoMail,
        //                TecnicoNombre = ant.TecnicoNombre,
        //                TextoLibre = ant.TextoLibre

        //            }).ToList();
        //}
        //public virtual EvaluacionViewModel ObtenerEvaluacionViewModelDefault(long jugadorId)
        //{

        //    var list = (from det in Session.Query<EvaluacionDetalle>()
        //                where det.EvaluacionCabecera.Evaluacion.Usuario.Jugador.Id.Equals(jugadorId)
        //               && det.EvaluacionCabecera.Evaluacion.TipoEvaluacion.EsDefault.Equals("S")
        //               && det.EvaluacionCabecera.Evaluacion.TipoEvaluacion.TipoUsuario == det.EvaluacionCabecera.Evaluacion.Usuario.TipoUsuario
        //                select new
        //                {
        //                    Id = det.EvaluacionCabecera.Evaluacion.Id,
        //                    JugadorId = det.EvaluacionCabecera.Evaluacion.Usuario.Id,
        //                    TipoEvaluacionId = det.EvaluacionCabecera.Evaluacion.TipoEvaluacion.Id,
        //                    Descripcion = det.EvaluacionCabecera.Evaluacion.TipoEvaluacion.Descripcion,
        //                    Chart = det.EvaluacionCabecera.TemplateEvaluacion.Chart,
        //                    CabeceraId = det.EvaluacionCabecera.Id,
        //                    CabeceraDescripcion = det.EvaluacionCabecera.TemplateEvaluacion.Descripcion,
        //                    DetalleId = det.Id,
        //                    DetalleDescripcion = det.TemplateEvaluacionDetalle.Descripcion,
        //                    DetallePuntuacion = det.Puntuacion
        //                }).ToList();
        //    List<EvaluacionViewModel> listEvo = list.Select(o => new { o.Id, o.JugadorId, o.TipoEvaluacionId, o.Descripcion, }).Distinct().Select(i => new EvaluacionViewModel
        //    {
        //        Id = i.Id,
        //        JugadorId = i.JugadorId,
        //        TipoEvaluacionId = i.TipoEvaluacionId,
        //        Descripcion = i.Descripcion,
        //        Cabeceras = (from cab in list.Select(c => new { c.Id, c.CabeceraId, c.CabeceraDescripcion, c.Chart }).Distinct()
        //                     where cab.Id.Equals(i.Id)
        //                     select new EvaluacionCabeceraViewModel
        //                     {
        //                         Id = cab.CabeceraId,
        //                         Descripcion = cab.CabeceraDescripcion,
        //                         Chart = cab.Chart,
        //                         Detalle = (from det in list.Where(r => r.Id.Equals(i.Id) && r.CabeceraId.Equals(cab.CabeceraId))
        //                                    select new EvaluacionDetalleViewModel
        //                                    {
        //                                        Id = det.DetalleId,
        //                                        Descripcion = det.DetalleDescripcion,
        //                                        Puntuacion = det.DetallePuntuacion
        //                                    }).ToList()
        //                     }).ToList()
        //    }).ToList();

        //    foreach (var evalu in listEvo)
        //    {
        //        foreach (var cab in evalu.Cabeceras)
        //        {
        //            decimal canResp = cab.Detalle.Count(o => o.Puntuacion.HasValue);
        //            decimal puntos = cab.Detalle.Where(o => o.Puntuacion.HasValue).Sum(i => i.Puntuacion.GetValueOrDefault());
        //            if (canResp > 0 && puntos > 0)
        //                cab.Promedio = Decimal.Round(puntos / canResp, 2);
        //        }
        //    }
        //    return listEvo.FirstOrDefault();
        //}

        //public virtual PerfilJugadorViewModel ObtenerPerfil(long jugadorId)
        //{

        //    return (from item in Session.Query<Usuario>()
        //            where item.Jugador != null && item.Jugador.Id.Equals(jugadorId)
        //            && item.Jugador.Perfil != null && item.Jugador.Fichaje != null && item.Jugador.Perfil != "" && item.Jugador.Fichaje != ""
        //            && item.Estado == "A"
        //            select new PerfilJugadorViewModel
        //            {
        //                PerfilId = item.Jugador.Id,
        //                Mail = item.Mail,
        //                Nombre = item.DatosPersona.Nombre,
        //                Apellido = item.DatosPersona.Apellido,
        //                FechaNacimiento = item.DatosPersona.FechaNacimiento,
        //                Pais = item.DatosPersona.Pais,
        //                PaisIso = item.DatosPersona.PaisIso,
        //                Nacionalidad = item.DatosPersona.Nacionalidad,
        //                Nacionalidad1 = item.DatosPersona.Nacionalidad1,
        //                NacionalidadIso = item.DatosPersona.NacionalidadIso,
        //                NacionalidadIso1 = item.DatosPersona.NacionalidadIso1,
        //                Altura = item.Jugador.Altura,
        //                FotoCuertoEntero = item.Jugador.FotoCuertoEntero,
        //                FotoRostro = item.Jugador.FotoRostro,
        //                Perfil = item.Jugador.Perfil,
        //                Peso = item.Jugador.Peso,
        //                PuestoDescripcion = item.Jugador.Puesto.Descripcion,
        //                PuestoEspecifico = item.Jugador.Puesto.PuestoEspecifico,
        //                PuestoCodigo = item.Jugador.Puesto.Codigo,
        //                PuestoAlterDescripcion = item.Jugador.PuestoAlternativo.Descripcion,
        //                PuestoAlterEspecifico = item.Jugador.PuestoAlternativo.PuestoEspecifico,
        //                PuestoAlterCodigo = item.Jugador.PuestoAlternativo.Codigo,
        //                Informacion = item.DatosPersona.Informacion,
        //                Pie = item.Jugador.Pie
        //            }).FirstOrDefault();
        //}

        //public List<RecomendacionViewModel> GetRecomendaciones(int jugadorId)
        //{

        //    return (from item in Session.Query<Recomendacion>()
        //            where item.Receptor.Jugador != null
        //            && item.Receptor.Jugador.Id == jugadorId
        //            orderby item.Fecha descending
        //            select new RecomendacionViewModel
        //            {
        //                FotoRostro = item.Emisor.Jugador!=null? item.Emisor.Jugador.FotoRostro: null,
        //                Id = item.Id,
        //                Emisor = string.Format("{0} {1}", item.Emisor.DatosPersona.Nombre, item.Emisor.DatosPersona.Apellido),
        //                Texto =  item.Texto,
        //                TipoUsuario = item.Emisor.TipoUsuario.Descripcion

        //            }).Take(10).ToList();
        //}

    }
}
