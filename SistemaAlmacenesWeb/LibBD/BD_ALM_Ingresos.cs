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
    // Ultima modificación: Ignacio Rios; Fecha: 10/12/2018
    // Descripción: Clase referente a la tabla alm_ingresos
    public class BD_ALM_Ingresos
    {
        #region Variables Locales
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        GEN_VarSession axVarSes = new GEN_VarSession();
        private string strSql = string.Empty;
        #endregion

        #region Atributos
        // Campos de la tabla alm_ingresos
        private long _num_sec_ingreso = 0;
        private string _cod_compra_sap = string.Empty;
        private string _fecha_ingreso = string.Empty;
        private long _num_sec_proveedor = 0;
        private short _tipo = 0;
        private string _fecharegistro = string.Empty;
        private string _usuarioregistro = string.Empty;
        private long _numsecusuarioregistro = 0;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecIngreso
        {
            get { return _num_sec_ingreso; }
            set { _num_sec_ingreso = value; }
        }

        public string CodCompraSAP
        {
            get { return _cod_compra_sap; }
            set { _cod_compra_sap = value; }
        }

        public string FechaIngreso
        {
            get { return _fecha_ingreso; }
            set { _fecha_ingreso = value; }
        }

        public short Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public long NumSecProveedor
        {
            get { return _num_sec_proveedor; }
            set { _num_sec_proveedor = value; }
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
        public BD_ALM_Ingresos()
        { 
            _num_sec_ingreso = 0;
            _cod_compra_sap = string.Empty;
            _fecha_ingreso = string.Empty;
            _num_sec_proveedor = 0;
            _tipo = 0;
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
            strSql = "insert into alm_ingresos (num_sec_ingreso, codigo_compra_sap, fecha_ingreso, tipo"+
                     ", num_sec_proveedor, num_sec_usuario_reg) values"+
                     " (alm_ingresos_sec.nextval,"+ _cod_compra_sap + ","+_fecha_ingreso + ","+_tipo + ","+
                     _num_sec_proveedor+"," +usuario +" )";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();
            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla alm_ingresos. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool Modificar()
        {
            bool blOperacionCorrecta = false;
            strSql = "update alm_ingresos set "+
                " codigo_compra_sap = " + _cod_compra_sap +
                ", fecha_ingreso = " + _fecha_ingreso+
                ", tipo = " + _fecha_ingreso +
                " where num_sec_ingreso = " + _num_sec_ingreso.ToString();

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla alm_ingresos. " + _mensaje;
            return blOperacionCorrecta;
        }

        public void Borrar()
        {
            
        }

        public bool Ver()
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            strSql = "select cod_orden_compra, to_char(fecha_ingreso, 'DD/MM/YYYY') fecha_ingreso, tipo, num_sec_proveedor"+
                        " from alm_ingresos where num_sec_ingreso="+_num_sec_ingreso;
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
                _cod_compra_sap = dr["codigo_orden_compra"].ToString();
                _fecha_ingreso= dr["fecha_ingreso"].ToString();
                _tipo = Convert.ToInt16(dr["tipo"].ToString());
                _num_sec_proveedor = Convert.ToInt64(dr["num_sec_proveedor"].ToString());
                _fecharegistro = dr["fecha_registro"].ToString();
                _usuarioregistro = dr["usuario_registro"].ToString();
                _numsecusuarioregistro = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
            }
            dt.Dispose();
            if (!blEncontrado)
            {
                _num_sec_ingreso = 0;
                _cod_compra_sap = string.Empty;
                _fecha_ingreso = string.Empty;
                _num_sec_proveedor = 0;
                _tipo = 0;
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
        public long ObtenerNSIngreso()
        {
            long num_sec = 0;
            string strSql = string.Empty;
            strSql = "select alm_ingresos.sec.nextval  as valor from dual";
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
               num_sec =  Convert.ToInt64(dr["valor"].ToString());
            }
            dt.Dispose();
            return num_sec;
        }
        #endregion

    }


}