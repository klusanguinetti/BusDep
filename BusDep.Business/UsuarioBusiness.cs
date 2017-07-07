

namespace BusDep.Business
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BusDep.Common;
    using BusDep.IBusiness;
    using BusDep.ViewModel;
    using BusDep.Entity;
    using BusDep.IDataAccess;
    using BusDep.UnityInject;

    public class UsuarioBusiness : IUsuarioBusiness
    {
        public virtual UsuarioViewModel Registracion(UsuarioViewModel userView)
        {
            var user = userView.MapperClass<Usuario>(TypeMapper.IgnoreCaseSensitive);
            TipoUsuario tipoUsuario =
                DependencyFactory.Resolve<IBaseDA<TipoUsuario>>()
                    .GetAll()
                    .FirstOrDefault(o => o.Descripcion.Equals(userView.TipoUsuario));
            if (tipoUsuario != null)
            {
                user.TipoUsuario = tipoUsuario;
                user.DatosPersona = new DatosPersona { Usuario = user, Nombre = userView.Nombre, Apellido = userView.Nombre};
                switch (user.TipoUsuario.Descripcion)
                {
                    case "Jugador":
                        user.Jugador = new Jugador { Usuario = user };
                        break;
                    case "Entrenador":
                        user.Entrenador = new Entrenador { Usuario = user };
                        break;
                    case "Intermediario":
                        user.Intermediario = new Intermediario { Usuario = user };
                        break;
                    case "Club":
                        user.Club = new Club { Usuario = user };
                        break;
                }
            }
            else
            {
                throw new Exception("No existe tipo usuario.");
            }
            user.Deporte = userView.DeporteId.HasValue
                ? DependencyFactory.Resolve<IBaseDA<Deporte>>().GetById(userView.DeporteId)
                : DependencyFactory.Resolve<IBaseDA<Deporte>>().GetAll().First();
            DependencyFactory.Resolve<IUsuarioDA>().Save(user);
            //DependencyFactory.Resolve<IBaseDA<DatosPersona>>().Save(user.DatosPersona);
            //DependencyFactory.Resolve<IBaseDA<Jugador>>().Save(user.Jugador);
            return FillViewModel.FillUsuarioViewModel(user);

        }

        public virtual DatosPersonaViewModel ObtenerDatosPersonales(UsuarioViewModel userView)
        {
            if (userView.DatosPersonaId.HasValue)
            {
                return FillViewModel.FillDatosPersonaViewModel(
                    DependencyFactory.Resolve<IBaseDA<DatosPersona>>().GetById(userView.DatosPersonaId));
            }
            return null;

        }

        public virtual void RegistracionDatosPersonales(DatosPersonaViewModel datosPersona)
        {
            var user = DependencyFactory.Resolve<IUsuarioDA>().GetById(datosPersona.UsuarioId);
            datosPersona.MapperClass(user.DatosPersona, TypeMapper.IgnoreCaseSensitive);
            DependencyFactory.Resolve<IUsuarioDA>().Save(user);
        }

        public virtual void ActualizarDatosJugador(JugadorViewModel jugadorView)
        {
            var jugador = DependencyFactory.Resolve<IJugadorDA>().GetById(jugadorView.Id);
            jugadorView.MapperClass(jugador, TypeMapper.IgnoreCaseSensitive);
            if (jugadorView.PuestoId.HasValue)
            { 
                if(jugador.Puesto==null || !jugador.Puesto.Id.Equals(jugadorView.PuestoId.Value))
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
            return null;
        }

        public virtual EvaluacionViewModel ObtenerEvaluacionViewModel(UsuarioViewModel userView)
        {
            var evaluacion =
                DependencyFactory.Resolve<IUsuarioDA>()
                    .ObtenerEvaluacionDefault(userView.JugadorId.GetValueOrDefault(),
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
                throw new Exception("No existe tipo de evaluación default");
            }
            else
            {
                var evaluacion = new Evaluacion
                {
                    TipoEvaluacion = tipoEvaluacion,
                    Jugador = DependencyFactory.Resolve<IJugadorDA>().GetById(userView.JugadorId.GetValueOrDefault())
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
            List<AntecedenteViewModel> ilRest = new List<AntecedenteViewModel>();
            foreach (var item in DependencyFactory.Resolve<IUsuarioDA>().ObtenerAntecedentes(userView.Id))
            {
                ilRest.Add(FillViewModel.FillAntecedenteViewModel(item));
            }
            return ilRest;
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
            if (antecedente.Id.Equals(0))
            {
                ante = new Antecedente{ Usuario = DependencyFactory.Resolve<IUsuarioDA>().GetById(antecedente.UsuarioId) };
            }
            else
            {
                ante = DependencyFactory.Resolve<IBaseDA<Antecedente>>().GetById(antecedente.Id);
            }
            antecedente.MapperClass(ante, TypeMapper.IgnoreCaseSensitive);
            DependencyFactory.Resolve<IBaseDA<Antecedente>>().Save(ante);

            return FillViewModel.FillAntecedenteViewModel(ante);
        }
    }
}

