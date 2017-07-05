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
        public virtual long Id { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string Tipo { get; set; }
        public virtual IList<Puesto> Puestos { get; set; }
        #endregion
    }
}
