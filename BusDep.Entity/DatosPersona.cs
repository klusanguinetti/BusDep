namespace BusDep.Entity
{
    using System;
    public class DatosPersona
    {
        public long Id { get; set; }
        public Usuario Usuario { get; set; }
        public string Apellido { get; set; }
        public string Calle { get; set; }
        public string Ciudad { get; set; }
        public string CodigoPostal { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string Nacionalidades1 { get; set; }
        public string Nacionalidades2 { get; set; }
        public string Nombre { get; set; }
        public string Numero { get; set; }
        public string NumeroDocumento { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Telefono { get; set; }
        public string TipoDocumento { get; set; }
        
    }
}