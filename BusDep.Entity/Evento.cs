using System.Collections.Generic;

namespace BusDep.Entity 
{
    using System;
	public class Evento  
	{
	    public Evento()
	    {
	        Participaciones = new List<Participacion>();
	    }
		#region Atributos
        public long Id { get; set; }
		public String Calle { get; set; }
 		public String Ciudad { get; set; }
 		public String Descripcion { get; set; }
 		public DateTime? FechaFin { get; set; }
 		public DateTime? FechaInicio { get; set; }
 		public String Logo { get; set; }
 		public String PaginaWeb { get; set; }
 		public String Pais { get; set; }
 		public String Provincia { get; set; }
 		public TipoEvento TipoEvento { get; set; }
 		public String Titulo { get; set; }
        public IList<Participacion> Participaciones { get; set; }
 		#endregion 
	}
}
