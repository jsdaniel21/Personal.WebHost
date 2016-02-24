using System;

namespace BussinessEntity
{
	public class MA_APERTURAR_AÑO
	{
		#region Fields

		private string c_COD_TIPO_SISTEMA;
		private int i_COD_AÑO;
		private DateTime fEC_APERTURA;
		private string fEC_FINALIZACION;
		private string c_ESTADO_APERTURA;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MA_APERTURAR_AÑO class.
		/// </summary>
		public MA_APERTURAR_AÑO()
		{
		}

		/// <summary>
		/// Initializes a new instance of the MA_APERTURAR_AÑO class.
		/// </summary>
		public MA_APERTURAR_AÑO(string c_COD_TIPO_SISTEMA, int i_COD_AÑO, DateTime fEC_APERTURA, string fEC_FINALIZACION, string c_ESTADO_APERTURA)
		{
			this.c_COD_TIPO_SISTEMA = c_COD_TIPO_SISTEMA;
			this.i_COD_AÑO = i_COD_AÑO;
			this.fEC_APERTURA = fEC_APERTURA;
			this.fEC_FINALIZACION = fEC_FINALIZACION;
			this.c_ESTADO_APERTURA = c_ESTADO_APERTURA;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the C_COD_TIPO_SISTEMA value.
		/// </summary>
		public virtual string C_COD_TIPO_SISTEMA
		{
			get { return c_COD_TIPO_SISTEMA; }
			set { c_COD_TIPO_SISTEMA = value; }
		}

		/// <summary>
		/// Gets or sets the I_COD_AÑO value.
		/// </summary>
		public virtual int I_COD_AÑO
		{
			get { return i_COD_AÑO; }
			set { i_COD_AÑO = value; }
		}

		/// <summary>
		/// Gets or sets the FEC_APERTURA value.
		/// </summary>
		public virtual DateTime FEC_APERTURA
		{
			get { return fEC_APERTURA; }
			set { fEC_APERTURA = value; }
		}

		/// <summary>
		/// Gets or sets the FEC_FINALIZACION value.
		/// </summary>
		public virtual string FEC_FINALIZACION
		{
			get { return fEC_FINALIZACION; }
			set { fEC_FINALIZACION = value; }
		}

		/// <summary>
		/// Gets or sets the C_ESTADO_APERTURA value.
		/// </summary>
		public virtual string C_ESTADO_APERTURA
		{
			get { return c_ESTADO_APERTURA; }
			set { c_ESTADO_APERTURA = value; }
		}

		#endregion
	}
}
