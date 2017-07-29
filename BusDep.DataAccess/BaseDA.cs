using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusDep.IDataAccess;

namespace BusDep.DataAccess
{
    public class BaseDA<T> : BaseDataAccess<T>, IBaseDA<T>
    {

    }
}
