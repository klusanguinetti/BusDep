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
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public TipoEvaluacion TipoEvaluacion { get; set; }
        public IList<TemplateEvaluacionDetalle> Detalles { get; set; }
        #endregion 
    }
}
