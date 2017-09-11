namespace BusDep.ViewModel
{
    using System;
    using System.Runtime.Serialization;
    [DataContract]
    public partial class AntecedenteViewModel
    {
        #region Atributos
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public DateTime? FechaFin { get; set; }
        [DataMember]
        public string FechaFinTexto
        {
            get { return this.FechaFin != null ? this.FechaFin.Value.ToString("dd/MM/yyyy") : null; }
            set
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        var fecha = value.Split('/');
                        if (fecha.Length.Equals(3))
                        {
                            this.FechaFin = new DateTime(Convert.ToInt32(fecha[2]), Convert.ToInt32(fecha[1]), Convert.ToInt32(fecha[0]));
                        }
                        else
                        {
                            this.FechaFin = null;
                        }
                    }
                }
                catch
                {
                    this.FechaFin = null;
                }
            }
        }
        [DataMember]
        public DateTime? FechaInicio { get; set; }
        [DataMember]
        public string FechaInicioTexto
        {
            get { return this.FechaInicio != null ? this.FechaInicio.Value.ToString("dd/MM/yyyy") : null; }
            set
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        var fecha = value.Split('/');
                        if (fecha.Length.Equals(3))
                        {
                            this.FechaInicio = new DateTime(Convert.ToInt32(fecha[2]), Convert.ToInt32(fecha[1]), Convert.ToInt32(fecha[0]));
                        }
                        else
                        {
                            this.FechaInicio = null;
                        }
                    }
                }
                catch
                {
                    this.FechaInicio = null;
                }
            }
        }
        [DataMember]
        public string InformacionAdicional { get; set; }
        [DataMember]
        public string ClubDescripcion { get; set; }
        [DataMember]
        public string ClubLogo { get; set; }
        [DataMember]
        public long UsuarioId { get; set; }
        [DataMember]
        public string Video { get; set; }

        [DataMember]
        public int? Goles { get; set; }
        [DataMember]
        public int? Partidos { get; set; }
        [DataMember]
        public int? Asistencias { get; set; }
        [DataMember]
        public string Puesto { get; set; }
        [DataMember]
        public string PuestoAlt { get; set; }
        [DataMember]
        public string TecnicoNombre { get; set; }
        [DataMember]
        public string TecnicoMail { get; set; }
        [DataMember]
        public string TextoLibre { get; set; }

        [DataMember]
        public string FechaInicioText
        {
            get { return FechaInicio.GetValueOrDefault().ToString("dd/MM/yyyy"); }
        }
        [DataMember]
        public string FechaFinText
        {
            get { return FechaFin?.ToString("dd/MM/yyyy"); }
        }
        #endregion 
    }
}