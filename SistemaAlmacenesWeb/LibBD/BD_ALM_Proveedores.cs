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
    // Creado por: Ignacio Rios; Fecha: 12/12/2018
    // Ultima modificación: Alvaro Mamani; Fecha: 18/12/2018
    // Descripción: Clase referente a la tabla alm_proveedores
    public class BD_ALM_Proveedores
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
        private long _num_sec_proveedor = 0;
        private string _nit = string.Empty;
        private string _nombre_comercial = string.Empty;
        private string _razon_social = string.Empty;
        private string _telefono = string.Empty;
        private string _email= string.Empty;
        private string _direccion = string.Empty;
        private string _nombre_contacto = string.Empty;
        private string _fecharegistro = string.Empty;
        private string _usuarioregistro = string.Empty;
        private long _numsecusuarioregistro = 0;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecProveedor
        {
            get { return _num_sec_proveedor; }
            set { _num_sec_proveedor = value; }
        }

        public string Nit
        {
            get { return _nit; }
            set { _nit = value; }
        }

        public string NombreComercial
        {
            get { return _nombre_comercial; }
            set { _nombre_comercial = value; }
        }

        public string RazonSocial
        {
            get { return _razon_social; }
            set { _razon_social = value; }
        }

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public string NombreContacto
        {
            get { return _nombre_contacto; }
            set { _nombre_contacto = value; }
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
        public BD_ALM_Proveedores()
        {
            _num_sec_proveedor = 0;
            _nit = string.Empty;
            _nombre_comercial = string.Empty;
            _razon_social = string.Empty;
            _telefono = string.Empty;
            _email = string.Empty;
            _direccion = string.Empty;
            _nombre_contacto = string.Empty;
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
            strSql = "insert into ALM_PROVEEDORES (num_sec_proveedor, nit, nombre_comercial, razon_social, " + 
                    "telefono, email, direccion, nombre_contacto, num_sec_usuario_reg) values " +
                    "(alm_proveedores_sec.nextval,'" + _nit + "', '" + _nombre_comercial + "', '" + _razon_social + "', '" +
                      _telefono + "', '" + _email + "', '" + _direccion + "', '" + _nombre_contacto + "', " + usuario + ")";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();
            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla alm_proveedores. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool Modificar()
        {
            bool blOperacionCorrecta = false;
            strSql = "update alm_proveedores set " +
                "telefono = '" + _telefono + "', " +
                "direccion = '" + _direccion + "', " +
                "email = '" + _email + "' "+
                "where num_sec_proveedor = " + _num_sec_proveedor.ToString();

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla alm_proveedores. " + _mensaje;
            return blOperacionCorrecta;
        }

        public void Borrar()
        {

        }

        public bool Ver()
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            strSql = "select * from alm_proveedores where num_sec_proveedor = " + _num_sec_proveedor.ToString();
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
                _num_sec_proveedor = Convert.ToInt64(dr["num_sec_proveedor"].ToString());
                _nit = dr["nit"].ToString();
                _nombre_comercial = dr["nombre_comercial"].ToString();
                _razon_social= dr["razon_social"].ToString();
                _telefono = dr["telefono"].ToString();
                _email = dr["email"].ToString();
                _direccion = dr["direccion"].ToString();
                _nombre_contacto = dr["nombre_contacto"].ToString();
                _fecharegistro = dr["fecha_registro"].ToString();
                _usuarioregistro = dr["usuario_registro"].ToString();
                _numsecusuarioregistro = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
            }
            dt.Dispose();
            if (!blEncontrado)
            {
                _num_sec_proveedor = 0;
                _nit = string.Empty;
                _nombre_comercial = string.Empty;
                _razon_social = string.Empty;
                _telefono = string.Empty;
                _email = string.Empty;
                _direccion = string.Empty;
                _nombre_contacto = string.Empty;
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
        public DataTable ListarProveedores()
        {            
            strSql = "SELECT * FROM ( " +
                        "SELECT 0 as num_sec_proveedor, '---------------------------' as nombre_comercial from dual UNION " +
                        "SELECT num_sec_proveedor, nombre_comercial FROM alm_proveedores " +
                    ") ORDER BY nombre_comercial ASC";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }
        #endregion

    }


}