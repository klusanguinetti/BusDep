﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusDep.IDataAccess;
using BusDep.Entity;
using BusDep.ViewModel;
using NHibernate.Linq;

namespace BusDep.DataAccess
{
    public class CommnDA : BaseDataAccess<Puesto>, ICommnDA
    {
        #region metodos publicos
        public virtual IEnumerable<PuestoViewModel> ObtenerPuestos(long deporteId)
        {
            return ObtenerPuestosViewModel(deporteId);
        }
        public virtual IEnumerable<DeporteViewModel> ObtenerDeportes()
        {
            return from o in Session.Query<Deporte>()
                   select new DeporteViewModel
                   {
                       Id = o.Id,
                       Descripcion = o.Descripcion,
                       Tipo = o.Tipo
                   };
        }

        public virtual IEnumerable<ComboViewModel> ObtenerComboPuestos(long deporteId)
        {
            return (from o in Session.Query<Puesto>()
                    where o.Deporte.Id.Equals(deporteId)
                    select new ComboViewModel
                    {
                        Id = o.Descripcion,
                        Descripcion = o.Descripcion
                    }).Distinct();
        }

        public virtual IEnumerable<ClubDetalleViewModel> ObtenerClubes()
        {
            return (from o in Session.Query<ClubDetalle>()
                    select new ClubDetalleViewModel
                    {
                        Code = o.Code,
                        Division = o.Division,
                        Nombre = o.Nombre
                    });
        }
        
        public virtual IEnumerable<PuestoViewModel> ObtenerDeportesPuestos()
        {
            return ObtenerPuestosViewModel(null);
        }
        #endregion

        #region metodos privados
        private IEnumerable<PuestoViewModel> ObtenerPuestosViewModel(long? deporteId)
        {
            return from o in Session.Query<Puesto>()
                   where deporteId.HasValue? o.Deporte.Id.Equals(deporteId.Value): 1.Equals(1)
                   select new PuestoViewModel
                   {
                       DeporteId = o.Deporte.Id,
                       Id = o.Id,
                       Descripcion = o.Descripcion,
                       PuestoEspecifico = o.PuestoEspecifico,
                       Codigo = o.Codigo
                   };
        }
        #endregion
    }
}
