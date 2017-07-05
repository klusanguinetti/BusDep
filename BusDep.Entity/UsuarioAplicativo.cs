namespace BusDep.Entity
{
    public class UsuarioAplicativo
    {
        public virtual long Id { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual string Aplicativo { get; set; }
        public virtual string Token { get; set; }

    }
}