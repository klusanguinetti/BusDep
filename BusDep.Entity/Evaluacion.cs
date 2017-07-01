namespace BusDep.Entity 
{ 
    public partial class Evaluacion
    {
        #region Atributos
        public long Id { get; set; }
        public Jugador Jugador { get; set; }
        public long? TipoEvaluacion { get; set; }
        #endregion 
    }
}
