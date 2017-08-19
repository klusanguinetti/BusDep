namespace BusDep.ViewModel
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class MenuViewModel
    {
        #region Atributos
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public string Icono { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public int? Orden { get; set; }
        [DataMember]
        public long? ParentMenuId { get; set; }
        #endregion
    }
}