namespace BusDep.DataAccess.Sessions
{
    using System;
    using System.Reflection;
    using System.Web;
    using NHibernate;
    using NHibernate.Cfg;
    internal class NHibernateHttpModule : IHttpModule
    {
        // this is only used if not running in HttpModule mode
        protected static ISessionFactory m_factory;
        // this is only used if not running in HttpModule mode
        private static ISession mSession;
        private static readonly string KEY_NHIBERNATE_FACTORY = "NHibernateSessionFactory";
        private static readonly string KEY_NHIBERNATE_SESSION = "NHibernateSession";
        protected static HttpContext context;
        public void Init(HttpApplication context)
        {
            //log4net.Config.XmlConfigurator.Configure();
            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
        }
        public static void ClearSession()
        {
            CurrentSession.Clear();
            CurrentSession.Close();
            CurrentSession.SessionFactory.Close();
            CurrentSession.Dispose();
            CurrentSession.SessionFactory.Dispose();
            mSession = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        public void Dispose()
        {
            if (context != null)
            {
                ISession session = context.Items[KEY_NHIBERNATE_SESSION] as ISession;
                if (session != null)
                {
                    try
                    {
                        session.Flush();
                        session.Close();
                    }
                    catch
                    {
                    }
                }
                context.Items[KEY_NHIBERNATE_SESSION] = null;
            }
            if (mSession != null)
            {
                mSession.Close();
                mSession.Dispose();
            }
            if (m_factory != null)
            {
                m_factory.Close();
            }
            if (context != null)
                context = null;
        }
        private void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            context = application.Context;
            context.Items[KEY_NHIBERNATE_SESSION] = CreateSession();
        }
        private void context_EndRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            context = application.Context;
        }
        protected static ISessionFactory CreateSessionFactory()
        {
            Configuration config;
            ISessionFactory factory;
            config = new Configuration();
            if (config == null)
            {
                throw new InvalidOperationException("NHibernate configuration is null.");
            }
            //string configDir = System.Configuration.ConfigurationManager.AppSettings["DirectorioConfiguraciones"];
            //if (String.IsNullOrEmpty(configDir))
            //    configDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            //string fileConfig = System.Configuration.ConfigurationManager.AppSettings["fileConfig"];
            //string configtxt = System.IO.Path.Combine(configDir, fileConfig);
            //config.Configure(configtxt);
            config.Configure();
            string stringconexion = config.GetProperty("connection.connection_string");
            string[] parseString = stringconexion.Split(';');
            if (System.Environment.MachineName.ToUpper().Equals("NBI051856") )
            {
                stringconexion = @"Server=NBI051856\SQLEXPRESS2012;Initial Catalog=BusDep;User Id=sa;Password=Server2012;";
                config.SetProperty("connection.connection_string", stringconexion);
            }
            //stringconexion = string.Empty;
            //foreach (string s in parseString)
            //{
            //    if (s.ToUpper().IndexOf("PASSWORD") >= 0)
            //    {
            //        stringconexion += s.Substring(0, s.IndexOf("=") + 1);
            //        //string aux = s.Substring((s.IndexOf("=") + 1), (s.Length - (s.IndexOf("=") + 1)));
            //        //aux = Utils.Common.DecryptFromString64(aux);
            //        stringconexion += stringconexion + ";";
            //    }
            //    else
            //    {
            //        stringconexion += s + ";";
            //    }
            //}
            //config.SetProperty("connection.connection_string", stringconexion);
            factory = config.BuildSessionFactory();
            if (factory == null)
            {
                throw new InvalidOperationException("Call to Configuration.BuildSessionFactory() returned null.");
            }
            else
            {
                return factory;
            }
        }
        public static ISessionFactory CurrentFactory
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    // running without an HttpContext (non-web mode)
                    // the nhibernate session is a singleton in the app domain
                    if (m_factory != null)
                    {
                        return m_factory;
                    }
                    else
                    {
                        m_factory = CreateSessionFactory();
                        return m_factory;
                    }
                }
                else
                {
                    // running inside of an HttpContext (web mode)
                    // the nhibernate session is a singleton to the http request
                    HttpContext currentContext = HttpContext.Current;
                    ISessionFactory factory = currentContext.Application[KEY_NHIBERNATE_FACTORY] as ISessionFactory;
                    if (factory == null)
                    {
                        factory = CreateSessionFactory();
                        currentContext.Application[KEY_NHIBERNATE_FACTORY] = factory;
                    }
                    return factory;
                }
            }
        }
        public static ISession CreateSession()
        {
            ISessionFactory factory;
            ISession session;
            factory = NHibernateHttpModule.CurrentFactory;
            if (factory == null)
            {
                throw new InvalidOperationException("Call to Configuration.BuildSessionFactory() returned null.");
            }
            session = factory.OpenSession();
            if (session == null)
            {
                throw new InvalidOperationException("Call to factory.OpenSession() returned null.");
            }
            return session;
        }
        public static ISession CurrentSession
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    // running without an HttpContext (non-web mode)
                    // the nhibernate session is a singleton in the app domain
                    if (mSession != null)
                    {
                        return mSession;
                    }
                    else
                    {
                        mSession = CreateSession();
                        return mSession;
                    }
                }
                else
                {
                    // running inside of an HttpContext (web mode)
                    // the nhibernate session is a singleton to the http request
                    HttpContext currentContext = HttpContext.Current;
                    ISession session = currentContext.Items[KEY_NHIBERNATE_SESSION] as ISession;
                    if (session == null)
                    {
                        session = CreateSession();
                        currentContext.Items[KEY_NHIBERNATE_SESSION] = session;
                    }
                    mSession = session;
                    return session;
                }
            }
        }
    }
}
