using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntity;

namespace Personal.ViewModels
{

    public class listarPermisosUsuarioVM
    {
        public listarPermisosUsuarioVM()
        {
            this.clsMenuSistema = new MA_MENU_SISTEMA();
            this.clsMenu = new MA_MENU();
            this.clsPrvUserPerfil = new PRV_USUARIO_PERFIL();
        }
        public MA_MENU_SISTEMA clsMenuSistema { get; set; }
        private MA_MENU clsMenu;

        public MA_MENU ClsMenu
        {
            get { return clsMenu; }
            set { clsMenu = new MA_MENU(); }
        }

        public PRV_USUARIO_PERFIL clsPrvUserPerfil { get; set; }
    }


    public class consultarAreaCargoxUsuarioEQ
    {

        public consultarAreaCargoxUsuarioEQ()
        {
            this.clsMaInstancia = new MA_INSTANCIA();
            this.clsMaInstanciaAreas = new MA_INSTANCIA_AREA();
            this.clsMaArea = new MA_AREA();
            this.clsMaCargo = new MA_CARGO();
        }

        public MA_INSTANCIA clsMaInstancia;
        public MA_INSTANCIA_AREA clsMaInstanciaAreas;
        public MA_AREA clsMaArea;
        public MA_CARGO clsMaCargo;
    }



}
