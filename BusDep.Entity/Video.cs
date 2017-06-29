namespace BusDep.Entity 
{
    using System;
	public class Video
	{
		#region Atributos
        public long Id { get; set; }
		public String Descripcion { get; set; }
 		public TipoVideo TipoVideo { get; set; }
 		public Usuario Usuario { get; set; }
 		#endregion 
	}
}
