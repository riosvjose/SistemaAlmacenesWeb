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
    // Ultima modificación: Ignacio Rios Villanueva; Fecha: 07/01/2018
    // Descripción: Clase referente a la tabla Personas
    public class BD_Personas
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
        private long _num_sec = 0;
        private string _nombres = string.Empty;
        private string _apellido_paterno = string.Empty;
        private string _apellido_materno = string.Empty;
        private string _nombre_completo = string.Empty;
        private string _fecha_registro = string.Empty;
        private string _usuario_registro = string.Empty;
        //private string _num_sec_usuario_reg = string.Empty;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;
        // Definicion GET y SET de los campos de la tabla TRS_AVANCES

        public long NumSec { get { return _num_sec; } set { _num_sec = value; } }
        public string Nombres { get { return _nombres; } set { _nombres = value; } }
        public string ApellidoPaterno { get { return _apellido_paterno; } set { _apellido_paterno = value; } }
        public string ApellidoMaterno { get { return _apellido_materno; } set { _apellido_materno = value; } }
        public string NombreCompleto { get { return _nombre_completo; } set { _nombre_completo = value; } }
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
        public BD_Personas()
        {
            _num_sec= 0;
            _nombres= string.Empty;
            _apellido_materno = string.Empty;
            _apellido_paterno = string.Empty;
            _nombre_completo = string.Empty;
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

        // Método para VER un dato en la tabla Personas
        public void Ver()
        {
            DataTable dt = new DataTable();
            string evento = axVarSes.Lee<string>("strEvento");
            strSql = "SELECT per.num_sec num_sec, per.nombres, per.ap_paterno, " +
                " per.ap_materno, "+
                " per.ap_paterno||' '||per.ap_materno||' '||per.nombres nombre_completo " +
                " FROM asignaciones a, cargos_rrhh c, personas per, " +
                " (SELECT d.num_sec_departamento, d.descripcion departamento " +
                "  FROM asignaciones a, cargos_rrhh c, departamentos_ucb d " +
                "  WHERE a.num_sec_persona = " + _num_sec +
                "  AND a.carga_horaria = 1 " +
                "  AND SYSDATE >= a.fecha_asignacion " +
                "  AND(SYSDATE <= a.fecha_retiro OR a.fecha_retiro IS NULL) " +
                "  AND a.num_sec_cargo = c.num_sec " +
                "  AND c.num_sec_departamento = d.num_sec_departamento) b " +
                " WHERE a.carga_horaria = 1 " +
                " AND SYSDATE >= a.fecha_asignacion" +
                " AND(SYSDATE <= a.fecha_retiro OR a.fecha_retiro IS null) " +
                " AND a.num_sec_cargo = c.num_sec" +
                " AND c.num_sec_departamento = b.num_sec_departamento" +
                " AND a.num_sec_persona = per.num_sec"+
                " AND per.num_sec="+_num_sec;
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                _nombre_completo = dr["nombre_completo"].ToString().Trim();
                _nombres= dr["nombres"].ToString().Trim();
                _apellido_paterno = dr["ap_paterno"].ToString().Trim();
                _apellido_materno = dr["ap_materno"].ToString().Trim();
            }
            dt.Dispose();

    }

        #endregion

        #region Procedimientos y Funciones Locales

        #endregion

        #region Procedimientos y Funciones Públicos

        public DataTable DTListaPersonasDepto()
        {
            string num_subdepto = axVarSes.Lee<string>("strDeptoUsuario");
            strSql = "SELECT a.num_sec, a.nombres||' '|| a.ap_paterno||' '|| a.ap_materno as nombre_completo " +
                     " from personas a, gen_subdeptos_personas g"+
                     " WHERE g.num_sec_subdepartamento= " + num_subdepto+
                     " and g.num_sec_persona=a.num_sec"+
                     " ORDER BY a.nombres||' '|| a.ap_paterno||' '|| a.ap_materno ASC";            
            OracleBD.MostrarError = false;  
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }
        #endregion
    }
}