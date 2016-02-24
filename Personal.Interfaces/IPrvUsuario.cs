using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal.ViewModels;
using BussinessEntity;

namespace BussinessLogic.Interfaces
{
    public interface IPrvUsuario
    {
        int verifyUser(string username, string password);
        List<listarPermisosUsuarioVM> permisosUsuarioXSistema(string codTipoSistema, string nomUsuario, string tipoMenu);
        consultarAreaCargoxUsuarioEQ consultarAreaCargoXusuarioEQ(string nomUsuario);
        List<listarPermisosUsuarioVM> listarPermisoXmenuParent(string codMenu, string codTipoSistema, string tipoOpcion, string nomUsuario);
        PRV_USUARIO usuarioXcodPersona(string codPersona);
    }

}
