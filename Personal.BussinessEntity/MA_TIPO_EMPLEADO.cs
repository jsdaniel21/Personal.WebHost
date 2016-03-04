using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntity;

using System.ComponentModel.DataAnnotations;
using Personal.Models;

namespace BussinessEntity
{
    [MetadataType(typeof(tipoEmpleadoModel))]
    public partial class MA_TIPO_EMPLEADO
    {
        public MA_TIPO_EMPLEADO()
        {
            this.MA_TIPO_MODALIDAD = new HashSet<MA_TIPO_MODALIDAD>();
        }
        public int I_COD_TIPO_EMPLEADO { get; set; }
        public string V_DES_TIPO_EMPLEADO { get; set; }
        public string C_ACTIVO { get; set; }
        public ICollection<MA_TIPO_MODALIDAD> MA_TIPO_MODALIDAD { get; set; }
    }
}
