using System;

namespace BusDep.Entity
{
    public class RecuperoUsuario
    {
        public virtual long Id { get; set; }
        public virtual string Mail { get; set; }
        public virtual long Codigo { get; set; }
        public virtual DateTime Fecha { get; set; }
    }
}