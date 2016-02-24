using System;

namespace BussinessEntity
{
	public class MA_AÑO
	{
		#region Fields

		private int i_COD_AÑO;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MA_AÑO class.
		/// </summary>
		public MA_AÑO()
		{
		}

		/// <summary>
		/// Initializes a new instance of the MA_AÑO class.
		/// </summary>
		public MA_AÑO(int i_COD_AÑO)
		{
			this.i_COD_AÑO = i_COD_AÑO;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the I_COD_AÑO value.
		/// </summary>
		public virtual int I_COD_AÑO
		{
			get { return i_COD_AÑO; }
			set { i_COD_AÑO = value; }
		}

		#endregion
	}
}
