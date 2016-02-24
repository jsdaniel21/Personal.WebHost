using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.Interfaces;
using BussinessLogic.DataAccess;
using Personal.ViewModels;
using BussinessEntity;

namespace BussinessLogic.BussinessLogic
{
    public class usuarioBL : IPrvUsuario
    {
        public PRV_USUARIO usuarioXcodPersona(string codPersona)
        {
            return new usuarioDA().usuarioXcodPersona(codPersona);
        }
        public int verifyUser(string username, string password)
        {
            return new usuarioDA().verifyUser(username, password);
        }
        public List<listarPermisosUsuarioVM> permisosUsuarioXSistema(string codTipoSistema, string nomUsuario, string tipoMenu)
        {
            return new usuarioDA().permisosUsuarioXSistema(codTipoSistema, nomUsuario, tipoMenu);
        }

        public consultarAreaCargoxUsuarioEQ consultarAreaCargoXusuarioEQ(string nomUsuario)
        {
            return new usuarioDA().consultarAreaCargoXusuarioEQ(nomUsuario);
        }

        public List<listarPermisosUsuarioVM> listarPermisoXmenuParent(string codMenu, string codTipoSistema, string tipoOpcion, string nomUsuario)
        {

            return new usuarioDA().listarPermisoXmenuParent(codMenu, codTipoSistema, tipoOpcion, nomUsuario);
        }
    }
}
