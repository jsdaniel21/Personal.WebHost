﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal.ViewModels;


namespace BussinessLogic.Interfaces
{
    public interface IArea
    {

        List<areaForInstanciaVM> listarAreaForIsntancia(int codInstancia);
    }
}
