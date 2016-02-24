using System;

namespace BussinessEntity
{
	public class MA_INSTANCIA_AREA
	{
		#region Fields

		private string i_COD_INSTANCIA;
		private int i_COD_INSTANCIA_SUPERIOR;
		private string c_COD_AREA;
		private string c_COD_AREA_SUPERIOR;
		private int i_NIVEL_INSTANCIA_AREA;
		private string c_ACTIVO;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MA_INSTANCIA_AREA class.
		/// </summary>
		public MA_INSTANCIA_AREA()
		{
		}

		/// <summary>
		/// Initializes a new instance of the MA_INSTANCIA_AREA class.
		/// </summary>
		public MA_INSTANCIA_AREA(string i_COD_INSTANCIA, int i_COD_INSTANCIA_SUPERIOR, string c_COD_AREA, string c_COD_AREA_SUPERIOR, int i_NIVEL_INSTANCIA_AREA, string c_ACTIVO)
		{
			this.i_COD_INSTANCIA = i_COD_INSTANCIA;
			this.i_COD_INSTANCIA_SUPERIOR = i_COD_INSTANCIA_SUPERIOR;
			this.c_COD_AREA = c_COD_AREA;
			this.c_COD_AREA_SUPERIOR = c_COD_AREA_SUPERIOR;
			this.i_NIVEL_INSTANCIA_AREA = i_NIVEL_INSTANCIA_AREA;
			this.c_ACTIVO = c_ACTIVO;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the I_COD_INSTANCIA value.
		/// </summary>
		public virtual string I_COD_INSTANCIA
		{
			get { return i_COD_INSTANCIA; }
			set { i_COD_INSTANCIA = value; }
		}

		/// <summary>
		/// Gets or sets the I_COD_INSTANCIA_SUPERIOR value.
		/// </summary>
		public virtual int I_COD_INSTANCIA_SUPERIOR
		{
			get { return i_COD_INSTANCIA_SUPERIOR; }
			set { i_COD_INSTANCIA_SUPERIOR = value; }
		}

		/// <summary>
		/// Gets or sets the C_COD_AREA value.
		/// </summary>
		public virtual string C_COD_AREA
		{
			get { return c_COD_AREA; }
			set { c_COD_AREA = value; }
		}

		/// <summary>
		/// Gets or sets the C_COD_AREA_SUPERIOR value.
		/// </summary>
		public virtual string C_COD_AREA_SUPERIOR
		{
			get { return c_COD_AREA_SUPERIOR; }
			set { c_COD_AREA_SUPERIOR = value; }
		}

		/// <summary>
		/// Gets or sets the I_NIVEL_INSTANCIA_AREA value.
		/// </summary>
		public virtual int I_NIVEL_INSTANCIA_AREA
		{
			get { return i_NIVEL_INSTANCIA_AREA; }
			set { i_NIVEL_INSTANCIA_AREA = value; }
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
