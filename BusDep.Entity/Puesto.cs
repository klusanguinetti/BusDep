namespace BusDep.Entity 
{ 
	public partial class Puesto
	{
		#region Atributos
		public long Id { get; set; }
		public Deporte Deporte { get; set; }
		public string Descripcion { get; set; }
		public string PuestoEspecifico { get; set; }
		#endregion 
	}
}
