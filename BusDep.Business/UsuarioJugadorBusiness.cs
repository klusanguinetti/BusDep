using System;
using System.Collections.Generic;
using System.Linq;
using BusDep.Common;
using BusDep.Entity;
using BusDep.IBusiness;
using BusDep.IDataAccess;
using BusDep.UnityInject;
using BusDep.ViewModel;

namespace BusDep.Business
{
    public class UsuarioJugadorBusiness : IUsuarioJugadorBusiness
    {
        #region metodos publicos
        public virtual List<AntecedenteViewModel> ObtenerAntecedentes(UsuarioViewModel userView)
        {
            return DependencyFactory.Resolve<IUsuarioDA>().ObtenerAntecedentes(userView.Id);
        }
        public virtual AntecedenteViewModel ObtenerAntecedenteViewModel(long antecedenteId, long userId)
        {
            return DependencyFactory.Resolve<IUsuarioDA>().ObtenerAntecedenteViewModel(antecedenteId, userId);
        }
        public virtual AntecedenteViewModel NuevoAntecedenteViewModel(UsuarioViewModel userView)
        {
            return new AntecedenteViewModel { UsuarioId = userView.Id };
        }
        public virtual AntecedenteViewModel GuardarAntecedenteViewModel(AntecedenteViewModel antecedente)
        {
            Antecedente ante = null;
            ante = antecedente.Id.Equals(0) ? new Antecedente { Usuario = DependencyFactory.Resolve<IUsuarioDA>().GetById(antecedente.UsuarioId) } : DependencyFactory.Resolve<IBaseDA<Antecedente>>().GetById(antecedente.Id);
            antecedente.MapperClass(ante, TypeMapper.IgnoreCaseSensitive);
            DependencyFactory.Resolve<IBaseDA<Antecedente>>().Save(ante);

            var listaAntecedentes = DependencyFactory.Resolve<IJugadorDA>().ObtenerAntecedentes(antecedente.UsuarioId).OrderByDescending(o => o.FechaInicio);
            Jugador jugador = listaAntecedentes.Any() ? listaAntecedentes.First().Usuario.Jugador : null;
            if (jugador == null)
                throw new Exception("No existe Jugador relacionado");
            if (listaAntecedentes.Count().Equals(1))
            {
                jugador.ClubDescripcion = listaAntecedentes.First().ClubDescripcion;
                jugador.ClubLogo = listaAntecedentes.First().ClubLogo;
            }
            else
            {
                var ultimo = listaAntecedentes.First();
                jugador.ClubDescripcion = listaAntecedentes.First().ClubDescripcion;
                jugador.ClubLogo = listaAntecedentes.First().ClubLogo;
                foreach (var item in listaAntecedentes)
                {
                    if (item.Id.Equals(ultimo.Id))
                        continue;
                    else
                    {
                        if (!item.FechaFin.HasValue)
                        {
                            item.FechaFin = ultimo.FechaInicio.AddDays(-1);
                            DependencyFactory.Resolve<IBaseDA<Antecedente>>().Save(item);
                        }
                        ultimo = item;
                    }
                }
            }
            DependencyFactory.Resolve<IJugadorDA>().Save(jugador);
            var ret = ante?.MapperClass<AntecedenteViewModel>();
            if (ret != null)
                ret.UsuarioId = ante.Usuario.Id;
            return ret;
        }
        public virtual void ActualizarDatosJugador(JugadorViewModel jugadorView)
        {
            var jugador = DependencyFactory.Resolve<IJugadorDA>().GetById(jugadorView.Id);
            jugadorView.MapperClass(jugador, TypeMapper.IgnoreCaseSensitive);
            if (jugadorView.PuestoId.HasValue)
            {
                if (jugador.Puesto == null || !jugador.Puesto.Id.Equals(jugadorView.PuestoId.Value))
                    jugador.Puesto = DependencyFactory.Resolve<IJugadorDA>().ObtenerPuesto(jugadorView.PuestoId.Value);
            }
            else
            {
                jugador.Puesto = null;
            }
            if (jugadorView.PuestoAltId.HasValue)
            {
                if (jugador.PuestoAlternativo == null || !jugador.PuestoAlternativo.Id.Equals(jugadorView.PuestoAltId.Value))
                    jugador.PuestoAlternativo = DependencyFactory.Resolve<IJugadorDA>().ObtenerPuesto(jugadorView.PuestoAltId.Value);
            }
            else
            {
                jugador.PuestoAlternativo = null;
            }

            DependencyFactory.Resolve<IJugadorDA>().Save(jugador);
        }

        public virtual JugadorViewModel ObtenerJugador(UsuarioViewModel userView)
        {
            if (userView.JugadorId.HasValue)
            {
                var user = DependencyFactory.Resolve<IJugadorDA>().ObtenerJugador(userView.JugadorId.Value);
                return user;
            }
            throw new ExceptionBusiness(1, "No existe Jugador");
        }

        public virtual void BorrarAntecedentes(AntecedenteViewModel antecedenteViewModel)
        {
            var antecedente = DependencyFactory.Resolve<IBaseDA<Antecedente>>().GetById(antecedenteViewModel.Id);
            DependencyFactory.Resolve<IBaseDA<Antecedente>>().Delete(antecedente);
        }

        public virtual void GuardarRecomendar(RecomendacionViewModel recomendacion)
        {
            var newRecomendacion = new Recomendacion
            {
                Texto = recomendacion.Texto,
                Receptor = DependencyFactory.Resolve<IBaseDA<Usuario>>().GetById(recomendacion.ReceptorId),
                Emisor = DependencyFactory.Resolve<IBaseDA<Usuario>>().GetById(recomendacion.EmisorId),
                Estado = "A",
                Fecha = DateTime.Now
            };
            DependencyFactory.Resolve<IBaseDA<Recomendacion>>().Save(newRecomendacion);
        }
        #endregion
    }
}