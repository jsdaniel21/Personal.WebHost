using System;

namespace BussinessEntity
{
	public class SG_PERSONA_IMAGENE
	{
		#region Fields

		private string c_COD_PERSONA;
		private int i_COD_TIPO_IMAGEN;
		private int i_COD_PERSONA_IMAGENES;
		private string v_DES_IMAGEN;
		private DateTime d_FEC_REGISTRO;
		private DateTime d_FEC_BAJA;
		private string c_ACTIVO;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SG_PERSONA_IMAGENE class.
		/// </summary>
		public SG_PERSONA_IMAGENE()
		{
		}

		/// <summary>
		/// Initializes a new instance of the SG_PERSONA_IMAGENE class.
		/// </summary>
		public SG_PERSONA_IMAGENE(string c_COD_PERSONA, int i_COD_TIPO_IMAGEN, int i_COD_PERSONA_IMAGENES, string v_DES_IMAGEN, DateTime d_FEC_REGISTRO, DateTime d_FEC_BAJA, string c_ACTIVO)
		{
			this.c_COD_PERSONA = c_COD_PERSONA;
			this.i_COD_TIPO_IMAGEN = i_COD_TIPO_IMAGEN;
			this.i_COD_PERSONA_IMAGENES = i_COD_PERSONA_IMAGENES;
			this.v_DES_IMAGEN = v_DES_IMAGEN;
			this.d_FEC_REGISTRO = d_FEC_REGISTRO;
			this.d_FEC_BAJA = d_FEC_BAJA;
			this.c_ACTIVO = c_ACTIVO;
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
		/// Gets or sets the I_COD_TIPO_IMAGEN value.
		/// </summary>
		public virtual int I_COD_TIPO_IMAGEN
		{
			get { return i_COD_TIPO_IMAGEN; }
			set { i_COD_TIPO_IMAGEN = value; }
		}

		/// <summary>
		/// Gets or sets the I_COD_PERSONA_IMAGENES value.
		/// </summary>
		public virtual int I_COD_PERSONA_IMAGENES
		{
			get { return i_COD_PERSONA_IMAGENES; }
			set { i_COD_PERSONA_IMAGENES = value; }
		}

		/// <summary>
		/// Gets or sets the V_DES_IMAGEN value.
		/// </summary>
		public virtual string V_DES_IMAGEN
		{
			get { return v_DES_IMAGEN; }
			set { v_DES_IMAGEN = value; }
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
