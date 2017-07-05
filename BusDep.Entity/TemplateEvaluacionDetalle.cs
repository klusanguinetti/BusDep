namespace BusDep.Entity 
{ 
	public partial class TemplateEvaluacionDetalle
	{
		#region Atributos
		public virtual long Id { get; set; }
		public virtual string Descripcion { get; set; }
		public virtual TemplateEvaluacion TemplateEvaluacion { get; set; }
		#endregion 
	}
}
