namespace BusDep.ViewModel
{
    using System;
    using System.Runtime.Serialization;
    [DataContract]
    public class JugadorViewModel
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public decimal? Altura { get; set; }
        [DataMember]
        public string FotoCuertoEntero { get; set; }
        [DataMember]
        public string FotoRostro { get; set; }
        [DataMember]
        public string Perfil { get; set; }
        [DataMember]
        public decimal? Peso { get; set; }
        [DataMember]
        public long? PuestoId { get; set; }
        [DataMember]
        public string PuestoDescripcion { get; set; }
        [DataMember]
        public long UsuarioId { get; set; }
    }
}