

namespace BusDep.DataAccess
{
    using System.Linq;
    using BusDep.Entity;
    using BusDep.IDataAccess;
    using NHibernate;
    using NHibernate.Criterion;
    public class UsuarioDA: BaseDataAccess<Usuario>, IUsuarioDA
    {
        public virtual void Save(Usuario user)
        {
            if (user.Id.Equals(0) && !string.IsNullOrWhiteSpace(user.Password))
                user.Password = Common.Encrypt.EncryptToBase64String(user.Password);
            base.Save(user);
        }
        public virtual Usuario LoginUser(string mail, string password)
        {
            password = Common.Encrypt.EncryptToBase64String(password);
            ICriteria criterio = Session.CreateCriteria(typeof(Usuario));
            criterio.Add(Restrictions.InsensitiveLike("Mail", mail)).Add(Restrictions.Eq("Password", password));
            Usuario u = criterio.UniqueResult<Usuario>();
            return u;
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
            if(usuarios.Any())
                return usuarios.First();
            return null;
        }

        public virtual Usuario Registracion(Usuario usuario)
        {
            if (usuario != null && usuario.Id.Equals(0) && 
                !string.IsNullOrWhiteSpace(usuario.Mail) &&
                !string.IsNullOrWhiteSpace(usuario.Password) && usuario.Password.Length>=8)
            {
                base.Save(usuario);
            }
            return usuario;
        }
    }
}
