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
            PerfilJugadorViewModel perfil = new PerfilJugadorViewModel { PerfilId = jugadorId };
            var jugador = DependencyFactory.Resolve<IBaseDA<Jugador>>().GetById(jugadorId);
            if (jugador == null)
                return null;
            UsuarioViewModel usuario = new UsuarioViewModel { Id = jugador.Usuario.Id, DeporteId = jugador.Usuario.Deporte.Id, JugadorId = jugador.Id };
            jugador.MapperClass(perfil, TypeMapper.IgnoreCaseSensitive);
            jugador.Usuario.MapperClass(perfil, TypeMapper.IgnoreCaseSensitive);
            jugador.Usuario.DatosPersona.MapperClass(perfil, TypeMapper.IgnoreCaseSensitive);
            perfil.PuestoDescripcion = jugador.Puesto.Descripcion;
            foreach (var item in DependencyFactory.Resolve<IUsuarioDA>().ObtenerAntecedentes(jugador.Usuario.Id))
            {
                perfil.Antecedentes.Add(FillViewModel.FillAntecedenteViewModel(item));
            }
            perfil.AutoEvaluacion = DependencyFactory.Resolve<IUsuarioJugadorBusiness>().ObtenerEvaluacionViewModel(usuario);
            return perfil;
        }

        [AuditMethod]
        public virtual List<JugadorBusquedaViewModel> BuscarJugador(long? puestoId, string pais, int? edadDesde, int? edadHasta, string fichaje, string perfil, string nombre)
        {
            return (from o in DependencyFactory.Resolve<IJugadorDA>()
                .BuscarJugador(puestoId, pais, edadDesde, edadHasta, fichaje, perfil, nombre)
                    select o.MapperClass<JugadorBusquedaViewModel>()).ToList();

        }
        [AuditMethod]
        public virtual List<JugadorBusquedaViewModel> BuscarJugador(string puesto, int? edadDesde, int? edadHasta, string fichaje, string perfil, string pie, string nombre)
        {
            return (from o in DependencyFactory.Resolve<IJugadorDA>()
                .BuscarJugador(puesto, edadDesde, edadHasta, fichaje, perfil, pie, nombre)
                    select o.MapperClass<JugadorBusquedaViewModel>()).ToList();
        }


        [AuditMethod]
        public virtual List<JugadorBusquedaViewModel> BuscarJugador(string[] puesto, int? edadDesde, int? edadHasta, string[] fichaje, string[] perfil, string[] pie, string nombre,
            int? pagina = null, int? cantidad = null)
        {

            return (from o in DependencyFactory.Resolve<IJugadorDA>()
               .BuscarJugador(puesto, edadDesde, edadHasta, fichaje, perfil, pie, nombre, pagina.GetValueOrDefault(), cantidad.GetValueOrDefault())
             select o.MapperClass<JugadorBusquedaViewModel>()).ToList();

            //if (pagina < 1 || cantidad < 1)
            //{
            //    return BuscarJugador(puesto, edadDesde, edadHasta, fichaje, perfil, pie, nombre);
            //}
            //var liPre = DependencyFactory.Resolve<IJugadorDA>()
            //    .BuscarJugador(puesto, edadDesde, edadHasta, fichaje, perfil, pie, nombre, pagina, cantidad);

            //var inicio = pagina.Equals(1) ? 0 : ((pagina - 1) * cantidad);
            //var fin = inicio + cantidad;
            //var listR = new List<JugadorBusquedaViewModel>();
            //while (inicio < fin)
            //{
            //    if (liPre.Count >= inicio)
            //    {
            //        listR.Add(liPre[inicio].MapperClass<JugadorBusquedaViewModel>());
            //        inicio++;
            //    }
            //    else
            //    {
            //        return listR;
            //    }

            //}


           // return listR;
        }
    }
}
