namespace BusDep.Entity 
{
    using System.Collections.Generic;
    public partial class TemplateEvaluacion
    {
        #region constructor
        public TemplateEvaluacion()
        {
            Detalles= new List<TemplateEvaluacionDetalle>();
        }
        #endregion
        #region Atributos
        public virtual long Id { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string Chart { get; set; }
        public virtual TipoEvaluacion TipoEvaluacion { get; set; }
        public virtual IList<TemplateEvaluacionDetalle> Detalles { get; set; }
        #endregion 
    }
}
