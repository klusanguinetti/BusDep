namespace BusDep.Entity
{
    using System;
    public class DatosPersona
    {
        public virtual long Id { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual string Apellido { get; set; }
        public virtual string Calle { get; set; }
        public virtual string Ciudad { get; set; }
        public virtual string CodigoPostal { get; set; }
        public virtual DateTime? FechaNacimiento { get; set; }
        public virtual string Nacionalidad { get; set; }
        public virtual string Nacionalidad1 { get; set; }
        public virtual string NacionalidadIso { get; set; }
        public virtual string NacionalidadIso1 { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Numero { get; set; }
        public virtual string NumeroDocumento { get; set; }
        public virtual string Pais { get; set; }
        public virtual string PaisIso { get; set; }
        public virtual string Provincia { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string TipoDocumento { get; set; }
        
    }
}