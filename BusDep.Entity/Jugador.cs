using System.Collections.Generic;

namespace BusDep.Entity 
{
    using System;
	public class Jugador
	{
	    public Jugador()
	    {
	        Evaluaciones = new List<Evaluacion>();
	    }
		#region Atributos
		public long Id{ get; set; }
		public decimal? Altura { get; set; }
 		public String FotoCuertoEntero { get; set; }
 		public String FotoRostro { get; set; }
 		public String Perfil { get; set; }
 		public decimal? Peso { get; set; }
 		public Puesto Puesto { get; set; }
	    public Usuario Usuario { get; set; }
        public IList<Evaluacion> Evaluaciones { get; set; }
 		#endregion 
	}
}
