using System;
using System.Runtime.Serialization;

namespace BusDep.ViewModel
{
    [DataContract]
    public class PerfilJugadorShortViewModel : PerfilBaseViewModel
    {
        [DataMember]
        public string Puesto { get; set; }
        [DataMember]
        public string PuestoCode { get; set; }
        [DataMember]
        public string PuestoAlt { get; set; }
        [DataMember]
        public string PuestoAltCode { get; set; }   
        [DataMember]
        public string Provincia { get; set; }
        [DataMember]
        public string Ciudad { get; set; }
        [DataMember]
        public decimal? Altura { get; set; }
        [DataMember]
        public decimal? Peso { get; set; }
        [DataMember]
        public string ClubActual { get; set; }
        [DataMember]
        public string ClubCode { get; set; }
        [DataMember]
        public string Pie { get; set; }
    }
}