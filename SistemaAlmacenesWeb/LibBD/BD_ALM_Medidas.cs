using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using nsGEN_OracleBD;
using nsGEN_Mensajes;
using nsGEN_VarSession;
using nsGEN_Cadenas;
using System.Collections;

namespace SistemaAlmacenesWeb
{
    // Creado por: Ignacio Rios; Fecha: 10/12/2018
    // Ultima modificación: Alvaro Mamani; Fecha: 20/12/2018
    // Descripción: Clase referente a la tabla alm_medidas
    public class BD_ALM_Medidas
    {
        #region Variables Locales
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        GEN_VarSession axVarSes = new GEN_VarSession();
        private string strSql = string.Empty;
        #endregion

        #region Atributos
        // Campos de la tabla alm_medidas
        private long _num_sec_medida = 0;
        private string _nombre = string.Empty;
        private string _abreviacion= string.Empty;
        private string _fecharegistro = string.Empty;
        private string _usuarioregistro = string.Empty;
        private long _numsecusuarioregistro = 0;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecMedida
        {
            get { return _num_sec_medida; }
            set { _num_sec_medida = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Abreviacion
        {
            get { return _abreviacion; }
            set { _abreviacion = value; }
        }

        public string FechaRegistro
        {
            get { return _fecharegistro; }
        }
        public string UsuarioRegistro
        {
            get { return _usuarioregistro; }
        }
        public long NumSecUsuarioRegistro
        {
            get { return _numsecusuarioregistro; }
            set { _numsecusuarioregistro = value; }
        }

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

        #region Constructores
        public BD_ALM_Medidas()
        { 
            _num_sec_medida = 0;
            _nombre = string.Empty;
            _abreviacion = string.Empty;
            _fecharegistro = string.Empty;
            _usuarioregistro = string.Empty;
            _numsecusuarioregistro = 0;

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }
        #endregion

        #region Metodos
        public bool Insertar()
        {
            bool blOperacionCorrecta = false;
            string usuario = axVarSes.Lee<string>("UsuarioNumSec");
            strSql = "insert into alm_medidas (num_sec_medida, nombre, abreviacion, num_sec_usuario_reg) values " +
                        " (alm_medidas_sec.nextval, '" + _nombre + "', '" + _abreviacion + "', " + usuario + " )";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();
            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla alm_medidas. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool Modificar()
        {
            bool blOperacionCorrecta = false;
            strSql = "update alm_medidas set "+
                " nombre = " + _nombre+
                ", abreviacion = " + _abreviacion+
                " where num_sec_almacen = " + _num_sec_medida.ToString();

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla alm_medidas. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            strSql = "delete alm_medida";
            strSql += " where num_sec_media = " + _num_sec_medida.ToString();

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible borrar el dato. Se encontró un error al eliminar en la tabla alm_almacenes. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool Ver()
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            strSql = "select a.num_sec_usuario, a.num_sec_persona, a.usuario, a.login, a.activo";
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count > 0)
            {
                blEncontrado = true;
                DataRow dr = dt.Rows[0];
                _num_sec_medida = Convert.ToInt64(dr["num_sec_medida"].ToString());
                _nombre = dr["nombre"].ToString();
                _abreviacion= dr["abreviacion"].ToString();
                _fecharegistro = dr["fecha_registro"].ToString();
                _usuarioregistro = dr["usuario_registro"].ToString();
                _numsecusuarioregistro = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
            }
            dt.Dispose();
            if (!blEncontrado)
            {
                _num_sec_medida = 0;
                _nombre = string.Empty;
                _abreviacion = string.Empty;
                _fecharegistro = string.Empty;
                _usuarioregistro = string.Empty;
                _numsecusuarioregistro = 0;

                _mensaje = string.Empty;
                _strconexion = string.Empty;
            }
            return blEncontrado;
        }

        #endregion

        #region Procedimientos y Funciones Locales
        //Listar todas las medidas
        public DataTable dtListarMedidas()
        {
            DataTable dt = new DataTable();
            strSql = "SELECT ROWNUM AS nro, num_sec_medida, nombre, abreviacion " +
                        "FROM " +
                            "(SELECT num_sec_medida, nombre, abreviacion " +
                            "FROM alm_medidas " +
                            "ORDER BY nombre ASC)";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt.Dispose();
            return OracleBD.DataTable;
        }
        #endregion

    }


}