
namespace BusDep.Common
{
    using System;
    using log4net;
    using log4net.Config;

    public class TraceLog4Net : IDisposable
    {
        public TraceLog4Net(Type logger, Type type, string method)
        {
            token = Guid.NewGuid();
            Type = type;
            Method = method;
            init = DateTime.Now;
            log = StaticLogger<TraceLog4Net>.GetLogger(logger);
            log.Info(string.Format("[INICIO token({0})] {1} - {2} {3}", token, init.ToString("O"), Type.Name, Method));
        }

        private Guid token;
        private DateTime init;
        private readonly ILog log;
        private Type Type { get; set; }

        private string Method { get; set; }

        public void Dispose()
        {
            log.Info(string.Format("[FIN token({0})] Inicio: {1} / Fin: {2} - {3} {4}", token, init.ToString("O"), DateTime.Now.ToString("O"), Type.Name, Method));
            log.Warn(string.Format("[TOKEN({0})] Inicio: {1} / Fin: {2} - {3} {4}", token, init.ToString("O"), DateTime.Now.ToString("O"), Type.Name, Method));
        }
    }
    public static class StaticLogger<T>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(T).FullName);
        static StaticLogger()
        {
            XmlConfigurator.Configure();
        }

        public static ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type.FullName);
        }

        public static ILog Logger { get { return logger; } }
    }
}
