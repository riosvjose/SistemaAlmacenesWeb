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
    // Creado por: Milco Cortes; Fecha: 18/05/2015
    // Ultima modificación: Milco Cortes;  Fecha:12/04/2018
    // Descripción: Clase referente a la tabla SAM_PARAMETROS_SEMESTRES
    public class BD_SAM_Parametros_Semestres
    {
        #region Variables Locales
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        private string strSql = string.Empty;
        #endregion

        #region Atributos
        // Campos de la tabla SAM_PARAMETROS_SEMESTRES
        private long _numsecsemestre = 0;
        private long _numsecparametro = 0;
        private string _valor = string.Empty;
        private string _fecharegistro = string.Empty;
        private string _usuarioregistro = string.Empty;
        private long _numsecusuarioregistroapp = 0;
        private string _usuarioregistroapp = string.Empty;

        // Campos de la tabla SAM_PARAMETROS_MODULOS
        private string _param_codigo = string.Empty;
        private string _param_descripcion = string.Empty;
        private string _param_alcance_str = string.Empty;
        private string _param_tipo_str = string.Empty;
        private int _param_tipo = 0;
        private string _param_valor_def = string.Empty;
        private string _param_observaciones = string.Empty;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecParametro
        {
            get { return _numsecparametro; }
            set { _numsecparametro = value; }
        }
        public long NumSecSemestre
        {
            get { return _numsecsemestre; }
            set { _numsecsemestre = value; }
        }
        public string Valor
        {
            get { return _valor; }
            set { _valor = value; }
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

        public string Param_Codigo
        {
            get { return _param_codigo; }
        }
        public string Param_Descripcion
        {
            get { return _param_descripcion; }
        }
        public string Param_Alcance_Str
        {
            get { return _param_alcance_str; }
        }
        public string Param_Tipo_Str
        {
            get { return _param_tipo_str; }
        }
        public int Param_Tipo
        {
            get { return _param_tipo; }
        }
        public string Param_Valor_Def
        {
            get { return _param_valor_def; }
        }
        public string Param_Observaciones
        {
            get { return _param_observaciones; }
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
        public BD_SAM_Parametros_Semestres()
        {
            _numsecsemestre = 0;
            _numsecparametro = 0;
            _valor = string.Empty;
            _fecharegistro = string.Empty;
            _usuarioregistro = string.Empty;
            _numsecusuarioregistroapp = 0;
            _usuarioregistroapp = string.Empty;

            _param_codigo = string.Empty;
            _param_descripcion = string.Empty;
            _param_alcance_str = string.Empty;
            _param_tipo_str = string.Empty;
            _param_tipo = 0;
            _param_valor_def = string.Empty;
            _param_observaciones = string.Empty;

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }
        #endregion

        #region Metodos
        public bool Insertar(int intTipoParametro)
        {
            bool blOperacionCorrecta = false;
            blOperacionCorrecta = Validar_Campos(1, intTipoParametro);
            if (blOperacionCorrecta)
            {
                strSql = "insert into sam_parametros_semestres (num_sec_semestre, num_sec_parametro, valor";
                strSql += " , num_sec_usuario_reg ) values";
                strSql += " ( " + _numsecsemestre.ToString();
                strSql += " , " + _numsecparametro.ToString();
                strSql += " , '" + _valor.Trim() + "'";
                strSql += ", " + _numsecusuarioregistroapp.ToString();
                strSql += " )";

                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.EjecutarSqlTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla SAM_PARAMETROS_SEMESTRES. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        public bool Modificar(int intTipoParametro)
        {
            bool blOperacionCorrecta = false;
            blOperacionCorrecta = Validar_Campos(2, intTipoParametro);
            if (blOperacionCorrecta)
            {
                strSql = "update sam_parametros_semestres set ";
                strSql += " valor = '" + _valor.Trim() + "'";
                strSql += " , usuario_registro = user";
                strSql += " , fecha_registro = sysdate";
                strSql += " , num_sec_usuario_reg = " + _numsecusuarioregistroapp.ToString();
                strSql += " where num_sec_semestre = " + _numsecsemestre.ToString();
                strSql += " and num_sec_parametro = " + _numsecparametro.ToString();
                strSql += " and (valor <> '" + _valor.Trim() + "'";
                strSql += " )";

                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.EjecutarSqlTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla SAM_PARAMETROS_SEMESTRES. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            strSql = "delete sam_parametros_semestres ";
            strSql += " where num_sec_semestre = " + _numsecsemestre.ToString();
            strSql += " and num_sec_parametro = " + _numsecparametro.ToString();

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible borrar el dato. Se encontró un error al eliminar en la tabla SAM_PARAMETROS_SEMESTRES. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool Ver(string strNSSemestre, string strNSParametro)
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            if (!string.IsNullOrEmpty(strNSParametro))
            {
                strSql = "select pm.num_sec_parametro, s.num_sec num_sec_semestre, pm.tipo, pm.descripcion parametro_descripcion";
                strSql += " , pm.codigo parametro_codigo, pm.tipo parametro_tipo, pm.valor valor_defecto, pm.observaciones";
                strSql += " , d1.descripcion tipo_str, d2.descripcion alcance_str";
                strSql += " , vs.valor, vs.f_reg, vs.usuarios_app, nvl(vs.num_sec_usuario_reg,0) num_sec_usuario_reg, vs.u_reg";
                strSql += " , s.resumido semestre, s.fecha_inicio";
                strSql += " , 'Seleccionar' seleccionar";
                strSql += " from sam_parametros_modulos pm, dominios d1, dominios d2, semestres s";
                strSql += " , (select ps.num_sec_parametro, ps.valor, ps.num_sec_usuario_reg";
                strSql += "   , to_char(ps.fecha_registro,'dd/mm/yyyy hh24:miss') f_reg";
                strSql += "   , u.usuarios_app, pm.usuario_registro u_reg";
                strSql += "   from sam_parametros_modulos pm, sam_parametros_semestres ps";
                strSql += "   , (select a.num_sec_usuario, a.num_sec_persona";
                strSql += "     , b.ap_paterno||' '||b.ap_materno||' '||b.nombres usuarios_app";
                strSql += "     from sam_usuarios a, personas b";
                strSql += "     where a.num_sec_persona = b.num_sec) u";
                strSql += "   where pm.num_sec_parametro = " + strNSParametro;
                strSql += "   and ps.num_sec_semestre = " + strNSSemestre;
                strSql += "   and pm.num_sec_parametro = ps.num_sec_parametro";
                strSql += "   and ps.num_sec_usuario_reg = u.num_sec_usuario";
                strSql += "   ) vs";
                strSql += " where pm.num_sec_parametro = " + strNSParametro;
                strSql += " and pm.alcance = 2";
                strSql += " and d1.dominio = 'TIPO_PARAM'";
                strSql += " and pm.tipo = d1.valor";
                strSql += " and d2.dominio = 'ALCANCE_PARAM'";
                strSql += " and pm.alcance = d2.valor";
                strSql += " and pm.num_sec_parametro = vs.num_sec_parametro(+)";
                strSql += " and s.num_sec = " + strNSSemestre;
                strSql += " order by pm.codigo, pm.descripcion";

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
                    _numsecsemestre = Convert.ToInt64(dr["num_sec_semestre"].ToString());
                    _numsecparametro = Convert.ToInt64(dr["num_sec_parametro"].ToString());
                    _valor = dr["valor"].ToString();
                    _fecharegistro = dr["f_reg"].ToString();
                    _usuarioregistro = dr["u_reg"].ToString();
                    _numsecusuarioregistroapp = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
                    _usuarioregistroapp = dr["usuarios_app"].ToString();

                    _param_codigo = dr["parametro_codigo"].ToString();
                    _param_descripcion = dr["parametro_descripcion"].ToString();
                    _param_alcance_str = dr["alcance_str"].ToString();
                    _param_tipo_str = dr["tipo_str"].ToString();
                    _param_tipo = Convert.ToInt32(dr["parametro_tipo"].ToString());
                    _param_valor_def = dr["valor_defecto"].ToString();
                    _param_observaciones = dr["observaciones"].ToString();
                }
                dt.Dispose();
            }
            if (!blEncontrado)
            {
                _numsecsemestre = 0;
                _numsecparametro = 0;
                _valor = string.Empty;
                _fecharegistro = string.Empty;
                _usuarioregistro = string.Empty;
                _numsecusuarioregistroapp = 0;
                _usuarioregistroapp = string.Empty;

                _param_codigo = string.Empty;
                _param_descripcion = string.Empty;
                _param_alcance_str = string.Empty;
                _param_tipo_str = string.Empty;
                _param_tipo = 0;
                _param_valor_def = string.Empty;
                _param_observaciones = string.Empty;

            }
            return blEncontrado;
        }

        public string Query_Grid_ABM1(string strNSParametro)
        {
            string strSql = string.Empty;

            strSql = "select a.num_sec_semestre, a.valor";
            strSql += " , b.resumido, b.fecha_inicio";
            strSql += " , 'Seleccionar' seleccionar";
            strSql += " from sam_parametros_semestres a, semestres b";
            strSql += " where a.num_sec_parametro = " + strNSParametro;
            strSql += " and a.num_sec_semestre = b.num_sec";
            strSql += " order by b.fecha_inicio desc";

            return strSql;
        }

        public string Query_Grid_ABM2(string strNSModulo, string strNSSemestre)
        {
            string strSql = string.Empty;

            strSql = "select pm.num_sec_parametro, pm.tipo, pm.descripcion parametro_descripcion";
            strSql += " , pm.codigo parametro_codigo, pm.valor valor_defecto";
            strSql += " , d1.descripcion tipo_str, d2.descripcion alcance_str";
            strSql += " , vs.valor, vs.f_reg, vs.usuario_reg";
            strSql += " , 'Seleccionar' seleccionar";
            strSql += " from sam_parametros_modulos pm, dominios d1, dominios d2";
            strSql += " , (select ps.num_sec_parametro, ps.valor, u.login usuario_reg";
            strSql += "   , to_char(ps.fecha_registro,'dd/mm/yyyy hh24:mi') f_reg";
            strSql += "   from sam_parametros_modulos pm, sam_parametros_semestres ps, sam_usuarios u";
            strSql += "   where pm.num_sec_modulo = " + strNSModulo;
            strSql += "   and ps.num_sec_semestre = " + strNSSemestre;
            strSql += "   and pm.num_sec_parametro = ps.num_sec_parametro";
            strSql += "   and ps.num_sec_usuario_reg = u.num_sec_usuario";
            strSql += "   ) vs";
            strSql += " where pm.num_sec_modulo = " + strNSModulo;
            strSql += " and pm.alcance = 2";
            strSql += " and d1.dominio = 'TIPO_PARAM'";
            strSql += " and pm.tipo = d1.valor";
            strSql += " and d2.dominio = 'ALCANCE_PARAM'";
            strSql += " and pm.alcance = d2.valor";
            strSql += " and pm.num_sec_parametro = vs.num_sec_parametro(+)";
            strSql += " order by pm.codigo, pm.descripcion";

            return strSql;
        }




        #endregion

        #region Procedimientos y Funciones Locales
        private bool Validar_Campos(int intModoPantalla, int intTipoParametro)
        {
            if (_valor.Trim().Length < 1 || _valor.Trim().Length > 150)
            {
                _mensaje = "El valor debe contener entre 1 y 150 caracteres.";
                return false;
            }

            switch (intTipoParametro)
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

            if (!Revisar_Repetido(intModoPantalla))
            {
                return false;
            }
            return true;
        }


        private bool Revisar_Repetido(int axModoPantalla)
        {
            if (axModoPantalla == 1)
            {
                strSql = " select valor from sam_parametros_semestres";
                strSql += " where num_sec_parametro = " + _numsecparametro.ToString();
                strSql += " and num_sec_semestre = " + _numsecsemestre.ToString();
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