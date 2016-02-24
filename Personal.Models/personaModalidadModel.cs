using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Personal.Models
{
    public partial class personaModalidadModel
    {
        [Display(Name="Fecha de Contrato")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime D_FECHA_CONTRATO;
    }
}
