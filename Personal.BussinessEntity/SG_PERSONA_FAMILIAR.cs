using System;

namespace BussinessEntity
{
	public class SG_PERSONA_FAMILIAR
	{
		#region Fields

		private int i_COD_OCUPACION;
		private int i_COD_TIPO_FAMILIAR;
		private int i_COD_PERSONA_FAMILIAR;
		private string v_NOM_FAMILIAR;
		private string v_APELL_PATERNO_FAMILIAR;
		private string v_APELL_MATERNO_FAMILIAR;
		private int i_EDAD;
		private string c_COD_DISTRITO;
		private int i_COD_PAIS;
		private string c_COD_PROVINCIA;
		private string c_COD_DEPARTAMENTO;
		private string v_DES_DIRECCION;
		private DateTime d_FEC_REGISTRO;
		private DateTime d_FEC_BAJA;
		private string c_ACTIVO;
		private string c_COD_PERSONA;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SG_PERSONA_FAMILIAR class.
		/// </summary>
		public SG_PERSONA_FAMILIAR()
		{
		}

		/// <summary>
		/// Initializes a new instance of the SG_PERSONA_FAMILIAR class.
		/// </summary>
		public SG_PERSONA_FAMILIAR(int i_COD_OCUPACION, int i_COD_TIPO_FAMILIAR, int i_COD_PERSONA_FAMILIAR, string v_NOM_FAMILIAR, string v_APELL_PATERNO_FAMILIAR, string v_APELL_MATERNO_FAMILIAR, int i_EDAD, string c_COD_DISTRITO, int i_COD_PAIS, string c_COD_PROVINCIA, string c_COD_DEPARTAMENTO, string v_DES_DIRECCION, DateTime d_FEC_REGISTRO, DateTime d_FEC_BAJA, string c_ACTIVO, string c_COD_PERSONA)
		{
			this.i_COD_OCUPACION = i_COD_OCUPACION;
			this.i_COD_TIPO_FAMILIAR = i_COD_TIPO_FAMILIAR;
			this.i_COD_PERSONA_FAMILIAR = i_COD_PERSONA_FAMILIAR;
			this.v_NOM_FAMILIAR = v_NOM_FAMILIAR;
			this.v_APELL_PATERNO_FAMILIAR = v_APELL_PATERNO_FAMILIAR;
			this.v_APELL_MATERNO_FAMILIAR = v_APELL_MATERNO_FAMILIAR;
			this.i_EDAD = i_EDAD;
			this.c_COD_DISTRITO = c_COD_DISTRITO;
			this.i_COD_PAIS = i_COD_PAIS;
			this.c_COD_PROVINCIA = c_COD_PROVINCIA;
			this.c_COD_DEPARTAMENTO = c_COD_DEPARTAMENTO;
			this.v_DES_DIRECCION = v_DES_DIRECCION;
			this.d_FEC_REGISTRO = d_FEC_REGISTRO;
			this.d_FEC_BAJA = d_FEC_BAJA;
			this.c_ACTIVO = c_ACTIVO;
			this.c_COD_PERSONA = c_COD_PERSONA;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the I_COD_OCUPACION value.
		/// </summary>
		public virtual int I_COD_OCUPACION
		{
			get { return i_COD_OCUPACION; }
			set { i_COD_OCUPACION = value; }
		}

		/// <summary>
		/// Gets or sets the I_COD_TIPO_FAMILIAR value.
		/// </summary>
		public virtual int I_COD_TIPO_FAMILIAR
		{
			get { return i_COD_TIPO_FAMILIAR; }
			set { i_COD_TIPO_FAMILIAR = value; }
		}

		/// <summary>
		/// Gets or sets the I_COD_PERSONA_FAMILIAR value.
		/// </summary>
		public virtual int I_COD_PERSONA_FAMILIAR
		{
			get { return i_COD_PERSONA_FAMILIAR; }
			set { i_COD_PERSONA_FAMILIAR = value; }
		}

		/// <summary>
		/// Gets or sets the V_NOM_FAMILIAR value.
		/// </summary>
		public virtual string V_NOM_FAMILIAR
		{
			get { return v_NOM_FAMILIAR; }
			set { v_NOM_FAMILIAR = value; }
		}

		/// <summary>
		/// Gets or sets the V_APELL_PATERNO_FAMILIAR value.
		/// </summary>
		public virtual string V_APELL_PATERNO_FAMILIAR
		{
			get { return v_APELL_PATERNO_FAMILIAR; }
			set { v_APELL_PATERNO_FAMILIAR = value; }
		}

		/// <summary>
		/// Gets or sets the V_APELL_MATERNO_FAMILIAR value.
		/// </summary>
		public virtual string V_APELL_MATERNO_FAMILIAR
		{
			get { return v_APELL_MATERNO_FAMILIAR; }
			set { v_APELL_MATERNO_FAMILIAR = value; }
		}

		/// <summary>
		/// Gets or sets the I_EDAD value.
		/// </summary>
		public virtual int I_EDAD
		{
			get { return i_EDAD; }
			set { i_EDAD = value; }
		}

		/// <summary>
		/// Gets or sets the C_COD_DISTRITO value.
		/// </summary>
		public virtual string C_COD_DISTRITO
		{
			get { return c_COD_DISTRITO; }
			set { c_COD_DISTRITO = value; }
		}

		/// <summary>
		/// Gets or sets the I_COD_PAIS value.
		/// </summary>
		public virtual int I_COD_PAIS
		{
			get { return i_COD_PAIS; }
			set { i_COD_PAIS = value; }
		}

		/// <summary>
		/// Gets or sets the C_COD_PROVINCIA value.
		/// </summary>
		public virtual string C_COD_PROVINCIA
		{
			get { return c_COD_PROVINCIA; }
			set { c_COD_PROVINCIA = value; }
		}

		/// <summary>
		/// Gets or sets the C_COD_DEPARTAMENTO value.
		/// </summary>
		public virtual string C_COD_DEPARTAMENTO
		{
			get { return c_COD_DEPARTAMENTO; }
			set { c_COD_DEPARTAMENTO = value; }
		}

		/// <summary>
		/// Gets or sets the V_DES_DIRECCION value.
		/// </summary>
		public virtual string V_DES_DIRECCION
		{
			get { return v_DES_DIRECCION; }
			set { v_DES_DIRECCION = value; }
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
		/// Gets or sets the C_COD_PERSONA value.
		/// </summary>
		public virtual string C_COD_PERSONA
		{
			get { return c_COD_PERSONA; }
			set { c_COD_PERSONA = value; }
		}

		#endregion
	}
}
