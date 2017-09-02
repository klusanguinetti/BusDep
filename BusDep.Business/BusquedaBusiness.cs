namespace BusDep.Business
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

            return DependencyFactory.Resolve<IJugadorDA>().ObtenerPerfil(jugadorId);
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
