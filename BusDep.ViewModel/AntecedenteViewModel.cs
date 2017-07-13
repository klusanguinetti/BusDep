namespace BusDep.ViewModel
{
    using System;
    using System.Runtime.Serialization;
    [DataContract]
    public partial class AntecedenteViewModel
    {
        #region Atributos
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public DateTime? FechaFin { get; set; }
        [DataMember]
        public DateTime FechaInicio { get; set; }
        [DataMember]
        public string InformacionAdicional { get; set; }
        [DataMember]
        public string ClubDescripcion { get; set; }
        [DataMember]
        public string ClubLogo { get; set; }
        [DataMember]
        public long UsuarioId { get; set; }
        [DataMember]
        public string Video { get; set; }
        [DataMember]
        public string Categoria { get; set; }
        [DataMember]
        public int? Goles { get; set; }
        [DataMember]
        public int? Partidos { get; set; }
        [DataMember]
        public int? Asistencias { get; set; }
        #endregion 
    }
}