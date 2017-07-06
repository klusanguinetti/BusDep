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
        public virtual Usuario Usuario { get; set; }
        public virtual string Pie { get; set; }
        public virtual string Fichaje { get; set; }
        public virtual string ClubDescripcion { get; set; }
        public virtual string ClubLogo { get; set; }
        #endregion 
    }

    public partial class Intermediario
    {
        #region Atributos
        public virtual long Id { get; set; }
        public virtual Usuario Usuario { get; set; }

        #endregion 
    }
    public partial class Entrenador
    {
        #region Atributos
        public virtual long Id { get; set; }
        public virtual Usuario Usuario { get; set; }

        #endregion 
    }
    public partial class Club
    {
        #region Atributos
        public virtual long Id { get; set; }
        public virtual Usuario Usuario { get; set; }

        #endregion 
    }
}
