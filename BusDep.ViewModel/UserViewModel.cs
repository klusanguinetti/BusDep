using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusDep.ViewModel
{
    public class UserViewModel
    {
        public long? Id { get; set; }
        public string Mail { get; set; }
        public string TipoUsuario { get; set; }
        public string Password { get; set; }

    }
}
