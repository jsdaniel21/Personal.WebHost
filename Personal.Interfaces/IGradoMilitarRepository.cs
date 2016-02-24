using BussinessEntity;
using BussinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Personal.Interfaces
{
    public interface IGradoMilitarRepository : IRepository
    {
        List<MA_GRADO_MILITAR> listarGradoMilitarXinstitucion(int codInstitucion, string activo);
    }
}
