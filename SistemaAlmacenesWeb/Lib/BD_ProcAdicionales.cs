using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using nsGEN_OracleBD;
using nsGEN_VarSession;

namespace SistemaAlmacenesWeb
{
    // Creado por: Ignacio Rios Villanueva; Fecha: 07/09/218
    // Ultima modificación: Alvaro Mamani; Fecha: 07/01/2019
    // Descripción: Clase para obtener datos adicionales 
    public class BD_ProcAdicionales
    {
        #region Librerias Externas

        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_VarSession axVarSes = new GEN_VarSession();

        #endregion

        #region Variables Locales

        private string strSql = string.Empty;

        #endregion

        #region Atributos

        // Campos de la tabla TRS_PROYETOS
        private long _num_sec_persona = 0;
        private long _num_sec_depto = 0;
        private string _fecha_registro = string.Empty;
        private string _usuario_registro = string.Empty;


        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        // Definicion GET y SET de los campos de la tabla TRS_PROYECTOS
        public long NumSecPersona { get { return _num_sec_persona; } set { _num_sec_persona = value; } }
        public long NumSecDepto { get { return _num_sec_depto; } set { _num_sec_depto = value; } }
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

        // Definición del contructor 
        public BD_ProcAdicionales()
        {
            _num_sec_persona = 0;
            _num_sec_depto = 0;
            _fecha_registro = string.Empty;
            _usuario_registro = string.Empty;

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }

        #endregion

        #region Metodos iBD_Tablas y Públicos

        // Método para insertar un dato en la tabla TRS_PROYECTOS
        public bool Insertar()
        {
            bool blOperacionCorrecta = false;
            return blOperacionCorrecta;
        }

        // Método para MODIFICAR un dato
        public bool Modificar()
        {
            bool blOperacionCorrecta = false;
            return blOperacionCorrecta;
        }
        // Método para eliminar un dato 
        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            return blOperacionCorrecta;
        }

        // Método para VER un dato 
        public bool Ver()
        {
            bool blOperacionCorrecta = false;
            return blOperacionCorrecta;
        }

        #endregion

        #region Procedimientos y Funciones Locales


        #endregion

        #region Procedimientos y Funciones Públicos
        //verifica avances no registrados por proyecto y los inserta en la tabla avances

        public bool AccesoObjetoUsuario(string nombre_objeto)
        {
            bool existe = false;
            string struser = axVarSes.Lee<string>("UsuarioNumSec");
            DataTable dt = new DataTable();
            strSql = "SELECT distinct o.num_sec_objeto " +
                    " FROM sam_usuarios_funciones fu, sam_funciones f, sam_accesos a, sam_objetos o " +
                    " WHERE fu.num_sec_usuario= " + struser +
                    " and o.nombre like '"+nombre_objeto+"%'"+
                    " and a.acceso=1"+
                    " and fu.num_sec_funcion=f.num_sec_funcion" +
                    " and f.num_sec_funcion=a.num_sec_funcion"+
                    " and a.num_sec_objeto=o.num_sec_objeto";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count >0)
            {
                existe = true;
            }
            dt.Dispose();
            return existe;
        }
        // devuelve true si la fecha indicada es menor o igual a la fecha actual
        public bool FechaMenorIgualHoy(string fecha)
        {
            bool menorigual = false;
            int dia = 0;
            DataTable dt = new DataTable();
            strSql = "SELECT trunc(sysdate) - To_Date('" + fecha.ToString().Trim() + "', 'dd/mm/yyyy') as dia FROM dual";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                dia = Convert.ToInt32(dr["dia"].ToString());
                if (dia >= 0)
                {
                    menorigual = true;
                }
            }
            dt.Dispose();
            return menorigual;
        }
        #endregion
    }
}