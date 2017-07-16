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
        public virtual EvaluacionViewModel ObtenerEvaluacionViewModel(UsuarioViewModel userView)
        {
            var evaluacion =
                DependencyFactory.Resolve<IUsuarioDA>()
                    .ObtenerEvaluacionDefault(userView.Id,
                        userView.DeporteId.GetValueOrDefault()) ??
                this.GenerarEvaluacion(userView);
            var eva = new EvaluacionViewModel
            {
                Id = evaluacion.Id,
                Descripcion = evaluacion.TipoEvaluacion.Descripcion,
                JugadorId = userView.JugadorId.GetValueOrDefault(),
                TipoEvaluacionId = evaluacion.TipoEvaluacion.Id
            };
            foreach (var cabecera in evaluacion.Cabeceras)
            {
                var cab = new EvaluacionCabeceraViewModel
                {
                    Id = cabecera.Id,
                    Descripcion = cabecera.TemplateEvaluacion.Descripcion
                };
                foreach (var detalle in cabecera.Detalles)
                {
                    var det = new EvaluacionDetalleViewModel
                    {
                        Id = detalle.Id,
                        Descripcion = detalle.TemplateEvaluacionDetalle.Descripcion,
                        Puntuacion = detalle.Puntuacion
                    };
                    cab.Detalle.Add(det);
                }
                decimal canResp = cabecera.Detalles.Count(o => o.Puntuacion.HasValue);
                decimal puntos =
                    cabecera.Detalles.Where(o => o.Puntuacion.HasValue).Sum(i => i.Puntuacion.GetValueOrDefault());
                if (canResp > 0 && puntos > 0)
                    cab.Promedio = puntos / canResp;

                eva.Cabeceras.Add(cab);
            }
            return eva;
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

        private Evaluacion GenerarEvaluacion(UsuarioViewModel userView)
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
                return evaluacion;
            }
        }

        public virtual List<AntecedenteViewModel> ObtenerAntecedentes(UsuarioViewModel userView)
        {
            return DependencyFactory.Resolve<IUsuarioDA>().ObtenerAntecedentes(userView.Id).Select(item => FillViewModel.FillAntecedenteViewModel(item)).ToList();
        }

        public virtual AntecedenteViewModel ObtenerAntecedenteViewModel(long antecedenteId)
        {
            return
                FillViewModel.FillAntecedenteViewModel(
                    DependencyFactory.Resolve<IBaseDA<Antecedente>>().GetById(antecedenteId));

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
            Jugador jugador = listaAntecedentes.Any()? listaAntecedentes.First().Usuario.Jugador : null;
            if(jugador==null)
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
            return FillViewModel.FillAntecedenteViewModel(ante);
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
                return
                    FillViewModel.FillJugadorViewModel(
                        DependencyFactory.Resolve<IJugadorDA>().GetById(userView.JugadorId));
            }
            throw new ExceptionBusiness(1, "No existe Jugador");
        }

       
    }
}