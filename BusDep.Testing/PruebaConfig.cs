using BusDep.Configuration;
using BusDep.Entity;
using BusDep.IBusiness;
using BusDep.IDataAccess;
using BusDep.UnityInject;
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
            IUsuarioDA DAu = DependencyFactory.Resolve<IUsuarioDA>();
            #region borrado
            foreach (var d in DAu.GetAll())
            {
                DAu.Delete(d);
            }
            var DAt = DependencyFactory.Resolve<IBaseDA<TipoUsuario>>();
            foreach (var t in DAt.GetAll())
            {
                DAt.Delete(t);
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

            #region creacion usuario
            Usuario usuario = new Usuario
            {
                Mail = "klusanguinetti@gmail.com",
                Password = "PruebaAlta",
                TipoUsuario = jugador
            };
            DatosPersona datos = new DatosPersona
            {
                Usuario = usuario,
                Nombre = "Lucas",
                Apellido = "Sanguinetti"
            };
            usuario.DatosPersona = datos;

            usuario.AplicacionToken.Add(new UsuarioAplicativo { Aplicativo = "Facebook", Token = "asdfg", Usuario = usuario });
            usuario.AplicacionToken.Add(new UsuarioAplicativo { Aplicativo = "Google", Token = "gfdsa", Usuario = usuario });

            DAu.Save(usuario);
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
            var login = DependencyFactory.Resolve<ILogin>();
            var user = login.LoginUser("klusanguinetti@gmail.com", "PruebaAlta");

            var user1 = login.LoginUser("klusanguinetti@gmail.com", "Facebook", "asdfg");
        }




    }
}
