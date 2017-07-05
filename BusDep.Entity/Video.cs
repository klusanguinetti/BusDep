namespace BusDep.Entity 
{ 
	public partial class Video
	{
		#region Atributos
		public virtual long Id { get; set; }
		public virtual string Descripcion { get; set; }
		public virtual TipoVideo TipoVideo { get; set; }
		public virtual Usuario Usuario { get; set; }
		#endregion 
	}
}
