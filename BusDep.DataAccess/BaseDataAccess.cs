using System;
using System.Collections.Generic;
using BusDep.DataAccess.Sessions;
using NHibernate;
using NHibernate.Criterion;

namespace BusDep.DataAccess
{
    public class BaseDataAccess<T>
    {
        public void ClearSession()
        {

            NHibernateHttpModule.ClearSession();
        }

        public static ISession Session
        {
            get
            {
                return NHibernateHttpModule.CurrentSession;
            }
        }
        /// <summary>
        /// Devuleve una instancia de la clase
        /// </summary>
        /// <param name="id">identificador</param>
        /// <returns></returns>
        public virtual T GetById<TId>(TId id)
        {
            return Session.Load<T>(id);
        }

        /// <summary>
        /// Guarda el objeto sin abrir una transaccion.
        /// </summary>
        /// <param name="obje"></param>
        /// <param name="tx">ITransaction</param>
        public virtual void Save(T obje, ITransaction tx)
        {
            if (tx == null)
                throw new Exception("Error: La transaccion es null");
            /*Si el objeto tiene una PK asignada desde el Mapping con Generator=Assigned usa el Insert o Update, 
            según esté en la base. Sino usa SaveOrUpdate*/
            //bool IsAssigned = false;
            //try
            //{
            //    IsAssigned =
            //        (((NHibernate.Persister.Entity.SingleTableEntityPersister)
            //          (m_session.SessionFactory.GetClassMetadata(typeof(obj)))).IdentifierGenerator.ToString().Equals("NHibernate.Id.Assigned"));
            //}
            //catch { }
            //if (IsAssigned)
            //{
            //    ICriteria cri = m_session.CreateCriteria(typeof(Type));
            //    cri.Add(Restrictions.Eq(m_session.SessionFactory.GetClassMetadata(typeof(obj)).IdentifierPropertyName, this.m_id));
            //    cri.SetProjection(Projections.Count(m_session.SessionFactory.GetClassMetadata(typeof(obj)).IdentifierPropertyName));
            //    bool nuevo = cri.List<int>()[0].Equals(0);
            //    if (nuevo)
            //        m_session.Save(obje);
            //    else
            //        m_session.Update(obje);
            //}
            //else //Es una PK autogenerada o generada por Hibernate
            Session.SaveOrUpdate(obje);
        }
        /// <summary>
        /// Guarda el objeto en la DB
        /// </summary>
        public virtual void Save(T obje)
        {
            ITransaction tx = null;
            try
            {
                tx = Session.BeginTransaction();
                Save(obje, tx);
                tx.Commit();
            }
            catch
            {
                //TODO:Se deberia escribir en el LOG??
                tx?.Rollback();
                throw;
            }
        }

        /// <summary>
        /// Borra el objeto sin abrir una transaccion
        /// </summary>
        /// <param name="obje"></param>
        /// <param name="tx">ITransaction</param>
        public virtual void Delete(T obje, ITransaction tx)
        {
            if (tx == null)
                throw new Exception("Error: La transaccion es null");
            Session.Delete(obje);
            Session.Flush();
        }
        /// <summary>
        /// Borra el objeto
        /// </summary>
        public virtual void Delete(T obje)
        {
            ITransaction tx = null;
            try
            {
                tx = Session.BeginTransaction();
                Delete(obje, tx);
                tx.Commit();
            }
            catch (Exception)
            {
                tx?.Rollback();
                throw;
            }
        }

        /// <summary>
        /// Devulve todos los objetos persistidos del tipo
        /// </summary>
        /// <returns></returns>
        public virtual IList<T> GetAll()
        {
            return Session.CreateCriteria(typeof(T)).List<T>();
        }

        /// <summary>
        /// Devulve todos los objetos persistidos del tipo. Permite ordenar por una propiedad, y en que 
        /// dirección
        /// </summary>
        /// <returns></returns>
        public virtual IList<T> GetAll(string orderByProperty, bool ascendente)
        {
            ICriteria criterio = Session.CreateCriteria(typeof(T));
            if (ascendente)
                criterio.AddOrder(Order.Asc(orderByProperty));
            else
                criterio.AddOrder(Order.Desc(orderByProperty));

            return criterio.List<T>();
        }

        /// <summary>
        /// Busca los objetos filtrando con la lista de parámetros
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public virtual IList<T> SearchBy(IList<KeyValuePair<string, object>> param)
        {
            ICriteria criterio = Session.CreateCriteria(typeof(T));
            if (param != null)
            {
                foreach (KeyValuePair<string, object> keyValue in param)
                {
                    if (keyValue.Value == null)
                        criterio.Add(Restrictions.IsNull(keyValue.Key));
                    else
                        criterio.Add(Restrictions.Eq(keyValue.Key, keyValue.Value));
                }
            }
            return criterio.List<T>();
        }

        /// <summary>
        /// Busca los objetos filtrando con la lista de parámetros. Permite ordenar por una propiedad, y
        /// en que dirección
        /// </summary>
        /// <param name="param"></param>
        /// <param name="orderByProperty"></param>
        /// <param name="ascendente"></param>
        /// <returns></returns>
        public virtual IList<T> SearchBy(IList<KeyValuePair<string, object>> param, string orderByProperty, bool ascendente)
        {
            ICriteria criterio = Session.CreateCriteria(typeof(T));
            if (param != null)
            {
                foreach (KeyValuePair<string, object> keyValue in param)
                {
                    if (keyValue.Value == null)
                        criterio.Add(Restrictions.IsNull(keyValue.Key));
                    else
                        criterio.Add(Restrictions.Eq(keyValue.Key, keyValue.Value));
                }
            }

            if (ascendente)
                criterio.AddOrder(Order.Asc(orderByProperty));
            else
                criterio.AddOrder(Order.Desc(orderByProperty));

            return criterio.List<T>();
        }

        /// <summary>
        /// Busca los objetos filtrando con la lista de parámetros. Los parametros de tipo string los filtra
        /// con %like%.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public virtual IList<T> SearchLike(IList<KeyValuePair<string, object>> param)
        {
            ICriteria criterio = Session.CreateCriteria(typeof(T));
            if (param != null)
            {
                foreach (KeyValuePair<string, object> keyValue in param)
                {
                    if (keyValue.Value == null)
                        criterio.Add(Restrictions.IsNull(keyValue.Key));
                    else
                    {
                        if (keyValue.Value.GetType() == Type.GetType("System.String"))
                            criterio.Add(Restrictions.InsensitiveLike(keyValue.Key, keyValue.Value.ToString(), MatchMode.Anywhere));
                        else
                            criterio.Add(Restrictions.Eq(keyValue.Key, keyValue.Value));
                    }
                }
            }

            return criterio.List<T>();
        }


        /// <summary>
        /// Busca los objetos filtrando con la lista de parámetros. Los parametros de tipo string los filtra
        /// con %like%. Permite ordenar por una propiedad, y en que dirección
        /// </summary>
        /// <param name="param"></param>
        /// <param name="orderByProperty"></param>
        /// <param name="ascendente"></param>
        /// <returns></returns>
        public virtual IList<T> SearchLike(IList<KeyValuePair<string, object>> param, string orderByProperty, bool ascendente)
        {
            ICriteria criterio = Session.CreateCriteria(typeof(T));
            if (param != null)
            {
                foreach (KeyValuePair<string, object> keyValue in param)
                {

                    if (keyValue.Value == null)
                        criterio.Add(Restrictions.IsNull(keyValue.Key));
                    {
                        if (keyValue.Value.GetType() == System.Type.GetType("System.String"))
                            criterio.Add(Restrictions.InsensitiveLike(keyValue.Key, keyValue.Value.ToString(), MatchMode.Anywhere));
                        else
                            criterio.Add(Restrictions.Eq(keyValue.Key, keyValue.Value));
                    }
                }
            }

            if (ascendente)
                criterio.AddOrder(Order.Asc(orderByProperty));
            else
                criterio.AddOrder(Order.Desc(orderByProperty));

            return criterio.List<T>();
        }
    }
}
