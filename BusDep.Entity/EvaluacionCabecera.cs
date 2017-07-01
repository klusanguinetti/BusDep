namespace BusDep.Entity 
{ 
    public partial class EvaluacionCabecera
    {
        #region Atributos
        public long Id { get; set; }
        public Evaluacion Evaluacion { get; set; }
        public TemplateEvaluacion TemplateEvaluacion { get; set; }
        #endregion 
    }
}
