

using System;
using System.Collections.Generic;
using System.Text;

namespace BusDep.Business
{
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
                    user.DatosPersona = new DatosPersona { Nombre = userView.Nombre, Apellido = userView.Apellido };
                    switch (user.TipoUsuario.Descripcion)
                    {
                        case "Jugador":
                            user.Jugador = new Jugador { };
                            break;
                        case "Entrenador":
                            user.Entrenador = new Entrenador { };
                            break;
                        case "Intermediario":
                            user.Intermediario = new Intermediario { };
                            break;
                        case "Club":
                            user.Club = new Club {  };
                            break;
                        case "Video Analista":
                            user.VideoAnalista = new VideoAnalista { };
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
                return FillViewModel.FillUsuarioViewModel(user);
            }
            else
            {
                throw new ExceptionBusiness(4, "Usuario ya existe.");
            }
        }
       

        [AuditMethod]
        public virtual RecuperoCodigoViewModel SolicitudRecuperoUsuario(SolicitudRecuperoUsuarioViewModel solicitud)
        {
            if (DependencyFactory.Resolve<IUsuarioDA>().ExisteUsuario(solicitud.Mail))
            {
                RecuperoUsuario recupero = null;
                List<KeyValuePair<string,object>>  buscar = new List<KeyValuePair<string, object>>();
                buscar.Add(new KeyValuePair<string, object>("Mail", solicitud.Mail));
                buscar.Add(new KeyValuePair<string, object>("Fecha", DateTime.Now.Date));
                var il = DependencyFactory.Resolve<IBaseDA<RecuperoUsuario>>().SearchBy(buscar);
                if (il.Count > 0)
                    recupero = il[0];
                else
                {
                    Random rnd = new Random();
                    recupero = new RecuperoUsuario {Codigo = rnd.Next(10000000, 99999999), Mail = solicitud.Mail, Fecha = DateTime.Now.Date };
                    DependencyFactory.Resolve<IBaseDA<RecuperoUsuario>>().Save(recupero);
                }
                return new RecuperoCodigoViewModel { Mail = solicitud.Mail, Codigo = recupero.Codigo};
            }
            else
            {
                throw new ExceptionBusiness(100, "Usuario no existe.");
            }
        }

        [AuditMethod]
        public virtual UsuarioViewModel RecuperarUsuario(RecuperarUsuarioViewModel recuperarUsuario)
        {
            
            List<KeyValuePair<string, object>> buscar = new List<KeyValuePair<string, object>>();
            buscar.Add(new KeyValuePair<string, object>("Mail", recuperarUsuario.Mail));
            buscar.Add(new KeyValuePair<string, object>("Fecha", DateTime.Now.Date));
            buscar.Add(new KeyValuePair<string, object>("Codigo", recuperarUsuario.Codigo));
            var il = DependencyFactory.Resolve<IBaseDA<RecuperoUsuario>>().SearchBy(buscar);
            if (il.Count.Equals(1))
            {
                if(!recuperarUsuario.Password.Equals(recuperarUsuario.VerificacionPassword))
                    throw new ExceptionBusiness(103, "Las password no son iguales.");
                var recupero = il[0];
                var usuario = DependencyFactory.Resolve<IUsuarioDA>().ObtenerUsuarioPorMail(recupero.Mail);
                var pass = Encrypt.DecryptFromString64(usuario.Password);
                var plainTextBytes = Encoding.UTF8.GetBytes(pass);
                string oldPassword = Convert.ToBase64String(plainTextBytes);
                
                var actualizar = new UsuarioCambioPasswordViewModel
                {
                    Id = usuario.Id,
                    Mail = recupero.Mail,
                    NewPassword = recuperarUsuario.Password,
                    OldPassword = oldPassword
                };
                
                return DependencyFactory.Resolve<ILoginBusiness>().ActualizarPassword(actualizar);
            }
            else
            {
                throw new ExceptionBusiness(100, "El N° de recuperación es invalido.");
            }
        }

    }
}

