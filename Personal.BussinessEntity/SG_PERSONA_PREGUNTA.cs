using System;

namespace BussinessEntity
{
	public class SG_PERSONA_PREGUNTA
	{
		#region Fields

		private string c_COD_PERSONA;
		private int i_COD_PREGUNTAS;
		private int i_COD_TIPO_PREGUNTAS;
		private int i_COD_PERSONA_PREGUNTAS;
		private string v_DES_RESPUESTA;
		private DateTime d_FECHA_REGISTRO;
		private DateTime d_FECHA_BAJA;
		private string c_ACTIVO;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SG_PERSONA_PREGUNTA class.
		/// </summary>
		public SG_PERSONA_PREGUNTA()
		{
		}

		/// <summary>
		/// Initializes a new instance of the SG_PERSONA_PREGUNTA class.
		/// </summary>
		public SG_PERSONA_PREGUNTA(string c_COD_PERSONA, int i_COD_PREGUNTAS, int i_COD_TIPO_PREGUNTAS, int i_COD_PERSONA_PREGUNTAS, string v_DES_RESPUESTA, DateTime d_FECHA_REGISTRO, DateTime d_FECHA_BAJA, string c_ACTIVO)
		{
			this.c_COD_PERSONA = c_COD_PERSONA;
			this.i_COD_PREGUNTAS = i_COD_PREGUNTAS;
			this.i_COD_TIPO_PREGUNTAS = i_COD_TIPO_PREGUNTAS;
			this.i_COD_PERSONA_PREGUNTAS = i_COD_PERSONA_PREGUNTAS;
			this.v_DES_RESPUESTA = v_DES_RESPUESTA;
			this.d_FECHA_REGISTRO = d_FECHA_REGISTRO;
			this.d_FECHA_BAJA = d_FECHA_BAJA;
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
		/// Gets or sets the I_COD_PREGUNTAS value.
		/// </summary>
		public virtual int I_COD_PREGUNTAS
		{
			get { return i_COD_PREGUNTAS; }
			set { i_COD_PREGUNTAS = value; }
		}

		/// <summary>
		/// Gets or sets the I_COD_TIPO_PREGUNTAS value.
		/// </summary>
		public virtual int I_COD_TIPO_PREGUNTAS
		{
			get { return i_COD_TIPO_PREGUNTAS; }
			set { i_COD_TIPO_PREGUNTAS = value; }
		}

		/// <summary>
		/// Gets or sets the I_COD_PERSONA_PREGUNTAS value.
		/// </summary>
		public virtual int I_COD_PERSONA_PREGUNTAS
		{
			get { return i_COD_PERSONA_PREGUNTAS; }
			set { i_COD_PERSONA_PREGUNTAS = value; }
		}

		/// <summary>
		/// Gets or sets the V_DES_RESPUESTA value.
		/// </summary>
		public virtual string V_DES_RESPUESTA
		{
			get { return v_DES_RESPUESTA; }
			set { v_DES_RESPUESTA = value; }
		}

		/// <summary>
		/// Gets or sets the D_FECHA_REGISTRO value.
		/// </summary>
		public virtual DateTime D_FECHA_REGISTRO
		{
			get { return d_FECHA_REGISTRO; }
			set { d_FECHA_REGISTRO = value; }
		}

		/// <summary>
		/// Gets or sets the D_FECHA_BAJA value.
		/// </summary>
		public virtual DateTime D_FECHA_BAJA
		{
			get { return d_FECHA_BAJA; }
			set { d_FECHA_BAJA = value; }
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
