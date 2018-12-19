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
    // Descripción: Clase referente a la tabla ALM_MOVIMIENTOS_TIPOS
    public class BD_ALM_MovimientosTipos
    {
        #region Variables Locales
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        GEN_VarSession axVarSes = new GEN_VarSession();
        private string strSql = string.Empty;
        #endregion

        #region Atributos
        // Campos de la tabla alm_movimientos_tipos
        private long _num_sec_tipo_mov = 0;
        private string _nombre = string.Empty;
        private string _abreviatura = string.Empty;
        private long _num_sec_tipo_mov_ant = 0;
        private short _tipo = 0;
        private string _fecha_registro = string.Empty;
        private string _usuario_registro = string.Empty;
        private long _num_sec_usuario_registro = 0;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecTipoMov
        {
            get { return _num_sec_tipo_mov; }
            set { _num_sec_tipo_mov = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Abreviatura
        {
            get { return _abreviatura; }
            set { _abreviatura = value; }
        }
        public long NucSecMovTipoAnt
        {
            get { return _num_sec_tipo_mov_ant; }
            set { _num_sec_tipo_mov_ant = value; }
        }

        public short Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
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
        public BD_ALM_MovimientosTipos()
        {
            _num_sec_tipo_mov = 0;
            _nombre = string.Empty;
            _abreviatura = string.Empty;
            _num_sec_tipo_mov_ant = 0;
            _tipo = 0;
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
            strSql = "insert into alm_movimientos_tipos (num_sec_tipo_mov, nombre, abreviatura, num_sec_tipo_mov_ant, tipo, num_sec_usuario_reg) values " +
                    "(alm_mov_tipos_sec.nextval, " + _nombre + ", " + _abreviatura + ", " + _num_sec_tipo_mov_ant + ", " + _tipo + ", " + usuario + " )";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();
            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla alm_movimientos_tipos. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool Modificar()
        {
            bool blOperacionCorrecta = false;
            strSql = "update alm_movimientos_tipos set " +
                "nombre = " + _nombre + ", " +
                "abreviatura = " + _abreviatura + ", " +
                "num_sec_tipo_mov_ant = " + _num_sec_tipo_mov_ant+ " " +
                "where num_sec_tipo_mov = " + _num_sec_tipo_mov.ToString().Trim();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla alm_movimientos_tipos. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            return blOperacionCorrecta;
        }

        public bool Ver()
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            strSql = "select num_sec_tipo_mov, nombre, abreviatura, num_sec_tipo_mov_ant, tipo " +
                "from alm_movimientos_tipos " +
                "where num_sec_tipo_mov = " + _num_sec_tipo_mov.ToString().Trim();
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
                _num_sec_tipo_mov = Convert.ToInt64(dr["num_sec_tipo_mov"].ToString());
                _nombre = dr["nombre"].ToString();
                _abreviatura = dr["abreviatura"].ToString();
                _num_sec_tipo_mov_ant = Convert.ToInt64(dr["num_sec_tipo_mov_ant"].ToString());
                _tipo = Convert.ToInt16(dr["tipo"].ToString());
                _fecha_registro = dr["fecha_registro"].ToString();
                _usuario_registro = dr["usuario_registro"].ToString();
                _num_sec_usuario_registro = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
            }
            dt.Dispose();
            if (!blEncontrado)
            {
                _num_sec_tipo_mov = 0;
                _nombre = string.Empty;
                _abreviatura = string.Empty;
                _num_sec_tipo_mov_ant = 0;
                _tipo = 0;
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