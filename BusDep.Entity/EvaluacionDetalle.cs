namespace BusDep.Entity 
{ 
    public partial class EvaluacionDetalle
    {
        #region Atributos
        public long Id { get; set; }
        public long? Puntuacion { get; set; }
        public EvaluacionCabecera EvaluacionCabecera { get; set; }
        public TemplateEvaluacionDetalle TemplateEvaluacionDetalle { get; set; }
        #endregion 
    }
}
