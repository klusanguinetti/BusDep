namespace BusDep.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    [DataContract]
    public class PerfilJugadorViewModel
    {
        public PerfilJugadorViewModel()
        {
            Antecedentes=new List<AntecedenteViewModel>();
        }

        [DataMember]
        public long PerfilId { get; set; }
        [DataMember]
        public string Mail { get; set; }

        #region datos personales
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Apellido { get; set; }
        [DataMember]
        public DateTime? FechaNacimiento { get; set; }
        [DataMember]
        public string Pais { get; set; }
        [DataMember]
        public string PaisIso { get; set; }
        [DataMember]
        public string Nacionalidad { get; set; }
        [DataMember]
        public string Nacionalidad1 { get; set; }
        [DataMember]
        public string NacionalidadIso { get; set; }
        [DataMember]
        public string NacionalidadIso1 { get; set; }
        #endregion

        #region Datos Jugador
        [DataMember]
        public decimal? Altura { get; set; }
        [DataMember]
        public string FotoCuertoEntero { get; set; }
        [DataMember]
        public string FotoRostro { get; set; }
        [DataMember]
        public string Perfil { get; set; }
        [DataMember]
        public decimal? Peso { get; set; }
        [DataMember]
        public string PuestoDescripcion { get; set; }
        [DataMember]
        public string PuestoEspecifico { get; set; }
        [DataMember]
        public string PuestoCodigo { get; set; }
        [DataMember]
        public string Informacion { get; set; }
        [DataMember]
        public string Pie { get; set; }
        [DataMember]
        public int? Edad
        {
            get
            {
                if (!FechaNacimiento.HasValue)
                    return null;
                return DateTime.Today.AddTicks(-FechaNacimiento.Value.Ticks).Year - 1;

            }
            set { }
        }
        #endregion

        #region Antecedentes deportivos
        public List<AntecedenteViewModel> Antecedentes { get; set; }
        #endregion

        #region AutoEvaluacion
        public EvaluacionViewModel AutoEvaluacion { get; set; }
        #endregion
    }
}
