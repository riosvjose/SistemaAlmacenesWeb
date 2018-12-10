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
    // Creado por: Milco Cortez; Fecha: 19/05/2015
    // Ultima modificación: Milco Cortez;  Fecha:19/05/2015
    //                      Willy Tenorio; Fecha:05/03/2018
    // Descripción: Clase referente a la tabla SAM_PARAMETROS_PERSONAS
    public class BD_SAM_Parametros_Personas
    {
        #region Variables Locales
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        private string strSql = string.Empty;
        #endregion

        #region Atributos
        // Campos de la tabla SAM_PARAMETROS_PERSONAS
        private long _num_sec_persona = 0;
        private long _num_sec_parametro = 0;
        private string _valor = string.Empty;
        private string _fecha_registro = string.Empty;
        private string _usuario_registro = string.Empty;
        private long _num_sec_usuario_reg = 0;

        // Campos de la tabla SAM_PARAMETROS
        private int _tipo = 0;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecParametro
        {
            get { return _num_sec_parametro; }
            set { _num_sec_parametro = value; }
        }
        public long NumSecPersona
        {
            get { return _num_sec_persona; }
            set { _num_sec_persona = value; }
        }
        public string Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
        public string FechaRegistro
        {
            get { return _fecha_registro; }
        }
        public string UsuarioRegistro
        {
            get { return _usuario_registro; }
        }
        public long NumSecUsuarioRegistroApp
        {
            get { return _num_sec_usuario_reg; }
            set { _num_sec_usuario_reg = value; }
        }

        public int Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
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
        public BD_SAM_Parametros_Personas()
        {
            _num_sec_persona = 0;
            _num_sec_parametro = 0;
            _valor = string.Empty;
            _fecha_registro = string.Empty;
            _usuario_registro = string.Empty;
            _num_sec_usuario_reg = 0;

            _tipo = 0;

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
                strSql = "insert into sam_parametros_personas (num_sec_persona, num_sec_parametro, valor";
                strSql += " , num_sec_usuario_reg ) values";
                strSql += " ( " + _num_sec_persona.ToString();
                strSql += " , " + _num_sec_parametro.ToString();
                strSql += " , '" + _valor.Trim() + "'";
                strSql += ", " + _num_sec_usuario_reg.ToString();
                strSql += " )";

                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.EjecutarSqlTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla SAM_PARAMETROS_PERSONAS. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        public bool Modificar()
        {
            bool blOperacionCorrecta = false;
            blOperacionCorrecta = Validar_Campos(2);
            if (blOperacionCorrecta)
            {
                strSql = "update sam_parametros_personas set ";
                strSql += " valor = '" + _valor.Trim() + "'";
                strSql += " , usuario_registro = user";
                strSql += " , fecha_registro = sysdate";
                strSql += " , num_sec_usuario_reg = " + _num_sec_usuario_reg.ToString();
                strSql += " where num_sec_persona = " + _num_sec_persona.ToString();
                strSql += " and num_sec_parametro = " + _num_sec_parametro.ToString();
                strSql += " and (valor <> '" + _valor.Trim() + "'";
                strSql += " )";

                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.EjecutarSqlTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla SAM_PARAMETROS_PERSONAS. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            strSql = "delete sam_parametros_personas ";
            strSql += " where num_sec_persona = " + _num_sec_persona.ToString();
            strSql += " and num_sec_parametro = " + _num_sec_parametro.ToString();

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible borrar el dato. Se encontró un error al eliminar en la tabla SAM_PARAMETROS_PERSONAS. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool Ver(string strNSpersona, string strNSParametro)
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            if (!string.IsNullOrEmpty(strNSParametro))
            {
                strSql = " select a.num_sec_parametro, a.num_sec_persona, a.valor";
                strSql += " , a.usuario_registro u_reg, to_char(a.fecha_registro,'dd/mm/rrrr hh24:mi:ss') f_reg";
                strSql += " , a.num_sec_usuario_reg";
                strSql += " , b.usuarios_app";
                strSql += " , c.cedula_identidad, c.ap_paterno||' '||c.ap_materno||' '||c.nombres persona";
                strSql += " from sam_parametros_personas a, personas c";
                strSql += " , (select a.num_sec_usuario, a.num_sec_persona";
                strSql += "   , b.ap_paterno||' '||b.ap_materno||' '||b.nombres usuarios_app";
                strSql += "   from sam_usuarios a, personas b";
                strSql += "   where a.num_sec_persona = b.num_sec) b";
                strSql += " where a.num_sec_persona = " + strNSpersona;
                strSql += " and a.num_sec_parametro = " + strNSParametro;
                strSql += " and a.num_sec_persona = c.num_sec";
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
                    _num_sec_persona = Convert.ToInt64(dr["num_sec_persona"].ToString());
                    _num_sec_parametro = Convert.ToInt64(dr["num_sec_parametro"].ToString());
                    _valor = dr["valor"].ToString();
                    _fecha_registro = dr["f_reg"].ToString();
                    _usuario_registro = dr["u_reg"].ToString();
                    _num_sec_usuario_reg = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
                }
                dt.Dispose();
            }
            if (!blEncontrado)
            {
                _num_sec_persona = 0;
                _num_sec_parametro = 0;
                _valor = string.Empty;
                _fecha_registro = string.Empty;
                _usuario_registro = string.Empty;
                _num_sec_usuario_reg = 0;
            }
            return blEncontrado;
        }

        public string Query_Grid_ABM1(string strNSParametro)
        {
            string strSql = string.Empty;

            strSql = "select a.num_sec_persona, a.valor";
            strSql += " , b.cedula_identidad, b.ap_paterno||' '||b.ap_materno||' '||b.nombres persona";
            strSql += " , 'Seleccionar' seleccionar";
            strSql += " from sam_parametros_personas a, personas b";
            strSql += " where a.num_sec_parametro = " + strNSParametro;
            strSql += " and a.num_sec_persona = b.num_sec";
            strSql += " order by persona";

            return strSql;
        }

        public DataTable DTParametrosPersonaPorModulo(string NSModulo)
        {
            strSql = "select pm.codigo, pm.descripcion, pp.valor " +
                     "from sam_parametros_personas pp, sam_parametros_modulos pm " +
                     "where pm.num_sec_modulo = " + NSModulo + " " +
                     "and pp.num_sec_persona = " + _num_sec_persona.ToString().Trim() + " " +
                     "and pp.num_sec_parametro = pm.num_sec_parametro";

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
            if (_valor.Trim().Length < 1 || _valor.Trim().Length > 150)
            {
                _mensaje = "El valor debe contener entre 1 y 150 caracteres.";
                return false;
            }

            switch (_tipo)
            {
                case 1:     //Numérico
                    if (!libCadenas.Cadena_Es_Numero(_valor.Trim(), 2))
                    {
                        _mensaje = "El valor debe ser numérico.";
                        return false;
                    }
                    break;
                case 2:     //Caracter
                    if (libCadenas.Texto_Contiene_Caracteres_Especiales(_valor.Trim(), 0, 1))
                    {
                        _mensaje = "El valor no debe contener caracteres epeciales.";
                        return false;
                    }
                    break;
                case 3:     //Fecha
                    if (!libCadenas.Validar_Fecha_Hora(_valor.Trim(), 1))
                    {
                        if (!libCadenas.Validar_Fecha_Hora(_valor.Trim(), 2))
                        {
                            if (!libCadenas.Validar_Fecha_Hora(_valor.Trim(), 3))
                            {
                                _mensaje = "La valor debe estar en formato de fecha.";
                                return false;
                            }
                        }
                    }
                    break;

                default:
                    _mensaje = "El tipo de parámetro no está definido correctamente.";
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
                strSql = " select valor from sam_parametros_personas";
                strSql += " where num_sec_parametro = " + _num_sec_parametro.ToString();
                strSql += " and num_sec_persona = " + _num_sec_persona.ToString();
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