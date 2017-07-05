namespace BusDep.ViewModel
{
    using System;
    using System.Runtime.Serialization;
    [DataContract]
    public class JugadorBusquedaViewModel
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Apellido { get; set; }
        public string FotoRostro { get; set; }
        [DataMember]
        public string Nacionalidad { get; set; }
        [DataMember]
        public string Nacionalidades1 { get; set; }
        [DataMember]
        public string PuestoDescripcion { get; set; }
        [DataMember]
        public string ClubActual { get; set; }
        [DataMember]
        public string Perfil { get; set; }
        [DataMember]
        public string Pie { get; set; }
        [DataMember]
        public string Fichaje { get; set; }
    }
}
