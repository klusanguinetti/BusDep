
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
        public string Nombre { get; set; }
        [DataMember]
        public string Apellido { get; set; }
        [DataMember]
        public string FotoRostro { get; set; }
        [DataMember]
        public string FotoCuertoEntero { get; set; }
        [DataMember]
        public long? PuestoId { get; set; }
        [DataMember]
        public string PuestoCodigo { get; set; }
        [DataMember]
        public string PuestoDescripcion { get; set; }

        [DataMember]
        public long? PuestoAltId { get; set; }
        [DataMember]
        public string PuestoAltCodigo { get; set; }
        [DataMember]
        public string PuestoAltDescripcion { get; set; }

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
        public string ClubActual { get; set; }
        [DataMember]
        public string ClubCode { get; set; }
        [DataMember]
        public string Perfil { get; set; }
        [DataMember]
        public string Pie { get; set; }
        [DataMember]
        public string Fichaje { get; set; }
        [DataMember]
        public string Informacion { get; set; }
        [DataMember]
        public string Pais { get; set; }
        [DataMember]
        public string PaisIso { get; set; }
        [DataMember]
        public decimal? Altura { get; set; }
        [DataMember]
        public decimal? Peso { get; set; }
        [DataMember]
        public DateTime? FechaNacimiento { get; set; }

        [DataMember]
        public int? Edad {
            get
            {
                if(!FechaNacimiento.HasValue)
                    return null;
                return DateTime.Today.AddTicks(-FechaNacimiento.Value.Ticks).Year - 1;
                
            }
            set { }
        }
    }
}
