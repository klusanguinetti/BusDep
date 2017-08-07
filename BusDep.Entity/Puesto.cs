namespace BusDep.Entity 
{ 
    public partial class Puesto
    {
        #region Atributos
        public virtual long Id { get; set; }
        public virtual Deporte Deporte { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string PuestoEspecifico { get; set; }
        public virtual string Codigo { get; set; }
        #endregion
    }
}
