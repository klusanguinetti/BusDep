namespace BusDep.ViewModel
{
    using System;
    using System.Runtime.Serialization;
    [DataContract]
    public class UserViewModel
    {
        [DataMember]
        public long? Id { get; set; }
        [DataMember]
        public string Mail { get; set; }
        [DataMember]
        public string TipoUsuario { get; set; }
        [DataMember]
        public string Password { get; set; }

    }
}
