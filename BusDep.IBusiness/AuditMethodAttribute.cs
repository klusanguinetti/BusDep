using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusDep.IBusiness
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class AuditMethodAttribute : Attribute
    {
       

    }
}
