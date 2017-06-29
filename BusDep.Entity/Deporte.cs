using System.Collections.Generic;

namespace BusDep.Entity 
{
    using System;
	public class Deporte  
	{
	    public Deporte()
	    {
	        Puestos = new List<Puesto>();
            Criterios= new List<Criterio>();
	    }
		#region Atributos
		public long Id { get; set; }
		public String Descripcion { get; set; }
 		public String Tipo { get; set; }
        public IList<Puesto> Puestos { get; set; }
        public IList<Criterio> Criterios { get; set; }
 		#endregion 
	}
}
