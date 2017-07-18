using System;

namespace BusDep.Entity
{
    public partial class LogError
    {
        #region Atributos
        public virtual long Id { get; set; }
        public virtual DateTime? Fecha { get; set; }
        public virtual string Modulo { get; set; }
        public virtual string Descripcion { get; set; }
        #endregion 
    }
}