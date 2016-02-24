using System;

namespace BussinessEntity
{
	public class SG_PERSONA_ARMA
	{
		#region Fields

		private string c_COD_PERSONA;
		private int i_COD_MARCA_ARMA;
		private int i_COD_TIPO_ARMA;
		private int i_COD_PERSONA_ARMAS;
		private string v_NUM_ARMA;
		private string v_LICENCIA;
		private DateTime d_FEC_REGISTRO;
		private DateTime d_FEC_BAJA;
		private string c_ACTIVO;
		private int i_CALIBRE;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SG_PERSONA_ARMA class.
		/// </summary>
		public SG_PERSONA_ARMA()
		{
		}

		/// <summary>
		/// Initializes a new instance of the SG_PERSONA_ARMA class.
		/// </summary>
		public SG_PERSONA_ARMA(string c_COD_PERSONA, int i_COD_MARCA_ARMA, int i_COD_TIPO_ARMA, int i_COD_PERSONA_ARMAS, string v_NUM_ARMA, string v_LICENCIA, DateTime d_FEC_REGISTRO, DateTime d_FEC_BAJA, string c_ACTIVO, int i_CALIBRE)
		{
			this.c_COD_PERSONA = c_COD_PERSONA;
			this.i_COD_MARCA_ARMA = i_COD_MARCA_ARMA;
			this.i_COD_TIPO_ARMA = i_COD_TIPO_ARMA;
			this.i_COD_PERSONA_ARMAS = i_COD_PERSONA_ARMAS;
			this.v_NUM_ARMA = v_NUM_ARMA;
			this.v_LICENCIA = v_LICENCIA;
			this.d_FEC_REGISTRO = d_FEC_REGISTRO;
			this.d_FEC_BAJA = d_FEC_BAJA;
			this.c_ACTIVO = c_ACTIVO;
			this.i_CALIBRE = i_CALIBRE;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the C_COD_PERSONA value.
		/// </summary>
		public virtual string C_COD_PERSONA
		{
			get { return c_COD_PERSONA; }
			set { c_COD_PERSONA = value; }
		}

		/// <summary>
		/// Gets or sets the I_COD_MARCA_ARMA value.
		/// </summary>
		public virtual int I_COD_MARCA_ARMA
		{
			get { return i_COD_MARCA_ARMA; }
			set { i_COD_MARCA_ARMA = value; }
		}

		/// <summary>
		/// Gets or sets the I_COD_TIPO_ARMA value.
		/// </summary>
		public virtual int I_COD_TIPO_ARMA
		{
			get { return i_COD_TIPO_ARMA; }
			set { i_COD_TIPO_ARMA = value; }
		}

		/// <summary>
		/// Gets or sets the I_COD_PERSONA_ARMAS value.
		/// </summary>
		public virtual int I_COD_PERSONA_ARMAS
		{
			get { return i_COD_PERSONA_ARMAS; }
			set { i_COD_PERSONA_ARMAS = value; }
		}

		/// <summary>
		/// Gets or sets the V_NUM_ARMA value.
		/// </summary>
		public virtual string V_NUM_ARMA
		{
			get { return v_NUM_ARMA; }
			set { v_NUM_ARMA = value; }
		}

		/// <summary>
		/// Gets or sets the V_LICENCIA value.
		/// </summary>
		public virtual string V_LICENCIA
		{
			get { return v_LICENCIA; }
			set { v_LICENCIA = value; }
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

		/// <summary>
		/// Gets or sets the I_CALIBRE value.
		/// </summary>
		public virtual int I_CALIBRE
		{
			get { return i_CALIBRE; }
			set { i_CALIBRE = value; }
		}

		#endregion
	}
}
