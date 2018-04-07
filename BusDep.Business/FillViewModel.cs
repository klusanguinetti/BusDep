

namespace BusDep.Business
{
    using BusDep.Common;
    using BusDep.Entity;
    using BusDep.ViewModel;
    internal static class FillViewModel
    {
        public static UsuarioViewModel FillUsuarioViewModel(Usuario user)
        {
            if (user != null)
            {
                var userView = user.MapperClass<UsuarioViewModel>(TypeMapper.IgnoreCaseSensitive);
                userView.TipoUsuario = user.TipoUsuario.Descripcion;
                userView.DeporteId = user.Deporte?.Id;
                userView.JugadorId = user.Jugador?.Id;
                userView.EntrenadorId = user.Entrenador?.Id;
                userView.IntermediarioId = user.Intermediario?.Id;
                userView.ClubId = user.Club?.Id;
                userView.VideoAnalistaId = user.VideoAnalista?.Id;
                userView.DatosPersonaId = user.DatosPersona?.Id;
                userView.Nombre = user.DatosPersona?.Nombre;
                userView.Apellido = user.DatosPersona?.Apellido;
                userView.Pais = user.DatosPersona?.Pais;
                userView.PaisIso = user.DatosPersona?.PaisIso;
                return userView;
            }
            return null;
        }
       
        public static AntecedenteViewModel FillAntecedenteViewModel(Antecedente antecedente)
        {
            var ante = antecedente?.MapperClass<AntecedenteViewModel>();
            if (ante != null)
            {
                ante.UsuarioId = antecedente.Usuario.Id;
            }
            return ante;
        }

       


    }
}