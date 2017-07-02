using System.Runtime.Serialization;

namespace BusDep.ViewModel
{
    [DataContract]
    public class DeporteViewModel
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