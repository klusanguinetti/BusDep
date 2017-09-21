using System;

namespace BusDep.ViewModel
{
    using System.Runtime.Serialization;
    [DataContract]
    public class EventoPublicidadViewModel
    {
        #region Atributos
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Titulo { get; set; }
        [DataMember]
        public string Informacion { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }
        [DataMember]
        public string Link { get; set; }
        [DataMember]
        public DateTime? FechaHasta { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string FechaHastaTexto
        {
            get { return this.FechaHasta != null ? this.FechaHasta.Value.ToString("dd/MM/yyyy") : null; }
            set
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        var fecha = value.Split('/');
                        if (fecha.Length.Equals(3))
                        {
                            this.FechaHasta = new DateTime(Convert.ToInt32(fecha[2]), Convert.ToInt32(fecha[1]), Convert.ToInt32(fecha[0]));
                        }
                        else
                        {
                            this.FechaHasta = null;
                        }
                    }
                }
                catch
                {
                    this.FechaHasta = null;
                }
            }
        }
        #endregion
    }
}