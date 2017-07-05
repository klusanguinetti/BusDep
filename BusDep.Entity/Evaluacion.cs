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
        public virtual long Id { get; set; }
        public virtual Jugador Jugador { get; set; }
        public virtual TipoEvaluacion TipoEvaluacion { get; set; }

        public virtual IList<EvaluacionCabecera> Cabeceras { get; set; }
        #endregion 
    }
}
