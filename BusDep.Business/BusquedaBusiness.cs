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
        public virtual PerfilJugadorViewModel ObtenerPerfil(long jugadorId)
        {
            PerfilJugadorViewModel perfil = new PerfilJugadorViewModel { PerfilId = jugadorId };
            var jugador = DependencyFactory.Resolve<IBaseDA<Jugador>>().GetById(jugadorId);
            if (jugador == null)
                return null;
            UsuarioViewModel usuario = new UsuarioViewModel {Id = jugador.Usuario.Id, DeporteId = jugador.Usuario.Deporte.Id, JugadorId = jugador.Id};
            jugador.MapperClass(perfil, TypeMapper.IgnoreCaseSensitive);
            jugador.Usuario.MapperClass(perfil, TypeMapper.IgnoreCaseSensitive);
            perfil.PuestoDescripcion = jugador.Puesto.Descripcion;
            foreach (var item in DependencyFactory.Resolve<IUsuarioDA>().ObtenerAntecedentes(jugador.Usuario.Id))
            {
                perfil.Antecedentes.Add(FillViewModel.FillAntecedenteViewModel(item));
            }
            perfil.AutoEvaluacion = DependencyFactory.Resolve<IUsuarioJugadorBusiness>().ObtenerEvaluacionViewModel(usuario);
            return perfil;
        }


        public virtual List<JugadorBusquedaViewModel> BuscarJugador(long? puestoId, string pais, int? edadDesde, int? edadHasta, string fichaje, string perfil, string nombre)
        {
            return (from o in DependencyFactory.Resolve<IJugadorDA>()
                .BuscarJugador(puestoId, pais, edadDesde, edadHasta, fichaje, perfil, nombre)
                    select o.MapperClass<JugadorBusquedaViewModel>()).ToList();

        }
    }
}
