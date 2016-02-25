using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal.ViewModels;
using BussinessEntity;

namespace Personal.Interfaces

{
    public interface IRptPersonalRepository
    {
          List<rptPersonalList> rptListarPersonal(int iCodigoTipoEmpleado, int iCodigoTipoModalidad, int iCodigoInstitucion, string vCodigoGradoMilitar, int iCodigoSituacionMilitar, int iCodigoInstancia,string cActivo);
    }
}
