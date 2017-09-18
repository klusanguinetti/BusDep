namespace BusDep.ViewModel
{
    using System.Runtime.Serialization;
    [DataContract]
    public class PublicidadViewModel
    {
        #region Atributos
        [DataMember]
        public virtual long Id { get; set; }
        [DataMember]
        public virtual string ImageUrl { get; set; }
        [DataMember]
        public virtual string Link { get; set; }
        [DataMember]
        public virtual string Estado { get; set; }
        #endregion 
    }
}