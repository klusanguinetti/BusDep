using System.Linq;
using BusDep.Entity;
using BusDep.IDataAccess;
using BusDep.ViewModel;
using NHibernate.Linq;

namespace BusDep.DataAccess
{
    public class VideoAnalistaDA : BaseDataAccess<VideoAnalista>, IVideoAnalistaDA
    {
        public virtual VideoAnalistaViewModel ObtenerVideoAnalista(long id)
        {
            var il = (from item in Session.Query<Usuario>()
                where item.VideoAnalista != null && item.VideoAnalista.Id.Equals(id)
                      && item.Estado == "A"
                select new VideoAnalistaViewModel
                {
                    Apellido = item.DatosPersona.Apellido,
                    FotoRostro = item.Entrenador.FotoRostro,
                    Id = item.VideoAnalista.Id,
                    Nacionalidad = item.DatosPersona.Nacionalidad,
                    Nacionalidad1 = item.DatosPersona.Nacionalidad1,
                    NacionalidadIso = item.DatosPersona.NacionalidadIso,
                    NacionalidadIso1 = item.DatosPersona.NacionalidadIso1,
                    FechaNacimiento = item.DatosPersona.FechaNacimiento,
                    Pais = item.DatosPersona.Pais,
                    PaisIso = item.DatosPersona.PaisIso,
                    Nombre = item.DatosPersona.Nombre,
                    Perfil = item.Entrenador.Perfil,
                    UsuarioId = item.Id
                }).ToList();
            return il.FirstOrDefault();

        }
    }
}