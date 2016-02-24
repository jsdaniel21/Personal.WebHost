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
//using System.Collections.Generic;
using System.Data.Spatial;

namespace BussinessLogic.DataAccess
{
    public class peopleChargeDA
    {
        public int actualizarCargoPrincipal(RRHH_PERSONA_CARGO entity)
        {
            int resultado = 0;
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            using (DbConnection cone = db.CreateConnection())
            {
                cone.Open();
                using (DbTransaction trans = cone.BeginTransaction())
                {
                    try
                    {
                        DbCommand cmd = db.GetStoredProcCommand("RRHH_ACTUALIZAR_CARGO_PRINCIPAL");
                        db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, entity.C_COD_PERSONA);
                        db.AddInParameter(cmd, "I_COD_PERSONA_CARGO", DbType.Int32, entity.I_COD_PERSONA_CARGO);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
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
        public List<listarAreaCargoxPersonaVM> listarAreaCargoxPersona(string codPersona)
        {
            List<listarAreaCargoxPersonaVM> lista = new List<listarAreaCargoxPersonaVM>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbCommand cmd = db.GetStoredProcCommand("RRHH_SP_LISTAR_AREA_CARGO_X_PERSONA");
            db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, codPersona);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    listarAreaCargoxPersonaVM entity = new listarAreaCargoxPersonaVM();
                    entity.clsPeopleCharge.I_COD_PERSONA_CARGO = Convert.ToInt32(lee["I_COD_PERSONA_CARGO"].ToString());
                    entity.clsInstancia.V_DES_INSTANCIA = lee["V_DES_INSTANCIA"].ToString();
                    entity.clsArea.V_ABREV_FUNCIONES = lee["V_ABREV_FUNCIONES"].ToString();
                    entity.clsCargo.V_DES_CARGO = lee["V_DES_CARGO"].ToString();
                    entity.clsPeopleCharge.D_FEC_REGISTRO = lee["D_FEC_REGISTRO"].ToString();
                    entity.clsPeopleCharge.D_FEC_INGRESO = lee["D_FEC_INGRESO"].ToString() == "" ? null : (DateTime?)Convert.ToDateTime(lee["D_FEC_INGRESO"].ToString());
                    entity.clsPeopleCharge.D_FEC_BAJA = lee["D_FEC_BAJA"].ToString() == "" ? DateTime.MinValue : Convert.ToDateTime(lee["D_FEC_BAJA"].ToString());
                    entity.clsPeopleCharge.C_ACTIVO = lee["C_ACTIVO"].ToString();
                    lista.Add(entity);
                }

            }

            return lista;
        }

        public DateTime anularChargeForPeople(int codCargo, string observacion)
        {
            DateTime resultado = DateTime.MinValue;
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            using (DbConnection cone = db.CreateConnection())
            {
                cone.Open();

                using (DbTransaction trans = cone.BeginTransaction())
                {
                    try
                    {
                        DbCommand cmd = db.GetStoredProcCommand("RRHH_SP_ANULAR_CARGO_X_PERSONA", codCargo, observacion);
                        resultado = Convert.ToDateTime(db.ExecuteScalar(cmd, trans));
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
            }
            return resultado;

        }

        public int savePeopleCharge(RRHH_PERSONA_CARGO entity)
        {

            int resultado = 0;

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            using (DbConnection cone = db.CreateConnection())
            {
                cone.Open();

                using (DbTransaction trans = cone.BeginTransaction())
                {
                    try
                    {
                        DbCommand cmd = db.GetStoredProcCommand("RRHH_SP_REGISTRAR_PERSONA_CARGO");
                        db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, entity.C_COD_PERSONA);
                        db.AddInParameter(cmd, "I_COD_INSTANCIA", DbType.String, entity.I_COD_INSTANCIA);
                        db.AddInParameter(cmd, "C_COD_AREA", DbType.String, entity.C_COD_AREA);
                        db.AddInParameter(cmd, "I_COD_CARGO", DbType.Int32, entity.I_COD_CARGO);
                        db.AddInParameter(cmd, "D_FEC_INGRESO", DbType.Date, entity.D_FEC_INGRESO);
                        db.AddInParameter(cmd, "V_OBSERVACION_INGRESO", DbType.String, entity.V_OBSERVACION_INGRESO);
                        db.AddInParameter(cmd, "C_ACTIVO", DbType.String, "S");
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
            }

            return resultado;
        }
        public listarAreaCargoxPersonaVM detailsChargeForPeople(int codPeopleCharge)
        {

            listarAreaCargoxPersonaVM entity = new listarAreaCargoxPersonaVM();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("RRHH_SP_DETALLE_AREA_CARGO_X_PERSONA", codPeopleCharge);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                lee.Read();
                entity.clsPeopleCharge.I_COD_PERSONA_CARGO = Convert.ToInt32(lee["I_COD_PERSONA_CARGO"].ToString());
                entity.clsInstancia.I_COD_INSTANCIA = lee["I_COD_INSTANCIA"].ToString();
                entity.clsInstancia.V_DES_INSTANCIA = lee["V_DES_INSTANCIA"].ToString();
                //entity.clsInstancia.V_GEO_LOCALIZACION = DbGeography.FromText(lee["V_GEO_LOCALIZACION"].ToString());
                entity.clsInstancia.V_GEO_LOCALIZACION = lee["V_GEO_LOCALIZACION"].ToString();
                entity.clsArea.C_COD_AREA = lee["C_COD_AREA"].ToString();
                entity.clsArea.V_DES_FUNCIONES = lee["V_DES_FUNCIONES"].ToString();
                entity.clsArea.V_ABREV_FUNCIONES = lee["V_ABREV_FUNCIONES"].ToString();
                entity.clsCargo.I_COD_CARGO = Convert.ToInt32(lee["I_COD_CARGO"].ToString());
                entity.clsCargo.V_DES_CARGO = lee["V_DES_CARGO"].ToString();
                entity.clsPeopleCharge.D_FEC_REGISTRO = lee["D_FEC_REGISTRO"].ToString();
                entity.clsPeopleCharge.D_FEC_INGRESO = lee["D_FEC_INGRESO"].ToString() == "" ? null : (DateTime?)Convert.ToDateTime(lee["D_FEC_INGRESO"].ToString());
                entity.clsPeopleCharge.V_OBSERVACION_INGRESO = lee["V_OBSERVACION_INGRESO"].ToString();
                entity.clsPeopleCharge.V_OBSERVACION_ANULADO = lee["V_OBSERVACION_ANULADO"].ToString();
                entity.clsPeopleCharge.D_FEC_BAJA = lee["D_FEC_BAJA"].ToString() == "" ? DateTime.MinValue : Convert.ToDateTime(lee["D_FEC_BAJA"].ToString());
                entity.clsPeopleCharge.C_ACTIVO = lee["C_ACTIVO"].ToString();
            }
            return entity;
        }

  
        public List<MA_CARGO> listarCargo()
        {

            List<MA_CARGO> lista = new List<MA_CARGO>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbCommand cmd = db.GetStoredProcCommand("[MA_SP_LISTAR_CARGO]");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_CARGO entity = new MA_CARGO();
                    entity.I_COD_CARGO = Convert.ToInt32(lee["I_COD_CARGO"].ToString());
                    entity.V_DES_CARGO = lee["V_DES_CARGO"].ToString();
                    lista.Add(entity);
                }

            }

            return lista;
        }
        public int verifychargeActiveForPeople(string codPersona)
        {
            int resultado = 0;

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            using (DbConnection cone = db.CreateConnection())
            {
                cone.Open();
                using (DbTransaction trans = cone.BeginTransaction())
                {

                    try
                    {
                        DbCommand cmd = db.GetStoredProcCommand("RRHH_SP_VERIFICAR_CARGO_ACTIVO_X_PERSONA");
                        db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, codPersona);
                        resultado = Convert.ToInt32(db.ExecuteScalar(cmd));
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

            }
            return resultado;
        }

    }
}
