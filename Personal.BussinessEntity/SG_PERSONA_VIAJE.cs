using System;
using Personal;
using System.ComponentModel.DataAnnotations;
using Personal.Models;

namespace BussinessEntity
{
    [MetadataType(typeof(peopleTravelModel))]
    public class SG_PERSONA_VIAJE
    {
        #region Fields

        private int i_COD_PERSONA_VIAJES;
        private string c_COD_PERSONA;
        private int i_COD_PAIS;
        private int i_AÑO;
        private string v_TIEMPO_PERMANENCIA;
        private string v_DES_MOTIVO;
        private DateTime d_FEC_REGISTRO;
        private DateTime d_FEC_BAJA;
        private string c_ACTIVO;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the SG_PERSONA_VIAJE class.
        /// </summary>
        public SG_PERSONA_VIAJE()
        {
        }

        /// <summary>
        /// Initializes a new instance of the SG_PERSONA_VIAJE class.
        /// </summary>
        public SG_PERSONA_VIAJE(int i_COD_PERSONA_VIAJES, string c_COD_PERSONA, int i_COD_PAIS, int i_AÑO, string v_TIEMPO_PERMANENCIA, string v_DES_MOTIVO, DateTime d_FEC_REGISTRO, DateTime d_FEC_BAJA, string c_ACTIVO)
        {
            this.i_COD_PERSONA_VIAJES = i_COD_PERSONA_VIAJES;
            this.c_COD_PERSONA = c_COD_PERSONA;
            this.i_COD_PAIS = i_COD_PAIS;
            this.i_AÑO = i_AÑO;
            this.v_TIEMPO_PERMANENCIA = v_TIEMPO_PERMANENCIA;
            this.v_DES_MOTIVO = v_DES_MOTIVO;
            this.d_FEC_REGISTRO = d_FEC_REGISTRO;
            this.d_FEC_BAJA = d_FEC_BAJA;
            this.c_ACTIVO = c_ACTIVO;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the I_COD_PERSONA_VIAJES value.
        /// </summary>
        public virtual int I_COD_PERSONA_VIAJES
        {
            get { return i_COD_PERSONA_VIAJES; }
            set { i_COD_PERSONA_VIAJES = value; }
        }

        /// <summary>
        /// Gets or sets the C_COD_PERSONA value.
        /// </summary>
        public virtual string C_COD_PERSONA
        {
            get { return c_COD_PERSONA; }
            set { c_COD_PERSONA = value; }
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
        /// Gets or sets the I_AÑO value.
        /// </summary>
        public virtual int I_AÑO
        {
            get { return i_AÑO; }
            set { i_AÑO = value; }
        }

        /// <summary>
        /// Gets or sets the V_TIEMPO_PERMANENCIA value.
        /// </summary>
        public virtual string V_TIEMPO_PERMANENCIA
        {
            get { return v_TIEMPO_PERMANENCIA; }
            set { v_TIEMPO_PERMANENCIA = value; }
        }

        /// <summary>
        /// Gets or sets the V_DES_MOTIVO value.
        /// </summary>
        public virtual string V_DES_MOTIVO
        {
            get { return v_DES_MOTIVO; }
            set { v_DES_MOTIVO = value; }
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

        #endregion
    }
}
