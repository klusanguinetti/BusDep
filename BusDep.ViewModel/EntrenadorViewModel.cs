using System.Runtime.Serialization;

namespace BusDep.ViewModel
{
    [DataContract]
    public class EntrenadorViewModel: PerfilBaseViewModel
    {  
        [DataMember]
        public string Informacion { get; set; }
        
        [DataMember]
        public bool Recomendar { get; set; }

        [DataMember]
        public string Link { get; set; }
    }
}