using System;
using System.Collections.Generic;
using System.Linq;


namespace BusDep.Entity 
{ 
	public partial class TemplateEvaluacionDetalle
	{
		#region Atributos
		public long Id { get; set; }
		public String Descripcion { get; set; }
		public BusDep.Entity.TemplateEvaluacion TemplateEvaluacion { get; set; }
		#endregion 
	}
}
