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
        public virtual EvaluacionViewModel ObtenerEvaluacionViewModel(UsuarioViewModel userView)
        {
            var evo = DependencyFactory.Resolve<IUsuarioDA>()
                .ObtenerEvaluacionViewModelDefault(userView.Id, userView.DeporteId.GetValueOrDefault());
            if (evo != null)
                return evo;
            this.GenerarEvaluacion(userView);
            return DependencyFactory.Resolve<IUsuarioDA>().ObtenerEvaluacionViewModelDefault(userView.Id, userView.DeporteId.GetValueOrDefault());
        }
        public virtual void GuardarEvalucacion(EvaluacionViewModel evaluacion)
        {
            var eva = DependencyFactory.Resolve<IBaseDA<Evaluacion>>().GetById(evaluacion.Id);
            foreach (var evaluacionCabecera in eva.Cabeceras)
            {
                var cab = evaluacion.Cabeceras.FirstOrDefault(o => o.Id.Equals(evaluacionCabecera.Id));
                if (cab != null)
                {
                    foreach (var evaluacionDetalle in evaluacionCabecera.Detalles)
                    {
                        var det = cab.Detalle.FirstOrDefault(o => o.Id.Equals(evaluacionDetalle.Id));
                        if (det != null)
                        {
                            evaluacionDetalle.Puntuacion = det.Puntuacion;
                        }
                    }
                }
            }
            DependencyFactory.Resolve<IBaseDA<Evaluacion>>().Save(eva);
        }
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
            DependencyFactory.Resolve<IJugadorDA>().Save(jugador);
        }

        public virtual JugadorViewModel ObtenerJugador(UsuarioViewModel userView)
        {
            if (userView.JugadorId.HasValue)
            {
                return DependencyFactory.Resolve<IJugadorDA>().ObtenerJugador(userView.JugadorId.Value);
            }
            throw new ExceptionBusiness(1, "No existe Jugador");
        }

        public virtual void BorrarAntecedentes(AntecedenteViewModel antecedenteViewModel)
        {
            var antecedente = DependencyFactory.Resolve<IBaseDA<Antecedente>>().GetById(antecedenteViewModel.Id);
            DependencyFactory.Resolve<IBaseDA<Antecedente>>().Delete(antecedente);
        }
        #endregion

        #region metodos privados
        private void GenerarEvaluacion(UsuarioViewModel userView)
        {
            var tipoEvaluacion =
                DependencyFactory.Resolve<IUsuarioDA>()
                    .ObtenerTipoEvaluacionDefault(userView.DeporteId.GetValueOrDefault(), userView.TipoUsuario);
            if (tipoEvaluacion == null)
            {
                throw new ExceptionBusiness(6, "No existe tipo de evaluación default");
            }
            else
            {
                var evaluacion = new Evaluacion
                {
                    TipoEvaluacion = tipoEvaluacion,
                    Usuario = DependencyFactory.Resolve<IUsuarioDA>().GetById(userView.Id)
                };
                foreach (var templateEvaluacion in tipoEvaluacion.Templates)
                {
                    EvaluacionCabecera cabecera = new EvaluacionCabecera
                    {
                        Evaluacion = evaluacion,
                        TemplateEvaluacion = templateEvaluacion
                    };
                    foreach (var det in templateEvaluacion.Detalles)
                    {
                        EvaluacionDetalle detalle = new EvaluacionDetalle
                        {
                            TemplateEvaluacionDetalle = det,
                            EvaluacionCabecera = cabecera
                        };
                        cabecera.Detalles.Add(detalle);
                    }
                    evaluacion.Cabeceras.Add(cabecera);
                }
                DependencyFactory.Resolve<IBaseDA<Evaluacion>>().Save(evaluacion);
            }
        }
        #endregion
    }
}