namespace BusDep.Entity 
{ 
	public class Participacion  
	{
		#region Atributos
        public long Id { get; set; }
		public long? Categoria { get; set; }
 		public Evento Evento { get; set; }
 		#endregion 
	}
}
