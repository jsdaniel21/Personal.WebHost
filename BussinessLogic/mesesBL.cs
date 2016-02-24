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
    public class mesesBL : IMesesRepository
    {
        public List<MA_MESES> getAll()
        {
            return new mesesDA().meses();
        }
    }
}
