using BusDep.Common;
using BusDep.IBusiness;
using BusDep.IDataAccess;
using BusDep.UnityInject;
using BusDep.ViewModel;

namespace BusDep.Business
{
    public class UsuarioVideoAnalistaBusiness : IUsuarioVideoAnalistaBusiness
    {
        public virtual void ActualizarDatos(VideoAnalistaViewModel videoAnalistaView)
        {
            var videoAnalista = DependencyFactory.Resolve<IVideoAnalistaDA>().GetById(videoAnalistaView.Id);
            videoAnalistaView.MapperClass(videoAnalista, TypeMapper.IgnoreCaseSensitive);
            DependencyFactory.Resolve<IVideoAnalistaDA>().Save(videoAnalista);
        }
    }
}