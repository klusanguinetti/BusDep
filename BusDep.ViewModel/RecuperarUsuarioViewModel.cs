namespace BusDep.ViewModel
{
    using System.Runtime.Serialization;
    [DataContract]
    public class RecuperarUsuarioViewModel
    {
        [DataMember]
        public string Mail { get; set; }
        [DataMember]
        public long Codigo { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string VerificacionPassword { get; set; }
    }

    [DataContract]
    public class SolicitudRecuperoUsuarioViewModel
    {
        [DataMember]
        public string Mail { get; set; }
    }

    [DataContract]
    public class RecuperoCodigoViewModel
    {
        [DataMember]
        public string Mail { get; set; }
        [DataMember]
        public long Codigo { get; set; }
    }
}
