using System;

namespace BussinessEntity
{
	public class MA_PERFIL_MENU_APLICACION
	{
		#region Fields

		private int i_COD_TIPO_PERFIL;
		private string c_COD_MENU_SISTEMA;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MA_PERFIL_MENU_APLICACION class.
		/// </summary>
		public MA_PERFIL_MENU_APLICACION()
		{
		}

		/// <summary>
		/// Initializes a new instance of the MA_PERFIL_MENU_APLICACION class.
		/// </summary>
		public MA_PERFIL_MENU_APLICACION(int i_COD_TIPO_PERFIL, string c_COD_MENU_SISTEMA)
		{
			this.i_COD_TIPO_PERFIL = i_COD_TIPO_PERFIL;
			this.c_COD_MENU_SISTEMA = c_COD_MENU_SISTEMA;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the I_COD_TIPO_PERFIL value.
		/// </summary>
		public virtual int I_COD_TIPO_PERFIL
		{
			get { return i_COD_TIPO_PERFIL; }
			set { i_COD_TIPO_PERFIL = value; }
		}

		/// <summary>
		/// Gets or sets the C_COD_MENU_SISTEMA value.
		/// </summary>
		public virtual string C_COD_MENU_SISTEMA
		{
			get { return c_COD_MENU_SISTEMA; }
			set { c_COD_MENU_SISTEMA = value; }
		}

		#endregion
	}
}
