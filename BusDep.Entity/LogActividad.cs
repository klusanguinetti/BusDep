using System;

namespace BusDep.Entity
{
    public partial class LogActividad
    {
        #region Atributos
        public virtual long Id { get; set; }
        public virtual long UsuarioId { get; set; }
        public virtual DateTime? Fecha { get; set; }
        public virtual string Metodo { get; set; }
        public virtual string Descripcion { get; set; }
        #endregion 
    }
}