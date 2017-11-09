using System;
using System.Collections.Generic;
using System.Linq;
using BusDep.Entity;
using BusDep.UnityInject;
using NHibernate.Linq;

namespace BusDep.DataAccess
{
    using BusDep.IDataAccess;
    using ViewModel;

    public class EventoPublicidadDA : BaseDataAccess<EventoPublicidad>, IEventoPublicidadDA
    {
       
        public virtual long EventoPublicidadActivaCount()
        {
            return (from item in Session.Query<EventoPublicidad>()
                where item.Estado == "A" &&
                      (item.FechaHasta == null || item.FechaHasta >= DateTime.Now.Date)
                      && item.ImageUrl!=null && item.Informacion != null && item.Titulo != null
                    select item
                ).Count();
        }
        public virtual List<EventoPublicidadViewModel> GetEventoPublicidadActivaAll()
        {
            
            return (from item in Session.Query<EventoPublicidad>()
                    where item.Estado == "A"
                          &&
                          (item.FechaHasta==null || item.FechaHasta>=DateTime.Now.Date)
                          && item.ImageUrl != null && item.Informacion != null && item.Titulo != null
                    orderby item.Id descending
                    select new EventoPublicidadViewModel
                    {
                        Id = item.Id,
                        Estado = item.Estado,
                        FechaHasta = item.FechaHasta,
                        ImageUrl = item.ImageUrl,
                        Informacion = item.Informacion,
                        Link = item.Link,
                        Titulo = item.Titulo,
                        Categorias = item.Categorias,
                        ClubDescripcion = item.ClubDescripcion,
                        ClubLogo = item.ClubLogo,
                        Lugar = item.Lugar
                    }).ToList();
        }

        public List<EventoPublicidadViewModel> GetEventoPublicidadBOAll()
        {
            return (from item in Session.Query<EventoPublicidad>()
                    where item.Estado == "A"
                          &&
                          (item.FechaHasta == null || item.FechaHasta >= DateTime.Now.Date.AddDays(-15))
                          && item.ImageUrl != null && item.Informacion != null && item.Titulo != null
                    orderby item.Id descending
                    select new EventoPublicidadViewModel
                    {
                        Id = item.Id,
                        Estado = item.Estado,
                        FechaHasta = item.FechaHasta,
                        ImageUrl = item.ImageUrl,
                        Informacion = item.Informacion,
                        Link = item.Link,
                        Titulo = item.Titulo,
                        Categorias = item.Categorias,
                        ClubDescripcion = item.ClubDescripcion,
                        ClubLogo = item.ClubLogo,
                        Lugar = item.Lugar
                    }).ToList();
        }

    }
}
