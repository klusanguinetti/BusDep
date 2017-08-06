using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using BusDep.Common;
using BusDep.Entity;
using BusDep.IBusiness;
using BusDep.IDataAccess;
using BusDep.UnityInject;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace BusDep.Configuration.Interception
{
    public abstract class InterceptorBase : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces() => Type.EmptyTypes;
        public virtual IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            using (TraceLog4Net trace = new TraceLog4Net(GetType(), input.Target.GetType(), input.MethodBase.Name))
            {
                GuardarLogActividad(input);
                var result = getNext()(input, getNext);
                if (result.Exception != null)
                    InterceptExceptions(result, input);
                return result;
            }
        }

        public abstract void InterceptExceptions(IMethodReturn result, IMethodInvocation input);

        private void GuardarLogActividad(IMethodInvocation input)
        {
            if (input.MethodBase.GetCustomAttributes().Any(o => o.GetType() == typeof(AuditMethodAttribute)))
            {
                LogActividad log = new LogActividad {Metodo = string.Format("{0}.{1}", input.Target.GetType().BaseType.FullName,input.MethodBase.Name), Fecha = DateTime.Now, Informacion = (input.Arguments.Count > 0 ? input.Arguments.SerializarToJson() : string.Empty) };
                DependencyFactory.Resolve<IBaseDA<LogActividad>>().Save(log);
            }
        }

        internal string GenerarInformacionTecnica(IMethodReturn result, IMethodInvocation input)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Clase: {0}", input.Target.GetType().Name));
            sb.AppendLine(string.Format("Metodo: {0}", input.MethodBase.Name));
            sb.AppendLine(string.Format("Parametros: {0}", input.Arguments.Count > 0 ? input.Arguments.SerializarToJson() : string.Empty));
            StaticLogger<InterceptorBase>.Logger.Error(sb.ToString(), result.Exception);
            return sb.ToString();
        }

        public bool WillExecute => true;
    }

    public class InterceptorDataAccess : InterceptorBase
    {
        public override void InterceptExceptions(IMethodReturn result, IMethodInvocation input)
        {
            if (result.Exception != null && !(result.Exception is IExceptionCode))
            {
                result.Exception = new ExceptionDataAccess(-99, "A ocurrido un error por favor intente más tarde",
                    this.GenerarInformacionTecnica(result, input), result.Exception);
            }
        }
        


    }
    public class InterceptorBusiness : InterceptorBase
    {

        public override void InterceptExceptions(IMethodReturn result, IMethodInvocation input)
        {
            if (result.Exception != null && !(result.Exception is IExceptionCode))
            {
                LogError logError = new LogError { Modulo = input.Target.GetType().Name, Descripcion = result.Exception.ToString() };
                DependencyFactory.Resolve<IBaseDA<LogError>>().Save(logError);
                result.Exception = new ExceptionBusiness(-99, "A ocurrido un error por favor intente más tarde",
                    this.GenerarInformacionTecnica(result, input), result.Exception);
            }
        }
    }

}