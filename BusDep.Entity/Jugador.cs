namespace BusDep.Entity 
{ 
    public partial class Jugador
    {
        #region Atributos
        public long Id { get; set; }
        public decimal? Altura { get; set; }
        public string FotoCuertoEntero { get; set; }
        public string FotoRostro { get; set; }
        public string Perfil { get; set; }
        public decimal? Peso { get; set; }
        public Puesto Puesto { get; set; }
        public Usuario Usuario { get; set; }
        #endregion 
    }
}
