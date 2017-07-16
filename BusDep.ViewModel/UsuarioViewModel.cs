using System;

namespace BusDep.ViewModel
{
    using System.Runtime.Serialization;

    [DataContract]
    public class UsuarioViewModel
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Mail { get; set; }
        [DataMember]
        public string TipoUsuario { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public long? DeporteId { get; set; }
        [DataMember]
        public long? JugadorId { get; set; }
        [DataMember]
        public long? DatosPersonaId { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Apellido { get; set; }
        [DataMember]
        public string Pais { get; set; }
        [DataMember]
        public string PaisIso { get; set; }
        [DataMember]
        public DateTime? UltimoLogin { get; set; }
    }


}
