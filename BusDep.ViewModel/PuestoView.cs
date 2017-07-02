namespace BusDep.ViewModel
{
    using System;
    using System.Runtime.Serialization;
    [DataContract]
    public class PuestoView
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
    [DataContract]
    public class DeporteView
    {
        #region Atributos
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string Tipo { get; set; }
        #endregion
    }
}