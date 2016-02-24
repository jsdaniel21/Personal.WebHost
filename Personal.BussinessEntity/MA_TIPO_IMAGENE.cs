using System;

namespace BussinessEntity
{
	public class MA_TIPO_IMAGENE
	{
		#region Fields

		private int i_COD_TIPO_IMAGEN;
		private string v_DES_TIPO_IMAGEN;
		private string c_ACTIVO;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MA_TIPO_IMAGENE class.
		/// </summary>
		public MA_TIPO_IMAGENE()
		{
		}

		/// <summary>
		/// Initializes a new instance of the MA_TIPO_IMAGENE class.
		/// </summary>
		public MA_TIPO_IMAGENE(int i_COD_TIPO_IMAGEN, string v_DES_TIPO_IMAGEN, string c_ACTIVO)
		{
			this.i_COD_TIPO_IMAGEN = i_COD_TIPO_IMAGEN;
			this.v_DES_TIPO_IMAGEN = v_DES_TIPO_IMAGEN;
			this.c_ACTIVO = c_ACTIVO;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the I_COD_TIPO_IMAGEN value.
		/// </summary>
		public virtual int I_COD_TIPO_IMAGEN
		{
			get { return i_COD_TIPO_IMAGEN; }
			set { i_COD_TIPO_IMAGEN = value; }
		}

		/// <summary>
		/// Gets or sets the V_DES_TIPO_IMAGEN value.
		/// </summary>
		public virtual string V_DES_TIPO_IMAGEN
		{
			get { return v_DES_TIPO_IMAGEN; }
			set { v_DES_TIPO_IMAGEN = value; }
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
