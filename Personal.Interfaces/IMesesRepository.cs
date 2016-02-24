using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntity;

namespace Personal.Interfaces
{
    public interface IMesesRepository
    {
        List<MA_MESES> getAll();
    }
}
