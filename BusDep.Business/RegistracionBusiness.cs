namespace BusDep.Business
{
    using System;
    using System.Linq;
    using BusDep.Common;
    using BusDep.IBusiness;
    using BusDep.ViewModel;
    using BusDep.Entity;
    using BusDep.IDataAccess;
    using BusDep.UnityInject;
    public class RegistracionBusiness : IRegistracionBusiness
    {
        public virtual UserViewModel Registracion(UserViewModel userView)
        {
            var user = userView.MapperClass<Usuario>(TypeMapper.IgnoreCaseSensitive);
            TipoUsuario tipoUsuario = DependencyFactory.Resolve<IBaseDA<TipoUsuario>>().GetAll().FirstOrDefault(o => o.Descripcion.Equals(userView.TipoUsuario));
            if (tipoUsuario != null)
            {
                user.TipoUsuario = tipoUsuario;
                user.DatosPersona= new DatosPersona {Usuario = user};
            }
            else
            {
                throw new Exception("No existe tipo usuario.");
            }
            DependencyFactory.Resolve<IUsuarioDA>().Save(user);
            return FillUser(user);

        }
        private UserViewModel FillUser(Usuario user)
        {
            if (user != null)
            {
                var userView = user.MapperClass<UserViewModel>(TypeMapper.IgnoreCaseSensitive);
                userView.TipoUsuario = user.TipoUsuario.Descripcion;
                return userView;
            }
            else
            {
                return null;
            }
        }

        public virtual DatosPersonaView ObtenerDatosPersonales(long userId)
        {
            var user = DependencyFactory.Resolve<IUsuarioDA>().GetById(userId);

            var dato = user.DatosPersona.MapperClass<DatosPersonaView>();
            dato.UsuarioId = user.Id;

            return dato;

        }

        public virtual void RegistracionDatosPersonales(DatosPersonaView datosPersona)
        {
            var user = DependencyFactory.Resolve<IUsuarioDA>().GetById(datosPersona.UsuarioId);
            datosPersona.MapperClass(user.DatosPersona, TypeMapper.IgnoreCaseSensitive);
            DependencyFactory.Resolve<IUsuarioDA>().Save(user);
        }
    }
}
