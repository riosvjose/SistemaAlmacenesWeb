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
    // Creado por: Ignacio Rios; Fecha: 18/12/2018
    // Ultima modificación: Alvaro Mamani; Fecha: 18/12/2018
    // Descripción: Clase referente a la tabla alm_proveedores
    public class BD_ALM_Plantillas
    {
        #region Variables Locales
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        GEN_VarSession axVarSes = new GEN_VarSession();
        private string strSql = string.Empty;
        #endregion

        #region Atributos
        // Campos de la tabla alm_proveedores
        private long _num_sec_plantilla = 0;
        private string _nombre = string.Empty;
        private long _num_sec_almacen = 0;
        private short _activo = 0;
        private short _tipo_ingreso = 0;
        private short _tipo_egreso = 0;
        private string _fecharegistro = string.Empty;
        private string _usuarioregistro = string.Empty;
        private long _numsecusuarioregistro = 0;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecPlantilla
        {
            get { return _num_sec_plantilla; }
            set { _num_sec_plantilla = value; }
        }

        public long NumSecAlmacen
        {
            get { return _num_sec_almacen; }
            set { _num_sec_almacen = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public short Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }

        public short TipoIngreso
        {
            get { return _tipo_ingreso; }
            set { _tipo_ingreso = value; }
        }

        public short TipoEgreso
        {
            get { return _tipo_egreso; }
            set { _tipo_egreso = value; }
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
        public BD_ALM_Plantillas()
        {
            _num_sec_plantilla = 0;
            _num_sec_almacen = 0;
            _nombre = string.Empty;
            _activo = 0;
            _tipo_ingreso = 0;
            _tipo_egreso = 0;
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
            string usuario = axVarSes.Lee<string>("UsuarioPersonaNumSec");
            strSql = "insert into alm_plantillas (num_sec_plantilla, nombre, num_sec_almacen, tipo_ingreso"+
                    ", tipo_egreso, activo, num_sec_usuario_reg) values " +
                    "(alm_plantillas_sec.nextval,'" + _nombre+ "', '" + _num_sec_almacen + "', '" + _tipo_ingreso + "', '" +
                      _tipo_egreso + "', '" + _activo +", " + usuario + ")";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();
            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla alm_plantillas. " + _mensaje;
            return blOperacionCorrecta;
        }

        public void Modificar()
        {
           
        }

        public void Borrar()
        {

        }

        public bool Ver()
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            strSql = "select * from alm_plantillas where activo=1 and tipo_ingreso = " + _tipo_ingreso.ToString()+
                    " and tipo_egreso="+_tipo_egreso+" and num_sec_almacen="+_num_sec_almacen;
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
                _num_sec_plantilla = Convert.ToInt64(dr["num_sec_plantilla"].ToString());
                _nombre = dr["nombre"].ToString();
                _fecharegistro = dr["fecha_registro"].ToString();
                _usuarioregistro = dr["usuario_registro"].ToString();
                _numsecusuarioregistro = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
            }
            dt.Dispose();
            if (!blEncontrado)
            {
                _num_sec_plantilla = 0;
                _num_sec_almacen = 0;
                _nombre = string.Empty;
                _activo = 0;
                _tipo_ingreso = 0;
                _tipo_egreso = 0;
                _fecharegistro = string.Empty;
                _usuarioregistro = string.Empty;
                _numsecusuarioregistro = 0;

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
        // Lista de todos los proveedores
        public DataTable ListarPlantillas()
        {            
            strSql = "SELECT * FROM alm_plantillas where activo=1 order by nombre asc";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }
        #endregion

    }


}