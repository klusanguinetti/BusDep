using System.Collections.Generic;

namespace BusDep.Entity 
{ 
    public partial class EvaluacionCabecera
    {
        public EvaluacionCabecera()
        {
            Detalles = new List<EvaluacionDetalle>();
        }
        #region Atributos
        public long Id { get; set; }
        public Evaluacion Evaluacion { get; set; }
        public TemplateEvaluacion TemplateEvaluacion { get; set; }
        public IList<EvaluacionDetalle> Detalles { get; set; }
        #endregion 
    }
}
