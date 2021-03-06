namespace BusDep.Entity 
{ 
    public partial class Jugador
    {
        #region Atributos
        public virtual long Id { get; set; }
        public virtual decimal? Altura { get; set; }
        public virtual string FotoCuertoEntero { get; set; }
        public virtual string FotoRostro { get; set; }
        public virtual string Perfil { get; set; }
        public virtual decimal? Peso { get; set; }
        public virtual Puesto Puesto { get; set; }
        public virtual Puesto PuestoAlternativo { get; set; }
        //public virtual Usuario Usuario { get; set; }
        public virtual string Pie { get; set; }
        public virtual string Fichaje { get; set; }
        public virtual string ClubDescripcion { get; set; }
        public virtual string ClubLogo { get; set; }
        public virtual string VideoUrl { get; set; }
        #endregion 
    }
}
