using System.Linq;
using BusDep.Common;
using BusDep.Entity;
using BusDep.IDataAccess;
using BusDep.UnityInject;
using BusDep.ViewModel;

namespace BusDep.Business
{
    using System;
    using System.Collections.Generic;
    using BusDep.IBusiness;

    public class BusquedaBusiness : IBusquedaBusiness
    {
        [AuditMethod]
        public virtual PerfilJugadorViewModel ObtenerPerfil(long jugadorId)
        {
            PerfilJugadorViewModel perfil = new PerfilJugadorViewModel {PerfilId = jugadorId};
            var jugador = DependencyFactory.Resolve<IBaseDA<Jugador>>().GetById(jugadorId);
            if (jugador == null)
                return null;
            UsuarioViewModel usuario = new UsuarioViewModel
            {
                Id = jugador.Usuario.Id,
                DeporteId = jugador.Usuario.Deporte.Id,
                JugadorId = jugador.Id
            };
            jugador.MapperClass(perfil, TypeMapper.IgnoreCaseSensitive);
            jugador.Usuario.MapperClass(perfil, TypeMapper.IgnoreCaseSensitive);
            jugador.Usuario.DatosPersona.MapperClass(perfil, TypeMapper.IgnoreCaseSensitive);
            perfil.PuestoDescripcion = jugador.Puesto.Descripcion;
            perfil.Antecedentes = DependencyFactory.Resolve<IUsuarioDA>().ObtenerAntecedentes(jugador.Usuario.Id);
            perfil.AutoEvaluacion = DependencyFactory.Resolve<IUsuarioJugadorBusiness>().ObtenerEvaluacionViewModel(usuario);
            return perfil;
        }

        [AuditMethod]
        public virtual List<JugadorViewModel> BuscarJugador(BuscarJugadorViewModel buscar)
        {
            return DependencyFactory.Resolve<IJugadorDA>()
                .BuscarJugador(buscar.Puesto, buscar.EdadDesde, buscar.EdadHasta, buscar.Fichaje, buscar.Perfil, buscar.Pie, buscar.Nombre, 
                buscar.Pagina.GetValueOrDefault(),buscar.Cantidad.GetValueOrDefault());
        }

       
        [AuditMethod]
        public virtual long BuscarJugadorCount(BuscarJugadorViewModel buscar)
        {
            return DependencyFactory.Resolve<IJugadorDA>()
                .BuscarJugadorCount(buscar.Puesto, buscar.EdadDesde, buscar.EdadHasta, buscar.Fichaje, buscar.Perfil, buscar.Pie, buscar.Nombre);
        }
    }
}
