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
    public class personaDA
    {
        private string cn = ConfigurationManager.AppSettings["conecion"].ToString();
        #region Reportes
        public List<rptPersonalList> rptListarPersonal(int iCodigoTipoEmpleado,int iCodigoTipoModalidad,int iCodigoInstitucion,string vCodigoGradoMilitar,int iCodigoSituacionMilitar,int iCodigoInstancia)
        {
            List<rptPersonalList> lista = new List<rptPersonalList>();
            Database db = DatabaseFactory.CreateDatabase(cn);
            DbCommand cmd = db.GetStoredProcCommand("RRHH_SP_RPT_LISTAR_PERSONAL");
            db.AddInParameter(cmd, "I_COD_TIPO_EMPLEADO",DbType.Int32,iCodigoTipoEmpleado);
            db.AddInParameter(cmd, "I_COD_TIPO_MODALIDAD", DbType.Int32, iCodigoTipoModalidad);
            db.AddInParameter(cmd, "I_COD_INSTITUCION", DbType.Int32, iCodigoInstitucion);
            db.AddInParameter(cmd, "C_COD_GRADO_MILITAR", DbType.String, vCodigoGradoMilitar);
            db.AddInParameter(cmd, "I_COD_SITUACION_MILITAR", DbType.Int32, iCodigoSituacionMilitar);
            db.AddInParameter(cmd, "I_COD_INSTANCIA", DbType.Int32, iCodigoInstancia);

            IDataReader lee = db.ExecuteReader(cmd);
            while (lee.Read())
            {
                rptPersonalList model = new rptPersonalList();
                model.ROW = Convert.ToInt32(lee["ROW"]);
                model.C_COD_PERSONA = lee["C_COD_PERSONA"].ToString();
                model.EMPLEADO = lee["EMPLEADO"].ToString();          
                model.V_DES_TIPO_MODALIDA = lee["V_DES_TIPO_MODALIDA"].ToString();
                model.INSTITUCION = lee["INSTITUCION"].ToString();
                model.GRADO = lee["GRADO"].ToString();
                model.V_DES_CARGO = lee["V_DES_CARGO"].ToString();
                model.V_DES_FUNCIONES = lee["V_DES_FUNCIONES"].ToString();
                model.V_DES_INSTANCIA = lee["V_DES_INSTANCIA"].ToString();
                model.C_ACTIVO = lee["C_ACTIVO"].ToString();
                lista.Add(model);
            }
            return lista;

        }
        #endregion
        
        public List<MA_TIPO_EMPLEADO> listarTipoEmpleado()
        {
            List<MA_TIPO_EMPLEADO> lista = new List<MA_TIPO_EMPLEADO>();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            //cuando usemos metodos conetados recien crear una conexion aiverta al servidor
            // en esta caso manejadores una conecion no conectada hacia servidor apra retornar los datos  y no maneja un transacion
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_TIPO_EMPLEADO_LISTAR_ACTIVOS");//esta clase generar los metodos para poder implementar la interfaz
            //este metodo genera un implementacion hacia esta interfaz
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_TIPO_EMPLEADO entity = new MA_TIPO_EMPLEADO();
                    entity.V_DES_TIPO_EMPLEADO = lee["V_DES_TIPO_EMPLEADO"].ToString();
                    entity.I_COD_TIPO_EMPLEADO = Convert.ToInt32(lee["I_COD_TIPO_EMPLEADO"].ToString());
                    lista.Add(entity);
                }
            }
            return lista;
        }
        public object changeIntNull(int? val)
        {
            if (Convert.ToInt32(val) == 0)
            {
                return DBNull.Value;
            }
            else
            {
                return val;
            }
        }
        public object changeStringNull(string val)
        {
            if (val == "")
            {
                return DBNull.Value;
            }
            else
            {
                return val;
            }
        }
        public int registrarCaracteristicas(RRHH_PERSONA entity)
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
                        DbCommand cmd = db.GetStoredProcCommand("RRHH_SP_REGISTRAR_CARACTERISTICAS_PERSONALES");
                        db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, entity.C_COD_PERSONA);
                        db.AddInParameter(cmd, "V_APELLIDO_PATERNO", DbType.String, entity.V_APELLIDO_PATERNO);
                        db.AddInParameter(cmd, "V_APELLIDO_MATERNO", DbType.String, entity.V_APELLIDO_MATERNO);
                        db.AddInParameter(cmd, "V_NOMBRES", DbType.String, entity.V_NOMBRES);
                        db.AddInParameter(cmd, "C_ACTIVO", DbType.String, entity.C_ACTIVO);
                        db.AddInParameter(cmd, "I_COD_TIPO_MODALIDAD", DbType.Int32, entity.RRHH_PERSONA_MODALIDAD.FirstOrDefault().I_COD_TIPO_MODALIDAD);
                        db.AddInParameter(cmd, "I_COD_PAIS", DbType.Int32, changeIntNull(entity.RRHH_PERSONA_DETALLE.FirstOrDefault().I_COD_PAIS));
                        db.AddInParameter(cmd, "C_COD_DEPARTAMENTO", DbType.String, entity.RRHH_PERSONA_DETALLE.FirstOrDefault().C_COD_DEPARTAMENTO);
                        db.AddInParameter(cmd, "C_COD_PROVINCIA", DbType.String, entity.RRHH_PERSONA_DETALLE.FirstOrDefault().C_COD_PROVINCIA);
                        db.AddInParameter(cmd, "C_COD_DISTRITO", DbType.String, entity.RRHH_PERSONA_DETALLE.FirstOrDefault().C_COD_DISTRITO);
                        db.AddInParameter(cmd, "D_FEC_NACIMIENTO", DbType.String, Convert.ToDateTime(entity.RRHH_PERSONA_DETALLE.FirstOrDefault().D_FEC_NACIMIENTO).ToShortDateString());
                        db.AddInParameter(cmd, "I_COD_ESTADO_CIVIL", DbType.Int32, changeIntNull(entity.RRHH_PERSONA_DETALLE.FirstOrDefault().I_COD_ESTADO_CIVIL));
                        db.AddInParameter(cmd, "I_COD_SEXO", DbType.Int32, changeIntNull(entity.RRHH_PERSONA_DETALLE.FirstOrDefault().I_COD_SEXO));
                        db.AddInParameter(cmd, "I_COD_GRUPO_SANGUINEO", DbType.Int32, changeIntNull(entity.RRHH_PERSONA_DETALLE.FirstOrDefault().I_COD_GRUPO_SANGUINEO));
                        db.AddInParameter(cmd, "I_PESO", DbType.Int32, changeIntNull(entity.RRHH_PERSONA_DETALLE.FirstOrDefault().I_PESO));
                        db.AddInParameter(cmd, "DE_TALLA", DbType.Decimal, entity.RRHH_PERSONA_DETALLE.FirstOrDefault().DE_TALLA);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        cone.Close();
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
        public List<RRHH_PERSONA_IDENTIFICACION> listarIdentificacionPersonal(string codPersona)
        {

            List<RRHH_PERSONA_IDENTIFICACION> lista = new List<RRHH_PERSONA_IDENTIFICACION>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("RRHH_SP_LISTAR_IDENTIFICACION");
            db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, codPersona);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    RRHH_PERSONA_IDENTIFICACION entity = new RRHH_PERSONA_IDENTIFICACION();
                    entity.I_COD_PERSONA_IDENTIFICACION = Convert.ToInt32(lee["I_COD_PERSONA_IDENTIFICACION"]);
                    entity.I_COD_TIPO_IDENTIFICACION = Convert.ToInt32(lee["I_COD_TIPO_IDENTIFICACION"]);
                    entity.V_NUM_DOCUMENTO = lee["V_NUM_DOCUMENTO"].ToString();
                    entity.MA_TIPO_IDENTIFICACION.V_ABREV_IDENTIFICACION = lee["V_ABREV_IDENTIFICACION"].ToString();
                    lista.Add(entity);
                }
            }
            return lista;
        }
        public List<MA_GRUPO_SANGUINEO> listarGrupoSanguineo()
        {
            List<MA_GRUPO_SANGUINEO> lista = new List<MA_GRUPO_SANGUINEO>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_LISTAR_GRUPOSANGUINEO_CBO");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_GRUPO_SANGUINEO entity = new MA_GRUPO_SANGUINEO();
                    entity.I_COD_GRUPO_SANGUINEO = Convert.ToInt32(lee["I_COD_GRUPO_SANGUINEO"]);
                    entity.V_DES_GRUPO_SANGUINEO = lee["V_DES_GRUPO_SANGUINEO"].ToString();
                    lista.Add(entity);
                }
            }

            return lista;
        }
        public List<MA_SEXO> listarSexo()
        {
            List<MA_SEXO> lista = new List<MA_SEXO>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("[MA_SP_LISTAR_SEXO_CBO]");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_SEXO entity = new MA_SEXO();
                    entity.I_COD_SEXO = Convert.ToInt32(lee["I_COD_SEXO"]);
                    entity.V_DES_SEXO = lee["V_DES_SEXO"].ToString();
                    lista.Add(entity);
                }


            }
            return lista;

        }
        public List<MA_ESTADO_CIVIL> listarEstadoCivil()
        {
            List<MA_ESTADO_CIVIL> lista = new List<MA_ESTADO_CIVIL>();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_LISTAR_ESTADO_CIVIL_CBO");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_ESTADO_CIVIL entity = new MA_ESTADO_CIVIL();
                    entity.I_COD_ESTADO_CIVIL = Convert.ToInt32(lee["I_COD_ESTADO_CIVIL"]);
                    entity.V_DES_ESTADO_CIVIL = lee["V_DES_ESTADO_CIVIL"].ToString();
                    lista.Add(entity);
                }
            }

            return lista;
        }
        public RRHH_PERSONA caracteristicasPeople(string codPersona)
        {
            RRHH_PERSONA entity = new RRHH_PERSONA();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("RRHH_SP_DETALLE_CARACTERISTICA_PERSONAL");
            db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, codPersona);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                lee.Read();
                entity.C_COD_PERSONA = lee["C_COD_PERSONA"].ToString();
                entity.V_APELLIDO_PATERNO = lee["V_APELLIDO_PATERNO"].ToString();
                entity.V_APELLIDO_MATERNO = lee["V_APELLIDO_MATERNO"].ToString();
                entity.V_NOMBRES = lee["V_NOMBRES"].ToString();
                entity.RRHH_PERSONA_MODALIDAD.Add(new RRHH_PERSONA_MODALIDAD
                {
                    I_COD_PERSONA_MODALIDAD = Convert.ToInt32(lee["I_COD_PERSONA_MODALIDAD"].ToString()),
                    D_FECHA_CONTRATO = Convert.ToDateTime(lee["D_FECHA_CONTRATO"].ToString()),
                    I_COD_TIPO_MODALIDAD = Convert.ToInt32(lee["I_COD_TIPO_MODALIDAD"].ToString()),
                    MA_TIPO_MODALIDAD = new MA_TIPO_MODALIDAD
                    {
                        V_DES_TIPO_MODALIDA = lee["V_DES_TIPO_MODALIDA"].ToString()
                        ,
                        I_COD_TIPO_EMPLEADO = Convert.ToInt32(lee["I_COD_TIPO_EMPLEADO"])
                    }
                });
                entity.RRHH_PERSONA_DETALLE.Add(new RRHH_PERSONA_DETALLE
                {
                    I_COD_PERSONA_DETALLE = Convert.ToInt32(lee["I_COD_PERSONA_DETALLE"]),
                    I_COD_PAIS = Convert.ToInt32(lee["I_COD_PAIS"]),
                    C_COD_DEPARTAMENTO = lee["C_COD_DEPARTAMENTO"].ToString(),
                    C_COD_PROVINCIA = lee["C_COD_PROVINCIA"].ToString(),
                    C_COD_DISTRITO = lee["C_COD_DISTRITO"].ToString(),
                    D_FEC_NACIMIENTO = lee["D_FEC_NACIMIENTO"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(lee["D_FEC_NACIMIENTO"].ToString()),
                    MA_PAIS = new MA_PAI { V_DES_PAIS = lee["V_DES_PAIS"].ToString() },
                    MA_DEPARTAMENTO = new MA_DEPARTAMENTO { V_DES_DEPARTAMENTO = lee["V_DES_DEPARTAMENTO"].ToString() },
                    MA_PROVINCIA = new MA_PROVINCIA { V_DES_PROVINCIA = lee["V_DES_PROVINCIA"].ToString() },
                    MA_DISTRITO = new MA_DISTRITO { V_DES_DISTRITO = lee["V_DES_DEPARTAMENTO"].ToString() },
                    I_COD_ESTADO_CIVIL = Convert.ToInt32(lee["I_COD_ESTADO_CIVIL"]),
                    I_COD_SEXO = Convert.ToInt32(lee["I_COD_SEXO"]),
                    I_COD_GRUPO_SANGUINEO = Convert.ToInt32(lee["I_COD_GRUPO_SANGUINEO"]),
                    MA_ESTADO_CIVIL = new MA_ESTADO_CIVIL { V_DES_ESTADO_CIVIL = lee["V_DES_ESTADO_CIVIL"].ToString() },
                    MA_SEXO = new MA_SEXO { V_DES_SEXO = lee["V_DES_SEXO"].ToString() },
                    MA_GRUPO_SANGUINEO = new MA_GRUPO_SANGUINEO { V_DES_GRUPO_SANGUINEO = lee["V_DES_GRUPO_SANGUINEO"].ToString() },
                    I_PESO = Convert.ToInt32(lee["I_PESO"]),
                    DE_TALLA = Convert.ToDecimal(lee["DE_TALLA"])
                });
            }

            return entity;

        }
        public int registrarImagen(SG_PERSONA_IMAGENE entity)
        {
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            int resultado = 0;

            using (DbConnection cone = db.CreateConnection())
            {
                cone.Open();

                using (DbTransaction trans = cone.BeginTransaction())
                {
                    try
                    {
                        DbCommand cmd = db.GetStoredProcCommand("SG_SP_REGISTRAR_PERSONA_IMAGENES");
                        db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, entity.C_COD_PERSONA);
                        db.AddInParameter(cmd, "I_COD_TIPO_IMAGEN", DbType.String, entity.I_COD_TIPO_IMAGEN);
                        db.AddInParameter(cmd, "V_DES_IMAGEN", DbType.String, entity.V_DES_IMAGEN);
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
        public int registrarEmpleado(RRHH_PERSONA entity)
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
                        DbCommand cmd = db.GetStoredProcCommand("RRHH_SP_REGISTRAR_EMPLEADO");
                        db.AddInParameter(cmd, "V_APELLIDO_PATERNO", DbType.String, entity.V_APELLIDO_PATERNO);
                        db.AddInParameter(cmd, "V_APELLIDO_MATERNO", DbType.String, entity.V_APELLIDO_MATERNO);
                        db.AddInParameter(cmd, "V_NOMBRES", DbType.String, entity.V_NOMBRES);
                        db.AddInParameter(cmd, "I_COD_TIPO_MODALIDAD", DbType.Int32, entity.RRHH_PERSONA_MODALIDAD.FirstOrDefault().I_COD_TIPO_MODALIDAD);

                        db.AddInParameter(cmd, "I_COD_INSTITUCION", DbType.Int32, entity.RRHH_PERSONA_GRADO.FirstOrDefault().I_COD_INSTITUCION);
                        db.AddInParameter(cmd, "C_COD_GRADO_MILITAR", DbType.String, entity.RRHH_PERSONA_GRADO.FirstOrDefault().C_COD_GRADO_MILITAR);
                        db.AddInParameter(cmd, "I_COD_SITUACION_MILITAR", DbType.Int32, entity.RRHH_PERSONA_GRADO.FirstOrDefault().I_COD_SITUACION_MILITAR);

                        db.AddInParameter(cmd, "I_COD_INSTANCIA", DbType.Int32, entity.RRHH_PERSONA_CARGO.FirstOrDefault().I_COD_INSTANCIA);
                        db.AddInParameter(cmd, "C_COD_AREA", DbType.String, entity.RRHH_PERSONA_CARGO.FirstOrDefault().C_COD_AREA);
                        db.AddInParameter(cmd, "I_COD_CARGO", DbType.String, entity.RRHH_PERSONA_CARGO.FirstOrDefault().I_COD_CARGO);
                        db.AddInParameter(cmd, "D_FEC_INGRESO", DbType.Date, entity.RRHH_PERSONA_CARGO.FirstOrDefault().D_FEC_INGRESO);
                        db.AddInParameter(cmd, "V_OBSERVACION_INGRESO", DbType.String, entity.RRHH_PERSONA_CARGO.FirstOrDefault().V_OBSERVACION_INGRESO.ToString() == "" ? null : entity.RRHH_PERSONA_CARGO.FirstOrDefault().V_OBSERVACION_INGRESO);

                        //db.AddInParameter(cmd, "BoolGrade", DbType.Boolean, BoolGrade);
                        var codPersona = db.ExecuteScalar(cmd, trans).ToString();
                        trans.Commit();
                        var count = 0;
                        if (codPersona.Length == 15)
                            cone.Close();
                        ICollection<RRHH_PERSONA_IDENTIFICACION> lista = new List<RRHH_PERSONA_IDENTIFICACION>();
                        lista = entity.RRHH_PERSONA_IDENTIFICACION;
                        for (int i = 0; i < lista.Count; i++)
                        {
                            var _entity = lista.ToArray()[i];
                            _entity.C_COD_PERSONA = codPersona;

                            if (registrarIdentificacion(_entity) > 0)
                            {
                                count++;
                            };
                        }

                        resultado = count;

                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw;
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

        public int deletePersonaIdentificacion(int tipoIdentificacion, string codPersona)
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
                        DbCommand cmd = db.GetStoredProcCommand("RRHH_SP_DELETE_PERSONA_IDENTIFICACION");
                        db.AddInParameter(cmd, "I_COD_TIPO_IDENTIFICACION", DbType.Int32, tipoIdentificacion);
                        db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, codPersona);
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
        public int registrarIdentificacion(RRHH_PERSONA_IDENTIFICACION entity)
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
                        DbCommand cmd = db.GetStoredProcCommand("RRHH_SP_REGISTRAR_PERSONA_IDENTIFICACION");
                        db.AddInParameter(cmd, "I_COD_TIPO_IDENTIFICACION", DbType.Int32, entity.I_COD_TIPO_IDENTIFICACION);
                        db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, entity.C_COD_PERSONA);
                        db.AddInParameter(cmd, "V_NUM_DOCUMENTO", DbType.String, entity.V_NUM_DOCUMENTO);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw;
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

        public List<MA_SITUACION_MILITAR> listarSituacionMilitar()
        {
            List<MA_SITUACION_MILITAR> lista = new List<MA_SITUACION_MILITAR>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_LISTAR_SITUACION_MILITAR");
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    MA_SITUACION_MILITAR entity = new MA_SITUACION_MILITAR();
                    entity.V_DES_TIPO_SITUACION = reader["V_DES_TIPO_SITUACION"].ToString();
                    entity.I_COD_SITUACION_MILITAR = Convert.ToInt32(reader["I_COD_SITUACION_MILITAR"].ToString());
                    lista.Add(entity);
                }
            }
            return lista;

        }

        public List<RRHH_PERSONA> queryEmployees(string vCodigoPersona, int iCodigoTipoEmpleado, int iCodigoTipoModalidad, int iCodigoInstitucion, string vCodigoGradoMilitar, int iCodigoSituacionMilitar, int iCodigoInstancia)
        {
            List<RRHH_PERSONA> lista = new List<RRHH_PERSONA>();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());

            DbCommand cmd = db.GetStoredProcCommand("[RRHH_SP_PERSONA_LISTAR]");
            db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, vCodigoPersona);
            db.AddInParameter(cmd, "I_COD_TIPO_EMPLEADO", DbType.Int32, iCodigoTipoEmpleado);
            db.AddInParameter(cmd, "I_COD_TIPO_MODALIDAD", DbType.Int32, iCodigoTipoModalidad);
            db.AddInParameter(cmd, "I_COD_INSTITUCION", DbType.Int32, iCodigoInstitucion);
            db.AddInParameter(cmd, "C_COD_GRADO_MILITAR", DbType.String, vCodigoGradoMilitar);
            db.AddInParameter(cmd, "I_COD_SITUACION_MILITAR", DbType.String, iCodigoSituacionMilitar);
            db.AddInParameter(cmd, "I_COD_INSTANCIA", DbType.Int32, iCodigoInstancia);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    RRHH_PERSONA Epersona = new RRHH_PERSONA();
                    Epersona.C_COD_PERSONA = lee["C_COD_PERSONA"].ToString();
                    Epersona.V_APELLIDO_PATERNO = lee["V_APELLIDO_PATERNO"].ToString();
                    Epersona.V_APELLIDO_MATERNO = lee["V_APELLIDO_MATERNO"].ToString();
                    Epersona.V_NOMBRES = lee["V_NOMBRES"].ToString();
                    Epersona.C_ACTIVO = lee["C_ACTIVO"].ToString();
                    lista.Add(Epersona);
                }
            }

            return lista;
        }

        public List<MA_INSTITUCION> listarInstitucionForTipo(int codTipoInstitucion, int codTipoEntidad)
        {
            List<MA_INSTITUCION> lista = new List<MA_INSTITUCION>();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbCommand cmd = db.GetStoredProcCommand("[MA_SP_LISTAR_INSTITUCIONES]");
            db.AddInParameter(cmd, "I_COD_TIPO_INSTITUCION", DbType.Int32, codTipoInstitucion);
            db.AddInParameter(cmd, "I_COD_TIPO_ENTIDAD", DbType.Int32, codTipoEntidad);
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    MA_INSTITUCION entity = new MA_INSTITUCION();
                    entity.I_COD_INSTITUCION = Convert.ToInt32(reader["I_COD_INSTITUCION"].ToString());
                    entity.V_DES_INSTITUCION = reader["V_DES_INSTITUCION"].ToString();
                    lista.Add(entity);
                }
            }
            return lista;

        }
        public List<MA_TIPO_IDENTIFICACION> listTypeIdentificacion()
        {
            List<MA_TIPO_IDENTIFICACION> lista = new List<MA_TIPO_IDENTIFICACION>();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbCommand cmd = db.GetStoredProcCommand("[MA_SP_LISTAR_IDENTITFICACION]");
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    MA_TIPO_IDENTIFICACION entity = new MA_TIPO_IDENTIFICACION();
                    entity.I_COD_TIPO_IDENTIFICACION = Convert.ToInt32(reader["I_COD_TIPO_IDENTIFICACION"].ToString());
                    entity.V_ABREV_IDENTIFICACION = reader["V_ABREV_IDENTIFICACION"].ToString();
                    entity.C_ACTIVO = reader["C_ACTIVO"].ToString();
                    lista.Add(entity);
                }
            }
            return lista;
        }
        public List<MA_TIPO_MODALIDAD> listTypeModality(int codTipoEmpleado)
        {
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_TIPO_MODALIDAD_LISTAR_ACTIVOS");
            db.AddInParameter(cmd, "I_COD_TIPO_EMPLEADO", DbType.Int32, codTipoEmpleado);
            List<MA_TIPO_MODALIDAD> list = new List<MA_TIPO_MODALIDAD>();
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    MA_TIPO_MODALIDAD entity = new MA_TIPO_MODALIDAD();
                    entity.I_COD_TIPO_MODALIDAD = Convert.ToInt32(reader["I_COD_TIPO_MODALIDAD"].ToString());
                    entity.V_DES_TIPO_MODALIDA = reader["V_DES_TIPO_MODALIDA"].ToString();
                    list.Add(entity);
                }
            }

            return list;

        }
        public dataPeopleForEmployeesVM dataPeopleForEmployees(string codPeople, string codTipoSistema, string username)
        {


            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbCommand cmd = db.GetStoredProcCommand("[RRHH_SP_OBTENER_DATOS_PERSONALES_X_EMPLEADO]", codPeople);
            dataPeopleForEmployeesVM Entity = new dataPeopleForEmployeesVM();

            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                lee.Read();
                Entity.clsPeople.C_COD_PERSONA = lee["C_COD_PERSONA"].ToString();
                Entity.clsPeople.V_APELLIDO_PATERNO = lee["V_APELLIDO_PATERNO"].ToString();
                Entity.clsPeople.V_APELLIDO_MATERNO = lee["V_APELLIDO_MATERNO"].ToString();
                Entity.clsPeople.V_NOMBRES = lee["V_NOMBRES"].ToString();
                Entity.clsPeopleIMG.V_DES_IMAGEN = lee["V_DES_IMAGEN"].ToString();
                Entity.clsPeopleIdentification.V_NUM_DOCUMENTO = lee["V_NUM_DOCUMENTO"].ToString();
                Entity.clsPeopleIdentification.I_COD_TIPO_IDENTIFICACION = Convert.ToInt32(lee["I_COD_TIPO_IDENTIFICACION"].ToString());
                Entity.clsPeopleModalidad.D_FECHA_CONTRATO = lee["D_FECHA_CONTRATO"].ToString() == "" ? null : (DateTime?)Convert.ToDateTime(lee["D_FECHA_CONTRATO"].ToString());
                Entity.clsTipoModalidad.V_DES_TIPO_MODALIDA = lee["V_DES_TIPO_MODALIDA"].ToString();
                Entity.clsGradoMilitar.C_COD_GRADO_MILITAR = lee["C_COD_GRADO_MILITAR"].ToString();
                Entity.clsGradoMilitar.V_ABREV_GRADOS = lee["V_ABREV_GRADOS"].ToString();
                if (lee["D_FEC_NACIMIENTO"].ToString() == "")
                    Entity.clsPeopleDetails.D_FEC_NACIMIENTO = null;
                else
                    Entity.clsPeopleDetails.D_FEC_NACIMIENTO = Convert.ToDateTime(lee["D_FEC_NACIMIENTO"]);
                Entity.clsEstadoCivil.I_COD_ESTADO_CIVIL = Convert.ToInt32(lee["I_COD_ESTADO_CIVIL"].ToString());
                Entity.clsEstadoCivil.V_DES_ESTADO_CIVIL = lee["V_DES_ESTADO_CIVIL"].ToString();
                Entity.clsCargo.I_COD_CARGO = Convert.ToInt32(lee["I_COD_CARGO"].ToString());
                Entity.clsCargo.V_DES_CARGO = lee["V_DES_CARGO"].ToString();
                Entity.clsMainstanciaArea.C_COD_AREA = lee["C_COD_AREA"].ToString();
                Entity.clsMainstanciaArea.C_COD_AREA_SUPERIOR = lee["C_COD_AREA_SUPERIOR"].ToString();
                Entity.clsMaArea.V_ABREV_FUNCIONES = lee["V_ABREV_FUNCIONES"].ToString();
                Entity.clsPermisosUserVM = new usuarioDA().permisosUsuarioXSistema(codTipoSistema, username, "MO");
            }
            return Entity;

        }
    }

}
