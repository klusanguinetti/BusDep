﻿namespace BusDep.ViewModel
{
    using System;
    using System.Runtime.Serialization;
    [DataContract]
    public class ClubDetalleViewModel
    {
        [DataMember]
        public string Division { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Code { get; set; }
    }
}
