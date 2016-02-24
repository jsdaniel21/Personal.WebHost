using System;
using System.ComponentModel.DataAnnotations;
using Personal.Models;

namespace BussinessEntity
{

    [MetadataType(typeof(areaModel))]
    public class MA_AREA
    {
        #region Fields

        private string c_COD_AREA;
        private string v_DES_FUNCIONES;
        private string v_ABREV_FUNCIONES;
        private string c_ACTIVO;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the MA_AREA class.
        /// </summary>
        public MA_AREA()
        {
        }

        /// <summary>
        /// Initializes a new instance of the MA_AREA class.
        /// </summary>
        public MA_AREA(string c_COD_AREA, string v_DES_FUNCIONES, string v_ABREV_FUNCIONES, string c_ACTIVO)
        {
            this.c_COD_AREA = c_COD_AREA;
            this.v_DES_FUNCIONES = v_DES_FUNCIONES;
            this.v_ABREV_FUNCIONES = v_ABREV_FUNCIONES;
            this.c_ACTIVO = c_ACTIVO;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the C_COD_AREA value.
        /// </summary>
        public virtual string C_COD_AREA
        {
            get { return c_COD_AREA; }
            set { c_COD_AREA = value; }
        }

        /// <summary>
        /// Gets or sets the V_DES_FUNCIONES value.
        /// </summary>
        public virtual string V_DES_FUNCIONES
        {
            get { return v_DES_FUNCIONES; }
            set { v_DES_FUNCIONES = value; }
        }

        /// <summary>
        /// Gets or sets the V_ABREV_FUNCIONES value.
        /// </summary>
        public virtual string V_ABREV_FUNCIONES
        {
            get { return v_ABREV_FUNCIONES; }
            set { v_ABREV_FUNCIONES = value; }
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
