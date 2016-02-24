using System;

namespace BussinessEntity
{
	public class MA_PROVINCIA
	{
		#region Fields

		private int i_COD_PAIS;
		private string c_COD_DEPARTAMENTO;
		private string c_COD_PROVINCIA;
		private string v_DES_PROVINCIA;
		private string c_ACTIVO;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MA_PROVINCIA class.
		/// </summary>
		public MA_PROVINCIA()
		{
		}

		/// <summary>
		/// Initializes a new instance of the MA_PROVINCIA class.
		/// </summary>
		public MA_PROVINCIA(int i_COD_PAIS, string c_COD_DEPARTAMENTO, string c_COD_PROVINCIA, string v_DES_PROVINCIA, string c_ACTIVO)
		{
			this.i_COD_PAIS = i_COD_PAIS;
			this.c_COD_DEPARTAMENTO = c_COD_DEPARTAMENTO;
			this.c_COD_PROVINCIA = c_COD_PROVINCIA;
			this.v_DES_PROVINCIA = v_DES_PROVINCIA;
			this.c_ACTIVO = c_ACTIVO;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the I_COD_PAIS value.
		/// </summary>
		public virtual int I_COD_PAIS
		{
			get { return i_COD_PAIS; }
			set { i_COD_PAIS = value; }
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
		/// Gets or sets the C_COD_PROVINCIA value.
		/// </summary>
		public virtual string C_COD_PROVINCIA
		{
			get { return c_COD_PROVINCIA; }
			set { c_COD_PROVINCIA = value; }
		}

		/// <summary>
		/// Gets or sets the V_DES_PROVINCIA value.
		/// </summary>
		public virtual string V_DES_PROVINCIA
		{
			get { return v_DES_PROVINCIA; }
			set { v_DES_PROVINCIA = value; }
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
