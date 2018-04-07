using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusDep.Common;
using BusDep.IBusiness;
using BusDep.IDataAccess;
using BusDep.UnityInject;
using BusDep.ViewModel;

namespace BusDep.Business
{
    public class DatosPersonalesBusiness: IDatosPersonalesBusiness
    {
        [AuditMethod]
        public virtual DatosPersonaViewModel ObtenerDatosPersonales(UsuarioViewModel userView)
        {
            if (userView.DatosPersonaId.HasValue)
            {
                return DependencyFactory.Resolve<IUsuarioDA>().ObtenerDatosPersonales(userView.DatosPersonaId.Value);
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
