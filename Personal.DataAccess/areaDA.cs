using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data;
using System.Data.Common;
using System.Configuration;
using BussinessEntity;
using Personal.ViewModels;
namespace BussinessLogic.DataAccess
{
    public class areaDA
    {
        public List<areaForInstanciaVM> listarAreaForIsntancia(int codInstancia)
        {

            List<areaForInstanciaVM> lista = new List<areaForInstanciaVM>();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());

            DbCommand cmd = db.GetStoredProcCommand("[MA_SP_LISTADO_INSTANCIA_AREAS]", codInstancia);

            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    areaForInstanciaVM entity = new areaForInstanciaVM();

                    entity.clsInstanciaArea.I_NIVEL_INSTANCIA_AREA = Convert.ToInt32(lee["I_NIVEL_INSTANCIA_AREA"].ToString());
                    entity.clsArea.V_DES_FUNCIONES = lee["V_DES_FUNCIONES"].ToString();
                    entity.clsInstanciaArea.C_COD_AREA = lee["C_COD_AREA"].ToString();
                    entity.clsInstanciaArea.C_COD_AREA_SUPERIOR = lee["C_COD_AREA_SUPERIOR"].ToString();

                    lista.Add(entity);

                }

            }

            return lista;

        }

    }
}
