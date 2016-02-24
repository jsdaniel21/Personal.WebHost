using System;

namespace BussinessEntity
{
	public class PED_VALE_PEDIDO
	{
		#region Fields

		private string c_COD_DET_VALE_RETIRO;
		private string c_COD_ARTICULO;
		private string c_COD_PEDIDO;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PED_VALE_PEDIDO class.
		/// </summary>
		public PED_VALE_PEDIDO()
		{
		}

		/// <summary>
		/// Initializes a new instance of the PED_VALE_PEDIDO class.
		/// </summary>
		public PED_VALE_PEDIDO(string c_COD_DET_VALE_RETIRO, string c_COD_ARTICULO, string c_COD_PEDIDO)
		{
			this.c_COD_DET_VALE_RETIRO = c_COD_DET_VALE_RETIRO;
			this.c_COD_ARTICULO = c_COD_ARTICULO;
			this.c_COD_PEDIDO = c_COD_PEDIDO;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the C_COD_DET_VALE_RETIRO value.
		/// </summary>
		public virtual string C_COD_DET_VALE_RETIRO
		{
			get { return c_COD_DET_VALE_RETIRO; }
			set { c_COD_DET_VALE_RETIRO = value; }
		}

		/// <summary>
		/// Gets or sets the C_COD_ARTICULO value.
		/// </summary>
		public virtual string C_COD_ARTICULO
		{
			get { return c_COD_ARTICULO; }
			set { c_COD_ARTICULO = value; }
		}

		/// <summary>
		/// Gets or sets the C_COD_PEDIDO value.
		/// </summary>
		public virtual string C_COD_PEDIDO
		{
			get { return c_COD_PEDIDO; }
			set { c_COD_PEDIDO = value; }
		}

		#endregion
	}
}
