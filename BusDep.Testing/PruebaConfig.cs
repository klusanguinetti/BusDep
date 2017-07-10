using System;
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

        private void Detele(dynamic dataAccess)
        {
            foreach (var d in dataAccess.GetAll())
            {
                dataAccess.Delete(d);
            }
        }

        [SetUp]
        public void Init()
        {
            if (configAll == null)
                configAll = new ConfigAll();
            configAll.Init();

            if (!cargaDB)
                return;
            #region borrado
            dynamic dataAccess = DependencyFactory.Resolve<IBaseDA<Evaluacion>>();
            Detele(dataAccess);
            Detele(DependencyFactory.Resolve<IBaseDA<Antecedente>>());
            Detele(DependencyFactory.Resolve<IBaseDA<Jugador>>());
            Detele(DependencyFactory.Resolve<IBaseDA<Entrenador>>());
            Detele(DependencyFactory.Resolve<IBaseDA<Intermediario>>());
            Detele(DependencyFactory.Resolve<IBaseDA<Club>>());
            Detele(DependencyFactory.Resolve<IUsuarioDA>());
            Detele(DependencyFactory.Resolve<IBaseDA<TipoEvaluacion>>());
            Detele(DependencyFactory.Resolve<IBaseDA<TipoUsuario>>());
            var DAti = DependencyFactory.Resolve<IBaseDA<TipoEvaluacion>>();
            foreach (var d in DAti.GetAll())
            {
                DAti.Delete(d);
            }
            Detele(DependencyFactory.Resolve<IBaseDA<TemplateEvaluacion>>());
            Detele(DependencyFactory.Resolve<IBaseDA<Deporte>>());
            #endregion

            #region tipo usuario

            var DAt = DependencyFactory.Resolve<IBaseDA<TipoUsuario>>();
            var DAd = DependencyFactory.Resolve<IBaseDA<Deporte>>();
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
            TipoEvaluacion tipoEvaluacion = new TipoEvaluacion { Deporte = dep1, Descripcion = "Auto Evaluación", EsDefault = "S", TipoUsuario= jugador };
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
        #region atributos

        private IUsuarioBusiness registracion => DependencyFactory.Resolve<IUsuarioBusiness>();
        private ICommonBusiness common => DependencyFactory.Resolve<ICommonBusiness>();
        private IBusquedaBusiness busqueda => DependencyFactory.Resolve<IBusquedaBusiness>();
        private ILoginBusiness login => DependencyFactory.Resolve<ILoginBusiness>();

        private IUsuarioJugadorBusiness jugador => DependencyFactory.Resolve<IUsuarioJugadorBusiness>();

        private DeporteViewModel deporte => common.ObtenerDeportes().FirstOrDefault();
        private IEnumerable<PuestoViewModel> listaPuesto => common.ObtenerPuestos(deporte.Id);

        #endregion

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
            for (int i = 0; i < 5; i++)
            {
                Registracion(i);
            }
        }


        public void Registracion(int i)
        {
            //var deporte = common.ObtenerDeportes().FirstOrDefault();
            Random rnd = new Random();
            var apellido = Apellidos[rnd.Next(0, 40)];
            var nombre = Nombres[rnd.Next(0, 40)];
            UsuarioViewModel userView = new UsuarioViewModel
            {
                Mail = string.Format(nombre + "{0}@{1}.com", i, apellido),
                Password = string.Format("{0}{1}", apellido, nombre),
                TipoUsuario = "Jugador",
                DeporteId = deporte.Id,
                Nombre = nombre,
                Apellido = apellido
            };
            
            userView = registracion.Registracion(userView);

            var datos = registracion.ObtenerDatosPersonales(userView);
            
            var pais = Paises.First(o => o.CodigoIso.Equals("ARG"));
            datos.Pais = pais.Nombre;
            datos.PaisIso = pais.CodigoIso;
            pais = Paises[rnd.Next(0, 6)];
            datos.Nacionalidad = pais.Nombre;
            datos.NacionalidadIso = pais.CodigoIso;
            datos.FechaNacimiento = new DateTime(rnd.Next(1990, 2010), rnd.Next(1, 12), rnd.Next(1, 28));

            datos.Informacion = string.Format("{0} {1} {2} {3} {4} {5}", datos.Nombre, datos.Apellido, ", Pais:",
                datos.Pais, ", Fecha Nacimiento:", datos.FechaNacimiento);
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
            jugadorView.Altura = rnd.NextDecimal(1.5m, 2.05m);
            ;
            jugadorView.FotoCuertoEntero = string.Format("aaa{0}.jpg", i);
            jugadorView.FotoRostro = string.Format("bbb{0}.jpg", i);

            jugador.ActualizarDatosJugador(jugadorView);
            var user = login.LoginUser(string.Format(nombre + "{0}@{1}.com", i, apellido), string.Format("{0}{1}", apellido, nombre));

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
            ante.FechaFin = ante.FechaInicio.AddYears(rnd.Next(0, 2));
            ante.InformacionAdicional = string.Format("Club: {0}, Desde: {1} - Hasta: {2}", ante.InstitucionDescripcion, ante.FechaInicio, ante.FechaFin);

            jugador.GuardarAntecedenteViewModel(ante);
            DateTime fechafin = ante.FechaFin.GetValueOrDefault();
            ante = jugador.NuevoAntecedenteViewModel(userView);
            ante.InstitucionDescripcion = Clubes[rnd.Next(0, 20)].Nombre;
            ante.FechaInicio = fechafin.AddYears(rnd.Next(6, 6));
            ante.InformacionAdicional = string.Format("Club: {0}, Desde: {1}", ante.InstitucionDescripcion, ante.FechaInicio);
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

        private List<ClubViewModel> Clubes => LeerClubes();

        private List<ClubViewModel> LeerClubes()
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

        private List<PaisViewModel> Paises => LeerPaises();

        private List<PaisViewModel> LeerPaises()
        {
            var path = System.Reflection.Assembly.GetAssembly(this.GetType()).CodeBase;
            UriBuilder uri = new UriBuilder(path);
            path = Uri.UnescapeDataString(uri.Path);

            var directory = Directory.GetParent(path).FullName;
            var jsonName = "Paises.json";
            var targetPath = Path.Combine(directory, jsonName);

            if (File.Exists(targetPath))
            {
                var json = File.ReadAllText(targetPath);
                return
                    json.DeserializarToJson<List<PaisViewModel>>()
                        .Where(o => new[] { "ARG", "BOL", "BRA", "CHL", "COL", "PRY", "PER" }.Contains(o.CodigoIso))
                        .ToList();
            }
            return new List<PaisViewModel>();
        }

        private string[] Nombres => CargarNombres();

        private string[] CargarNombres()
        {
            return new[]
            {
                "Benjamin",
                "Vicente",
                "Martin",
                "Matias",
                "Joaquin",
                "Agustin",
                "Cristobal",
                "Maximiliano",
                "Sebastian",
                "Tomas",
                "Diego",
                "Jose",
                "Nicolas",
                "Felipe",
                "Lucas",
                "Alonso",
                "Bastian",
                "Juan",
                "Gabriel",
                "Ignacio",
                "Francisco",
                "Renato",
                "Maximo",
                "Mateo",
                "Javier",
                "Daniel",
                "Luis",
                "Gaspar",
                "Angel",
                "Fernando",
                "Carlos",
                "Emilio",
                "Franco",
                "Cristian",
                "Pablo",
                "Santiago",
                "Esteban",
                "David",
                "Damian",
                "Jorge",
                "Camilo",
                "Alexander",
                "Rodrigo",
                "Amaro",
                "Luciano",
                "Bruno",
                "Alexis",
                "Victor",
                "Thomas",
                "Julian"

            };
        }

        private string[] Apellidos => CargarApelidos();
        private string[] CargarApelidos()
        {
            return new[]
            {
                "Garcia",
                "Lopez",
                "Perez",
                "Gonzalez",
                "Sanchez",
                "Martinez",
                "Rodriguez",
                "Fernandez",
                "Gomez",
                "Martin",
                "Garcia",
                "Hernandez",
                "Ruiz",
                "Diaz",
                "Alvarez",
                "Jimenez",
                "Lopez",
                "Moreno",
                "Perez",
                "Munoz",
                "Alonso",
                "Gutierrez",
                "Romero",
                "Sanz",
                "Torres",
                "Suarez",
                "Ramirez",
                "Vazquez",
                "Navarro",
                "Dominguez",
                "Ramos",
                "Castro",
                "Gil",
                "Flores",
                "Morales",
                "Blanco",
                "Sanchez",
                "Fernandez",
                "Serrano",
                "Molina",
                "Martinez",
                "Ortiz",
                "Gonzalez",
                "Santos",
                "Perez",
                "Ortega"
            };
        }
        [Test]
        public void ReadClub()
        {
            string css = @".flagclubicon.flag-{0} {{ background - image: url('../Content/img/Clubes/{0}.png'); }}" + Environment.NewLine;
            string ret = string.Empty;
            foreach (var club in Clubes)
            {
                ret += string.Format(css, club.Code);
            }
            Console.WriteLine(ret);
        }
    }
}

