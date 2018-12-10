using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using nsGEN_OracleBD;
using nsGEN_Mensajes;
using nsGEN_Cadenas;

namespace nsBD_SAM
{
    // Creado por: Milco Cortez; Fecha: 23/03/2015
    // Ultima modificación: Milco Cortez;  Fecha:14/05/2015
    // Descripción: Clase referente a la tabla SAM_MODULOS
    public class BD_SAM_Modulos
    {
        #region Variables Locales
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        //BD_SAM_Perfiles bdSAM_Perfiles1 = new BD_SAM_Perfiles();

        private string strSql = string.Empty;
        #endregion

        #region Atributos
        // Campos de la tabla SAM_MODULOS
        private long _numsecmodulo = 0;
        private long _numsecsubunidad = 0;
        private int _numeromodulo = 0;
        private string _nombre = string.Empty;
        private string _programa = string.Empty;
        private string _versionvigente = string.Empty;
        private int _herramienta = 0;
        private string _fecharegistro = string.Empty;
        private string _usuarioregistro = string.Empty;
        private long _numsecusuarioregistroapp = 0;
        private string _usuarioregistroapp = string.Empty;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecModulo
        {
            get { return _numsecmodulo; }
            set { _numsecmodulo = value; }
        }
        public long NumSecSubUnidad
        {
            get { return _numsecsubunidad; }
            set { _numsecsubunidad = value; }
        }
        public int NumeroModulo
        {
            get { return _numeromodulo; }
            set { _numeromodulo = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Programa
        {
            get { return _programa; }
            set { _programa = value; }
        }
        public string VersionVigente
        {
            get { return _versionvigente; }
            set { _versionvigente = value; }
        }
        public int Herramienta
        {
            get { return _herramienta; }
            set { _herramienta = value; }
        }
        public string FechaRegistro
        {
            get { return _fecharegistro; }
        }
        public string UsuarioRegistro
        {
            get { return _usuarioregistro; }
        }
        public long NumSecUsuarioRegistroApp
        {
            get { return _numsecusuarioregistroapp; }
            set { _numsecusuarioregistroapp = value; }
        }
        public string UsuarioRegistroApp
        {
            get { return _usuarioregistroapp; }
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
        public BD_SAM_Modulos()
        { 
            _numsecmodulo = 0;
            _numsecsubunidad = 0;
            _numeromodulo = 0;
            _nombre = string.Empty;
            _programa = string.Empty;
            _versionvigente = string.Empty;
            _herramienta = 0;
            _fecharegistro = string.Empty;
            _usuarioregistro = string.Empty;
            _numsecusuarioregistroapp = 0;
            _usuarioregistroapp = string.Empty;

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }
        #endregion

        #region Metodos
        public bool Insertar()
        {
            bool blOperacionCorrecta = false;
            blOperacionCorrecta = Validar_Campos(1);
            if (blOperacionCorrecta)
            {
                strSql = " insert into sam_modulos (num_sec_modulo, num_sec_subunidad, numero_modulo";
                strSql += " , nombre, herramienta, programa, version_vigente, num_sec_usuario_reg) values";
                strSql += " ( sam_modulos_sec.nextval";
                strSql += " , " + _numsecsubunidad.ToString();
                strSql += " , " + _numeromodulo.ToString();
                strSql += " , '" + _nombre.Trim() + "'";
                strSql += " , " + _herramienta.ToString();
                strSql += " , '" + _programa.Trim() + "'";
                strSql += " , '" + _versionvigente.Trim() + "'";
                strSql += ", " + _numsecusuarioregistroapp.ToString();
                strSql += " )";

                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.EjecutarSqlTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla SAM_MODULOS. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        public bool Modificar()
        {
            bool blOperacionCorrecta = false;
            blOperacionCorrecta = Validar_Campos(2);
            if (blOperacionCorrecta)
            {
                strSql = " update sam_modulos set ";
                strSql += " num_sec_subunidad = " + _numsecsubunidad.ToString();
                strSql += " , numero_modulo = " + _numeromodulo.ToString();
                strSql += " , nombre = '" + _nombre.Trim() + "'";
                strSql += " , herramienta = " + _herramienta.ToString();
                strSql += " , programa = '" + _programa.Trim() + "'";
                strSql += " , version_vigente = '" + _versionvigente.Trim() + "'";
                strSql += " , usuario_registro = user";
                strSql += " , fecha_registro = sysdate";
                strSql += " , num_sec_usuario_reg = " + _numsecusuarioregistroapp.ToString();
                strSql += " where num_sec_modulo = " + _numsecmodulo.ToString();
                strSql += " and (num_sec_subunidad <> " + _numsecsubunidad.ToString();
                strSql += " or numero_modulo <> " + _numeromodulo.ToString();
                strSql += " or nombre <> '" + _nombre.Trim() + "'";
                strSql += " or herramienta <> " + _herramienta.ToString();
                strSql += " or programa <> '" + _programa.Trim() + "'";
                strSql += " or version_vigente <> '" + _versionvigente.Trim() + "'";
                strSql += " )";

                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.EjecutarSqlTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla SAM_MODULOS. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            strSql = " delete sam_modulos ";
            strSql += " where num_sec_modulo = " + _numsecmodulo.ToString();

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible borrar el dato. Se encontró un error al eliminar en la tabla SAM_MODULOS. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool Ver(string strNSModulo)
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            if (!string.IsNullOrEmpty(strNSModulo))
            {
                strSql = " select a.num_sec_modulo, a.num_sec_subunidad, a.numero_modulo";
                strSql += " , a.nombre, a.herramienta, a.programa, a.version_vigente";
                strSql += " , a.usuario_registro u_reg, to_char(a.fecha_registro,'dd/mm/rrrr hh24:mi:ss') f_reg";
                strSql += " , a.num_sec_usuario_reg";
                strSql += " , b.usuarios_app";
                strSql += " from sam_modulos a";
                strSql += " , (select a.num_sec_usuario, a.num_sec_persona";
                strSql += "   , b.ap_paterno||' '||b.ap_materno||' '||b.nombres usuarios_app";
                strSql += "   from sam_usuarios a, personas b";
                strSql += "   where a.num_sec_persona = b.num_sec) b";
                strSql += " where a.num_sec_modulo = " + strNSModulo;
                strSql += " and a.num_sec_usuario_reg = b.num_sec_usuario";

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
                    _numsecmodulo = Convert.ToInt64(dr["num_sec_modulo"].ToString());
                    _numsecsubunidad = Convert.ToInt64(dr["num_sec_subunidad"].ToString());
                    _numeromodulo = Convert.ToInt16(dr["numero_modulo"].ToString());
                    _nombre = dr["nombre"].ToString();
                    _herramienta = Convert.ToInt16(dr["herramienta"].ToString());
                    _programa = dr["programa"].ToString();
                    _versionvigente = dr["version_vigente"].ToString();
                    _fecharegistro = dr["f_reg"].ToString();
                    _usuarioregistro = dr["u_reg"].ToString();
                    _numsecusuarioregistroapp = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
                    _usuarioregistroapp = dr["usuarios_app"].ToString();
                }
                dt.Dispose();
            }
            if (!blEncontrado)
            {
                _numsecmodulo = 0;
                _numsecsubunidad = 0;
                _numeromodulo = 0;
                _nombre = string.Empty;
                _herramienta = 0;
                _programa = string.Empty;
                _versionvigente = string.Empty;
                _fecharegistro = string.Empty;
                _usuarioregistro = string.Empty;
                _numsecusuarioregistroapp = 0;
                _usuarioregistroapp = string.Empty;
            }
            return blEncontrado;
        }

        public string Query_Grid_ABM1(string strNSSubUnidad)
        {
            string strSql = string.Empty;
            strSql = " select a.num_sec_modulo, a.numero_modulo, a.nombre, a.programa, b.descripcion herramienta_str";
            strSql += " , 'Ver' verdocs, 'Seleccionar' seleccionar ";
            strSql += " from sam_modulos a, dominios b";
            strSql += " where a.num_sec_subunidad = " + strNSSubUnidad;
            strSql += " and b.dominio = 'SAM_HERRAMIENTA'";
            strSql += " and b.valor = a.herramienta";
            strSql += " order by nombre";
            return strSql;
        }

        public string Query_DropDownList1(string strNSSubUnidad)
        {
            string strSql = string.Empty;
            strSql = " select num_sec_modulo, numero_modulo, nombre, nombre||' ('||numero_modulo||')' nombre_desp ";
            strSql += " from sam_modulos where num_sec_subunidad = " + strNSSubUnidad;
            strSql += " order by nombre_desp ";
            return strSql;
        }
        #endregion

        #region Procedimientos y Funciones Locales

        private bool Validar_Campos(int axTipo)
        {
            if (_nombre.Trim().Length < 3 || _nombre.Trim().Length > 100)
            {
                _mensaje = "El nombre del módulo debe contener entre 3 y 100 caracteres.";
                return false;
            }
            if (libCadenas.Texto_Contiene_Caracteres_Especiales(_nombre.Trim(), 3, 1))
            {
                _mensaje = "El nombre del módulo no debe contener caracteres epeciales.";
                return false;
            }
            if (!(_numeromodulo>0 && _numeromodulo<999))
            {
                _mensaje = "El número de módulo debe ser un número entre 1 y 999.";
                return false;
            }
            if (!(_herramienta > 0 && _herramienta < 99))
            {
                _mensaje = "La herramienta debe ser un número entre 1 y 99.";
                return false;
            }
            if (_programa.Trim().Length < 5 || _programa.Trim().Length > 100)
            {
                _mensaje = "El programa debe contener entre 5 y 100 caracteres.";
                return false;
            }
            if (libCadenas.Texto_Contiene_Caracteres_Especiales(_programa.Trim(), 3, 1))
            {
                _mensaje = "El programa no debe contener caracteres epeciales.";
                return false;
            }
            if (_versionvigente.Trim().Length < 1 || _versionvigente.Trim().Length > 10)
            {
                _mensaje = "La versión vigente debe contener entre 1 y 10 caracteres.";
                return false;
            }
            if (libCadenas.Texto_Contiene_Caracteres_Especiales(_versionvigente.Trim(), 3, 1))
            {
                _mensaje = "La versión vigente  no debe contener caracteres epeciales.";
                return false;
            }

            if (!Revisar_Repetido(axTipo))
            {
                return false;
            }
            return true;
        }


        private bool Revisar_Repetido(int axModoPantalla)
        {
            strSql = " select * from sam_modulos";
            strSql += " where num_sec_subunidad = " + _numsecsubunidad.ToString();
            if (axModoPantalla == 2)
            {
                strSql += " and num_sec_modulo <> " + _numsecmodulo.ToString();
                strSql += " and (nombre = '" + _nombre + "'";
                strSql += " or numero_modulo = " + _numeromodulo + ")";
            }
            else
            {
                strSql += " and (nombre = '" + _nombre + "'";
                strSql += " or numero_modulo = " + _numeromodulo + ")";
            }
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count > 0)
            {
                dt.Dispose();
                if (axModoPantalla == 1)
                    _mensaje = "El dato que requiere insertar se encuentra repetido";
                else
                    _mensaje = "El dato que requiere modificar se encuentra repetido";

                return false;
            }
            else
            {
                dt.Dispose();
                return true;
            }
        }

        #endregion
 
    }
}