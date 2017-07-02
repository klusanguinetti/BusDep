using System;
using System.Linq;
using BusDep.Common;
using BusDep.Configuration;
using BusDep.Entity;
using BusDep.IBusiness;
using BusDep.IDataAccess;
using BusDep.UnityInject;
using BusDep.ViewModel;
using NUnit.Framework;

namespace BusDep.Testing
{
    [SetUpFixture]
    public class InicioPruebas
    {
        private ConfigAll configAll = null;
        [SetUp]
        public void Init()
        {
            if(configAll == null)
                configAll = new ConfigAll();
            configAll.Init();
            
            #region borrado
            var DAev = DependencyFactory.Resolve<IBaseDA<Evaluacion>>();
            foreach (var d in DAev.GetAll())
            {
                DAev.Delete(d);
            }
            IUsuarioDA DAu = DependencyFactory.Resolve<IUsuarioDA>();
            foreach (var d in DAu.GetAll())
            {
                DAu.Delete(d);
            }
            var DAt = DependencyFactory.Resolve<IBaseDA<TipoUsuario>>();
            foreach (var t in DAt.GetAll())
            {
                DAt.Delete(t);
            }
            
            var DAti = DependencyFactory.Resolve<IBaseDA<TipoEvaluacion>>();
            foreach (var d in DAti.GetAll())
            {
                DAti.Delete(d);
            }
            var DAte = DependencyFactory.Resolve<IBaseDA<TemplateEvaluacion>>();
            foreach (var d in DAte.GetAll())
            {
                DAte.Delete(d);
            }
            var DAd = DependencyFactory.Resolve<IBaseDA<Deporte>>();
            foreach (var d in DAd.GetAll())
            {
                DAd.Delete(d);
            }
            #endregion

            #region tipo usuario
            TipoUsuario jugador = new TipoUsuario { Descripcion = "Jugador" };
            DAt.Save(jugador);
            TipoUsuario tu = new TipoUsuario { Descripcion = "Entrenador" };
            DAt.Save(tu);
            tu = new TipoUsuario { Descripcion = "Intermediario" };
            DAt.Save(tu);
            tu = new TipoUsuario { Descripcion = "Club" };
            DAt.Save(tu);
            #endregion

            #region deporte y puestos
            Deporte dep1 = new Deporte { Descripcion = "Futbol", Tipo = "Futbol" };
            dep1.Puestos.Add(new Puesto { Deporte = dep1, Descripcion = "Delantero", PuestoEspecifico = "Delantero Centro" });
            dep1.Puestos.Add(new Puesto { Deporte = dep1, Descripcion = "Delantero", PuestoEspecifico = "Delantero Derecho" });
            dep1.Puestos.Add(new Puesto { Deporte = dep1, Descripcion = "Delantero", PuestoEspecifico = "Delantero Izquierdo" });
            dep1.Puestos.Add(new Puesto { Deporte = dep1, Descripcion = "Mediocampista", PuestoEspecifico = "Mediocampista Centro" });
            dep1.Puestos.Add(new Puesto { Deporte = dep1, Descripcion = "Mediocampista", PuestoEspecifico = "Mediocampista Derecho" });
            dep1.Puestos.Add(new Puesto { Deporte = dep1, Descripcion = "Mediocampista", PuestoEspecifico = "Mediocampista Izquierdo" });
            dep1.Puestos.Add(new Puesto { Deporte = dep1, Descripcion = "Defensor", PuestoEspecifico = "Defensor Centro" });
            dep1.Puestos.Add(new Puesto { Deporte = dep1, Descripcion = "Defensor", PuestoEspecifico = "Defensor Derecho" });
            dep1.Puestos.Add(new Puesto { Deporte = dep1, Descripcion = "Defensor", PuestoEspecifico = "Defensor Izquierdo" });
            dep1.Puestos.Add(new Puesto { Deporte = dep1, Descripcion = "Arquero", PuestoEspecifico = "Arquero" });
            DAd.Save(dep1);
            #endregion

            #region template
            TipoEvaluacion tipoEvaluacion = new TipoEvaluacion { Deporte = dep1, Descripcion = "Auto Evaluación", EsDefault = "S"};
            //Técnica
            TemplateEvaluacion template = new TemplateEvaluacion { TipoEvaluacion = tipoEvaluacion, Descripcion = "Técnica"};
            template.Detalles.Add( new TemplateEvaluacionDetalle {Descripcion = "Juego con ambas piernas", TemplateEvaluacion = template});
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Pase", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Control orientación (recepción y pase)", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Amague y dribleo", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Remate al arco", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Juego de cabeza", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Carga y marcación", TemplateEvaluacion = template });
            tipoEvaluacion.Templates.Add(template);
            //DAte.Save(template);

            //Condición Fisica
            template = new TemplateEvaluacion { TipoEvaluacion = tipoEvaluacion, Descripcion = "Condición Fisica" };
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Fuerza (explosiva)", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Velocidad", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Resistencia", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Flexibilidad (movilidad)", TemplateEvaluacion = template });
            tipoEvaluacion.Templates.Add(template);
            //DAte.Save(template);

            //Táctica
            template = new TemplateEvaluacion { TipoEvaluacion = tipoEvaluacion, Descripcion = "Táctica (cualidades cognoscitivas)" };
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Inteligencia de juego (visión)", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Conducta o juego ofensivo", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Conducta o juevo defensivo", TemplateEvaluacion = template });
            tipoEvaluacion.Templates.Add(template);
            //DAte.Save(template);

            //Cualidades mentales
            template = new TemplateEvaluacion { TipoEvaluacion = tipoEvaluacion, Descripcion = "Cualidades mentales" };
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Concentración", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Voluntad", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Perservación", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Confianza", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Disposición al riesgo", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Creatividad", TemplateEvaluacion = template });
            tipoEvaluacion.Templates.Add(template);
            //DAte.Save(template);

            //Coordinación
            template = new TemplateEvaluacion { TipoEvaluacion = tipoEvaluacion, Descripcion = "Coordinación" };
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Orientación", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Ritmo", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Reacción", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Equilibrio", TemplateEvaluacion = template });
            tipoEvaluacion.Templates.Add(template);
            //DAte.Save(template);

            //Cualidades mentales
            template = new TemplateEvaluacion { TipoEvaluacion = tipoEvaluacion, Descripcion = "Cualidades mentales" };
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Concentración", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Voluntad", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Perseverancia", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Confianza", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Disposición al riesgo", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Creatividad", TemplateEvaluacion = template });
            tipoEvaluacion.Templates.Add(template);
            //DAte.Save(template);

            //Cualidades mentales
            template = new TemplateEvaluacion { TipoEvaluacion = tipoEvaluacion, Descripcion = "Entorno social" };
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Comunicación", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Conducta", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Carisma / personalidad", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Seriedad", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Compañerismo", TemplateEvaluacion = template });
            tipoEvaluacion.Templates.Add(template);
            //DAte.Save(template);

            DAti.Save(tipoEvaluacion);
            #endregion

            #region creacion usuario
            //Usuario usuario = new Usuario
            //{
            //    Mail = "klusanguinetti@gmail.com",
            //    Password = "PruebaAlta",
            //    TipoUsuario = jugador
            //};
            //DatosPersona datos = new DatosPersona
            //{
            //    Usuario = usuario,
            //    Nombre = "Lucas",
            //    Apellido = "Sanguinetti"
            //};
            //usuario.DatosPersona = datos;

            //usuario.AplicacionToken.Add(new UsuarioAplicativo { Aplicativo = "Facebook", Token = "asdfg", Usuario = usuario });
            //usuario.AplicacionToken.Add(new UsuarioAplicativo { Aplicativo = "Google", Token = "gfdsa", Usuario = usuario });

            //DAu.Save(usuario);
            #endregion
        }

        [TearDown]
        public void Dispose()
        {
            configAll?.Dispose();
        }
    }

    [TestFixture]
    public class PruebaConfig
    {
        [Test]
        public void PruebaLogin()
        {
            var login = DependencyFactory.Resolve<ILoginBusiness>();
            var user = login.LoginUser("klusanguinetti@gmail.com", "PruebaAlta");

            var user1 = login.LoginUser("klusanguinetti@gmail.com", "Facebook", "asdfg");
        }

        [Test]
        public void Registracion()
        {
            var registracion = DependencyFactory.Resolve<IUsuarioBusiness>();
            var common = DependencyFactory.Resolve<ICommonBusiness>();
            var login = DependencyFactory.Resolve<ILoginBusiness>();

            var deporte = common.ObtenerDeportes().FirstOrDefault();

            UsuarioViewModel userView = new UsuarioViewModel { Mail = "prueba@prueba.com", Password = "Facebook", TipoUsuario = "Jugador", DeporteId = deporte.Id};

            userView = registracion.Registracion(userView);

            var datos = registracion.ObtenerDatosPersonales(userView);

            datos.Nacionalidad = "Argentino";
            datos.Nombre = "Pepe";
            datos.Apellido = "Asasd";
            registracion.RegistracionDatosPersonales(datos);

            var jugadorView = common.ObtenerJugador(userView);
            var listaPuesto = common.ObtenerPuestos(userView.DeporteId.GetValueOrDefault());
            if(listaPuesto.Any())
                jugadorView.PuestoId = listaPuesto.FirstOrDefault().Id;

            jugadorView.Perfil = "Derecho";
            jugadorView.Peso = 75.4m;
            jugadorView.Altura = 1.87m;
            jugadorView.FotoCuertoEntero = "aaa.jpg";
            jugadorView.FotoRostro = "bbb.jpg";
            registracion.ActualizarDatosJugador(jugadorView);
            var user = login.LoginUser("prueba@prueba.com", "Facebook");

            var evaluacion = registracion.ObtenerEvaluacionViewModel(user);
            Random rnd = new Random();
            foreach (var cabecera in evaluacion.Cabeceras)
            {
                foreach (var detalle in cabecera.Detalle)
                {
                    detalle.Puntuacion = rnd.Next(0, 5);
                }
            }
            registracion.GuardarEvalucacion(evaluacion);

            Console.WriteLine(evaluacion.SerializarToJson());
        }


    }
}
