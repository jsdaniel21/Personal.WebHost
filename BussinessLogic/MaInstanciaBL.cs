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
    public class MaInstanciaBL : IMaInstanciaRepository
    {
        public List<MA_INSTANCIA> listInstanciaForTypeInst(string typeInstitution)
        {
            return new MaInstanciaDA().listInstanciaForTypeInst(typeInstitution);
        }

        public List<T> GetAll<T>()
        {
            throw new NotImplementedException();
        }

        public int create<T>(T x)
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(object id)
        {
            throw new NotImplementedException();
        }

        public int edit<T>(T x)
        {
            throw new NotImplementedException();
        }

        public int delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}
