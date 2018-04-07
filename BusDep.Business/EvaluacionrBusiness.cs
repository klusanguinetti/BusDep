using System.Linq;
using BusDep.Entity;
using BusDep.IBusiness;
using BusDep.IDataAccess;
using BusDep.UnityInject;
using BusDep.ViewModel;

namespace BusDep.Business
{
    public class EvaluacionrBusiness : IEvaluacionrBusiness
    {
        #region metodos publicos
        public virtual EvaluacionViewModel ObtenerEvaluacionViewModel(UsuarioViewModel userView)
        {
            var evo = DependencyFactory.Resolve<IUsuarioDA>()
                .ObtenerEvaluacionViewModelDefault(userView.Id, userView.DeporteId.GetValueOrDefault());
            if (evo != null)
                return evo;
            this.GenerarEvaluacion(userView);
            return DependencyFactory.Resolve<IUsuarioDA>()
                .ObtenerEvaluacionViewModelDefault(userView.Id, userView.DeporteId.GetValueOrDefault());
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