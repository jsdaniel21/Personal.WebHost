using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Personal.ViewModels;
using System.Configuration;
using System.Data.Common;
using System.Data;
using BussinessEntity;


namespace BussinessLogic.DataAccess
{
    public class peopleTravelDA
    {
        public List<listTravelVM> listPeopleTravel(string codPersona)
        {
            List<listTravelVM> list = new List<listTravelVM>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbCommand cmd = db.GetStoredProcCommand("SG_LISTAR_VIAJES_X_PERSONA");
            db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, codPersona);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    listTravelVM entity = new listTravelVM();
                    entity.clsPeopleTravel.I_COD_PERSONA_VIAJES = Convert.ToInt32(lee["I_COD_PERSONA_VIAJES"].ToString());
                    entity.clsPais.V_DES_PAIS = lee["V_DES_PAIS"].ToString();
                    entity.clsPeopleTravel.I_AÑO = Convert.ToInt32(lee["I_AÑO"].ToString());
                    entity.clsPeopleTravel.V_TIEMPO_PERMANENCIA = lee["V_TIEMPO_PERMANENCIA"].ToString();
                    entity.clsPeopleTravel.V_DES_MOTIVO = lee["V_DES_MOTIVO"].ToString();
                    list.Add(entity);
                }

            }
            return list;
        }
        public listTravelVM DetailsPeopleTravel(int codpeopleTravels)
        {
            listTravelVM entity = new listTravelVM();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbCommand cmd = db.GetStoredProcCommand("SG_SP_DETALLE_PERSONA_VIAJES");
            db.AddInParameter(cmd, "I_COD_PERSONA_VIAJES", DbType.Int32, codpeopleTravels);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                lee.Read();
                entity.clsPais.I_COD_PAIS = Convert.ToInt32(lee["I_COD_PAIS"]);
                entity.clsPais.V_DES_PAIS = lee["V_DES_PAIS"].ToString();
                entity.clsPeopleTravel.I_AÑO = Convert.ToInt32(lee["I_AÑO"].ToString());
                entity.clsPeopleTravel.V_TIEMPO_PERMANENCIA = lee["V_TIEMPO_PERMANENCIA"].ToString();
                entity.clsPeopleTravel.V_DES_MOTIVO = lee["V_DES_MOTIVO"].ToString();
                entity.clsPeopleTravel.I_COD_PERSONA_VIAJES = Convert.ToInt32(lee["I_COD_PERSONA_VIAJES"]);
            }
            return entity;
        }
        public List<MA_PAI> listPais()
        {
            List<MA_PAI> list = new List<MA_PAI>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_LISTAR_PAIS");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_PAI entity = new MA_PAI();
                    entity.I_COD_PAIS = Convert.ToInt32(lee["I_COD_PAIS"]);
                    entity.V_DES_PAIS = lee["V_DES_PAIS"].ToString();
                    list.Add(entity);
                }

            }
            return list;
        }

        public int registerPeopleTravels(SG_PERSONA_VIAJES entity)
        {
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            int resultado = 0;


            using (DbConnection cone = db.CreateConnection())
            {
                cone.Open();
                using (DbTransaction trans = cone.BeginTransaction())
                {
                    try
                    {
                        DbCommand cmd = db.GetStoredProcCommand("[SG_SP_REGISTRAR_VIAJES_X_PERSONA]");
                        db.AddInParameter(cmd, "I_COD_PAIS", DbType.Int32, entity.I_COD_PAIS);
                        db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, entity.C_COD_PERSONA);
                        db.AddInParameter(cmd, "I_AÑO", DbType.Int32, entity.I_AÑO);
                        db.AddInParameter(cmd, "V_TIEMPO_PERMANENCIA", DbType.String, entity.V_TIEMPO_PERMANENCIA);
                        db.AddInParameter(cmd, "V_DES_MOTIVO", DbType.String, entity.V_DES_MOTIVO);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();

                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        if (cone.State == ConnectionState.Open)
                        {
                            cone.Close();
                        }

                    }

                }
                return resultado;
            }

        }
        public int actualizarPeopleTravels(SG_PERSONA_VIAJES entity)
        {
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            int resultado = 0;

            using (DbConnection cone = db.CreateConnection())
            {
                cone.Open();
                using (DbTransaction trans = cone.BeginTransaction())
                {
                    try
                    {
                        DbCommand cmd = db.GetStoredProcCommand("[SG_SP_ACTUALIZAR_VIAJES_X_PERSONA]");
                        db.AddInParameter(cmd, "I_COD_PERSONA_VIAJES", DbType.Int32, entity.I_COD_PERSONA_VIAJES);
                        db.AddInParameter(cmd, "I_COD_PAIS", DbType.Int32, entity.I_COD_PAIS);
                        db.AddInParameter(cmd, "I_AÑO", DbType.Int32, entity.I_AÑO);
                        db.AddInParameter(cmd, "V_TIEMPO_PERMANENCIA", DbType.String, entity.V_TIEMPO_PERMANENCIA);
                        db.AddInParameter(cmd, "V_DES_MOTIVO", DbType.String, entity.V_DES_MOTIVO);
                        resultado = db.ExecuteNonQuery(cmd, trans);
                        trans.Commit();
                    }
                    catch (Exception EX)
                    {
                        trans.Rollback();
                        throw new Exception(EX.Message);
                    }
                    finally
                    {
                        if (cone.State == ConnectionState.Open)
                        {
                            cone.Close();
                        }

                    }
                }
            }
            return resultado;

        }


        public int delete(int codPeopleTravels)
        {

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            int resultado = 0;


            using (DbConnection cone = db.CreateConnection())
            {
                cone.Open();
                using (DbTransaction trans = cone.BeginTransaction())
                {
                    try
                    {
                        DbCommand cmd = db.GetStoredProcCommand("[SG_SP_ELIMINAR_VIAJES_X_PERSONA]");
                        db.AddInParameter(cmd, "I_COD_PERSONA_VIAJES", DbType.Int32, codPeopleTravels);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();

                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        if (cone.State == ConnectionState.Open)
                        {
                            cone.Close();
                        }

                    }

                }
                return resultado;
            }
        }
    }
}
