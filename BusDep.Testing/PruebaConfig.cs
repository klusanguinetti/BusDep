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

        [SetUp]
        public void Init()
        {
            ConfigAll.Instance.Init();
        }

        [TearDown]
        public void Dispose()
        {
            ConfigAll.Instance.Dispose();
        }
    }

    [TestFixture]
    public class LimpiesaDB
    {
        private void Detele(dynamic dataAccess)
        {
            foreach (var d in dataAccess.GetAll())
            {
                dataAccess.Delete(d);
            }
        }
        [Test]
        public void LimpiesaYCargaDeDatos()
        {

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
            //Detele(DependencyFactory.Resolve<IBaseDA<ClubDetalle>>());
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
            dep1.Puestos.Add(new Puesto
            {
                Deporte = dep1,
                Descripcion = "Delantero",
                PuestoEspecifico = "Delantero Centro"
            });
            dep1.Puestos.Add(new Puesto
            {
                Deporte = dep1,
                Descripcion = "Delantero",
                PuestoEspecifico = "Delantero Derecho"
            });
            dep1.Puestos.Add(new Puesto
            {
                Deporte = dep1,
                Descripcion = "Delantero",
                PuestoEspecifico = "Delantero Izquierdo"
            });
            dep1.Puestos.Add(new Puesto
            {
                Deporte = dep1,
                Descripcion = "Mediocampista",
                PuestoEspecifico = "Mediocampista Centro"
            });
            dep1.Puestos.Add(new Puesto
            {
                Deporte = dep1,
                Descripcion = "Mediocampista",
                PuestoEspecifico = "Mediocampista Derecho"
            });
            dep1.Puestos.Add(new Puesto
            {
                Deporte = dep1,
                Descripcion = "Mediocampista",
                PuestoEspecifico = "Mediocampista Izquierdo"
            });
            dep1.Puestos.Add(new Puesto { Deporte = dep1, Descripcion = "Defensor", PuestoEspecifico = "Defensor Centro" });
            dep1.Puestos.Add(new Puesto
            {
                Deporte = dep1,
                Descripcion = "Defensor",
                PuestoEspecifico = "Defensor Derecho"
            });
            dep1.Puestos.Add(new Puesto
            {
                Deporte = dep1,
                Descripcion = "Defensor",
                PuestoEspecifico = "Defensor Izquierdo"
            });
            dep1.Puestos.Add(new Puesto { Deporte = dep1, Descripcion = "Arquero", PuestoEspecifico = "Arquero" });
            DAd.Save(dep1);

            #endregion

            #region template

            TipoEvaluacion tipoEvaluacion = new TipoEvaluacion
            {
                Deporte = dep1,
                Descripcion = "Auto Evaluación",
                EsDefault = "S",
                TipoUsuario = jugador
            };
            //Técnica
            TemplateEvaluacion template = new TemplateEvaluacion
            {
                TipoEvaluacion = tipoEvaluacion,
                Descripcion = "Técnica"
            };
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Juego con ambas piernas",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Pase", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Control orientación (recepción y pase)",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Amague y dribleo",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Remate al arco",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Juego de cabeza",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Carga y marcación",
                TemplateEvaluacion = template
            });
            tipoEvaluacion.Templates.Add(template);
            //DAte.Save(template);

            //Condición Fisica
            template = new TemplateEvaluacion { TipoEvaluacion = tipoEvaluacion, Descripcion = "Condición Fisica" };
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Fuerza (explosiva)",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Velocidad",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Resistencia",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Flexibilidad (movilidad)",
                TemplateEvaluacion = template
            });
            tipoEvaluacion.Templates.Add(template);
            //DAte.Save(template);

            //Táctica
            template = new TemplateEvaluacion
            {
                TipoEvaluacion = tipoEvaluacion,
                Descripcion = "Táctica (cualidades cognoscitivas)"
            };
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Inteligencia de juego (visión)",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Conducta o juego ofensivo",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Conducta o juevo defensivo",
                TemplateEvaluacion = template
            });
            tipoEvaluacion.Templates.Add(template);
            //DAte.Save(template);

            //Cualidades mentales
            template = new TemplateEvaluacion { TipoEvaluacion = tipoEvaluacion, Descripcion = "Cualidades mentales" };
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Concentración",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Voluntad",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Perservación",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Confianza",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Disposición al riesgo",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Creatividad",
                TemplateEvaluacion = template
            });
            tipoEvaluacion.Templates.Add(template);
            //DAte.Save(template);

            //Coordinación
            template = new TemplateEvaluacion { TipoEvaluacion = tipoEvaluacion, Descripcion = "Coordinación" };
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Orientación",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle { Descripcion = "Ritmo", TemplateEvaluacion = template });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Reacción",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Equilibrio",
                TemplateEvaluacion = template
            });
            tipoEvaluacion.Templates.Add(template);
            //DAte.Save(template);

            //Cualidades mentales
            template = new TemplateEvaluacion { TipoEvaluacion = tipoEvaluacion, Descripcion = "Cualidades mentales" };
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Concentración",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Voluntad",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Perseverancia",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Confianza",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Disposición al riesgo",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Creatividad",
                TemplateEvaluacion = template
            });
            tipoEvaluacion.Templates.Add(template);
            //DAte.Save(template);

            //Cualidades mentales
            template = new TemplateEvaluacion { TipoEvaluacion = tipoEvaluacion, Descripcion = "Entorno social" };
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Comunicación",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Conducta",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Carisma / personalidad",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Seriedad",
                TemplateEvaluacion = template
            });
            template.Detalles.Add(new TemplateEvaluacionDetalle
            {
                Descripcion = "Compañerismo",
                TemplateEvaluacion = template
            });
            tipoEvaluacion.Templates.Add(template);
            //DAte.Save(template);

            DAti.Save(tipoEvaluacion);

            #endregion
        }
    }


    [TestFixture]
    public class PruebaUsuarios
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
        public void ComboPuestos()
        {
           Console.WriteLine(common.ObtenerComboPuestos(deporte.Id).SerializarToJson());
        }

        [Test]
        public void PruebaLogin()
        {
            var login = DependencyFactory.Resolve<ILoginBusiness>();
            var user = login.LoginUser("klusanguinetti@gmail.com", "PruebaAlta");

            var user1 = login.LoginUser("klusanguinetti@gmail.com", "Facebook", "asdfg");
        }
        [Test]
        public void Desencript()
        {
            Console.Write(BusDep.Common.Encrypt.DecryptFromString64( "w5ZSeZOJ62qVnhlwLut4oA=="));
        }
        //w5ZSeZOJ62qVnhlwLut4oA==
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        [Test]
        public void RegistracionMasiva()
        {
            for (int i = 0; i < 200; i++)
            {
                Registracion(i);
            }
        }

        [Test]
        public void GetPerfil()
        {
            var per = busqueda.ObtenerPerfil(714);
            Console.WriteLine(per.SerializarToJson());
        }

        Random rnd = new Random();
        public void Registracion(int i)
        {
            //var deporte = common.ObtenerDeportes().FirstOrDefault();

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
            try
            {
                userView = registracion.Registracion(userView);
            }
            catch
            {
                return;
            }


            var datos = registracion.ObtenerDatosPersonales(userView);

            var pais = Paises.First(o => o.CodigoIso.Equals("ar"));
            datos.Pais = pais.Nombre;
            datos.PaisIso = pais.CodigoIso;
            pais = Paises[rnd.Next(0, 6)];
            datos.Nacionalidad = pais.Nombre;
            datos.NacionalidadIso = pais.CodigoIso;
            datos.FechaNacimiento = new DateTime(rnd.Next(1990, 2010), rnd.Next(1, 12), rnd.Next(1, 28));

            datos.Informacion = string.Format("{0} {1} {2} {3} {4} {5}", datos.Nombre, datos.Apellido, ", Pais:",
                datos.Pais, ", Fecha Nacimiento:", datos.FechaNacimiento);
            registracion.RegistracionDatosPersonales(datos);

            var jugadorView = jugador.ObtenerJugador(userView);
            //var listaPuesto = common.ObtenerPuestos(userView.DeporteId.GetValueOrDefault());
            if (listaPuesto.Any())
            {
                jugadorView.PuestoId = listaPuesto.ToList()[rnd.Next(0, 10)].Id;
            }
            jugadorView.Pie = Pies[rnd.Next(0, 3)];
            jugadorView.Fichaje = Fichajes[rnd.Next(0, 2)];
            jugadorView.Perfil = Perfiles[rnd.Next(0, 2)];
            jugadorView.Peso = rnd.NextDecimal(75m, 110m);
            jugadorView.Altura = rnd.NextDecimal(1.5m, 2.05m);
            ;
            jugadorView.FotoCuertoEntero = string.Format("aaa{0}.jpg", i);
            jugadorView.FotoRostro = string.Format("bbb{0}.jpg", i);

            jugador.ActualizarDatosJugador(jugadorView);
            var user = login.LoginUser(string.Format(nombre + "{0}@{1}.com", i, apellido), Base64Encode(string.Format("{0}{1}", apellido, nombre)));

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
            var club = Clubes[rnd.Next(0, 20)];
            ante.ClubDescripcion = club.Nombre;
            ante.ClubLogo = club.Code;
            ante.FechaInicio = new DateTime(rnd.Next(2010, 2015), rnd.Next(1, 12), rnd.Next(1, 28));// DateTime.Now.AddYears(-rnd.Next(6, 10));
            ante.FechaFin = ante.FechaInicio.Value.AddYears(rnd.Next(0, 2));
            ante.InformacionAdicional = string.Format("Club: {0}, Desde: {1} - Hasta: {2}", ante.ClubDescripcion, ante.FechaInicio, ante.FechaFin);

            jugador.GuardarAntecedenteViewModel(ante);
            DateTime fechafin = ante.FechaFin.GetValueOrDefault();

            ante = jugador.NuevoAntecedenteViewModel(userView);
            club = Clubes[rnd.Next(0, 20)];
            ante.ClubDescripcion = club.Nombre;
            ante.ClubLogo = club.Code;
            ante.FechaInicio = fechafin.AddMonths(rnd.Next(1, 6));
            ante.InformacionAdicional = string.Format("Club: {0}, Desde: {1}", ante.ClubDescripcion, ante.FechaInicio);
            jugador.GuardarAntecedenteViewModel(ante);

            Console.WriteLine(string.Format("Usuario:{0}", user.Mail));
        }

        [Test]
        public void BusquedaJugador2()
        {
            //for (int w = 0; w < 5; w++)
            //{
                var oo = new BuscarJugadorViewModel
                {
                    Puesto = new[] {listaPuesto.ToList()[rnd.Next(0, 10)].Descripcion},
                    Fichaje = new[] {"Libre"},
                    Perfil = new[] {Perfiles[rnd.Next(0, 2)]},
                    Pie = new[] {"Derecho", "Ambidiestro"},
                    Pagina = 0,
                    Cantidad = 2
                };
                //Fichajes[rnd.Next(0, 2)], Perfiles[rnd.Next(0, 2)]
                var list = busqueda.BuscarJugador(oo);
                Console.WriteLine(list.SerializarToJson());
           //}
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
                var DataList = json.DeserializarToJson<List<ClubDetalleViewModel>>();
            }
            jsonName = "Paises.json";
            targetPath = Path.Combine(directory, jsonName);
            if (File.Exists(targetPath))
            {
                var json = File.ReadAllText(targetPath);
                var DataList = json.DeserializarToJson<List<PaisViewModel>>();
            }
        }

        private List<ClubDetalleViewModel> Clubes => LeerClubes();

        private List<ClubDetalleViewModel> LeerClubes()
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
                return json.DeserializarToJson<List<ClubDetalleViewModel>>();
            }
            return new List<ClubDetalleViewModel>();
        }

        private List<PaisViewModel> paises = null;
        private List<PaisViewModel> Paises
        {
            get
            {
                if (paises == null)
                    paises = LeerPaises();
                return paises;
            }
        }



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
                        .Where(o => new[] { "ar", "bo", "br", "cl", "co", "py", "pe" }.Contains(o.CodigoIso))
                        .ToList();
            }
            return new List<PaisViewModel>();
        }

        private string[] Pies = new[] { "Derecho", "Zurdo", "Ambidiestro" };
        private string[] Fichajes = new[] { "Libre", "Contratado" };
        private string[] Perfiles = new[] { "Amateur", "Profecional" };
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

        [Test]
        public void TestCombo()
        {
            var il = common.ObtenerComboPuestosEspecifico(deporte.Id);
            Console.Write(il.SerializarToJson());

            var il1 = common.ObtenerComboPuestos(deporte.Id);
            Console.Write(il1.SerializarToJson());

            Console.Write(common.ObtenerComboPie().SerializarToJson());
            Console.Write(common.ObtenerComboFichajes().SerializarToJson());
            Console.Write(common.ObtenerComboPerfiles().SerializarToJson());
            Console.Write(common.ObtenerClubes().SerializarToJson());
        }

        [Test]
        public void CargaClub()
        {
            dynamic dataAccess = DependencyFactory.Resolve<IBaseDA<ClubDetalle>>();
            foreach (var viewModel in Clubes)
            {
                var club = viewModel.MapperClass<ClubDetalle>();
                dataAccess.Save(club);
            }
        }


    }

}

