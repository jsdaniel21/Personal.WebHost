
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
    public class peopleVehiclesDA
    {
        public List<listPeopleVehiclesVM> listPeopleVehicles(string codPersona)
        {
            List<listPeopleVehiclesVM> lista = new List<listPeopleVehiclesVM>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("SG_LISTA_VEHICULOS_X_PERSONA");
            db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, codPersona);

            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    listPeopleVehiclesVM entity = new listPeopleVehiclesVM();
                    entity.clsPeopleVehicles.I_COD_PERSONA_VEHICULOS = Convert.ToInt32(lee["I_COD_PERSONA_VEHICULOS"].ToString());
                    entity.clsColor.V_DES_COLOR = lee["V_DES_COLOR"].ToString();
                    entity.clsBrandVehicles.V_DES_MARCA_VEHICULO = lee["V_DES_MARCA_VEHICULO"].ToString();
                    entity.clsModelVehicles.V_DES_MODELO_VEHICULOS = lee["V_DES_MODELO_VEHICULOS"].ToString();
                    entity.clsPeopleVehicles.V_DES_PLACA = lee["V_DES_PLACA"].ToString();
                    entity.clsPeopleVehicles.D_FEC_REGISTRO = Convert.ToDateTime(lee["D_FEC_REGISTRO"].ToString());
                    lista.Add(entity);
                }
            }
            return lista;
        }
    }
}
