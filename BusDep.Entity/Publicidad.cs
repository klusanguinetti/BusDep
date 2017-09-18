namespace BusDep.Entity
{
    public class Publicidad
    {
        #region Atributos
        public virtual long Id { get; set; }
        public virtual string ImageUrl { get; set; }
        public virtual string Link { get; set; }
        public virtual string Estado { get; set; }
        #endregion 
    }
}