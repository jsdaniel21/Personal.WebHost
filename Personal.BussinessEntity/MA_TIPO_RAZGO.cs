using System;

namespace BussinessEntity
{
	public class MA_TIPO_RAZGO
	{
		#region Fields

		private int i_COD_RAZGOS;
		private string v_DES_RAZGOS;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MA_TIPO_RAZGO class.
		/// </summary>
		public MA_TIPO_RAZGO()
		{
		}

		/// <summary>
		/// Initializes a new instance of the MA_TIPO_RAZGO class.
		/// </summary>
		public MA_TIPO_RAZGO(int i_COD_RAZGOS, string v_DES_RAZGOS)
		{
			this.i_COD_RAZGOS = i_COD_RAZGOS;
			this.v_DES_RAZGOS = v_DES_RAZGOS;
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
		/// Gets or sets the V_DES_RAZGOS value.
		/// </summary>
		public virtual string V_DES_RAZGOS
		{
			get { return v_DES_RAZGOS; }
			set { v_DES_RAZGOS = value; }
		}

		#endregion
	}
}
