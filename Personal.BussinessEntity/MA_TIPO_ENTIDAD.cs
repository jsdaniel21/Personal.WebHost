using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntity
{
    public class MA_TIPO_ENTIDAD
    {
        public MA_TIPO_ENTIDAD()
        {

            this.MA_INSTITUCION = new HashSet<MA_INSTITUCION>();

        }
        public int I_COD_TIPO_ENTIDAD { get; set; }
        public string V_DES_ENTIDAD { get; set; }

        public ICollection<MA_INSTITUCION> MA_INSTITUCION { get; set; }
    }
}
