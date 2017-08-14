using System;
using System.Runtime.Serialization;

namespace BusDep.ViewModel
{
    [DataContract]
    public class PerfilJugadorShortViewModel
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Apellido { get; set; }
        [DataMember]
        public string Nacionalidad { get; set; }
        [DataMember]
        public string NacionalidadIso { get; set; }
        [DataMember]
        public string Nacionalidad1 { get; set; }
        [DataMember]
        public string NacionalidadIso1 { get; set; }
        [DataMember]
        public string Puesto { get; set; }
        [DataMember]
        public string PuestoCode { get; set; }
        [DataMember]
        public string Perfil { get; set; }
        [DataMember]
        public string Provincia { get; set; }
        [DataMember]
        public string Ciudad { get; set; }
        [DataMember]
        public DateTime? FechaNacimiento { get; set; }
        [DataMember]
        public decimal? Altura { get; set; }
        [DataMember]
        public decimal? Peso { get; set; }
        [DataMember]
        public string ClubActual { get; set; }
        [DataMember]
        public string ClubCode { get; set; }

        [DataMember]
        public int? Edad
        {
            get
            {
                if (!FechaNacimiento.HasValue)
                    return null;
                return DateTime.Today.AddTicks(-FechaNacimiento.Value.Ticks).Year - 1;

            }
            set { }
        }

    }
}