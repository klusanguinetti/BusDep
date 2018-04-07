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
    public class UsuarioEntrenadorBusiness : IUsuarioEntrenadorBusiness
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

        public virtual void ActualizarDatosEntrenador(EntrenadorViewModel entrenadorView)
        {
            var entrenador = DependencyFactory.Resolve<IEntrenadorDA>().GetById(entrenadorView.Id);
            entrenadorView.MapperClass(entrenador, TypeMapper.IgnoreCaseSensitive);
            DependencyFactory.Resolve<IEntrenadorDA>().Save(entrenador);
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
            antecedente.Id = ante.Id;
            return antecedente;
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

        public virtual EntrenadorViewModel GetPerfilEntrenador(UsuarioViewModel userView)
        {
            if (userView.EntrenadorId.HasValue)
                return DependencyFactory.Resolve<IEntrenadorDA>().ObtenerEntrenador(userView.EntrenadorId.Value);
            else
                return null;
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