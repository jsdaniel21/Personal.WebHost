using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Personal.BussinessEntity;
using Personal.Interfaces;
using Personal.DataAccess;

namespace BussinessLogic
{
    public class maTipoDocumentoBL : IMaTipoDocumentoRepository
    {
        public List<T> GetAll<T>()
        {
            return (List<T>)(object)new MaTipoDoumentoDA().ListarTipoDocumentos();
        }

        public int create<T>(T x)
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(object id)
        {
            var model = new MaTipoDoumentoDA().BuscarTipoDocumentoPorCodigo((int?)id);
            return (T)(object)(model == null ? new MA_TIPO_DOCUMENTO() : model);
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
