using BussinessEntity;
using BussinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Interfaces
{
    public interface IMaInstanciaRepository:IRepository
    {
        List<MA_INSTANCIA> listInstanciaForTypeInst(string typeInstitution);
    }
}
