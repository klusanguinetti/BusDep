



using System.Collections.Generic;

namespace BusDep.DataAccess
{
    using System.Linq;
    using BusDep.Entity;
    using BusDep.IDataAccess;
    using NHibernate;
    using NHibernate.Linq;
    using System;
    using System.Text;

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

        public virtual Evaluacion ObtenerEvaluacionDefault(long jugadorId, long deporteId)
        {
            return Session.Query<Evaluacion>().FirstOrDefault(o => o.Jugador.Id.Equals(jugadorId) 
            && o.TipoEvaluacion.Deporte.Id.Equals(deporteId) && o.TipoEvaluacion.EsDefault.Equals("S")
            && o.TipoEvaluacion.TipoUsuario == o.Jugador.Usuario.TipoUsuario);
        }

        public virtual TipoEvaluacion ObtenerTipoEvaluacionDefault(long deporteId, string tipoUsuario)
        {
            return Session.Query<TipoEvaluacion>().FirstOrDefault(o => o.Deporte.Id.Equals(deporteId) && o.EsDefault.Equals("S")
            && o.TipoUsuario.Descripcion.Equals(tipoUsuario));
        }

        public virtual List<Antecedente> ObtenerAntecedentes(long usuarioId)
        {
            return Session.Query<Antecedente>().Where(o => o.Usuario.Id.Equals(usuarioId)).ToList();
        }
    }
}
