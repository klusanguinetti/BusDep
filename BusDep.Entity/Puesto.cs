using System;
using System.Collections.Generic;
using System.Linq;


namespace BusDep.Entity 
{ 
	public partial class Puesto
	{
		#region Atributos
		public long Id { get; set; }
		public BusDep.Entity.Deporte Deporte { get; set; }
		public String Descripcion { get; set; }
		public String PuestoEspecifico { get; set; }
		#endregion 
	}
}
