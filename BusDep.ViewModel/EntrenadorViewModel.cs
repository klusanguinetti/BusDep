using System;
using System.Runtime.Serialization;

namespace BusDep.ViewModel
{
    [DataContract]
    public class EntrenadorViewModel
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Apellido { get; set; }
        [DataMember]
        public string FotoRostro { get; set; }
        [DataMember]
        public long UsuarioId { get; set; }
        [DataMember]
        public string Nacionalidad { get; set; }
        [DataMember]
        public string Nacionalidad1 { get; set; }
        [DataMember]
        public string NacionalidadIso { get; set; }
        [DataMember]
        public string NacionalidadIso1 { get; set; }
        [DataMember]
        public string Perfil { get; set; }
        [DataMember]
        public string Informacion { get; set; }
        [DataMember]
        public string Pais { get; set; }
        [DataMember]
        public string PaisIso { get; set; }
        [DataMember]
        public bool Recomendar { get; set; }
        [DataMember]
        public DateTime? FechaNacimiento { get; set; }

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

        [DataMember]
        public string Link { get; set; }
    }
}