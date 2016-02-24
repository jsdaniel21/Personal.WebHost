using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Personal.Models
{
    public partial class cargoModel
    {
        [Display(Name = "Cargo")]
        [Required]
        public string V_DES_CARGO;
    }
}
