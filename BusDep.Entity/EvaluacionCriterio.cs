namespace BusDep.Entity 
{
    using System;
	public class EvaluacionCriterio
	{
		#region Atributos
        public long Id { get; set; }
		public Criterio Criterio { get; set; }
 		public Evaluacion Evaluacion { get; set; }
 		public decimal? Puntuacion { get; set; }
 		#endregion 
	}
}
