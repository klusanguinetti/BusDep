namespace BusDep.DataAccess
{
    using System.Collections.Generic;
    using System.Linq;
    using BusDep.Entity;
    using NHibernate.Linq;
    using BusDep.IDataAccess;
    using ViewModel;

    public class EntrenadorDA : BaseDataAccess<Entrenador>, IEntrenadorDA
    {
        public virtual long BuscarEntrenadorCount(BuscarEntrenadorViewModel buscar)
        {
            return (from item in Session.Query<Usuario>()
                where item.Entrenador != null
                      && item.Estado == "A"
                      &&
                      ((!string.IsNullOrEmpty(buscar.Nombre))
                          ? item.DatosPersona.Nombre.ToUpper().Contains(buscar.Nombre.ToUpper()) ||
                            item.DatosPersona.Apellido.ToUpper().Contains(buscar.Nombre.ToUpper())
                          : 1.Equals(1))

                select new EntrenadorViewModel
                {
                    Apellido = item.DatosPersona.Apellido,
                    FotoRostro = item.Entrenador.FotoRostro,
                    Id = item.Entrenador.Id,
                    Nacionalidad = item.DatosPersona.Nacionalidad,
                    Nacionalidad1 = item.DatosPersona.Nacionalidad1,
                    NacionalidadIso = item.DatosPersona.NacionalidadIso,
                    NacionalidadIso1 = item.DatosPersona.NacionalidadIso1,
                    FechaNacimiento = item.DatosPersona.FechaNacimiento,
                    Informacion = item.DatosPersona.Informacion,
                    Pais = item.DatosPersona.Pais,
                    PaisIso = item.DatosPersona.PaisIso,
                    Nombre = item.DatosPersona.Nombre,
                    Perfil = item.Entrenador.Perfil,
                    UsuarioId = item.Id
                }).Count();
        }
        public virtual List<EntrenadorViewModel> BuscarEntrenador(BuscarEntrenadorViewModel buscar)
        {
            if (!buscar.Cantidad.HasValue)
                buscar.Cantidad = 10;
            var inicio = buscar.Pagina.GetValueOrDefault().Equals(1) ? 0 : (buscar.Pagina.GetValueOrDefault() - 1) * buscar.Cantidad.GetValueOrDefault();

            return (from item in Session.Query<Usuario>()
                    where item.Entrenador != null
                          && item.Estado == "A"
                          &&
                          ((!string.IsNullOrEmpty(buscar.Nombre))
                              ? item.DatosPersona.Nombre.ToUpper().Contains(buscar.Nombre.ToUpper()) ||
                                item.DatosPersona.Apellido.ToUpper().Contains(buscar.Nombre.ToUpper())
                              : 1.Equals(1))
                    orderby item.Entrenador.Id descending
                    select new EntrenadorViewModel
                    {
                        Apellido = item.DatosPersona.Apellido,
                        FotoRostro = item.Entrenador.FotoRostro,
                        Id = item.Entrenador.Id,
                        Nacionalidad = item.DatosPersona.Nacionalidad,
                        Nacionalidad1 = item.DatosPersona.Nacionalidad1,
                        NacionalidadIso = item.DatosPersona.NacionalidadIso,
                        NacionalidadIso1 = item.DatosPersona.NacionalidadIso1,
                        FechaNacimiento = item.DatosPersona.FechaNacimiento,
                        Informacion = item.DatosPersona.Informacion,
                        Pais = item.DatosPersona.Pais,
                        PaisIso = item.DatosPersona.PaisIso,
                        Nombre = item.DatosPersona.Nombre,
                        Perfil = item.Entrenador.Perfil,
                        UsuarioId = item.Id
                    }).Skip(inicio).Take(buscar.Cantidad.GetValueOrDefault()).ToList();
        }
        public virtual EntrenadorViewModel ObtenerEntrenador(long id)
        {
            var il = (from item in Session.Query<Usuario>()
                      where item.Entrenador != null && item.Entrenador.Id.Equals(id)
                      && item.Estado == "A"
                      select new EntrenadorViewModel
                      {
                          Apellido = item.DatosPersona.Apellido,
                          FotoRostro = item.Entrenador.FotoRostro,
                          Id = item.Entrenador.Id,
                          Nacionalidad = item.DatosPersona.Nacionalidad,
                          Nacionalidad1 = item.DatosPersona.Nacionalidad1,
                          NacionalidadIso = item.DatosPersona.NacionalidadIso,
                          NacionalidadIso1 = item.DatosPersona.NacionalidadIso1,
                          FechaNacimiento = item.DatosPersona.FechaNacimiento,
                          Informacion = item.DatosPersona.Informacion,
                          Pais = item.DatosPersona.Pais,
                          PaisIso = item.DatosPersona.PaisIso,
                          Nombre = item.DatosPersona.Nombre,
                          Perfil = item.Entrenador.Perfil,
                          UsuarioId = item.Id
                      }).ToList();
            return il.FirstOrDefault();

        }
    }
}
