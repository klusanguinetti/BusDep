namespace BusDep.Entity
{
    public class Menu
    {
        #region Atributos
        public virtual long Id { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string Url { get; set; }
        public virtual string Icono { get; set; }
        public virtual string Img { get; set; }
        public virtual string Estado { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
        public virtual int? Orden { get; set; }
        public virtual long? ParentMenuId { get; set; }
        #endregion
    }
}