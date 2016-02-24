using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntity
{
    public partial class MA_CARRERA_PROFESIONALES
    {

        public int I_COD_CARRERA_PROFESIONAL { get; set; }

        public string V_DES_CARRERA_PROFESIONAL { get; set; }

        public string C_ACTIVO { get; set; }

        public ICollection<SG_PERSONA_ESTUDIOS> SG_PERSONA_ESTUDIOS { get; set; }
    }
}
