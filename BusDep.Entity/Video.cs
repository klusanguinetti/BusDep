using System;
using System.Collections.Generic;
using System.Linq;


namespace BusDep.Entity 
{ 
	public partial class Video
	{
		#region Atributos
		
		public long Id { get; set; }
		public String Descripcion { get; set; }
		public BusDep.Entity.TipoVideo TipoVideo { get; set; }
		public BusDep.Entity.Usuario Usuario { get; set; }
		#endregion 
	}
}
