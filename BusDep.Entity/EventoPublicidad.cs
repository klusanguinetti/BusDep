using System;

namespace BusDep.Entity
{
    public class EventoPublicidad
    {
        #region Atributos
        public virtual long Id { get; set; }
        public virtual string Titulo { get; set; }
        public virtual string Informacion { get; set; }
        public virtual string ImageUrl { get; set; }
        public virtual string Link { get; set; }
        public virtual DateTime? FechaHasta { get; set; }
        public virtual string Estado { get; set; }
        #endregion 
    }
}