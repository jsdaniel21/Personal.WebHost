using System;

namespace BussinessEntity
{
	public class SG_PERSONA_RAZGO
	{
		#region Fields

		private string c_COD_PERSONA;
		private int i_COD_DETALLE_RAZGOS;
		private int i_COD_RAZGOS;
		private int i_COD_PERSONA_RAZGOS;
		private string v_DES_COLOR;
		private string c_ACTIVO;
		private DateTime d_FEC_REGISTRO;
		private DateTime d_FEC_BAJA;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SG_PERSONA_RAZGO class.
		/// </summary>
		public SG_PERSONA_RAZGO()
		{
		}

		/// <summary>
		/// Initializes a new instance of the SG_PERSONA_RAZGO class.
		/// </summary>
		public SG_PERSONA_RAZGO(string c_COD_PERSONA, int i_COD_DETALLE_RAZGOS, int i_COD_RAZGOS, int i_COD_PERSONA_RAZGOS, string v_DES_COLOR, string c_ACTIVO, DateTime d_FEC_REGISTRO, DateTime d_FEC_BAJA)
		{
			this.c_COD_PERSONA = c_COD_PERSONA;
			this.i_COD_DETALLE_RAZGOS = i_COD_DETALLE_RAZGOS;
			this.i_COD_RAZGOS = i_COD_RAZGOS;
			this.i_COD_PERSONA_RAZGOS = i_COD_PERSONA_RAZGOS;
			this.v_DES_COLOR = v_DES_COLOR;
			this.c_ACTIVO = c_ACTIVO;
			this.d_FEC_REGISTRO = d_FEC_REGISTRO;
			this.d_FEC_BAJA = d_FEC_BAJA;
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
		/// Gets or sets the I_COD_DETALLE_RAZGOS value.
		/// </summary>
		public virtual int I_COD_DETALLE_RAZGOS
		{
			get { return i_COD_DETALLE_RAZGOS; }
			set { i_COD_DETALLE_RAZGOS = value; }
		}

		/// <summary>
		/// Gets or sets the I_COD_RAZGOS value.
		/// </summary>
		public virtual int I_COD_RAZGOS
		{
			get { return i_COD_RAZGOS; }
			set { i_COD_RAZGOS = value; }
		}

		/// <summary>
		/// Gets or sets the I_COD_PERSONA_RAZGOS value.
		/// </summary>
		public virtual int I_COD_PERSONA_RAZGOS
		{
			get { return i_COD_PERSONA_RAZGOS; }
			set { i_COD_PERSONA_RAZGOS = value; }
		}

		/// <summary>
		/// Gets or sets the V_DES_COLOR value.
		/// </summary>
		public virtual string V_DES_COLOR
		{
			get { return v_DES_COLOR; }
			set { v_DES_COLOR = value; }
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

		#endregion
	}
}
