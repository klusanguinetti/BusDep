namespace BusDep.Entity
{
    public class UsuarioAplicativo
    {
        public long Id { get; set; }
        public Usuario Usuario { get; set; }
        public string Aplicativo { get; set; }
        public string Token { get; set; }

    }
}