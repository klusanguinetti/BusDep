using System.Collections.Generic;
using System.Linq;
using BusDep.Common;
using BusDep.Entity;
using BusDep.IBusiness;
using BusDep.IDataAccess;
using BusDep.UnityInject;
using BusDep.ViewModel;

namespace BusDep.Business
{
    public class BackOfficeBusiness : IBackOfficeBusiness
    {
        public virtual void SavePublicidad(PublicidadViewModel publicidadViewModel)
        {
            Publicidad publicidad = (publicidadViewModel.Id.Equals(0))?new Publicidad() : 
                 DependencyFactory.Resolve<IBaseDA<Publicidad>>().GetById(publicidadViewModel.Id);
            publicidadViewModel.MapperClass(publicidad);
            publicidad.Estado = "A";
            DependencyFactory.Resolve<IBaseDA<Publicidad>>().Save(publicidad);
        }

        public virtual void DeletePublicidad(PublicidadViewModel publicidadViewModel)
        {
            var publicidad = DependencyFactory.Resolve<IBaseDA<Publicidad>>().GetById(publicidadViewModel.Id);
            DependencyFactory.Resolve<IBaseDA<Publicidad>>().Delete(publicidad);
        }

        public virtual List<PublicidadViewModel> GetPublicidadAll()
        {
            return DependencyFactory.Resolve<IBaseDA<Publicidad>>().GetAll().MapperEnumerable<PublicidadViewModel>().ToList();
        }

        public virtual PublicidadViewModel GetPublicidadById(long id)
        {
            Publicidad publicidad = DependencyFactory.Resolve<IBaseDA<Publicidad>>().GetById(id);
            return publicidad.MapperClass<PublicidadViewModel>();
        }


    }
}
