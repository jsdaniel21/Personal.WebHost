using System;

namespace BussinessEntity
{
	public class MA_DETALLE_RAZGO
	{
		#region Fields

		private int i_COD_RAZGOS;
		private int i_COD_DETALLE_RAZGOS;
		private string v_DES_DETALLE_RAZGOS;
		private string c_ACTIVO;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MA_DETALLE_RAZGO class.
		/// </summary>
		public MA_DETALLE_RAZGO()
		{
		}

		/// <summary>
		/// Initializes a new instance of the MA_DETALLE_RAZGO class.
		/// </summary>
		public MA_DETALLE_RAZGO(int i_COD_RAZGOS, int i_COD_DETALLE_RAZGOS, string v_DES_DETALLE_RAZGOS, string c_ACTIVO)
		{
			this.i_COD_RAZGOS = i_COD_RAZGOS;
			this.i_COD_DETALLE_RAZGOS = i_COD_DETALLE_RAZGOS;
			this.v_DES_DETALLE_RAZGOS = v_DES_DETALLE_RAZGOS;
			this.c_ACTIVO = c_ACTIVO;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the I_COD_RAZGOS value.
		/// </summary>
		public virtual int I_COD_RAZGOS
		{
			get { return i_COD_RAZGOS; }
			set { i_COD_RAZGOS = value; }
		}

		/// <summary>
		/// Gets or sets the I_COD_DETALLE_RAZGOS value.
		/// </summary>
		public virtual int I_COD_DETALLE_RAZGOS
		{
			get { return i_COD_DETALLE_RAZGOS; }
			set { i_COD_DETALLE_RAZGOS = value; }
		}

		/// <summary>
		/// Gets or sets the V_DES_DETALLE_RAZGOS value.
		/// </summary>
		public virtual string V_DES_DETALLE_RAZGOS
		{
			get { return v_DES_DETALLE_RAZGOS; }
			set { v_DES_DETALLE_RAZGOS = value; }
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
