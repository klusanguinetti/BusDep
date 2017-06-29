using System.Collections.Generic;

namespace BusDep.Entity 
{
    using System;
	public class Evaluacion
	{
	    public Evaluacion()
	    {
            Criterios = new List<EvaluacionCriterio>();
	    }
		#region Atributos
		public long Id{ get; set; }
		public Certificacion Certificacion { get; set; }
 		public decimal? PuntuacionGeneral { get; set; }
 		public long? TipoEvaluacion { get; set; }
 		public Usuario Usuario { get; set; }
        public IList<EvaluacionCriterio> Criterios { get; set; }
 		#endregion 
	}
}
