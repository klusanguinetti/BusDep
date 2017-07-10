namespace BusDep.ViewModel
{
    using System;
    using System.Runtime.Serialization;
    [DataContract]
    public class DatosPersonaViewModel
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public long UsuarioId { get; set; }
        [DataMember]
        public string Apellido { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Ciudad { get; set; }
        [DataMember]
        public string CodigoPostal { get; set; }
        [DataMember]
        public DateTime? FechaNacimiento { get; set; }
        [DataMember]
        public virtual string Nacionalidad { get; set; }
        [DataMember]
        public virtual string Nacionalidad1 { get; set; }
        [DataMember]
        public virtual string NacionalidadIso { get; set; }
        [DataMember]
        public virtual string NacionalidadIso1 { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string NumeroDocumento { get; set; }
        [DataMember]
        public string Pais { get; set; }
        [DataMember]
        public virtual string PaisIso { get; set; }
        [DataMember]
        public string Provincia { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string TipoDocumento { get; set; }
        [DataMember]
        public string Informacion { get; set; }
    }
}
