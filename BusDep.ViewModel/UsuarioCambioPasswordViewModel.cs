using System.Runtime.Serialization;

namespace BusDep.ViewModel
{
    [DataContract]
    public class UsuarioCambioPasswordViewModel
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Mail { get; set; }

        [DataMember]
        public string OldPassword { get; set; }

        [DataMember]
        public string NewPassword { get; set; }
    }
}
