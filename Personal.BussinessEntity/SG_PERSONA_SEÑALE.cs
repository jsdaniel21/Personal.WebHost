using System;

namespace BussinessEntity
{
	public class SG_PERSONA_SEÑALE
	{
		#region Fields

		private int i_COD_PERSOÑALES;
		private string c_COD_PERSONA;
		private int i_COD_TIPO_SEÑALES;
		private string v_DES_SEÑAL;
		private DateTime d_FEC_REGISTRO;
		private DateTime d_FEC_BAJA;
		private string c_ACTIVO;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SG_PERSONA_SEÑALE class.
		/// </summary>
		public SG_PERSONA_SEÑALE()
		{
		}

		/// <summary>
		/// Initializes a new instance of the SG_PERSONA_SEÑALE class.
		/// </summary>
		public SG_PERSONA_SEÑALE(int i_COD_PERSOÑALES, string c_COD_PERSONA, int i_COD_TIPO_SEÑALES, string v_DES_SEÑAL, DateTime d_FEC_REGISTRO, DateTime d_FEC_BAJA, string c_ACTIVO)
		{
			this.i_COD_PERSOÑALES = i_COD_PERSOÑALES;
			this.c_COD_PERSONA = c_COD_PERSONA;
			this.i_COD_TIPO_SEÑALES = i_COD_TIPO_SEÑALES;
			this.v_DES_SEÑAL = v_DES_SEÑAL;
			this.d_FEC_REGISTRO = d_FEC_REGISTRO;
			this.d_FEC_BAJA = d_FEC_BAJA;
			this.c_ACTIVO = c_ACTIVO;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the I_COD_PERSOÑALES value.
		/// </summary>
		public virtual int I_COD_PERSOÑALES
		{
			get { return i_COD_PERSOÑALES; }
			set { i_COD_PERSOÑALES = value; }
		}

		/// <summary>
		/// Gets or sets the C_COD_PERSONA value.
		/// </summary>
		public virtual string C_COD_PERSONA
		{
			get { return c_COD_PERSONA; }
			set { c_COD_PERSONA = value; }
		}

		/// <summary>
		/// Gets or sets the I_COD_TIPO_SEÑALES value.
		/// </summary>
		public virtual int I_COD_TIPO_SEÑALES
		{
			get { return i_COD_TIPO_SEÑALES; }
			set { i_COD_TIPO_SEÑALES = value; }
		}

		/// <summary>
		/// Gets or sets the V_DES_SEÑAL value.
		/// </summary>
		public virtual string V_DES_SEÑAL
		{
			get { return v_DES_SEÑAL; }
			set { v_DES_SEÑAL = value; }
		}

		/// <summary>
		/// Gets or sets the D_FEC_REGISTRO value.
		/// </summary>
		public virtual DateTime D_FEC_REGISTRO
		{
			get { return d_FEC_REGISTRO; }
			set { d_FEC_REGISTRO = value; }
		}

		/// <summary>
		/// Gets or sets the D_FEC_BAJA value.
		/// </summary>
		public virtual DateTime D_FEC_BAJA
		{
			get { return d_FEC_BAJA; }
			set { d_FEC_BAJA = value; }
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
