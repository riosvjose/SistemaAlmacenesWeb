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
    // Creado por: Alvaro Mamani            ; Fecha: 12/12/2018
    // Ultima modificación: Alvaro Mamani   ; Fecha: 12/12/2018
    // Descripción: Clase referente a la tabla ALM_MOVIMIENTOS_PUNTAJES
    public class BD_ALM_MovimientosPuntajes
    {
        #region Variables Locales
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        GEN_VarSession axVarSes = new GEN_VarSession();
        private string strSql = string.Empty;
        #endregion

        #region Atributos
        // Campos de la tabla alm_movimientos_puntajes
        private long _num_sec_movimiento_puntaje = 0;
        private long _num_sec_movimiento = 0;
        private short _aspecto = 0;
        private short _puntaje = 0;
        private string _fecha_registro = string.Empty;
        private string _usuario_registro = string.Empty;
        private long _num_sec_usuario_registro = 0;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecMovimientoPuntaje
        {
            get { return _num_sec_movimiento_puntaje; }
            set { _num_sec_movimiento_puntaje = value; }
        }

        public long NumSecMovimiento
        {
            get { return _num_sec_movimiento; }
            set { _num_sec_movimiento = value; }
        }

        public short Aspecto
        {
            get { return _aspecto; }
            set { _aspecto = value; }
        }

        public short Puntaje
        {
            get { return _puntaje; }
            set { _puntaje = value; }
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
        public BD_ALM_MovimientosPuntajes()
        {
            _num_sec_movimiento_puntaje = 0;
            _num_sec_movimiento = 0;
            _aspecto = 0;
            _puntaje = 0;
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
            strSql = "insert into alm_movimientos_puntajes (num_sec_movimiento_puntaje, num_sec_movimiento, aspecto, puntaje, num_sec_usuario_reg) values " +
                    "(alm_mov_puntajes_sec.nextval, " + _num_sec_movimiento + ", " + _aspecto + ", " + _puntaje + ", " + usuario + " )";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();
            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla alm_movimientos_puntajes. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool Modificar()
        {
            bool blOperacionCorrecta = false;
            strSql = "update alm_movimientos_puntajes set " +
                "num_sec_movimiento = " + _num_sec_movimiento + ", " +
                "aspecto = " + _aspecto + ", " +
                "puntaje = " + _puntaje + " " +
                "where num_sec_movimiento_puntaje = " + _num_sec_movimiento_puntaje.ToString().Trim();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla alm_movimientos_puntajes. " + _mensaje;
            return blOperacionCorrecta;
        }

        public void Borrar()
        {

        }

        public bool Ver()
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            strSql = "select num_sec_movimiento_puntaje, num_sec_movimiento, aspecto, puntaje " +
                "from alm_movimientos_puntajes " +
                "where num_sec_movimiento_puntaje = " + _num_sec_movimiento_puntaje.ToString().Trim();
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
                _num_sec_movimiento_puntaje = Convert.ToInt64(dr["num_sec_movimiento_puntaje"].ToString());
                _num_sec_movimiento = Convert.ToInt64(dr["num_sec_movimiento"].ToString());
                _aspecto = Convert.ToInt16(dr["aspecto"].ToString());
                _puntaje = Convert.ToInt16(dr["puntaje"].ToString());
                _fecha_registro = dr["fecha_registro"].ToString();
                _usuario_registro = dr["usuario_registro"].ToString();
                _num_sec_usuario_registro = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
            }
            dt.Dispose();
            if (!blEncontrado)
            {
                _num_sec_movimiento_puntaje = 0;
                _num_sec_movimiento = 0;
                _aspecto = 0;
                _puntaje = 0;
                _fecha_registro = string.Empty;
                _usuario_registro = string.Empty;
                _num_sec_usuario_registro = 0;

                _mensaje = string.Empty;
                _strconexion = string.Empty;
            }
            return blEncontrado;
        }

        #endregion

        #region Procedimientos y Funciones Locales
        #endregion
    }
}