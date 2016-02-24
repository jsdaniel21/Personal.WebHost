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
    public class peopleFamilyDA
    {

        public List<MA_TIPO_FAMILIAR> typeFamily()
        {
            List<MA_TIPO_FAMILIAR> list = new List<MA_TIPO_FAMILIAR>();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_LISTAR_TIPO_FAMILIAR");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_TIPO_FAMILIAR entity = new MA_TIPO_FAMILIAR();
                    entity.I_COD_TIPO_FAMILIAR = Convert.ToInt32(lee["I_COD_TIPO_FAMILIAR"]);
                    entity.V_DES_TIPO_FAMILIAR = lee["V_DES_TIPO_FAMILIAR"].ToString();
                    list.Add(entity);
                }

            }
            return list;

        }
        public List<listPeopleFamilyVM> listPeopleFamily(string codPersona)
        {

            List<listPeopleFamilyVM> list = new List<listPeopleFamilyVM>();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbCommand cmd = db.GetStoredProcCommand("SG_SP_LISTAR_FAMILIAR_X_PERSONA");
            db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, codPersona);

            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    listPeopleFamilyVM entity = new listPeopleFamilyVM();

                    entity.clsCabPeopleFamily.C_COD_FAMILIAR = lee["C_COD_FAMILIAR"].ToString();
                    entity.clsPeople.V_NOMBRES = lee["V_NOMBRES"].ToString();
                    entity.clsPeople.V_APELLIDO_PATERNO = lee["V_APELLIDO_PATERNO"].ToString();
                    entity.clsPeople.V_APELLIDO_MATERNO = lee["V_APELLIDO_MATERNO"].ToString();
                    entity.clsTypeFamily.V_DES_TIPO_FAMILIAR = lee["V_DES_TIPO_FAMILIAR"].ToString();
                    entity.clsPeopleDetails.D_FEC_NACIMIENTO = Convert.ToDateTime(lee["D_FEC_NACIMIENTO"].ToString());
                    entity.clsCabPeopleFamily.C_COD_FAMILIAR = lee["C_COD_FAMILIAR"].ToString();
                    entity.clsOccupation.V_DES_OCUPACION = lee["V_DES_OCUPACION"].ToString();
                    list.Add(entity);
                }

            }
            return list;


        }
    }
}
