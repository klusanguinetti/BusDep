﻿namespace BusDep.Business
{
    using System;
    using System.Collections.Generic;
    using BusDep.Common;
    using BusDep.IDataAccess;
    using BusDep.UnityInject;
    using BusDep.ViewModel;
    using BusDep.IBusiness;

    public class BusquedaBusiness : IBusquedaBusiness
    {
        [AuditMethod]
        public virtual PerfilJugadorViewModel ObtenerPerfil(long jugadorId)
        {
            if (!DependencyFactory.Resolve<IJugadorDA>().ExisteJugador(jugadorId))
                throw new ExceptionBusiness(40, "No existe jugador");
            PerfilJugadorViewModel perfil = new PerfilJugadorViewModel { PerfilId = jugadorId };
            var jugador = DependencyFactory.Resolve<IJugadorDA>().GetById(jugadorId);
            if (jugador == null)
                return null;
            //UsuarioViewModel usuario = new UsuarioViewModel
            //{
            //    Id = jugador.Usuario.Id,
            //    DeporteId = jugador.Usuario.Deporte.Id,
            //    JugadorId = jugador.Id
            //};
            jugador.MapperClass(perfil, TypeMapper.IgnoreCaseSensitive);
            jugador.Usuario.MapperClass(perfil, TypeMapper.IgnoreCaseSensitive);
            jugador.Usuario.DatosPersona.MapperClass(perfil, TypeMapper.IgnoreCaseSensitive);
            if (jugador.Puesto != null)
            {
                perfil.PuestoDescripcion = jugador.Puesto.Descripcion;
                perfil.PuestoEspecifico = jugador.Puesto.PuestoEspecifico;
                perfil.PuestoCodigo = jugador.Puesto.Codigo;
            }
            if (jugador.PuestoAlternativo != null)
            {
                perfil.PuestoAlterDescripcion = jugador.PuestoAlternativo.Descripcion;
                perfil.PuestoAlterEspecifico = jugador.PuestoAlternativo.PuestoEspecifico;
                perfil.PuestoAlterCodigo = jugador.PuestoAlternativo.Codigo;
            }
            //perfil.Antecedentes = DependencyFactory.Resolve<IUsuarioDA>().ObtenerAntecedentes(jugador.Usuario.Id);
            //perfil.AutoEvaluacion = DependencyFactory.Resolve<IUsuarioJugadorBusiness>().ObtenerEvaluacionViewModel(usuario);
            return perfil;
        }

        [AuditMethod]
        public virtual List<JugadorViewModel> BuscarJugador(BuscarJugadorViewModel buscar)
        {
            return DependencyFactory.Resolve<IJugadorDA>()
                .BuscarJugador(buscar.Puesto, buscar.EdadDesde, buscar.EdadHasta, buscar.Fichaje, buscar.Perfil, buscar.Pie, buscar.Nombre,
                buscar.Pagina.GetValueOrDefault(), buscar.Cantidad.GetValueOrDefault());
        }


        public virtual List<JugadorViewModel> TopJugador()
        {
            return DependencyFactory.Resolve<IJugadorDA>().TopJugador();
        }

        [AuditMethod]
        public virtual long BuscarJugadorCount(BuscarJugadorViewModel buscar)
        {
            return DependencyFactory.Resolve<IJugadorDA>()
                .BuscarJugadorCount(buscar.Puesto, buscar.EdadDesde, buscar.EdadHasta, buscar.Fichaje, buscar.Perfil, buscar.Pie, buscar.Nombre);
        }

        public virtual PerfilJugadorShortViewModel GetPerfilJugadorShort(UsuarioViewModel usuario)
        {
            return DependencyFactory.Resolve<IJugadorDA>().GetPerfilJugadorShort(usuario.JugadorId.Value);
        }

        public virtual EvaluacionViewModel GetAutoEvaluacionDefault(long jugadorId)
        {
            return DependencyFactory.Resolve<IJugadorDA>().ObtenerEvaluacionViewModelDefault(jugadorId);
        }

        public virtual List<AntecedenteViewModel> GetAntecedentes(long jugadorId)
        {
            return DependencyFactory.Resolve<IJugadorDA>().GetAntecedentes(jugadorId);
        }
    }
}
