using System.Collections.Generic;

namespace BusDep.View
{
    public class UsuarioView
    {
        public long Id { get; set; }
        public string Mail { get; set; }
        public long TipoUsuario { get; set; }
        public string Aplicativo { get; set; }
        public string Token { get; set; }
    }


    public class TemplateView
    {
        public long Id { get; set; }
        public string Nombre { get; set; }

        public List<TemplateDetalleView> Detalle { get; set; }
    }

    public class TemplateDetalleView
    {
        public long Id { get; set; }
        public long Puntuacion { get; set; }
        public string Nombre { get; set; }

    }
}
