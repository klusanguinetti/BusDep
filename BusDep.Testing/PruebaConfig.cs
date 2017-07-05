﻿using System;
using System.Collections.Generic;
using System.IO;
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
        public bool cargaDB = false;
        [SetUp]
        public void Init()
        {
            if (configAll == null)
                configAll = new ConfigAll();
            configAll.Init();

            if (!cargaDB)
                return;
            #region borrado
            var DAev = DependencyFactory.Resolve<IBaseDA<Evaluacion>>();
            foreach (var d in DAev.GetAll())
            {
                DAev.Delete(d);
            }

            var DAan = DependencyFactory.Resolve<IBaseDA<Antecedente>>();
            foreach (var d in DAan.GetAll())
            {
                DAan.Delete(d);
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
            TipoEvaluacion tipoEvaluacion = new TipoEvaluacion { Deporte = dep1, Descripcion = "Auto Evaluación", EsDefault = "S" };
            //Técnica
            TemplateEvaluacion template = new TemplateEvaluacion { TipoEvaluacion = tipoEvaluacion, Descripcion = "Técnica" };
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Juego con ambas piernas", TemplateEvaluacion = template });
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
        public void RegistracionMasiva()
        {
            for (int i = 0; i < 50; i++)
            {
                Registracion(i);
            }
        }

        IUsuarioBusiness registracion => DependencyFactory.Resolve<IUsuarioBusiness>();
        ICommonBusiness common => DependencyFactory.Resolve<ICommonBusiness>();
        IBusquedaBusiness busqueda => DependencyFactory.Resolve<IBusquedaBusiness>();
        ILoginBusiness login => DependencyFactory.Resolve<ILoginBusiness>();

        IUsuarioJugadorBusiness jugador => DependencyFactory.Resolve<IUsuarioJugadorBusiness>();

        DeporteViewModel deporte => common.ObtenerDeportes().FirstOrDefault();
        IEnumerable<PuestoViewModel> listaPuesto => common.ObtenerPuestos(deporte.Id);
        public void Registracion(int i)
        {
            //var deporte = common.ObtenerDeportes().FirstOrDefault();
            UsuarioViewModel userView = new UsuarioViewModel { Mail = string.Format("prueba{0}@prueba.com", i), Password = string.Format("Facebook{0}", i), TipoUsuario = "Jugador", DeporteId = deporte.Id };

            userView = registracion.Registracion(userView);

            var datos = registracion.ObtenerDatosPersonales(userView);
            Random rnd = new Random();
            datos.Nacionalidad = "Argentino";
            datos.Nombre = string.Format("Pepe{0}", i);
            datos.Apellido = string.Format("Asasd{0}", i);
            datos.FechaNacimiento = new DateTime(rnd.Next(1990, 2010), rnd.Next(1, 12), rnd.Next(1, 28));
            registracion.RegistracionDatosPersonales(datos);

            var jugadorView = common.ObtenerJugador(userView);
            //var listaPuesto = common.ObtenerPuestos(userView.DeporteId.GetValueOrDefault());
            if (listaPuesto.Any())
            {
                jugadorView.PuestoId = listaPuesto.ToList()[rnd.Next(0, 10)].Id;
            }
            jugadorView.Pie = i.Equals(0) ? "Derecho" : (i % 2).Equals(0) ? "Derecho" : "Zurdo";
            jugadorView.Fichaje = i.Equals(0) ? "Libre" : (i % 2).Equals(0) ? "Libre" : "Contratado";
            jugadorView.Perfil = i.Equals(0) ? "Amateur" : (i % 2).Equals(0) ? "Amateur" : "Profecional";
            jugadorView.Peso = rnd.NextDecimal(75m, 110m);
            jugadorView.Altura = rnd.NextDecimal(1.5m, 2.05m); ;
            jugadorView.FotoCuertoEntero = string.Format("aaa{0}.jpg", i);
            jugadorView.FotoRostro = string.Format("bbb{0}.jpg", i);
            jugador.ActualizarDatosJugador(jugadorView);
            var user = login.LoginUser(string.Format("prueba{0}@prueba.com", i), string.Format("Facebook{0}", i));

            var evaluacion = jugador.ObtenerEvaluacionViewModel(user);
            foreach (var cabecera in evaluacion.Cabeceras)
            {
                foreach (var detalle in cabecera.Detalle)
                {
                    detalle.Puntuacion = rnd.Next(0, 5);
                }
            }
            jugador.GuardarEvalucacion(evaluacion);

            var ante = jugador.NuevoAntecedenteViewModel(userView);
            ante.InstitucionDescripcion = Clubes[rnd.Next(0, 20)].Nombre;
            ante.FechaInicio = DateTime.Now.AddYears(-rnd.Next(6, 10));
            ante.FechaFin = ante.FechaInicio.AddYears(rnd.Next(0,2));
            jugador.GuardarAntecedenteViewModel(ante);
            DateTime fechafin = ante.FechaFin.GetValueOrDefault();
            ante = jugador.NuevoAntecedenteViewModel(userView);
            ante.InstitucionDescripcion = Clubes[rnd.Next(0, 20)].Nombre;
            ante.FechaInicio = fechafin.AddYears(rnd.Next(6, 6));
            jugador.GuardarAntecedenteViewModel(ante);

            Console.WriteLine(string.Format("Usuario:{0}", user.Mail));
        }

        [Test]
        public void BusquedaJugador()
        {
            var list = busqueda.BuscarJugador(54, null, 14, 21, "Libre", "Amateur", "3");
            Console.WriteLine(list.SerializarToJson());
        }

        [Test]
        public void LeerJson()
        {
            var path = System.Reflection.Assembly.GetAssembly(this.GetType()).CodeBase;
            UriBuilder uri = new UriBuilder(path);
            path = Uri.UnescapeDataString(uri.Path);

            var directory = Directory.GetParent(path).FullName;
            var jsonName = "Clubes.json";
            var targetPath = Path.Combine(directory, jsonName);

            if (File.Exists(targetPath))
            {
                var json = File.ReadAllText(targetPath);
                var DataList = json.DeserializarToJson<List<ClubViewModel>>();
            }
            jsonName = "Paises.json";
            targetPath = Path.Combine(directory, jsonName);
            if (File.Exists(targetPath))
            {
                var json = File.ReadAllText(targetPath);
                var DataList = json.DeserializarToJson<List<PaisViewModel>>();
            }
        }

        private List<ClubViewModel> Clubes => LeerCluber(); 
        private List<ClubViewModel> LeerCluber()
        {
            var path = System.Reflection.Assembly.GetAssembly(this.GetType()).CodeBase;
            UriBuilder uri = new UriBuilder(path);
            path = Uri.UnescapeDataString(uri.Path);

            var directory = Directory.GetParent(path).FullName;
            var jsonName = "Clubes.json";
            var targetPath = Path.Combine(directory, jsonName);

            if (File.Exists(targetPath))
            {
                var json = File.ReadAllText(targetPath);
                return json.DeserializarToJson<List<ClubViewModel>>();
            }
            return new List<ClubViewModel>();
        }
    }

}
