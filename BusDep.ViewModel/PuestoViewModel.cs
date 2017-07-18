using System.Collections.Generic;

namespace BusDep.ViewModel
{
    using System;
    using System.Runtime.Serialization;
    [DataContract]
    public class PuestoViewModel
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public long DeporteId { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string PuestoEspecifico { get; set; }
    }
}