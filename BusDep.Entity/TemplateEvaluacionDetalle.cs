namespace BusDep.Entity 
{ 
	public partial class TemplateEvaluacionDetalle
	{
		#region Atributos
		public long Id { get; set; }
		public string Descripcion { get; set; }
		public TemplateEvaluacion TemplateEvaluacion { get; set; }
		#endregion 
	}
}
