using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace BusDep.Configuration.Interception
{
    public class InterceptorBase : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces() => Type.EmptyTypes;
        public virtual IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {

            var result = getNext()(input, getNext);
            InterceptExceptions(result, input);
            return result;

        }
        private void InterceptExceptions(IMethodReturn result, IMethodInvocation input)
        {
            if (result.Exception != null)
            {
                //OracleException ex = null;
                //if (result.Exception.InnerException != null)
                //{
                //    ex = (result.Exception.InnerException as OracleException);
                //}

                //if (ex != null && Math.Abs(ex.Number) == 20499)
                //{
                //    result.Exception = new DBCodeException(ex.Number, ex.Message);
                //}
                //if (!(result.Exception is IsbanException))
                //{
                //    var message = string.Format("Error {0} | Día y Hora: {1}. | Exception: {2}", this.GetType().Name,
                //        DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), result.Exception);
                //    TraceHelper.Error(message);
                //    var innerException = new Exception(result.Exception.Message);
                //    result.Exception = new DBException("Error no controlado en Acceso a Datos.", innerException);
                //}
            }
        }

        public bool WillExecute => true;
    }
}