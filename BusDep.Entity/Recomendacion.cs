using System;

namespace BusDep.Entity
{
    public class Recomendacion
    {
        #region Atributos
        public virtual long Id { get; set; }
        public virtual DateTime Fecha { get; set; }
        public virtual string Estado { get; set; }
        public virtual string Texto { get; set; }
        public virtual Usuario Emisor { get; set; }
        public virtual Usuario Receptor { get; set; }
        #endregion 
    }
}