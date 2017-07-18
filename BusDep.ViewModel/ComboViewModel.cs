using System.Runtime.Serialization;

namespace BusDep.ViewModel
{
    [DataContract]
    public class ComboViewModel
    {
        [DataMember]
        public dynamic Id { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

    }
    [DataContract]
    public class ComboAgrupadoViewModel : ComboViewModel
    {
        [DataMember]
        public string Agrupador { get; set; }
    }
}