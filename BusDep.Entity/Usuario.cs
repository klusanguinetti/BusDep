using System;
using System.Collections.Generic;
using System.Linq;


namespace BusDep.Entity 
{ 
	public partial class Usuario
	{
        #region Atributos
        public long Id { get; set; }
        public String Apellido { get; set; }
		public String Calle { get; set; }
		public String Ciudad { get; set; }
		public String CodigoPostal { get; set; }
		public DateTime? FechaNacimiento { get; set; }
		public String Mail { get; set; }
		public String Nacionalidad { get; set; }
		public String Nacionalidades1 { get; set; }
		public String Nacionalidades2 { get; set; }
		public String Nombre { get; set; }
		public String Numero { get; set; }
		public String NumeroDocumento { get; set; }
		public String Pais { get; set; }
		public String Provincia { get; set; }
		public String Telefono { get; set; }
		public String TipoDocumento { get; set; }
		public BusDep.Entity.TipoUsuario TipoUsuario { get; set; }
		#endregion 
	}
}
