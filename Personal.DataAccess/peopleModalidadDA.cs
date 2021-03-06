﻿using System;
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
namespace Personal.DataAccess
{
    public class peopleModalidadDA
    {
        public int DesactivarPersonal(string vCodigoPersona,
            string vTipoBaja,
            DateTime dFechaCese,
            string vTexto,
            int iCodigoTipoEmpleado,
            string vDescripcionTipoEmpleado,
            string vDescripcionTipoDocumento,
            string vNumeroDocumento,
            int iCodigoTipoDocumento
            )
        {
            int resultado = 0;
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbConnection cone = db.CreateConnection();
            cone.Open();
            using (DbTransaction trans = cone.BeginTransaction())
            {
                try
                {
                    DbCommand cmd = db.GetStoredProcCommand("[RRHH_SP_DESACTIVAR_EMPLEADO]");
                    db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, vCodigoPersona);
                    db.AddInParameter(cmd, "vTipoBaja", DbType.String, vTipoBaja);
                    db.AddInParameter(cmd, "D_FEC_CESE", DbType.Date, dFechaCese);
                    db.AddInParameter(cmd, "V_TEXTO", DbType.String, vTexto);
                    db.AddInParameter(cmd, "iCodigoTipoEmpleado", DbType.Int32, iCodigoTipoEmpleado);
                    db.AddInParameter(cmd, "vDescripcionTipoEmpleado", DbType.String, vDescripcionTipoEmpleado);
                    db.AddInParameter(cmd, "V_DES_TIPO_DOCUMENTO", DbType.String, vDescripcionTipoDocumento);
                    db.AddInParameter(cmd, "V_N_DOCUMENTO", DbType.String, vNumeroDocumento);
                    db.AddInParameter(cmd, "I_COD_TIPO_DOCUMENTO_CESE", DbType.Int32, iCodigoTipoDocumento);
                    resultado = db.ExecuteNonQuery(cmd, trans);
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
            return resultado;

        }
        public ModalidadPersonal ModalidadActualPersona(string vCodigoPersona)
        {

            ModalidadPersonal entity = new ModalidadPersonal();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbCommand cmd = db.GetStoredProcCommand("[RRHH_SP_BUSCAR_MODALIDAD_ACTUAL_X_PERSONA]");
            db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, vCodigoPersona);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                if (lee.Read())
                {
                    entity.persona.C_COD_PERSONA = lee["C_COD_PERSONA"].ToString();
                    entity.institucion.V_DES_INSTITUCION = lee["V_DES_INSTITUCION"].ToString();
                    entity.situacionMilitar.I_COD_SITUACION_MILITAR = lee["I_COD_SITUACION_MILITAR"].ToString() == "" ? 0 : Convert.ToInt32(lee["I_COD_SITUACION_MILITAR"]);
                    entity.tipoModalidad.I_COD_TIPO_MODALIDAD = Convert.ToInt32(lee["I_COD_TIPO_MODALIDAD"].ToString());
                    entity.tipoModalidad.V_DES_TIPO_MODALIDA = lee["V_DES_TIPO_MODALIDA"].ToString();
                    entity.tipoEmpleado.I_COD_TIPO_EMPLEADO = Convert.ToInt32(lee["I_COD_TIPO_EMPLEADO"].ToString());
                    entity.tipoEmpleado.V_DES_TIPO_EMPLEADO = lee["V_DES_TIPO_EMPLEADO"].ToString();
                    entity.vDescripcionGrado = lee["GRADO"].ToString();
                    entity.vDescripcionArma = lee["ARMA"].ToString();
                    entity.personaModalidad.I_COD_TIPO_DOCUMENTO_INGRESO = lee["I_COD_TIPO_DOCUMENTO_INGRESO"].ToString() == "" ? null : (int?)Convert.ToInt32(lee["I_COD_TIPO_DOCUMENTO_INGRESO"].ToString());
                    entity.personaModalidad.V_NRO_DOCUMENTO_INGRESO = lee["V_NRO_DOCUMENTO_INGRESO"].ToString();
                    entity.personaModalidad.D_FECHA_CONTRATO = lee["D_FECHA_CONTRATO"].ToString() == "" ? null : (DateTime?)Convert.ToDateTime(lee["D_FECHA_CONTRATO"].ToString());
                    entity.personaModalidad.I_COD_TIPO_DOCUMENTO_CESE = lee["I_COD_TIPO_DOCUMENTO_CESE"].ToString() == "" ? null : (int?)Convert.ToInt32(lee["I_COD_TIPO_DOCUMENTO_CESE"].ToString());
                    entity.personaModalidad.V_NRO_DOCUMENTO_CESE = lee["V_NRO_DOCUMENTO_CESE"].ToString();
                    entity.personaModalidad.D_FECHA_SECE = lee["D_FECHA_SECE"].ToString() == "" ? null : (DateTime?)Convert.ToDateTime(lee["D_FECHA_SECE"].ToString());
                    entity.personaModalidad.V_MOTIVO_CESE_CONTRATO = lee["V_MOTIVO_CESE_CONTRATO"].ToString();
                    entity.personaModalidad.C_ACTIVO = lee["C_ACTIVO"].ToString();
                    entity.personaGrado.D_FECHA_BAJA = lee["D_FECHA_BAJA"].ToString() == "" ? null : (DateTime?)Convert.ToDateTime(lee["D_FECHA_BAJA"].ToString());
                    entity.personaGrado.V_OBSERVACION_ANULACION = lee["V_OBSERVACION_ANULACION"].ToString();
                }

            }

            return entity;
        }


        public List<ModalidadPersonal> ListarModalidadesXpersona(string vCodigoPersona)
        {
            List<ModalidadPersonal> lista = new List<ModalidadPersonal>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbCommand cmd = db.GetStoredProcCommand("[RRHH_SP_BUSCAR_MODALIDAD_ACTUAL_X_PERSONA]");
            db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, vCodigoPersona);

            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    ModalidadPersonal entity = new ModalidadPersonal();

                    entity.persona.C_COD_PERSONA = lee["C_COD_PERSONA"].ToString();
                    entity.institucion.V_DES_INSTITUCION = lee["V_DES_INSTITUCION"].ToString();
                    entity.situacionMilitar.I_COD_SITUACION_MILITAR = lee["I_COD_SITUACION_MILITAR"].ToString() == "" ? 0 : Convert.ToInt32(lee["I_COD_SITUACION_MILITAR"]);
                    entity.tipoModalidad.I_COD_TIPO_MODALIDAD = Convert.ToInt32(lee["I_COD_TIPO_MODALIDAD"].ToString());
                    entity.tipoModalidad.V_DES_TIPO_MODALIDA = lee["V_DES_TIPO_MODALIDA"].ToString();
                    entity.tipoEmpleado.I_COD_TIPO_EMPLEADO = Convert.ToInt32(lee["I_COD_TIPO_EMPLEADO"].ToString());
                    entity.tipoEmpleado.V_DES_TIPO_EMPLEADO = lee["V_DES_TIPO_EMPLEADO"].ToString();
                    entity.vDescripcionGrado = lee["GRADO"].ToString();
                    entity.vDescripcionArma = lee["ARMA"].ToString();
                    entity.personaModalidad.I_COD_TIPO_DOCUMENTO_INGRESO = lee["I_COD_TIPO_DOCUMENTO_INGRESO"].ToString() == "" ? null : (int?)Convert.ToInt32(lee["I_COD_TIPO_DOCUMENTO_INGRESO"].ToString());
                    entity.personaModalidad.V_NRO_DOCUMENTO_INGRESO = lee["V_NRO_DOCUMENTO_INGRESO"].ToString();
                    entity.personaModalidad.D_FECHA_CONTRATO = lee["D_FECHA_CONTRATO"].ToString() == "" ? null : (DateTime?)Convert.ToDateTime(lee["D_FECHA_CONTRATO"].ToString());
                    entity.personaModalidad.I_COD_TIPO_DOCUMENTO_CESE = lee["I_COD_TIPO_DOCUMENTO_CESE"].ToString() == "" ? null : (int?)Convert.ToInt32(lee["I_COD_TIPO_DOCUMENTO_CESE"].ToString());
                    entity.personaModalidad.V_NRO_DOCUMENTO_CESE = lee["V_NRO_DOCUMENTO_CESE"].ToString();
                    entity.personaModalidad.D_FECHA_SECE = lee["D_FECHA_SECE"].ToString() == "" ? null : (DateTime?)Convert.ToDateTime(lee["D_FECHA_SECE"].ToString());
                    entity.personaModalidad.V_MOTIVO_CESE_CONTRATO = lee["V_MOTIVO_CESE_CONTRATO"].ToString();
                    entity.personaModalidad.C_ACTIVO = lee["C_ACTIVO"].ToString();
                    entity.personaGrado.D_FECHA_BAJA = lee["D_FECHA_BAJA"].ToString() == "" ? null : (DateTime?)Convert.ToDateTime(lee["D_FECHA_BAJA"].ToString());
                    entity.personaGrado.V_OBSERVACION_ANULACION = lee["V_OBSERVACION_ANULACION"].ToString();

                    lista.Add(entity);
                }
                return lista;
            }
        }
        //public List<DetallePersonaModalidadRpt> RptListarModalidad(string vCodigoPersona)
        //{

        //    List<DetallePersonaModalidadRpt> list = new List<DetallePersonaModalidadRpt>();

        //    Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
        //    DbCommand cmd = db.GetStoredProcCommand("[RRHH_SP_LISTAR_MODALIDAD]");
        //    db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, vCodigoPersona);
        //    using (IDataReader lee = db.ExecuteReader(cmd))
        //    {
        //        while (lee.Read())
        //        {

        //            DetallePersonaModalidadRpt entity = new DetallePersonaModalidadRpt();
        //            entity.V_DES_TIPO_EMPLEADO = lee["V_DES_TIPO_EMPLEADO"].ToString();
        //            entity.V_DES_TIPO_MODALIDA = lee["V_DES_TIPO_MODALIDA"].ToString();
        //            entity.D_FECHA_CONTRATO = lee["D_FECHA_CONTRATO"].ToString() == "" ? null : (DateTime?)Convert.ToDateTime(lee["D_FECHA_CONTRATO"].ToString());
        //            entity.D_FECHA_SECE = lee["D_FECHA_SECE"].ToString() == "" ? null : (DateTime?)Convert.ToDateTime(lee["D_FECHA_SECE"].ToString());
        //            entity.V_MOTIVO_CESE_CONTRATO = lee["V_MOTIVO_CESE_CONTRATO"].ToString();
        //            entity.C_ACTIVO = lee["C_ACTIVO"].ToString();
        //            list.Add(entity);

        //        }

        //    }

        //    return list;
        //}


    }
}
