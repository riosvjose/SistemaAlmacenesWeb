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
    // Creado por: Milco Cortez; Fecha: 11/05/2015
    // Ultima modificación: Milco Cortez;  Fecha: 14/05/2015
    // Descripción: Clase referente a la tabla SAM_USUARIOS_SUBDEPTOS
    public class BD_SAM_Usuarios_Subdeptos
    {
        #region Variables Locales
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        private string strSql = string.Empty;
        #endregion

        #region Atributos
        // Campos de la tabla SAM_USUARIOS_SUBDEPTOS
        private long _numsecusuario = 0;
        private long _numsecsubdepartamento = 0;
        private string _fechaexpiracion = string.Empty;
        private string _fecharegistro = string.Empty;
        private string _usuarioregistro = string.Empty;
        private long _numsecusuarioregistroapp = 0;
        private string _usuarioregistroapp = string.Empty;

        // Campos de la tabla PERSONAS
        private string _personanombre = string.Empty;

        // Campos de la tabla SAM_USUARIOS
        private long _numsecpersona = 0;
        private string _usuario = string.Empty;
        private string _login = string.Empty;

        // Campos de la tabla GEN_SUBDEPARTAMENTOS
        private string _nombresubdepartamento = string.Empty;

        // Campos de la tabla GEN_DEPARTAMENTOS
        private long _numsecdepartamento = 0;
        private string _nombredepartamento = string.Empty;

        // Campos de la tabla GEN_FACULTADES
        private long _numsecfacultad = 0;
        private string _nombrefacultad = string.Empty;


        // Campos de la tabla GEN_SUBUNIDADES
        private long _numsecsubunidad = 0;
        private string _nombresubunidad = string.Empty;

        // Campos de la tabla GEN_UNIDADES
        private string _nombreunidad = string.Empty;


        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;
        private string _ip_nuevo = string.Empty;

        public long NumSecUsuario
        {
            get { return _numsecusuario; }
            set { _numsecusuario = value; }
        }
        public long NumSecSubdepartamento
        {
            get { return _numsecsubdepartamento; }
            set { _numsecsubdepartamento = value; }
        }
        public string FechaExpiracion
        {
            get { return _fechaexpiracion; }
            set { _fechaexpiracion = value; }
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

        public long NumSecPersona
        {
            get { return _numsecpersona; }
            set { _numsecpersona = value; }
        }
        public string Persona_Nombre
        {
            get { return _personanombre; }
            set { _personanombre = value; }
        }
        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        public long NumSecDepartamento
        {
            get { return _numsecdepartamento; }
            set { _numsecdepartamento = value; }
        }
        public long NumSecFacultad
        {
            get { return _numsecfacultad; }
            set { _numsecfacultad = value; }
        }

        public long NumSecSubUnidad
        {
            get { return _numsecsubunidad; }
            set { _numsecsubunidad = value; }
        }

        public string NombreSubDepartamento
        {
            get { return _nombresubdepartamento; }
        }
        public string NombreDepartamento
        {
            get { return _nombredepartamento; }
        }
        public string NombreFacultad
        {
            get { return _nombrefacultad; }
        }
        public string NombreSubUnidad
        {
            get { return _nombresubunidad; }
        }
        public string NombreUnidad
        {
            get { return _nombreunidad; }
        }


        #endregion

        #region Constructores
        public BD_SAM_Usuarios_Subdeptos()
        { 
            _numsecusuario = 0;
            _numsecsubdepartamento = 0;
            _fechaexpiracion = string.Empty;
            _fecharegistro = string.Empty;
            _usuarioregistro = string.Empty;
            _numsecusuarioregistroapp = 0;
            _usuarioregistroapp = string.Empty;

            _personanombre = string.Empty;
            _numsecpersona = 0;
            _usuario = string.Empty;
            _login = string.Empty;

            _numsecdepartamento = 0;
            _numsecfacultad = 0;
            _numsecsubunidad = 0;

            _mensaje = string.Empty;
            _strconexion = string.Empty;
            _ip_nuevo = string.Empty;
        }
        #endregion

        #region Metodos
        public bool Insertar()
        {
            bool blOperacionCorrecta = false;
            blOperacionCorrecta = Validar_Campos(1);
            if (blOperacionCorrecta)
            {
                strSql = " insert into sam_usuarios_subdeptos (num_sec_usuario, num_sec_subdepartamento, fecha_expiracion";
                strSql += " , num_sec_usuario_reg) values";
                strSql += " ( " + _numsecusuario.ToString();
                strSql += " , " + _numsecsubdepartamento.ToString();
                strSql += " , to_date('" + _fechaexpiracion.Trim() + "','dd/mm/rrrr')";
                strSql += ", " + _numsecusuarioregistroapp.ToString();
                strSql += " )";

                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.EjecutarSqlTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla SAM_USUARIOS_SUBDEPTOS. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        public bool Modificar()
        {
            bool blOperacionCorrecta = false;
            blOperacionCorrecta = Validar_Campos(2);
            if (blOperacionCorrecta)
            {
                strSql = " update sam_usuarios_subdeptos set";
                strSql += " fecha_expiracion = to_date('" + _fechaexpiracion.Trim() + "','dd/mm/rrrr')";
                strSql += " , usuario_registro = user";
                strSql += " , fecha_registro = sysdate";
                strSql += " , num_sec_usuario_reg = " + _numsecusuarioregistroapp.ToString();
                strSql += " where num_sec_usuario = " + _numsecusuario.ToString();
                strSql += " and num_sec_subdepartamento = " + _numsecsubdepartamento.ToString();
                strSql += " and fecha_expiracion <> to_date('" + _fechaexpiracion.Trim() + "','dd/mm/rrrr')";

                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.EjecutarSqlTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla SAM_USUARIOS_SUBDEPTOS. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            strSql = " delete sam_usuarios_subdeptos";
            strSql += " where num_sec_usuario = " + _numsecusuario.ToString();
            strSql += " and num_sec_subdepartamento = " + _numsecsubdepartamento.ToString();

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible borrar el dato. Se encontró un error al eliminar en la tabla SAM_USUARIOS_SUBDEPTOS. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool Ver(string strNSSubDepto, string strNSUsuario)
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            if (!string.IsNullOrEmpty(strNSSubDepto) || !string.IsNullOrEmpty(strNSUsuario))
            {

                strSql = "select d.num_sec_facultad, d.nombre facultad, d.num_sec_subunidad";
                strSql += " , c.num_sec_departamento, c.nombre depto";
                strSql += " , b.num_sec_subdepartamento, b.nombre subdepto";
                strSql += " , e.nombre subunidad, f.nombre unidad";
                strSql += " , a.num_sec_usuario, to_char(a.fecha_expiracion,'dd/mm/rrrr') f_exp";
                strSql += " , a.usuario_registro u_reg, to_char(a.fecha_registro,'dd/mm/rrrr hh24:mi:ss') f_reg";
                strSql += " , a.num_sec_usuario_reg";
                strSql += " , u1.num_sec_persona, u1.persona_nombre, u1.usuario, u1.login";
                strSql += " , ur.usuario_app";
                strSql += " from sam_usuarios_subdeptos a, gen_subdepartamentos b, gen_departamentos c, gen_facultades d";
                strSql += " , gen_subunidades e, gen_unidades f";
                strSql += " , (select a.num_sec_usuario, a.num_sec_persona, a.usuario, a.login";
                strSql += "   , b.ap_paterno||' '||b.ap_materno||' '||b.nombres persona_nombre";
                strSql += "   from sam_usuarios a, personas b";
                strSql += "   where a.num_sec_persona = b.num_sec) u1";
                strSql += " , (select a.num_sec_usuario, a.num_sec_persona";
                strSql += "   , b.ap_paterno||' '||b.ap_materno||' '||b.nombres usuario_app";
                strSql += "   from sam_usuarios a, personas b";
                strSql += "   where a.num_sec_persona = b.num_sec) ur";
                strSql += " where a.num_sec_usuario = " + strNSUsuario;
                strSql += " and a.num_sec_subdepartamento = " + strNSSubDepto;
                strSql += " and b.num_sec_subdepartamento = a.num_sec_subdepartamento";
                strSql += " and b.num_sec_departamento = c.num_sec_departamento";
                strSql += " and c.num_sec_facultad = d.num_sec_facultad";
                strSql += " and d.num_sec_subunidad = e.num_sec_subunidad";
                strSql += " and e.num_sec_unidad = f.num_sec_unidad";
                strSql += " and a.num_sec_usuario = u1.num_sec_usuario";
                strSql += " and a.num_sec_usuario_reg = ur.num_sec_usuario";

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
                    _numsecusuario = Convert.ToInt64(dr["num_sec_usuario"].ToString());
                    _numsecsubdepartamento = Convert.ToInt64(dr["num_sec_subdepartamento"].ToString());
                    _fechaexpiracion = dr["f_exp"].ToString();
                    _fecharegistro = dr["f_reg"].ToString();
                    _usuarioregistro = dr["u_reg"].ToString();
                    _numsecusuarioregistroapp = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
                    _usuarioregistroapp = dr["usuario_app"].ToString();

                    _numsecpersona = Convert.ToInt64(dr["num_sec_persona"].ToString());
                    _personanombre = dr["persona_nombre"].ToString();
                    _usuario = dr["usuario"].ToString();
                    _login = dr["login"].ToString();

                    _numsecdepartamento = Convert.ToInt64(dr["num_sec_departamento"].ToString());
                    _numsecfacultad = Convert.ToInt64(dr["num_sec_facultad"].ToString());
                    _numsecsubunidad = Convert.ToInt64(dr["num_sec_subunidad"].ToString());

                    _nombresubdepartamento = dr["subdepto"].ToString();
                    _nombredepartamento = dr["depto"].ToString();
                    _nombrefacultad = dr["facultad"].ToString();
                    _nombresubunidad = dr["subunidad"].ToString();
                    _nombreunidad = dr["unidad"].ToString();

                }
                dt.Dispose();
            }
            if (!blEncontrado)
            {
                _numsecusuario = 0;
                _numsecsubdepartamento = 0;
                _fechaexpiracion = string.Empty;
                _fecharegistro = string.Empty;
                _usuarioregistro = string.Empty;
                _numsecusuarioregistroapp = 0;
                _usuarioregistroapp = string.Empty;

                _numsecpersona = 0;
                _personanombre = string.Empty;
                _usuario = string.Empty;
                _login = string.Empty;
                _numsecdepartamento = 0;
                _numsecfacultad = 0;
                _numsecsubunidad = 0;

                _nombresubdepartamento = string.Empty;
                _nombredepartamento = string.Empty;
                _nombrefacultad = string.Empty;
                _nombresubunidad = string.Empty;
                _nombreunidad = string.Empty;
            }
            return blEncontrado;
        }

        public string Query_Grid_Usuarios1(string strNSSubDepto)
        {
            string strSql = string.Empty;
            strSql = " select a.num_sec_usuario, a.num_sec_subdepartamento";
            strSql += " , to_char(a.fecha_expiracion,'dd/mm/rrrr') f_exp";
            strSql += " , to_char(a.fecha_registro,'dd/mm/rrrr hh24:mi') f_reg";
            strSql += " , b.num_sec_persona, b.usuario, b.login";
            strSql += " , c.ap_paterno||' '||c.ap_materno||' '||c.nombres persona";
            strSql += " , 'Seleccionar' seleccionar";
            strSql += " from sam_usuarios_subdeptos a, sam_usuarios b, personas c";
            strSql += " where a.num_sec_subdepartamento = " + strNSSubDepto;
            strSql += " and a.num_sec_usuario = b.num_sec_usuario";
            strSql += " and b.num_sec_persona = c.num_sec";
            strSql += " order by persona, usuario";
            return strSql;
        }

        public string Query_Grid_Subdeptos1(string strNSUsuario, string strNSSubUnidad)
        {
            string strSql = string.Empty;
            strSql = "select d.num_sec_facultad, d.nombre facultad";
            strSql += " , c.num_sec_departamento, c.nombre depto";
            strSql += " , b.num_sec_subdepartamento, b.nombre subdepto";
            strSql += " , a.num_sec_usuario, to_char(a.fecha_expiracion,'dd/mm/rrrr') f_exp";
            strSql += " , 'Seleccionar' seleccionar";
            strSql += " from gen_subdepartamentos b, gen_departamentos c, gen_facultades d";
            strSql += " , (select * from sam_usuarios_subdeptos";
            strSql += "   where num_sec_usuario = " + strNSUsuario;
            strSql += "   ) a";
            strSql += " where d.num_sec_subunidad = " + strNSSubUnidad;
            strSql += " and c.num_sec_facultad = d.num_sec_facultad";
            strSql += " and b.num_sec_departamento = c.num_sec_departamento";
            strSql += " and b.num_sec_subdepartamento = a.num_sec_subdepartamento";
            strSql += " order by d.nombre, c.nombre, b.nombre";

            return strSql;
        }

        public DataTable DTUsuarioSubSeptos(string strNSUsuario, string strNSSubUnidad)
        {
            strSql = Query_Grid_Subdeptos1(strNSUsuario, strNSSubUnidad);
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }
        #endregion

        #region Procedimientos y Funciones Locales
        private bool Validar_Campos(int axTipo)
        {
            if (_fechaexpiracion.Trim().Length > 0)
            {
                if (!libCadenas.Validar_Fecha_Hora(_fechaexpiracion.Trim(), 1))
                {
                    _mensaje = "La dirección IP debe contener entre 7 y 39 caracteres en formato IPv4.";
                    return false;
                }
            }
            else
            {
                _mensaje = "Debe ingresar la fecha de expiración de acceso.";
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
            if (axModoPantalla == 1)
            {
                strSql = " select * from sam_usuarios_subdeptos";
                strSql += " where num_sec_usuario = " + _numsecusuario.ToString();
                strSql += " and num_sec_subdepartamento = " + _numsecsubdepartamento.ToString();

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
            return true;
        }
        #endregion

    }
}