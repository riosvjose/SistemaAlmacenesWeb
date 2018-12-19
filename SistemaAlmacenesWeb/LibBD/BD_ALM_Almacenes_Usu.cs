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
    // Ultima modificación: Ignacio Rios; Fecha: 18/12/2018
    // Descripción: Clase referente a la tabla alm_almacenes
    public class BD_ALM_Almacenes_Usu
    {
        #region Variables Locales
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        GEN_VarSession axVarSes = new GEN_VarSession();
        private string strSql = string.Empty;
        #endregion

        #region Atributos
        // Campos de la tabla alm_almacenes
        private long _num_sec_alm_usu= 0;
        private long _num_sec_almacen = 0;
        private long _num_sec_usuario = 0;
        private string _fecharegistro = string.Empty;
        private string _usuarioregistro = string.Empty;
        private long _numsecusuarioregistro = 0;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecAlmacenusu
        {
            get { return _num_sec_alm_usu; }
            set { _num_sec_alm_usu = value; }
        }

        public long NumSecAlmacen
        {
            get { return _num_sec_almacen; }
            set { _num_sec_almacen = value; }
        }

        public long NumSecUsu
        {
            get { return _num_sec_usuario; }
            set { _num_sec_usuario = value; }
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
        public BD_ALM_Almacenes_Usu()
        {
            _num_sec_alm_usu = 0;
            _num_sec_almacen = 0;
            _num_sec_usuario = 0;
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
            strSql = "insert into alm_almacenes_usuarios (num_sec_alm_usuario, num_sec_almacen, num_sec_usuario, num_sec_usuario_reg) values";
            strSql += " (alm_almacenes_usu.nextval,"+ _num_sec_almacen+","+_num_sec_usuario+","+usuario +" )";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();
            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla alm_almacenes. " + _mensaje;
            return blOperacionCorrecta;
        }

        public void Modificar()
        {

        }

        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            strSql = "update alm_almacenes set estado=0"+
                     " where num_sec_alm_usuario = " + _num_sec_alm_usu.ToString();

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
            strSql = "select * from alm_almacenes usuarios where num_sec_alm_usuario="+_num_sec_alm_usu.ToString();
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
                _num_sec_alm_usu = Convert.ToInt64(dr["num_sec_alm_usuario"].ToString());
                _num_sec_almacen = Convert.ToInt64(dr["num_sec_almacen"].ToString());
                _num_sec_usuario = Convert.ToInt64(dr["num_sec_usuario"].ToString());
                _fecharegistro = dr["fecha_registro"].ToString();
                _usuarioregistro = dr["usuario_registro"].ToString();
                _numsecusuarioregistro = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
            }
            dt.Dispose();
            if (!blEncontrado)
            {
                _num_sec_alm_usu = 0;
                _num_sec_almacen = 0;
                _num_sec_usuario = 0;
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
        public string[] ObtenerAlmacenUsuario()
        {
            string strSql = string.Empty;
            strSql = "select distinct num_sec_almacen from alm_almacenes_usuarios where num_sec_usuario=" + _num_sec_usuario.ToString()+
                     " and activo=1";
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            string[] almacenes = new string[dt.Rows.Count];
            if (dt.Rows.Count > 0)
            {
               for(int i=0; i< dt.Rows.Count;i++)
                {
                    DataRow dr = dt.Rows[i];
                    _num_sec_almacen = Convert.ToInt64(dr["num_sec_almacen"].ToString());
                    almacenes[i] = _num_sec_almacen.ToString();
                }
                
            }
            return almacenes;
        }
            #endregion

        }


}