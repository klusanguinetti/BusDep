namespace BusDep.Entity 
{
    using System;
    public partial class Antecedente
    {
        #region Atributos
        public long Id { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? FechaInicio { get; set; }
        public string InformacionAdicional { get; set; }
        public string InstitucionDescripcion { get; set; }
        public string LogoInstitucion { get; set; }
        public Usuario Usuario { get; set; }
        public string Video { get; set; }
        #endregion 
    }
}
