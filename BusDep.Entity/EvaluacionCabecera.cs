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
        public virtual long Id { get; set; }
        public virtual Evaluacion Evaluacion { get; set; }
        public virtual TemplateEvaluacion TemplateEvaluacion { get; set; }
        public virtual IList<EvaluacionDetalle> Detalles { get; set; }
        #endregion 
    }
}
