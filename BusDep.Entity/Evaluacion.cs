using System.Collections.Generic;

namespace BusDep.Entity 
{ 
    public partial class Evaluacion
    {
        public Evaluacion()
        {
            Cabeceras = new List<EvaluacionCabecera>();
        }
        #region Atributos
        public long Id { get; set; }
        public Jugador Jugador { get; set; }
        public TipoEvaluacion TipoEvaluacion { get; set; }

        public IList<EvaluacionCabecera> Cabeceras { get; set; }
        #endregion 
    }
}
