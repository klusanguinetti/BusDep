using System;
using System.Collections.Generic;
using System.Linq;


namespace BusDep.Entity 
{ 
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
		public String Descripcion { get; set; }
		public Deporte Deporte { get; set; }
		public IList<TemplateEvaluacionDetalle> Detalles { get; set; }
		#endregion 
	}
}
