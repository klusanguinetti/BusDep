using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusDep.Entity.DTO
{
    public class JugadorBusquedaDTO
    {
        public long Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }
        public string FotoRostro { get; set; }

        public string Nacionalidad { get; set; }

        public string Nacionalidad1 { get; set; }
        public string NacionalidadIso { get; set; }

        public string NacionalidadIso1 { get; set; }

        public string PuestoDescripcion { get; set; }

        public string Puesto { get; set; }

        public string ClubActual { get; set; }
        public string LogClubActual { get; set; }

        public string Perfil { get; set; }

        public string Fichaje { get; set; }
        
        public string Pais { get; set; }
        
        public string PaisIso { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Informacion { get; set; }

        #region datos fisico
        public virtual decimal? Altura { get; set; }
        public virtual decimal? Peso { get; set; }
        public string Pie { get; set; }
        #endregion

    }
}
