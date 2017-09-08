using System;
using System.Runtime.Serialization;

namespace BusDep.ViewModel
{
    [DataContract]
    public class RecomendacionViewModel
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string Texto { get; set; }
        [DataMember]
        public string Emisor { get; set; }
        [DataMember]
        public string Receptor { get; set; }
        [DataMember]
        public long EmisorId { get; set; }
        [DataMember]
        public long ReceptorId { get; set; }

    }
}