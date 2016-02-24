using System;
using System.ComponentModel.DataAnnotations;
using Personal.Models;
using System.Collections.Generic;

namespace BussinessEntity
{
    [MetadataType(typeof(paisModel))]
    public class MA_PAI
    {

        public MA_PAI()
        {
            this.RRHH_PERSONA_CARGO = new HashSet<RRHH_PERSONA_CARGO>();
        }
        #region Fields

        private int i_COD_PAIS;
        private string v_DES_PAIS;
        private string c_ACTIVO;

        #endregion

        public virtual ICollection<RRHH_PERSONA_CARGO> RRHH_PERSONA_CARGO { get; set; }

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the MA_PAI class.
        /// </summary>


        /// <summary>
        /// Initializes a new instance of the MA_PAI class.
        /// </summary>
        public MA_PAI(int i_COD_PAIS, string v_DES_PAIS, string c_ACTIVO)
        {
            this.i_COD_PAIS = i_COD_PAIS;
            this.v_DES_PAIS = v_DES_PAIS;
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
        /// Gets or sets the V_DES_PAIS value.
        /// </summary>
        public virtual string V_DES_PAIS
        {
            get { return v_DES_PAIS; }
            set { v_DES_PAIS = value; }
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
