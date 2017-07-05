using System.Collections.Generic;

namespace BusDep.Entity
{
    public partial class TipoEvaluacion
    {
        public TipoEvaluacion()
        {
            Templates= new List<TemplateEvaluacion>();
        }
        public virtual long Id { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string EsDefault { get; set; }
        public virtual Deporte Deporte { get; set; }
        public virtual IList<TemplateEvaluacion> Templates { get; set; }
    }
}
