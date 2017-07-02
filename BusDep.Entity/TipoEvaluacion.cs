using System.Collections.Generic;

namespace BusDep.Entity
{
    public partial class TipoEvaluacion
    {
        public TipoEvaluacion()
        {
            Templates= new List<TemplateEvaluacion>();
        }
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public string EsDefault { get; set; }
        public Deporte Deporte { get; set; }
        public IList<TemplateEvaluacion> Templates { get; set; }
    }
}
