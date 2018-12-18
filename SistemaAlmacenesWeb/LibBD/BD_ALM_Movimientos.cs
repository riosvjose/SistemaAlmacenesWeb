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
    // Creado por: Alvaro Mamani   ; Fecha: 12/12/2018
    // Ultima modificación: IGNACIO RIOS   ; Fecha: 18/12/2018
    // Descripción: Clase referente a la tabla ALM_MOVIMIENTOS
    public class BD_ALM_Movimientos
    {
        #region Variables Locales
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        GEN_VarSession axVarSes = new GEN_VarSession();
        BD_ALM_Items libItem = new BD_ALM_Items();
        private string strSql = string.Empty;
        #endregion

        #region Atributos
        // Campos de la tabla alm_movimientos
        private long _num_sec_movimiento = 0;
        private long _num_sec_transaccion = 0;
        private long _num_sec_item = 0;
        private long _num_sec_persona = 0;
        private long _num_sec_usuario = 0;
        private long _num_sec_tipo_mov = 0;
        private double _precio_unitario = 0;
        private long _ingreso = 0;
        private long _egreso = 0;
        private string _fecha_registro = string.Empty;
        private string _usuario_registro = string.Empty;
        private long _num_sec_usuario_registro = 0;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecMovimiento
        {
            get { return _num_sec_movimiento; }
            set { _num_sec_movimiento = value; }
        }

        public long CodTransaccion
        {
            get { return _num_sec_transaccion; }
            set { _num_sec_transaccion = value; }
        }
        public long NumSecItem
        {
            get { return _num_sec_item; }
            set { _num_sec_item = value; }
        }
        public long NumSecPersona
        {
            get { return _num_sec_persona; }
            set { _num_sec_persona = value; }
        }
        public long NumSecUsuario
        {
            get { return _num_sec_usuario; }
            set { _num_sec_usuario = value; }
        }
        public long NumSecTipoMov
        {
            get { return _num_sec_tipo_mov; }
            set { _num_sec_tipo_mov = value; }
        }
        public double PrecioUnitario
        {
            get { return _precio_unitario; }
            set { _precio_unitario = value; }
        }
        public long Ingreso
        {
            get { return _ingreso; }
            set { _ingreso = value; }
        }
        public long Egreso
        {
            get { return _egreso; }
            set { _egreso = value; }
        }
        public string FechaRegistro
        {
            get { return _fecha_registro; }
        }
        public string UsuarioRegistro
        {
            get { return _usuario_registro; }
        }
        public long NumSecUsuarioRegistro
        {
            get { return _num_sec_usuario_registro; }
            set { _num_sec_usuario_registro = value; }
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
        public BD_ALM_Movimientos()
        {
            _num_sec_movimiento = 0;
            _num_sec_transaccion = 0;
            _num_sec_item = 0;
            _num_sec_persona = 0;
            _num_sec_usuario = 0;
            _num_sec_tipo_mov = 0;
            _precio_unitario = 0;
            _ingreso = 0;
            _egreso = 0;
            _fecha_registro = string.Empty;
            _usuario_registro = string.Empty;
            _num_sec_usuario_registro = 0;

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }
        #endregion

        #region Metodos
        public bool Insertar()
        {
            bool blOperacionCorrecta = false;
            string usuario = axVarSes.Lee<string>("UsuarioPersonaNumSec");
            strSql = "insert into alm_movimientos (num_sec_movimiento, num_sec_transaccion, num_sec_item, num_sec_persona, num_sec_usuario, num_sec_mov_tipo, precio_unitario, ingreso, egreso, num_sec_usuario_reg) values " +
                    "(alm_movimientos_sec.nextval, " + _num_sec_transaccion + ", " + _num_sec_item + ", " + _num_sec_persona + ", " + _num_sec_usuario + ", " + _num_sec_tipo_mov + ", " + _precio_unitario + ", " + _ingreso + ", " + _egreso + ", " + usuario + " )";/* Revisar el num_sec_ de "num_sec_transaccion" */
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();
            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla alm_movimientos. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool Modificar()
        {
            bool blOperacionCorrecta = false;
            strSql = "update alm_movimientos set " +
                "num_sec_transaccion = " + _num_sec_transaccion + ", " +
                "num_sec_item = " + _num_sec_item + ", " +
                "num_sec_persona = " + _num_sec_persona + ", " +
                "num_sec_usuario = " + _num_sec_usuario + ", " +
                "num_sec_mov_tipo = " + _num_sec_tipo_mov + ", " +
                "precio_unitario = " + _precio_unitario + ", " +
                "ingreso = " + _ingreso + ", " +
                "egreso = " + _egreso + " " +
                "where num_sec_almacen = " + _num_sec_movimiento.ToString().Trim();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla alm_movimientos. " + _mensaje;
            return blOperacionCorrecta;
        }

        public void Borrar()
        {

        }

        public bool Ver()
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            strSql = "select num_sec_movimiento, num_sec_transaccion, num_sec_item, num_sec_persona, num_sec_usuario, num_sec_mov_tipo, precio_unitario, ingreso, egreso " +
                "from alm_movimientos " +
                "where num_sec_movimiento = " + _num_sec_movimiento.ToString().Trim();
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
                _num_sec_movimiento = Convert.ToInt64(dr["num_sec_movimiento"].ToString());
                _num_sec_transaccion = Convert.ToInt64(dr["num_sec_transaccion"].ToString());
                _num_sec_item = Convert.ToInt64(dr["num_sec_item"].ToString());
                _num_sec_persona = Convert.ToInt64(dr["num_sec_persona"].ToString());
                _num_sec_usuario = Convert.ToInt64(dr["num_sec_usuario"].ToString());
                _num_sec_tipo_mov = Convert.ToInt64(dr["num_sec_mov_tipo"].ToString());
                _precio_unitario = Convert.ToDouble(dr["precio_unitario"].ToString());
                _ingreso = Convert.ToInt64(dr["ingreso"].ToString());
                _egreso = Convert.ToInt64(dr["egreso"].ToString());
                _fecha_registro = dr["fecha_registro"].ToString();
                _usuario_registro = dr["usuario_registro"].ToString();
                _num_sec_usuario_registro = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
            }
            dt.Dispose();
            if (!blEncontrado)
            {
                _num_sec_movimiento = 0;
                _num_sec_transaccion = 0;
                _num_sec_item = 0;
                _num_sec_persona = 0;
                _num_sec_usuario = 0;
                _num_sec_tipo_mov = 0;
                _precio_unitario = 0;
                _ingreso = 0;
                _egreso = 0;
                _fecha_registro = string.Empty;
                _usuario_registro = string.Empty;
                _num_sec_usuario_registro = 0;

                _mensaje = string.Empty;
                _strconexion = string.Empty;
            }
            return blEncontrado;
        }
        public bool InsetarVarios(string[] strSql, int cant)
        {
            bool blOperacionCorrecta = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.ListaSqls = strSql;
            OracleBD.NumSqls = cant;
            OracleBD.EjecutarSqlsTrans();
            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar los datos. Se encontró un error al insertaren la tabla alm_movimientos. " + _mensaje;
            return blOperacionCorrecta;
        }
        #endregion

        #region Procedimientos y Funciones Locales
        public string SQLCadenaMovimiento()
        {
            libItem = new BD_ALM_Items();
            libItem.StrConexion = StrConexion;
            libItem.NumSecItem = _num_sec_item;
            if (libItem.Ver())
            {
                _precio_unitario = libItem.PrecioMov;
            }  
            strSql = "INSERT INTO alm_movimientos (num_sec_movimiento, num_sec_transaccion, num_sec_item,"+
                     " num_sec_persona, num_sec_usuario, num_sec_tipo_mov, precio_unitario, ingreso, egreso,"+
                     " num_sec_usuario_reg) VALUES "+
                     " (alm_movimientos_sec.NEXTVAL"+
                     ", alm_mov_trans_sec.NEXTVAL" +
                     ", " +_num_sec_item+
                     ", " +_num_sec_persona+
                     ", " +_num_sec_usuario+
                     ", " +_num_sec_tipo_mov+
                     ", " +_precio_unitario+
                     ", " +_ingreso+
                     ", " +_egreso+
                     ", "+_num_sec_usuario_registro+")";
            return strSql;
        }
        #endregion
    }
}