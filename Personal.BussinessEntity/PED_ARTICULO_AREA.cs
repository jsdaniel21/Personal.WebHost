using System;

namespace BussinessEntity
{
	public class PED_ARTICULO_AREA
	{
		#region Fields

		private int i_COD_TIPO_ARTICULO;
		private string i_COD_INSTANCIA;
		private int i_COD_INSTANCIA_SUPERIOR;
		private string c_COD_AREA;
		private string c_COD_AREA_SUPERIOR;
		private int i_COD_PED_ARTICULO_AREA;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PED_ARTICULO_AREA class.
		/// </summary>
		public PED_ARTICULO_AREA()
		{
		}

		/// <summary>
		/// Initializes a new instance of the PED_ARTICULO_AREA class.
		/// </summary>
		public PED_ARTICULO_AREA(int i_COD_TIPO_ARTICULO, string i_COD_INSTANCIA, int i_COD_INSTANCIA_SUPERIOR, string c_COD_AREA, string c_COD_AREA_SUPERIOR, int i_COD_PED_ARTICULO_AREA)
		{
			this.i_COD_TIPO_ARTICULO = i_COD_TIPO_ARTICULO;
			this.i_COD_INSTANCIA = i_COD_INSTANCIA;
			this.i_COD_INSTANCIA_SUPERIOR = i_COD_INSTANCIA_SUPERIOR;
			this.c_COD_AREA = c_COD_AREA;
			this.c_COD_AREA_SUPERIOR = c_COD_AREA_SUPERIOR;
			this.i_COD_PED_ARTICULO_AREA = i_COD_PED_ARTICULO_AREA;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the I_COD_TIPO_ARTICULO value.
		/// </summary>
		public virtual int I_COD_TIPO_ARTICULO
		{
			get { return i_COD_TIPO_ARTICULO; }
			set { i_COD_TIPO_ARTICULO = value; }
		}

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
		/// Gets or sets the I_COD_PED_ARTICULO_AREA value.
		/// </summary>
		public virtual int I_COD_PED_ARTICULO_AREA
		{
			get { return i_COD_PED_ARTICULO_AREA; }
			set { i_COD_PED_ARTICULO_AREA = value; }
		}

		#endregion
	}
}
