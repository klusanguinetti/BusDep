namespace BusDep.Entity 
{
    using System;
	public class InscripcionEvento
	{
		#region Atributos
		public long Id{ get; set; }
		public Evento Evento { get; set; }
 		public DateTime? Fecha { get; set; }
 		public Usuario Usuario { get; set; }
 		#endregion 
	}
}
