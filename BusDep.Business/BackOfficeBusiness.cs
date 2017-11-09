using System;
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

        public virtual PublicidadViewModel GetPublicidadId(long id)
        {
            Publicidad publicidad = DependencyFactory.Resolve<IBaseDA<Publicidad>>().GetById(id);
            return publicidad.MapperClass<PublicidadViewModel>();
        }




        #region EventoPublicidadViewModel

        public virtual List<EventoPublicidadViewModel> GetEventoPublicidadAll()
        {
            return DependencyFactory.Resolve<IEventoPublicidadDA>().GetEventoPublicidadBOAll().MapperEnumerable<EventoPublicidadViewModel>().ToList();
        }

        public virtual List<EventoPublicidadViewModel> GetEventoPublicidadActivaAll()
        {
            return DependencyFactory.Resolve<IEventoPublicidadDA>().GetEventoPublicidadActivaAll();
        }
        public virtual long EventoPublicidadActivaCount()
        {
            return DependencyFactory.Resolve<IEventoPublicidadDA>().EventoPublicidadActivaCount();
        }
        public virtual void DeleteEventoPublicidad(EventoPublicidadViewModel eventoPublicidadViewModel)
        {
            var publicidad = DependencyFactory.Resolve<IBaseDA<EventoPublicidad>>().GetById(eventoPublicidadViewModel.Id);
            DependencyFactory.Resolve<IBaseDA<EventoPublicidad>>().Delete(publicidad);

        }
        public virtual EventoPublicidadViewModel GetEventoPublicidadId(long id)
        {
            EventoPublicidad publicidad = DependencyFactory.Resolve<IBaseDA<EventoPublicidad>>().GetById(id);
            return publicidad.MapperClass<EventoPublicidadViewModel>();
        }
        public virtual void SaveEventoPublicidad(EventoPublicidadViewModel publicidadViewModel)
        {
            EventoPublicidad publicidad = (publicidadViewModel.Id.Equals(0)) ? new EventoPublicidad() :
                DependencyFactory.Resolve<IBaseDA<EventoPublicidad>>().GetById(publicidadViewModel.Id);
            publicidadViewModel.MapperClass(publicidad);
            publicidad.Estado = "A";

            if(string.IsNullOrWhiteSpace(publicidad.Titulo) || string.IsNullOrWhiteSpace(publicidad.Informacion) || string.IsNullOrWhiteSpace(publicidad.ImageUrl))
                throw new ExceptionBusiness(123, "Falta cargar información");
            DependencyFactory.Resolve<IBaseDA<EventoPublicidad>>().Save(publicidad);
        }

       
        #endregion
    }
}
