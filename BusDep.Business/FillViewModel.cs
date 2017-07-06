

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
                userView.DatosPersonaId = user.DatosPersona?.Id;
                userView.Nombre = user.DatosPersona?.Nombre;
                userView.Apellido = user.DatosPersona?.Apellido;
                return userView;
            }
            return null;
        }

        public static JugadorViewModel FillJugadorViewModel(Jugador jugador)
        {
            if (jugador != null)
            {
                var jugadorView = jugador.MapperClass<JugadorViewModel>();
                jugadorView.UsuarioId = jugador.Usuario.Id;
                if (jugador.Puesto != null)
                {
                    jugadorView.PuestoId = jugador.Puesto.Id;
                    jugadorView.PuestoDescripcion = jugador.Puesto.Descripcion;
                }
                return jugadorView;
            }
            return null;
        }

        public static PuestoViewModel FillPuestoViewModel(Puesto puesto)
        {
            if (puesto != null)
            {
                var puestoViewModel = puesto.MapperClass<PuestoViewModel>();
                puestoViewModel.DeporteId = puesto.Deporte.Id;
                return puestoViewModel;
            }
            return null;
        }

        public static DatosPersonaViewModel FillDatosPersonaViewModel(DatosPersona datosPersona)
        {
            if (datosPersona != null)
            {
                var dato = datosPersona.MapperClass<DatosPersonaViewModel>();
                dato.UsuarioId = datosPersona.Usuario.Id;
                return dato;
            }
            return null;
        }

        public static DeporteViewModel FillDeporteViewModel(Deporte deporte)
        {
            return deporte?.MapperClass<DeporteViewModel>();
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

        public static JugadorBusquedaViewModel FillJugadorBusquedaViewModel(Jugador jugador)
        {
            if (jugador != null)
            {
                var jugadorView = jugador.MapperClass<JugadorBusquedaViewModel>();
                jugadorView.Id = jugador.Id;
                jugadorView.PuestoDescripcion = jugador.Puesto?.Descripcion;
                jugadorView.Nombre = jugador.Usuario.DatosPersona?.Nombre;
                jugadorView.Apellido = jugador.Usuario.DatosPersona?.Apellido;
                jugadorView.Nacionalidad1 = jugador.Usuario.DatosPersona?.Nacionalidad1;
                jugadorView.Nacionalidad = jugador.Usuario.DatosPersona?.Nacionalidad;
                jugadorView.PuestoDescripcion = jugador.Puesto?.Descripcion;
                return jugadorView;
            }
            return null;
        }


    }
}