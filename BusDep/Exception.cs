namespace BusDep
{
    using System;
    public interface IExceptionCode
    {
         long Codigo { get;  }

         string Message { get; }
         string MessageMechnical { get;  }
    }

    public abstract class ExceptionBase : Exception, IExceptionCode
    {
        public ExceptionBase(long codigo, string message, string messageMechnical = null, Exception ex = null) :base(message, ex)
        {
            this.Codigo = codigo;
            if (!string.IsNullOrWhiteSpace(messageMechnical))
                this.MessageMechnical = messageMechnical;
            else
            {
                if(ex!=null)
                    this.MessageMechnical = ex.ToString();
            }
        }

        public long Codigo { get; private set; }

        public string MessageMechnical { get; private set; }
    }
    public class ExceptionDataAccess : ExceptionBase
    {
        public ExceptionDataAccess(long codigo, string message, string messageMechnical = null, Exception ex = null)
            : base(codigo, message, messageMechnical, ex)
        {
        }
    }
    public class ExceptionBusiness : ExceptionBase
    {
        public ExceptionBusiness(long codigo, string message, string messageMechnical = null, Exception ex = null)
            : base(codigo, message, messageMechnical, ex)
        {
        }
    }
}
