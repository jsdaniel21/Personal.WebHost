using System;

namespace BussinessEntity
{
	public class PED_ARTICULO_NO_ASIGNADO
	{
		#region Fields

		private int i_COD_PED_ARTICULO_AREA;
		private string c_COD_ARTICULO;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PED_ARTICULO_NO_ASIGNADO class.
		/// </summary>
		public PED_ARTICULO_NO_ASIGNADO()
		{
		}

		/// <summary>
		/// Initializes a new instance of the PED_ARTICULO_NO_ASIGNADO class.
		/// </summary>
		public PED_ARTICULO_NO_ASIGNADO(int i_COD_PED_ARTICULO_AREA, string c_COD_ARTICULO)
		{
			this.i_COD_PED_ARTICULO_AREA = i_COD_PED_ARTICULO_AREA;
			this.c_COD_ARTICULO = c_COD_ARTICULO;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the I_COD_PED_ARTICULO_AREA value.
		/// </summary>
		public virtual int I_COD_PED_ARTICULO_AREA
		{
			get { return i_COD_PED_ARTICULO_AREA; }
			set { i_COD_PED_ARTICULO_AREA = value; }
		}

		/// <summary>
		/// Gets or sets the C_COD_ARTICULO value.
		/// </summary>
		public virtual string C_COD_ARTICULO
		{
			get { return c_COD_ARTICULO; }
			set { c_COD_ARTICULO = value; }
		}

		#endregion
	}
}
