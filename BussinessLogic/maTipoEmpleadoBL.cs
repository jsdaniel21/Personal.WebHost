using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.DataAccess;
using Personal.ViewModels;
using BussinessEntity;
using BussinessLogic.Interfaces;
using Personal.Interfaces;
using Personal.DataAccess;
namespace BussinessLogic
{
    public class maTipoEmpleadoBL : IMatipoEmpleadoRepository
    {
        public List<MA_TIPO_EMPLEADO> getAll()
        {
            return new maTipoEmpleadoDA().getAll();
        }
    }
}
