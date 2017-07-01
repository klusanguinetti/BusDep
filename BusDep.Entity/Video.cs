namespace BusDep.Entity 
{ 
	public partial class Video
	{
		#region Atributos
		public long Id { get; set; }
		public string Descripcion { get; set; }
		public TipoVideo TipoVideo { get; set; }
		public Usuario Usuario { get; set; }
		#endregion 
	}
}
