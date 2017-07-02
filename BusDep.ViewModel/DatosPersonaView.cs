namespace BusDep.ViewModel
{
    using System;
    using System.Runtime.Serialization;
    [DataContract]
    public class DatosPersonaView
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public long UsuarioId { get; set; }
        [DataMember]
        public string Apellido { get; set; }
        [DataMember]
        public string Calle { get; set; }
        [DataMember]
        public string Ciudad { get; set; }
        [DataMember]
        public string CodigoPostal { get; set; }
        [DataMember]
        public DateTime? FechaNacimiento { get; set; }
        [DataMember]
        public string Nacionalidad { get; set; }
        [DataMember]
        public string Nacionalidades1 { get; set; }
        [DataMember]
        public string Nacionalidades2 { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Numero { get; set; }
        [DataMember]
        public string NumeroDocumento { get; set; }
        [DataMember]
        public string Pais { get; set; }
        [DataMember]
        public string Provincia { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string TipoDocumento { get; set; }
    }
}
