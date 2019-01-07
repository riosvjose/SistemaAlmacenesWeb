using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nsGEN_VarSession;
using nsGEN_Java;
using nsGEN_WebForms;
using System.Data;
using nsGEN;

using nsGEN_OracleBD;
namespace SistemaAlmacenesWeb
{
    // Creado por: Ignacio Rios Villanueva; Fecha: 27/08/218
    // Ultima modificación: Ignacio Rios Villanueva; Fecha: 07/01/2019
    // Descripción: Clase referente a la tabla Personas
    public class BD_GEN_Subdeptos_Personas
    {
        #region Librerias Externas

        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_VarSession axVarSes = new GEN_VarSession();

        #endregion

        #region Variables Locales

        private string strSql = string.Empty;

        #endregion

        #region Atributos
        // Campos de la tabla TRS_AVANCES
        private long _num_sec_modulo = 0;
        private long _num_sec_persona = 0;
        private long _num_sec_subdepartamento = 0;
        private long _num_sec_persona_autoriza = 0;
        private string _fecha_registro = string.Empty;
        private string _usuario_registro = string.Empty;
        //private string _num_sec_usuario_reg = string.Empty;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;
        // Definicion GET y SET de los campos de la tabla TRS_AVANCES

        public long NumSecModulo { get { return _num_sec_modulo; } set { _num_sec_modulo = value; } }
        public long NumSecPersona { get { return _num_sec_persona; } set { _num_sec_persona = value; } }
        public long NumSecSubdepto { get { return _num_sec_subdepartamento; } set { _num_sec_subdepartamento = value; } }
        public long ApellidoMaterno { get { return _num_sec_persona_autoriza; } set { _num_sec_persona_autoriza = value; } }
        public string FechaRegistro { get { return _fecha_registro; } set { _fecha_registro = value; } }
        public string UsuarioRegistro { get { return _usuario_registro; } set { _usuario_registro = value; } }

        // Definicion GET y SET para las otras propiedades 
        public string Mensaje
        {
            get { return _mensaje; }
        }
        public string StrConexion
        {
            get { return _strconexion; }
            set { _strconexion = value; }
        }

        #endregion

        #region Constructor
        // Definición del contructor de la clase TRS_AVANCES
        public BD_GEN_Subdeptos_Personas()
        {
            _num_sec_modulo= 0;
            _num_sec_persona = 0;
            _num_sec_persona_autoriza = 0;
            _num_sec_subdepartamento = 0;
            _fecha_registro = string.Empty;
            _usuario_registro = string.Empty;

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }

        #endregion

        #region Metodos iBD_Tablas y Públicos

        // Método para insertar un dato en la tabla TRS_AVANCES
        public bool Insertar()
        {
            return false;
        }

        // Método para MODIFICAR un dato en la tabla TRS_AVANCES
        public bool Modificar()
        {
            bool blOperacionCorrecta = false;
            return blOperacionCorrecta;
        }

        // Método para ELIMINAR un dato en la tabla Personas
        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            return blOperacionCorrecta;
        }

        // Método para VER un dato en la tabla GEN_subdeptos_Personas
        public void Ver()
        {
            DataTable dt = new DataTable();
            string num_modulo = axVarSes.Lee<string>("NumModulo");
            string num_subunidad = axVarSes.Lee<string>("SubUnidad");
            string persona = axVarSes.Lee<string>("UsuarioPersonaNumSec");
            strSql = "SELECT a.num_sec_modulo, a.num_sec_subdepartamento, a.num_sec_persona, a.num_sec_persona_autoriza"+
                     " from gen_subdeptos_personas a, sam_modulos m"+
                     " where m.numero_modulo = "+ num_modulo +
                     " and m.num_sec_subunidad = "+ num_subunidad +
                     " and a.num_sec_persona="+persona+
                     " and a.num_sec_modulo=m.num_sec_modulo";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                _num_sec_modulo = Convert.ToInt64(dr["num_sec_modulo"].ToString().Trim());
                _num_sec_persona = Convert.ToInt64(dr["num_sec_persona"].ToString().Trim());
                _num_sec_persona_autoriza = Convert.ToInt64(dr["num_sec_persona_autoriza"].ToString().Trim());
                _num_sec_subdepartamento = Convert.ToInt64(dr["num_sec_subdepartamento"].ToString().Trim());
            }
            else
            {
                _num_sec_modulo = 0;
                _num_sec_persona = 0;
                _num_sec_persona_autoriza = 0;
                _num_sec_subdepartamento = 0;
            }
            dt.Dispose();

    }

        #endregion

        #region Procedimientos y Funciones Locales

        #endregion

        #region Procedimientos y Funciones Públicos

        #endregion
    }
}