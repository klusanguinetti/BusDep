namespace BusDep.Entity 
{
    using System.Collections.Generic;
    public partial class Usuario
    {
        #region constructor
        public Usuario()
        {
            AplicacionToken= new List<UsuarioAplicativo>();

        }
        #endregion

        #region Atributos
        public long Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public DatosPersona DatosPersona { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public IList<UsuarioAplicativo> AplicacionToken { get; set; }
        #endregion 
    }
}
