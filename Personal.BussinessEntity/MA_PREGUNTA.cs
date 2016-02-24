using System;

namespace BussinessEntity
{
	public class MA_PREGUNTA
	{
		#region Fields

		private int i_COD_TIPO_PREGUNTAS;
		private int i_COD_PREGUNTAS;
		private string v_DES_PREGUNTAS;
		private string c_ACTIVO;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MA_PREGUNTA class.
		/// </summary>
		public MA_PREGUNTA()
		{
		}

		/// <summary>
		/// Initializes a new instance of the MA_PREGUNTA class.
		/// </summary>
		public MA_PREGUNTA(int i_COD_TIPO_PREGUNTAS, int i_COD_PREGUNTAS, string v_DES_PREGUNTAS, string c_ACTIVO)
		{
			this.i_COD_TIPO_PREGUNTAS = i_COD_TIPO_PREGUNTAS;
			this.i_COD_PREGUNTAS = i_COD_PREGUNTAS;
			this.v_DES_PREGUNTAS = v_DES_PREGUNTAS;
			this.c_ACTIVO = c_ACTIVO;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the I_COD_TIPO_PREGUNTAS value.
		/// </summary>
		public virtual int I_COD_TIPO_PREGUNTAS
		{
			get { return i_COD_TIPO_PREGUNTAS; }
			set { i_COD_TIPO_PREGUNTAS = value; }
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
		/// Gets or sets the V_DES_PREGUNTAS value.
		/// </summary>
		public virtual string V_DES_PREGUNTAS
		{
			get { return v_DES_PREGUNTAS; }
			set { v_DES_PREGUNTAS = value; }
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
