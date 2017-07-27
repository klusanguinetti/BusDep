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

        [DataMember]
        public bool Selected { get; set; }

    }
    [DataContract]
    public class ComboAgrupadoViewModel : ComboViewModel
    {
        [DataMember]
        public string Agrupador { get; set; }
    }
    [DataContract]
    public class BuscarJugadorViewModel
    {
        [DataMember]
        public string[] Puesto { get; set; }
        [DataMember]
        public int? EdadDesde { get; set; }
        [DataMember]
        public int? EdadHasta { get; set; }
        [DataMember]
        public string[] Fichaje { get; set; }
        [DataMember]
        public string[] Perfil { get; set; }
        [DataMember]
        public string[] Pie { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int? Pagina { get; set; }
        [DataMember]
        public int? Cantidad { get; set; }
    }
    
}