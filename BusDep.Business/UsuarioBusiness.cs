

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
        [AuditMethod]
        public virtual UsuarioViewModel Registracion(UsuarioViewModel userView)
        {
            if (!DependencyFactory.Resolve<IUsuarioDA>().ExisteUsuario(userView.Mail))
            {
                var user = userView.MapperClass<Usuario>(TypeMapper.IgnoreCaseSensitive);
                TipoUsuario tipoUsuario =
                    DependencyFactory.Resolve<IBaseDA<TipoUsuario>>()
                        .GetAll()
                        .FirstOrDefault(o => o.Descripcion.Equals(userView.TipoUsuario));
                if (tipoUsuario != null)
                {
                    user.TipoUsuario = tipoUsuario;
                    user.DatosPersona = new DatosPersona { Usuario = user, Nombre = userView.Nombre, Apellido = userView.Apellido };
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
                    throw new ExceptionBusiness(5, "Error en selección de tipo de usuario.");
                }
                user.Deporte = userView.DeporteId.HasValue
                    ? DependencyFactory.Resolve<IBaseDA<Deporte>>().GetById(userView.DeporteId)
                    : DependencyFactory.Resolve<IBaseDA<Deporte>>().GetAll().First();
                DependencyFactory.Resolve<IUsuarioDA>().Save(user);
                //DependencyFactory.Resolve<IBaseDA<DatosPersona>>().Save(user.DatosPersona);
                //DependencyFactory.Resolve<IBaseDA<Jugador>>().Save(user.Jugador);
                return FillViewModel.FillUsuarioViewModel(user);
            }
            else
            {
                throw new ExceptionBusiness(4, "Usuario ya existe.");
            }
        }
        [AuditMethod]
        public virtual DatosPersonaViewModel ObtenerDatosPersonales(UsuarioViewModel userView)
        {
            if (userView.DatosPersonaId.HasValue)
            {
                return FillViewModel.FillDatosPersonaViewModel(
                    DependencyFactory.Resolve<IBaseDA<DatosPersona>>().GetById(userView.DatosPersonaId));
            }
            return null;

        }
        [AuditMethod]
        public virtual void RegistracionDatosPersonales(DatosPersonaViewModel datosPersona)
        {
            var user = DependencyFactory.Resolve<IUsuarioDA>().GetById(datosPersona.UsuarioId);
            datosPersona.MapperClass(user.DatosPersona, TypeMapper.IgnoreCaseSensitive);
            DependencyFactory.Resolve<IUsuarioDA>().Save(user);
        }

    }
}

