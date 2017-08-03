using System.Collections.Generic;
using System.Linq;

namespace BusDep.ViewModel
{
    using System;
    using System.Runtime.Serialization;
    [DataContract]
    public class EvaluacionViewModel
    {
        public EvaluacionViewModel()
        {
            Cabeceras = new List<EvaluacionCabeceraViewModel>();
        }
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public long JugadorId { get; set; }
        [DataMember]
        public long TipoEvaluacionId { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public List<EvaluacionCabeceraViewModel> Cabeceras { get; set; }
    }

    [DataContract]
    public class EvaluacionCabeceraViewModel
    {
        public EvaluacionCabeceraViewModel()
        {
            Detalle=new List<EvaluacionDetalleViewModel>();
        }
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public decimal Promedio { get; set; }
        [DataMember]
        public List<EvaluacionDetalleViewModel> Detalle { get; set; }

        [DataMember]
        public string[] Labels
        {
            get { return Detalle.Select(o => o.Descripcion).ToArray(); }
        }

        [DataMember]
        public long[] Values
        {
            get { return Detalle.Select(o => o.Puntuacion.GetValueOrDefault()).ToArray(); }
        }
    }

    [DataContract]
    public class EvaluacionDetalleViewModel
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public long? Puntuacion { get; set; }

    }
}
