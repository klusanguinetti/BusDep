using BusDep.Entity;
using BusDep.ViewModel;

namespace BusDep.IDataAccess
{
    public interface IVideoAnalistaDA : IBaseDA<VideoAnalista>
    {
        VideoAnalistaViewModel ObtenerVideoAnalista(long id);
    }
}