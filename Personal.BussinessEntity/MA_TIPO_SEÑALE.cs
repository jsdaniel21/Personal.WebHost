using System;

namespace BussinessEntity
{
	public class MA_TIPO_SEÑALE
	{
		#region Fields

		private int i_COD_TIPO_SEÑALES;
		private string v_DES_TIPO_SEÑALES;
		private string c_ACTIVO;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MA_TIPO_SEÑALE class.
		/// </summary>
		public MA_TIPO_SEÑALE()
		{
		}

		/// <summary>
		/// Initializes a new instance of the MA_TIPO_SEÑALE class.
		/// </summary>
		public MA_TIPO_SEÑALE(int i_COD_TIPO_SEÑALES, string v_DES_TIPO_SEÑALES, string c_ACTIVO)
		{
			this.i_COD_TIPO_SEÑALES = i_COD_TIPO_SEÑALES;
			this.v_DES_TIPO_SEÑALES = v_DES_TIPO_SEÑALES;
			this.c_ACTIVO = c_ACTIVO;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the I_COD_TIPO_SEÑALES value.
		/// </summary>
		public virtual int I_COD_TIPO_SEÑALES
		{
			get { return i_COD_TIPO_SEÑALES; }
			set { i_COD_TIPO_SEÑALES = value; }
		}

		/// <summary>
		/// Gets or sets the V_DES_TIPO_SEÑALES value.
		/// </summary>
		public virtual string V_DES_TIPO_SEÑALES
		{
			get { return v_DES_TIPO_SEÑALES; }
			set { v_DES_TIPO_SEÑALES = value; }
		}

		/// <summary>
		/// Gets or sets the C_ACTIVO value.
		/// </summary>
		public virtual string C_ACTIVO
		{
			get { return c_ACTIVO; }
			set { c_ACTIVO = value; }
		}

		#endregion
	}
}
