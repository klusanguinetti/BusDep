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
        public new virtual void Save(Usuario user)
        {
            if (user.Id.Equals(0) && !string.IsNullOrWhiteSpace(user.Password))
                user.Password = Common.Encrypt.EncryptToBase64String(user.Password);
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

        public virtual Evaluacion ObtenerEvaluacionDefault(long usuarioId, long deporteId)
        {
            return Session.Query<Evaluacion>().FirstOrDefault(o => o.Usuario.Id.Equals(usuarioId)
            && o.TipoEvaluacion.Deporte.Id.Equals(deporteId) && o.TipoEvaluacion.EsDefault.Equals("S")
            && o.TipoEvaluacion.TipoUsuario == o.Usuario.TipoUsuario);
        }

        public virtual TipoEvaluacion ObtenerTipoEvaluacionDefault(long deporteId, string tipoUsuario)
        {
            return Session.Query<TipoEvaluacion>().FirstOrDefault(o => o.Deporte.Id.Equals(deporteId) && o.EsDefault.Equals("S")
            && o.TipoUsuario.Descripcion.Equals(tipoUsuario));
        }

        public virtual List<AntecedenteViewModel> ObtenerAntecedentes(long usuarioId)
        {
            return (from ant in Session.Query<Antecedente>()
                    where ant.Usuario.Id.Equals(usuarioId)
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
                        Video = ant.Video
                    }).ToList();
        }

        public virtual AntecedenteViewModel ObtenerAntecedenteViewModel(long antecedenteId)
        {
            return (from ant in Session.Query<Antecedente>()
                    where ant.Id.Equals(antecedenteId)
                    select new AntecedenteViewModel
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
                        Video = ant.Video
                    }).FirstOrDefault();
        }

        public virtual Usuario ActualizarPassword(Usuario usuario)
        {
            usuario.Password = Common.Encrypt.EncryptToBase64String(usuario.Password);
            base.Save(usuario);
            return usuario;
        }

        public bool ExisteUsuario(string mail)
        {
            return !Session.Query<Usuario>().Count(o => o.Mail.ToUpper().Equals(mail.ToUpper().Trim())).Equals(0);
        }

        public DatosPersonaViewModel ObtenerDatosPersonales(long datosPersonalesId)
        {
            return (from o in Session.Query<DatosPersona>()
                    where o.Id.Equals(datosPersonalesId)
                    select new DatosPersonaViewModel
                    {
                        Id = o.Id,
                        UsuarioId = o.Usuario.Id,
                        Apellido = o.Apellido,
                        Direccion = o.Direccion,
                        Ciudad = o.Ciudad,
                        CodigoPostal = o.CodigoPostal,
                        FechaNacimiento = o.FechaNacimiento,
                        Nacionalidad = o.Nacionalidad,
                        Nacionalidad1 = o.Nacionalidad1,
                        NacionalidadIso = o.NacionalidadIso,
                        NacionalidadIso1 = o.NacionalidadIso1,
                        Nombre = o.Nombre,
                        NumeroDocumento = o.NumeroDocumento,
                        Pais = o.Pais,
                        PaisIso = o.PaisIso,
                        Provincia = o.Provincia,
                        Telefono = o.Telefono,
                        TipoDocumento = o.TipoDocumento,
                        Informacion = o.Informacion,
                        UltimoLogin = o.Usuario.UltimoLogin,
                    }).FirstOrDefault();
        }
    }
}
