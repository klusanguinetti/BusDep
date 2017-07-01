namespace BusDep.Entity 
{
    using System.Collections.Generic;
    public partial class Deporte
    {
        public Deporte()
        {
            Puestos = new List<Puesto>();
        }
        #region Atributos
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public IList<Puesto> Puestos { get; set; }
        #endregion
    }
}
