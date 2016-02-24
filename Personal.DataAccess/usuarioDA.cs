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
    public class usuarioDA
    {

        public PRV_USUARIO usuarioXcodPersona(string codPersona)
        {
            PRV_USUARIO ent = new PRV_USUARIO();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("PRV_USUARIO_X_COD_PERSONA");
            db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, codPersona);
            using (IDataReader read = db.ExecuteReader(cmd))
            {
                read.Read();
                ent.I_COD_USUARIO = Convert.ToInt32(read["I_COD_USUARIO"].ToString());
                ent.V_NOM_USUARIO = read["V_NOM_USUARIO"].ToString();
            }
            return ent;
        }

        public int verifyUser(string username, string password)
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
                        DbCommand cmd = db.GetStoredProcCommand("SP_PRV_USUARIO_ACCESS", username, password);
                        resultado = Convert.ToInt32(db.ExecuteScalar(cmd, trans));
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

        public List<listarPermisosUsuarioVM> listarPermisoXmenuParent(string codMenu, string codTipoSistema, string tipoOpcion, string nomUsuario)
        {
            List<listarPermisosUsuarioVM> lista = new List<listarPermisosUsuarioVM>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbCommand cmd = db.GetStoredProcCommand("PRV_SP_VERIFICAR_PERMISO_X_MENU_PARENT");
            db.AddInParameter(cmd, "C_COD_MENU", DbType.String, codMenu);
            db.AddInParameter(cmd, "C_COD_TIPO_SISTEMA", DbType.String, codTipoSistema);
            db.AddInParameter(cmd, "C_TIPO_OPCION", DbType.String, tipoOpcion);
            db.AddInParameter(cmd, "V_NOM_USUARIO", DbType.String, nomUsuario);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    listarPermisosUsuarioVM entity = new listarPermisosUsuarioVM();
                    entity.ClsMenu.C_COD_MENU = lee["C_COD_MENU"].ToString();
                    entity.ClsMenu.V_DES_MENU = lee["V_DES_MENU"].ToString();
                    entity.clsMenuSistema.C_COD_MENU_SUPERIOR = lee["C_COD_MENU_SUPERIOR"].ToString();
                    entity.clsMenuSistema.C_DES_DIRECTORIO_IMG = lee["C_DES_DIRECTORIO_IMG"].ToString();
                    entity.clsMenuSistema.C_NAME_FORM = lee["C_NAME_FORM"].ToString();
                    entity.clsMenuSistema.V_DES_OPCION = lee["V_DES_OPCION"].ToString();
                    lista.Add(entity);
                }
            }

            return lista;
        }
        public List<listarPermisosUsuarioVM> permisosUsuarioXSistema(string codTipoSistema, string nomUsuario, string tipoMenu)
        {
            List<listarPermisosUsuarioVM> lista = new List<listarPermisosUsuarioVM>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbCommand cmd = db.GetStoredProcCommand("[PRV_SP_LISTAR_PERMISOS_X_USUARIO_X_SISTEMA]", codTipoSistema, nomUsuario, tipoMenu);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    listarPermisosUsuarioVM Elista = new listarPermisosUsuarioVM();
                    Elista.ClsMenu.V_DES_MENU = lee["V_DES_MENU"].ToString();
                    Elista.clsPrvUserPerfil.I_COD_USUARIO = Convert.ToInt32(lee["I_COD_USUARIO"].ToString());
                    Elista.clsMenuSistema.I_NIVEL_MENU_APLICACION = Convert.ToInt32(lee["I_NIVEL_MENU_APLICACION"].ToString());
                    Elista.clsMenuSistema.C_COD_MENU_SUPERIOR = lee["C_COD_MENU_SUPERIOR"].ToString();
                    Elista.clsMenuSistema.C_COD_MENU = lee["C_COD_MENU"].ToString();
                    Elista.clsMenuSistema.C_NAME_FORM = lee["C_NAME_FORM"].ToString();
                    Elista.clsMenuSistema.C_DES_DIRECTORIO_IMG = lee["C_DES_DIRECTORIO_IMG"].ToString();
                    lista.Add(Elista);
                }
            }
            return lista;
        }

        public consultarAreaCargoxUsuarioEQ consultarAreaCargoXusuarioEQ(string nomUsuario)
        {
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbCommand cmd = db.GetStoredProcCommand("[PRV_SP_CONSULTAR_AREA_CARGO_X_PERSONA]", nomUsuario);
            consultarAreaCargoxUsuarioEQ Elista = new consultarAreaCargoxUsuarioEQ();
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                lee.Read();
                Elista.clsMaInstancia.I_COD_INSTANCIA = lee["I_COD_INSTANCIA"].ToString();
                Elista.clsMaInstancia.V_DES_INSTANCIA = lee["V_DES_INSTANCIA"].ToString();
                //Elista.clsMaInstancia.I_COD_INSTANCIA_SUPERIOR = Convert.ToInt32(lee["I_COD_INSTANCIA_SUPERIOR"].ToString());
                Elista.clsMaInstanciaAreas.C_COD_AREA = lee["C_COD_AREA"].ToString();
                Elista.clsMaArea.V_DES_FUNCIONES = lee["V_DES_FUNCIONES"].ToString();
                Elista.clsMaInstanciaAreas.C_COD_AREA_SUPERIOR = lee["C_COD_AREA_SUPERIOR"].ToString();
                Elista.clsMaCargo.V_DES_CARGO = lee["V_DES_CARGO"].ToString();
                Elista.clsMaCargo.I_COD_CARGO = Convert.ToInt32(lee["I_COD_CARGO"].ToString());
            }
            return Elista;
        }


    }



}
