namespace BusDep.Entity 
{
    using System;
	public class Antecedente  
	{
		#region Atributos
		public long Id { get; set; }
		public DateTime? FechaFin { get; set; }
 		public DateTime? FechaInicio { get; set; }
 		public String InformacionAdicional { get; set; }
 		public String InstitucionDescripcion { get; set; }
 		public String LogoInstitucion { get; set; }
 		public Usuario Usuario { get; set; }
 		public String Video { get; set; }
 		#endregion 
	}
}
