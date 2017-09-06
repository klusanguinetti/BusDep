namespace BusDep.DataAccess
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using NHibernate;
    using NHibernate.Linq;
    using BusDep.Entity;
    using BusDep.IDataAccess;
    using ViewModel;

    public class UsuarioDA : BaseDataAccess<Usuario>, IUsuarioDA
    {
        #region metodos publicos
        public new virtual void Save(Usuario user)
        {
            if (user.Id.Equals(0) && !string.IsNullOrWhiteSpace(user.Password))
                user.Password = Common.Encrypt.EncryptToBase64String(user.Password);
            if (string.IsNullOrWhiteSpace(user.Estado))
                user.Estado = "A";
            base.Save(user);
        }
        public virtual Usuario LoginUser(string mail, string password)
        {

            byte[] data = Convert.FromBase64String(password);
            string decodedPassword = Encoding.UTF8.GetString(data);

            password = Common.Encrypt.EncryptToBase64String(decodedPassword);
            return Session.Query<Usuario>().FirstOrDefault(o => o.Password.Equals(password) && o.Mail.ToUpper().Equals(mail.ToUpper()));
        }

        public virtual Usuario LoginUser(string mail, string aplicacion, string token)
        {
            string sql = string.Format("select u ");
            sql += " from Usuario u \n";
            sql += string.Format("left join u.AplicacionToken at \n");
            sql += string.Format("where 1 = 1 \n");
            sql += string.Format("and at.Aplicativo like :aplicacion \n");
            sql += string.Format("and at.Token like :token \n");
            sql += string.Format("and upper(u.Mail) like upper(:mail) \n");
            IQuery query = Session.CreateQuery(sql);
            query.SetString("mail", mail);
            query.SetString("aplicacion", aplicacion);
            query.SetString("token", token);
            var usuarios = query.List<Usuario>();
            if (usuarios.Any())
                return usuarios.First();
            return null;
        }

        public virtual Usuario Registracion(Usuario usuario)
        {
            if (usuario != null && usuario.Id.Equals(0) &&
                !string.IsNullOrWhiteSpace(usuario.Mail) &&
                !string.IsNullOrWhiteSpace(usuario.Password) && usuario.Password.Length >= 8)
            {
                Save(usuario);
            }
            return usuario;
        }
        public virtual EvaluacionViewModel ObtenerEvaluacionViewModelDefault(long usuarioId, long deporteId)
        {

            var list = (from det in Session.Query<EvaluacionDetalle>()
                        where det.EvaluacionCabecera.Evaluacion.Usuario.Id.Equals(usuarioId)
                       && det.EvaluacionCabecera.Evaluacion.TipoEvaluacion.Deporte.Id.Equals(deporteId)
                       && det.EvaluacionCabecera.Evaluacion.TipoEvaluacion.EsDefault.Equals("S")
                       && det.EvaluacionCabecera.Evaluacion.TipoEvaluacion.TipoUsuario == det.EvaluacionCabecera.Evaluacion.Usuario.TipoUsuario
                        select new
                        {
                            Id = det.EvaluacionCabecera.Evaluacion.Id,
                            JugadorId = det.EvaluacionCabecera.Evaluacion.Usuario.Id,
                            TipoEvaluacionId = det.EvaluacionCabecera.Evaluacion.TipoEvaluacion.Id,
                            Descripcion = det.EvaluacionCabecera.Evaluacion.TipoEvaluacion.Descripcion,
                            Chart = det.EvaluacionCabecera.TemplateEvaluacion.Chart,
                            CabeceraId = det.EvaluacionCabecera.Id,
                            CabeceraDescripcion = det.EvaluacionCabecera.TemplateEvaluacion.Descripcion,
                            DetalleId = det.Id,
                            DetalleDescripcion = det.TemplateEvaluacionDetalle.Descripcion,
                            DetallePuntuacion = det.Puntuacion
                        }).ToList();
            List<EvaluacionViewModel> listEvo = list.Select(o => new { o.Id, o.JugadorId, o.TipoEvaluacionId, o.Descripcion, }).Distinct().Select(i => new EvaluacionViewModel
            {
                Id = i.Id,
                JugadorId = i.JugadorId,
                TipoEvaluacionId = i.TipoEvaluacionId,
                Descripcion = i.Descripcion,
                Cabeceras = (from cab in list.Select(c => new { c.Id, c.CabeceraId, c.CabeceraDescripcion, c.Chart }).Distinct()
                             where cab.Id.Equals(i.Id)
                             select new EvaluacionCabeceraViewModel
                             {
                                 Id = cab.CabeceraId,
                                 Descripcion = cab.CabeceraDescripcion,
                                 Chart = cab.Chart,
                                 Detalle = (from det in list.Where(r => r.Id.Equals(i.Id) && r.CabeceraId.Equals(cab.CabeceraId))
                                            select new EvaluacionDetalleViewModel
                                            {
                                                Id = det.DetalleId,
                                                Descripcion = det.DetalleDescripcion,
                                                Puntuacion = det.DetallePuntuacion
                                            }).ToList()
                             }).ToList()
            }).ToList();

            foreach (var evalu in listEvo)
            {
                foreach (var cab in evalu.Cabeceras)
                {
                    decimal canResp = cab.Detalle.Count(o => o.Puntuacion.HasValue);
                    decimal puntos = cab.Detalle.Where(o => o.Puntuacion.HasValue).Sum(i => i.Puntuacion.GetValueOrDefault());
                    if (canResp > 0 && puntos > 0)
                        cab.Promedio = Decimal.Round(puntos / canResp, 2);
                }
            }
            return listEvo.FirstOrDefault();
        }
        public virtual TipoEvaluacion ObtenerTipoEvaluacionDefault(long deporteId, string tipoUsuario)
        {
            return Session.Query<TipoEvaluacion>().FirstOrDefault(o => o.Deporte.Id.Equals(deporteId) && o.EsDefault.Equals("S")
            && o.TipoUsuario.Descripcion.Equals(tipoUsuario));
        }

        public virtual List<AntecedenteViewModel> ObtenerAntecedentes(long usuarioId)
        {
            return ObtenerAntecedentesViewModel(usuarioId, null);
        }

        public virtual AntecedenteViewModel ObtenerAntecedenteViewModel(long antecedenteId, long usuarioId)
        {
            return ObtenerAntecedentesViewModel(usuarioId, antecedenteId).FirstOrDefault();
        }


        public virtual Usuario ActualizarPassword(Usuario usuario)
        {
            usuario.Password = Common.Encrypt.EncryptToBase64String(usuario.Password);
            base.Save(usuario);
            return usuario;
        }

        public virtual bool ExisteUsuario(string mail)
        {
            return !Session.Query<Usuario>().Count(o => o.Mail.ToUpper().Equals(mail.ToUpper().Trim())).Equals(0);
        }

        public virtual DatosPersonaViewModel ObtenerDatosPersonales(long datosPersonalesId)
        {
            return (from o in Session.Query<Usuario>()
                    where o.DatosPersona!=null && o.DatosPersona.Id.Equals(datosPersonalesId)
                    select new DatosPersonaViewModel
                    {
                        Id = o.Id,
                        UsuarioId = o.Id,
                        Apellido = o.DatosPersona.Apellido,
                        Direccion = o.DatosPersona.Direccion,
                        Ciudad = o.DatosPersona.Ciudad,
                        CodigoPostal = o.DatosPersona.CodigoPostal,
                        FechaNacimiento = o.DatosPersona.FechaNacimiento,
                        Nacionalidad = o.DatosPersona.Nacionalidad,
                        Nacionalidad1 = o.DatosPersona.Nacionalidad1,
                        NacionalidadIso = o.DatosPersona.NacionalidadIso,
                        NacionalidadIso1 = o.DatosPersona.NacionalidadIso1,
                        Nombre = o.DatosPersona.Nombre,
                        NumeroDocumento = o.DatosPersona.NumeroDocumento,
                        Pais = o.DatosPersona.Pais,
                        PaisIso = o.DatosPersona.PaisIso,
                        Provincia = o.DatosPersona.Provincia,
                        Telefono = o.DatosPersona.Telefono,
                        TipoDocumento = o.DatosPersona.TipoDocumento,
                        Informacion = o.DatosPersona.Informacion,
                        UltimoLogin = o.UltimoLogin,
                        ContactoMail = o.DatosPersona.ContactoMail,
                        ContactoNombre = o.DatosPersona.ContactoNombre,
                        ContactoTelefono = o.DatosPersona.ContactoTelefono,
                    }).FirstOrDefault();
        }

        public virtual Usuario ObtenerUsuarioPorMail(string mail)
        {
            return Session.Query<Usuario>().FirstOrDefault(o => o.Mail.ToUpper().Equals(mail.ToUpper().Trim()));
        }

        public virtual List<MenuViewModel> ObtenerMenuTipoUsuario(long tipoUsuarioId)
        {
            return (from ant in Session.Query<Menu>()
                    where ant.TipoUsuario.Id.Equals(tipoUsuarioId)
                    && ant.Estado.Equals("A")
                    select new MenuViewModel
                    {
                        Id = ant.Id,
                        Descripcion = ant.Descripcion,
                        Estado = ant.Estado,
                        Icono = ant.Icono,
                        ParentMenuId = ant.ParentMenuId,
                        Url = ant.Url,
                        Orden = ant.Orden
                    }).OrderBy(o=> o.Orden).ToList();
        }
        #endregion
        #region metodos privados
        private List<AntecedenteViewModel> ObtenerAntecedentesViewModel(long usuarioId, long? antecedenteId)
        {
            return (from ant in Session.Query<Antecedente>()
                    where ant.Usuario.Id.Equals(usuarioId)
                    && (antecedenteId != null ? ant.Id.Equals(antecedenteId.Value) : 1.Equals(1))
                    orderby ant.FechaInicio descending
                    select
                    new AntecedenteViewModel
                    {
                        Asistencias = ant.Asistencias,
                        ClubDescripcion = ant.ClubDescripcion,
                        ClubLogo = ant.ClubLogo,
                        FechaFin = ant.FechaFin,
                        FechaInicio = ant.FechaInicio,
                        Goles = ant.Goles,
                        Id = ant.Id,
                        InformacionAdicional = ant.InformacionAdicional,
                        Partidos = ant.Partidos,
                        UsuarioId = ant.Usuario.Id,
                        Video = ant.Video,
                        Puesto = ant.Puesto,
                        PuestoAlt = ant.PuestoAlt,
                        TecnicoMail = ant.TecnicoMail,
                        TecnicoNombre = ant.TecnicoNombre,
                        TextoLibre = ant.TextoLibre

                    }).ToList();
        }
        #endregion
    }
}
