using System;
using System.Collections.Generic;
using System.Linq;


namespace BusDep.Entity 
{ 
	public partial class Jugador
	{
        #region Atributos
        public long Id { get; set; }
        public decimal? Altura { get; set; }
		public String FotoCuertoEntero { get; set; }
		public String FotoRostro { get; set; }
		public String Perfil { get; set; }
		public decimal? Peso { get; set; }
		public BusDep.Entity.Puesto Puesto { get; set; }
		public BusDep.Entity.Usuario Usuario { get; set; }
		#endregion 
	}
}
