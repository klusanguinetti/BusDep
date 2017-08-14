namespace BusDep.Entity 
{
    using System;
    public partial class Antecedente
    {
        #region Atributos
        public virtual long Id { get; set; }
        public virtual DateTime? FechaFin { get; set; }
        public virtual DateTime FechaInicio { get; set; }
        public virtual string InformacionAdicional { get; set; }
        public virtual string ClubDescripcion { get; set; }
        public virtual string ClubLogo { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual string Video { get; set; }
        public virtual int? Goles { get; set; }
        public virtual int? Partidos { get; set; }
        public virtual int? Asistencias { get; set; }
        public virtual string Puesto { get; set; }
        public virtual string PuestoAlt { get; set; }
        public virtual string TecnicoNombre { get; set; }
        public virtual string TecnicoMail { get; set; }
        public virtual string TextoLibre { get; set; }
        
        #endregion 
    }
}
