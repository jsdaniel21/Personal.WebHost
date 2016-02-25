using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntity;

namespace Personal.ViewModels
{

    public class rptPersonalList
    {
        public int ROW { get; set; }
        public string C_COD_PERSONA { get; set; }
        public int I_COD_INSTANCIA { get; set; }
        public string V_DES_INSTANCIA { get; set; }
        public string TITULO_INSTITUCION { get; set; }
        public string INSTITUCION { get; set; }
        public string V_DES_TIPO_EMPLEADO { get; set; }
        public int I_COD_TIPO_EMPLEADO { get; set; }
        public int I_COD_TIPO_MODALIDAD { get; set; }
        public string GRADO { get; set; }
        public string DNI { get; set; }
        public string ARMA { get; set; }
        public string EMPLEADO { get; set; }
        public string AREA { get; set; }
        public string CARGO { get; set; }
        public string SEXO { get; set; }
        public string C_ACTIVO { get; set; }

    }
}
