namespace BusDep.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
            this.MenuUsuario = new List<MenuViewModel>();
        }
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
        public long? EntrenadorId { get; set; }
        [DataMember]
        public long? IntermediarioId { get; set; }
        [DataMember]
        public long? ClubId { get; set; }
        [DataMember]
        public long? VideoAnalistaId { get; set; }
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
        [DataMember]
        public List<MenuViewModel> MenuUsuario { get; set; }

}
}
