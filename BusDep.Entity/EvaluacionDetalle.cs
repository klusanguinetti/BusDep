using System;
using System.Collections.Generic;
using System.Linq;


namespace BusDep.Entity 
{ 
	public partial class EvaluacionDetalle
	{
        #region Atributos
        public long Id { get; set; }
        public BusDep.Entity.EvaluacionCabecera EvaluacionCabecera { get; set; }
 		public long? Puntuacion { get; set; }
 		public BusDep.Entity.TemplateEvaluacionDetalle TemplateEvaluacionDetalle { get; set; }
 		#endregion 
	}
}
