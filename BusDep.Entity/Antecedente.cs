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
        #endregion 
    }

    public class ClubDetalle
    {
        public virtual long Id { get; set; }
        public virtual string Division { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Code { get; set; }
    }
}
