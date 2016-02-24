using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Personal.Models
{
    public partial class usuarioModel
    {
        [Display(Name = "Usuario:")]
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string V_NOM_USUARIO { get; set; }

        [Display(Name = "Contraseña:")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string V_CONTRASEÑA { get; set; }
        public bool remember { get; set; }
    }
}
