namespace BusDep.ViewModel
{
    using System;
    using System.Runtime.Serialization;
    [DataContract]
    public class ClubViewModel
    {
        [DataMember]
        public string Division { get; set; }
        [DataMember]
        public string Nombre { get; set; }
    }
}
