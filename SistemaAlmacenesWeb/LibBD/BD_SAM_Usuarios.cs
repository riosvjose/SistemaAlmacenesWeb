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
    // Creado por: Milco Cortez; Fecha: 22/04/2015
    // Ultima modificación: Milco Cortez;  Fecha:14/05/2015
    // Descripción: Clase referente a la tabla SAM_USUARIOS
    public class BD_SAM_Usuarios
    {
        #region Variables Locales
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        private string strSql = string.Empty;
        #endregion

        #region Atributos
        // Campos de la tabla SAM_USUARIOS
        private long _numsecusuario = 0;
        private long _numsecpersona = 0;
        private string _usuario = string.Empty;
        private string _login = string.Empty;
        private int _activo = 0;
        private string _fechavigencia = string.Empty;
        private string _fecharegistro = string.Empty;
        private string _usuarioregistro = string.Empty;
        private long _numsecusuarioregistroapp = 0;
        private string _usuarioregistroapp = string.Empty;

        // Campos de la tabla SAM_USUARIOS_CAMBIOSPWD
        private bool _pedircambiopwd = false;

        // Campos de la tabla PERSONAS
        private string _personaci = string.Empty;
        private string _persona = string.Empty;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;


        public long NumSecUsuario
        {
            get { return _numsecusuario; }
            set { _numsecusuario = value; }
        }
        public long NumSecPersona
        {
            get { return _numsecpersona; }
            set { _numsecpersona = value; }
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
        public int Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }
        public string FechaVigencia
        {
            get { return _fechavigencia; }
            set { _fechavigencia = value; }
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

        public bool PedirCambioPWD
        {
            get { return _pedircambiopwd; }
            set { _pedircambiopwd = value; }
        }

        public string PersonaCI
        {
            get { return _personaci; }
            set { _personaci = value; }
        }
        public string Persona
        {
            get { return _persona; }
            set { _persona = value; }
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
        public BD_SAM_Usuarios()
        { 
            _numsecusuario = 0;
            _numsecpersona = 0;
            _usuario = string.Empty;
            _login = string.Empty;
            _activo = 0;
            _fechavigencia = string.Empty;
            _fecharegistro = string.Empty;
            _usuarioregistro = string.Empty;
            _numsecusuarioregistroapp = 0;
            _usuarioregistroapp = string.Empty;

            _pedircambiopwd = false;

            _personaci = string.Empty;
            _persona = string.Empty;

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }
        #endregion

        #region Metodos
        public bool Insertar(bool blAsignarFuncionesPerfil, long lngNSPerfil, bool blObligarCambioPWD)
        {
            bool blOperacionCorrecta = false;
            blOperacionCorrecta = Validar_Campos(1);
            if (blOperacionCorrecta)
            {
                long lngNSUsario = 0;
                int intNumSqls = 1;
                string[] strSqls = new string[2];

                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;

                if (blAsignarFuncionesPerfil || blObligarCambioPWD)
                    lngNSPerfil = OracleBD.Generar_NumSec("sam_usuarios_sec");

                if (blAsignarFuncionesPerfil)
                {
                    strSql = Sql_Asignar_Funciones_Perfil(lngNSUsario, lngNSPerfil, _numsecusuarioregistroapp);
                    if (!string.IsNullOrEmpty(strSql))
                    {
                        strSqls[intNumSqls] = strSql;
                        intNumSqls++;
                    }
                }
                if (blObligarCambioPWD)
                {
                    strSql = Sql_Obligar_CambioPWD(lngNSUsario, _numsecusuarioregistroapp);
                    if (!string.IsNullOrEmpty(strSql))
                    {
                        strSqls[intNumSqls] = strSql;
                        intNumSqls++;
                    }
                }


                strSql = "insert into sam_usuarios (num_sec_usuario, num_sec_persona, usuario, login, activo, fecha_vigencia, num_sec_usuario_reg) values";
                if (blAsignarFuncionesPerfil)
                    strSql += " (" + lngNSPerfil.ToString();
                else
                    strSql += " (sam_usuarios_sec.nextval";
                strSql += " , " + _numsecpersona.ToString();
                strSql += " , '" + _usuario.Trim() + "'";
                strSql += " , '" + _login.Trim().ToUpper() + "'";
                strSql += " , " + _activo.ToString();
                strSql += " , to_date('" + _fechavigencia.Trim() + "','dd/mm/rrrr')";
                strSql += " , " + _numsecusuarioregistroapp.ToString();
                strSql += " )";

                strSqls[0] = strSql;

                OracleBD.NumSqls = intNumSqls;
                OracleBD.ListaSqls = strSqls;
                OracleBD.EjecutarSqlsTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla SAM_USUARIOS. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        public string Sql_Asignar_Funciones_Perfil(long lngNSUsuario, long lngNSPerfil, long lngNSUsuarioRegApp)
        {
            string strSql = string.Empty;
            if (lngNSUsuario>=0 && lngNSPerfil >= 0)
            {
                strSql = " insert into sam_usuarios_funciones (num_sec_usuario, num_sec_funcion, num_sec_usuario_reg)";
                strSql += " select " + lngNSUsuario.ToString() + " ns_usuario";
                strSql += " , num_sec_funcion";
                strSql += " , " + lngNSUsuarioRegApp.ToString() + " ns_usuario_reg";
                strSql += " from sam_funciones_perfiles";
                strSql += " where num_sec_perfil = " + lngNSPerfil.ToString();
            }
            return strSql;
        }

        public string Sql_Obligar_CambioPWD(long lngNSUsuario, long lngNSUsuarioRegApp)
        {
            string strSql = string.Empty;
            if (lngNSUsuario >= 0)
            {
                strSql = " insert into sam_usuarios_cambiospwd (num_sec_cambiopwd, num_sec_usuario, num_sec_usuario_reg) values ";
                strSql += " (sam_usuarios_cambiospwd_sec.nextval";
                strSql += " , " + lngNSUsuario.ToString();
                strSql += " , " + lngNSUsuarioRegApp.ToString() + ")";
            }
            return strSql;
        }

        public bool Modificar()
        {
            bool blOperacionCorrecta = false;
            blOperacionCorrecta = Validar_Campos(2);
            if (blOperacionCorrecta)
            {
                strSql = "update sam_usuarios set ";
                strSql += " num_sec_persona = " + _numsecpersona.ToString();
                strSql += " , usuario = '" + _usuario.Trim() + "'";
                strSql += " , login = '" + _login.Trim().ToUpper() + "'";
                strSql += " , activo = " + _activo.ToString();
                strSql += " , fecha_vigencia = to_date('" + _fechavigencia.Trim() + "','dd/mm/rrrr')";
                strSql += " , usuario_registro = user";
                strSql += " , fecha_registro = sysdate";
                strSql += " , num_sec_usuario_reg = " + _numsecusuarioregistroapp.ToString();
                strSql += " where num_sec_usuario = " + _numsecusuario.ToString();
                strSql += " and (num_sec_persona <> " + _numsecpersona.ToString();
                strSql += " or usuario <> '" + _usuario.Trim() + "'";
                strSql += " or login <> '" + _login.Trim().ToUpper() + "'";
                strSql += " or activo <> " + _activo.ToString();
                strSql += " or fecha_vigencia <> to_date('" + _fechavigencia.Trim() + "','dd/mm/rrrr')";
                strSql += " )";

                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.EjecutarSqlTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla SAM_USUARIOS. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            strSql = "delete sam_usuarios ";
            strSql += " where num_sec_usuario = " + _numsecusuario.ToString();

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible borrar el dato. Se encontró un error al eliminar en la tabla SAM_USUARIOS. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool Ver(string strNSUsuario)
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            if (!string.IsNullOrEmpty(strNSUsuario))
            {
                strSql = "select a.num_sec_usuario, a.num_sec_persona, a.usuario, a.login, a.activo";
                strSql += " , to_char(a.fecha_vigencia,'dd/mm/rrrr') f_vig";
                strSql += " , a.usuario_registro u_reg, to_char(a.fecha_registro,'dd/mm/rrrr hh24:mi:ss') f_reg";
                strSql += " , a.num_sec_usuario_reg";
                strSql += " , decode(nvl(d.num_cambios_pendientes,0),0,0,1) cambio_pwd";
                strSql += " , c.cedula_identidad persona_ci";
                strSql += " , c.ap_paterno||' '||c.ap_materno||' '||c.nombres persona";
                strSql += " , b.usuarios_app";
                strSql += " from sam_usuarios a, personas c";
                strSql += " , (select a.num_sec_usuario, a.num_sec_persona";
                strSql += "    , b.ap_paterno||' '||b.ap_materno||' '||b.nombres usuarios_app";
                strSql += "    from sam_usuarios a, personas b";
                strSql += "    where a.num_sec_persona = b.num_sec) b";
                strSql += " , (select num_sec_usuario, count(0) num_cambios_pendientes";
                strSql += "    from sam_usuarios_cambiospwd";
                strSql += "    where num_sec_usuario = " + strNSUsuario;
                strSql += "    and fecha_cambio is null";
                strSql += "    group by num_sec_usuario ";
                strSql += "    ) d";
                strSql += " where a.num_sec_usuario = " + strNSUsuario;
                strSql += " and a.num_sec_persona = c.num_sec";
                strSql += " and a.num_sec_usuario_reg = b.num_sec_usuario";
                //strSql += " and a.activo = 1";
                //strSql += " and a.fecha_vigencia >= trunc(sysdate)";
                strSql += " and a.num_sec_usuario = d.num_sec_usuario(+)";
                strSql += " order by persona, usuario";

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
                    _numsecpersona = Convert.ToInt64(dr["num_sec_persona"].ToString());
                    _usuario = dr["usuario"].ToString();
                    _login = dr["login"].ToString();
                    _activo = Convert.ToInt16(dr["activo"].ToString());
                    _fechavigencia = dr["f_vig"].ToString();
                    _fecharegistro = dr["f_reg"].ToString();
                    _usuarioregistro = dr["u_reg"].ToString();
                    _numsecusuarioregistroapp = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
                    _usuarioregistroapp = dr["usuarios_app"].ToString();
                    if (dr["cambio_pwd"].ToString() == "0")
                        _pedircambiopwd = false;
                    else
                        _pedircambiopwd = true;
                    _personaci = dr["persona_ci"].ToString();
                    _persona = dr["persona"].ToString();
                }
                dt.Dispose();
            }
            if (!blEncontrado)
            {
                _numsecusuario = 0;
                _numsecpersona = 0;
                _usuario = string.Empty;
                _login = string.Empty;
                _activo = 0;
                _fechavigencia = string.Empty;
                _fecharegistro = string.Empty;
                _usuarioregistro = string.Empty;
                _numsecusuarioregistroapp = 0;
                _usuarioregistroapp = string.Empty;
                _pedircambiopwd = false;
                _personaci = string.Empty;
                _persona = string.Empty;
            }
            return blEncontrado;
        }

        public string Query_Grid_ABM1(bool blSoloVigentes, string strCriterioBusqueda)
        {
            string strSql = string.Empty;
            strSql = "select a.num_sec_usuario, a.usuario, a.login";
            strSql += " , decode(a.activo,1,'Si','No') activo_str";
            strSql += " , to_char(a.fecha_vigencia,'dd/mm/rrrr') f_vig";
            strSql += " , b.ap_paterno||' '||b.ap_materno||' '||b.nombres persona";
            strSql += " , 'Seleccionar' seleccionar";
            strSql += " from sam_usuarios a, personas b";
            strSql += " where a.num_sec_persona = b.num_sec";
            if (!string.IsNullOrEmpty(strCriterioBusqueda))
            {
                strSql += " and (a.usuario like '" + strCriterioBusqueda + "'";
                strSql += " or b.ap_paterno||' '||b.ap_materno||' '||b.nombres like '" + strCriterioBusqueda + "')";
            }
            if (blSoloVigentes)
            {
                strSql += " and a.activo = 1";
                strSql += " and a.fecha_vigencia >= trunc(sysdate)";
            }
            strSql += " order by persona, usuario";
            return strSql;
        }

        public string Query_DropDownList1(bool blSoloVigentes)
        {
            string strSql = string.Empty;
            strSql = " select a.num_sec_usuario, b.ap_paterno||' '||b.ap_materno||' '||b.nombres||' ('||a.usuario||')' usuario_str";
            strSql += " from sam_usuarios a, personas b";
            strSql += " where a.num_sec_persona = b.num_sec";
            if (blSoloVigentes)
            {
                strSql += " and a.activo = 1";
                strSql += " and a.fecha_vigencia >= trunc(sysdate)";
            }
            strSql += " order by usuario_str";
            return strSql;
        }

        #endregion

        #region Procedimientos y Funciones Locales
        private bool Validar_Campos(int axTipo)
        {
            if (_usuario.Trim().Length < 2 || _usuario.Trim().Length > 60)
            {
                _mensaje = "El usuario debe contener entre 2 y 60 caracteres.";
                return false;
            }
            if (libCadenas.Texto_Contiene_Caracteres_Especiales(_usuario.Trim(), 3, 1))
            {
                _mensaje = "El usuario no debe contener caracteres epeciales.";
                return false;
            }
            if (_login.Trim().Length < 2 || _login.Trim().Length > 32)
            {
                _mensaje = "El login debe contener entre 2 y 32 caracteres.";
                return false;
            }
            if (libCadenas.Texto_Contiene_Caracteres_Especiales(_login.Trim(), 3, 1))
            {
                _mensaje = "El login no debe contener caracteres epeciales.";
                return false;
            }

            if (!libCadenas.Validar_Fecha_Hora(_fechavigencia.Trim(), 1))
            {
                _mensaje = "La fecha de vigencia debe tener el formato DD/MM/AAAA.";
                return false;
            }

            if (_numsecpersona <= 0)
            {
                _mensaje = "El num_sec_persona debe ser mayor o igual a 0.";
                return false;
            }
            if (!(_activo == 0 || _activo == 1))
            {
                _mensaje = "El activo debe ser 0 o 1.";
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
            strSql = " select * from sam_perfiles";
            if (axModoPantalla == 2)
            {
                strSql += " where num_sec_usuario <> " + _numsecusuario.ToString();
                strSql += " and (usuario = '" + _usuario.Trim() + "'";
                strSql += " or login = '" + _login.Trim().ToUpper() + "'";
            }
            else
            {
                strSql += " where usuario = '" + _usuario.Trim() + "'";
                strSql += " or login = '" + _login.Trim().ToUpper() + "'";
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

        public DataTable ObtenerUsuariosSugeridos(string cad)
        {
            string strSql = string.Empty;
            strSql = "select u.num_sec_usuario, u.usuario, p.ap_paterno||' '||p.ap_materno||' '||p.nombres as persona " +
                     " from sam_usuarios u, personas p" +
                     " where u.usuario like '%" +cad+"%'"+
                     " and u.num_sec_persona=p.num_sec" +
                     " order by p.ap_paterno||' '||p.ap_materno||' '||p.nombres asc";
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            return dt;
        }
        #endregion

    }


}