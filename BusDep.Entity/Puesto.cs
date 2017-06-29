
namespace BusDep.Entity 
{
    using System;
	public class Puesto 
	{
		#region Atributos
        public long Id { get; set; }
		public Deporte Deporte { get; set; }
 		public String Descripcion { get; set; }
 		public String PuestoEspecifico { get; set; }
 		#endregion 
	}
}
