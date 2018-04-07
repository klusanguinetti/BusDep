using System;

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
        public virtual long Id { get; set; }
        public virtual string Mail { get; set; }
        public virtual string Password { get; set; }
        public virtual DatosPersona DatosPersona { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
        public virtual Deporte Deporte { get; set; }
        public virtual Jugador Jugador { get; set; }
        public virtual Intermediario Intermediario { get; set; }
        public virtual Entrenador Entrenador { get; set; }
        public virtual Club Club { get; set; }
        public virtual VideoAnalista VideoAnalista { get; set; }

        public virtual DateTime? UltimoLogin { get; set; }

        public virtual string Estado { get; set; }

        public virtual IList<UsuarioAplicativo> AplicacionToken { get; set; }
        #endregion 
    }
}
