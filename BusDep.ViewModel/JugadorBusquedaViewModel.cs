﻿
namespace BusDep.ViewModel
{
    using System;
    using System.Runtime.Serialization;
    [DataContract]
    public class JugadorBusquedaViewModel
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Apellido { get; set; }
        public string FotoRostro { get; set; }
        [DataMember]
        public string Nacionalidad { get; set; }
        [DataMember]
        public string Nacionalidad1 { get; set; }
        [DataMember]
        public string NacionalidadIso { get; set; }
        [DataMember]
        public string Nacionalidad1Iso { get; set; }
        [DataMember]
        public string PuestoDescripcion { get; set; }
        [DataMember]
        public string ClubActual { get; set; }
        [DataMember]
        public string LogClubActual { get; set; }
        [DataMember]
        public string Perfil { get; set; }
        [DataMember]
        public string Pie { get; set; }
        [DataMember]
        public string Fichaje { get; set; }
        [DataMember]
        public string Informacion { get; set; }
        [DataMember]
        public string Pais { get; set; }
        [DataMember]
        public string PaisIso { get; set; }
    }
}
