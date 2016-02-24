using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Personal.Models
{
    public partial class maEstadoCivilModel
    {
        [Display(Name = "Estado civil")]
        public string V_DES_ESTADO_CIVIL;
    }
}
