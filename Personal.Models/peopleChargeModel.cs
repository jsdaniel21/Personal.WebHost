using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Personal.Models
{
    public partial class peopleChargeModel
    {
        [Display(Name = "Codigo")]
        public int I_COD_PERSONA_CARGO;
        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string D_FEC_REGISTRO;
        [Display(Name = "Fecha de Baja")]
        [DataType(DataType.DateTime)]
        public DateTime D_FEC_BAJA;
        [Display(Name = "Estado")]
        public string C_ACTIVO;
        [Display(Name = "Observacion Ingreso")]
        public string V_OBSERVACION_INGRESO;
        [Display(Name = "Observacion Anulacion")]
        public string V_OBSERVACION_ANULADO;

        [Display(Name = "Fecha de Ingreso")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string D_FEC_INGRESO;

    }
}
