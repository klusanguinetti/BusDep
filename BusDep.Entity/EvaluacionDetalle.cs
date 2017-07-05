namespace BusDep.Entity 
{ 
    public partial class EvaluacionDetalle
    {
        #region Atributos
        public virtual long Id { get; set; }
        public virtual long? Puntuacion { get; set; }
        public virtual EvaluacionCabecera EvaluacionCabecera { get; set; }
        public virtual TemplateEvaluacionDetalle TemplateEvaluacionDetalle { get; set; }
        #endregion 
    }
}
