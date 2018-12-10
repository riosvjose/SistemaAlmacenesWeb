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
    // Creado por: Milco Cortez; Fecha: 23/04/2015
    // Ultima modificación: Milco Cortez;  Fecha:14/05/2015
    // Descripción: Clase referente a la tabla SAM_PARAMETROS_MODULOS
    public class BD_SAM_Parametros_Modulos
    {
        #region Variables Locales
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        private string strSql = string.Empty;
        #endregion

        #region Atributos
        // Campos de la tabla SAM_PARAMETROS_MODULOS
        private long _numsecparametro = 0;
        private long _numsecmodulo = 0;
        private long _codigo = 0;
        private string _descripcion = string.Empty;
        private int _alcance = 0;
        private int _tipo = 0;
        private string _valor = string.Empty;
        private string _observaciones = string.Empty;
        private string _fecharegistro = string.Empty;
        private string _usuarioregistro = string.Empty;
        private long _numsecusuarioregistroapp = 0;
        private string _usuarioregistroapp = string.Empty;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecParametro
        {
            get { return _numsecparametro; }
            set { _numsecparametro = value; }
        }
        public long NumSecModulo
        {
            get { return _numsecmodulo; }
            set { _numsecmodulo = value; }
        }
        public long Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public int Alcance
        {
            get { return _alcance; }
            set { _alcance = value; }
        }
        public int Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public string Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
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
        public BD_SAM_Parametros_Modulos()
        {
            _numsecparametro = 0;
            _numsecmodulo = 0;
            _codigo = 0;
            _descripcion = string.Empty;
            _alcance = 0;
            _tipo = 0;
            _valor = string.Empty;
            _observaciones = string.Empty;
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
                strSql = "insert into sam_parametros_modulos (num_sec_parametro, num_sec_modulo, codigo, descripcion";
                strSql += " , alcance, tipo, valor, observaciones, num_sec_usuario_reg ) values";
                strSql += " (sam_parametros_modulos_sec.nextval";
                strSql += " , " + _numsecmodulo.ToString();
                strSql += " , " + _codigo.ToString();
                strSql += " , '" + _descripcion.Trim() + "'";
                strSql += " , " + _alcance.ToString();
                strSql += " , " + _tipo.ToString();
                strSql += " , '" + _valor.Trim() + "'";
                strSql += " , '" + _observaciones.Trim() + "'";
                strSql += ", " + _numsecusuarioregistroapp.ToString();
                strSql += " )";

                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.EjecutarSqlTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla SAM_PARAMETROS_MODULOS. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        public bool Modificar()
        {
            bool blOperacionCorrecta = false;
            blOperacionCorrecta = Validar_Campos(2);
            if (blOperacionCorrecta)
            {
                strSql = "update sam_parametros_modulos set ";
                strSql += " codigo = " + _codigo.ToString();
                strSql += " , descripcion = '" + _descripcion.Trim() + "'";
                strSql += " , alcance = " + _alcance.ToString();
                strSql += " , tipo = " + _tipo.ToString();
                strSql += " , valor = '" + _valor.Trim() + "'";
                strSql += " , observaciones = '" + _observaciones.Trim() + "'";
                strSql += " , usuario_registro = user";
                strSql += " , fecha_registro = sysdate";
                strSql += " , num_sec_usuario_reg = " + _numsecusuarioregistroapp.ToString();
                strSql += " where num_sec_parametro = " + _numsecparametro.ToString();
                strSql += " and (codigo <> " + _codigo.ToString();
                strSql += " or descripcion <> '" + _descripcion.Trim() + "'";
                strSql += " or alcance <> " + _alcance.ToString();
                strSql += " or tipo <> " + _tipo.ToString();
                strSql += " or valor <> '" + _valor.Trim() + "'";
                strSql += " or observaciones <> '" + _observaciones.Trim() + "'";
                strSql += " )";
                
                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.EjecutarSqlTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla SAM_PARAMETROS_MODULOS. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            strSql = "delete sam_parametros_modulos ";
            strSql += " where num_sec_parametro = " + _numsecparametro.ToString();

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible borrar el dato. Se encontró un error al eliminar en la tabla SAM_PARAMETROS_MODULOS. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool Ver(string strNSParametro)
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            if (!string.IsNullOrEmpty(strNSParametro))
            {
                strSql = " select a.num_sec_parametro, a.num_sec_modulo, a.codigo, a.descripcion, a.alcance, a.tipo, a.valor, a.observaciones";
                strSql += " , a.usuario_registro u_reg, to_char(a.fecha_registro,'dd/mm/rrrr hh24:mi:ss') f_reg";
                strSql += " , a.num_sec_usuario_reg";
                strSql += " , b.usuarios_app";
                strSql += " from sam_parametros_modulos a";
                strSql += " , (select a.num_sec_usuario, a.num_sec_persona";
                strSql += "   , b.ap_paterno||' '||b.ap_materno||' '||b.nombres usuarios_app";
                strSql += "   from sam_usuarios a, personas b";
                strSql += "   where a.num_sec_persona = b.num_sec) b";
                strSql += " where a.num_sec_parametro = " + strNSParametro;
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
                    _numsecparametro = Convert.ToInt64(dr["num_sec_parametro"].ToString());
                    _numsecmodulo = Convert.ToInt64(dr["num_sec_modulo"].ToString());
                    _codigo = Convert.ToInt64(dr["codigo"].ToString());
                    _descripcion = dr["descripcion"].ToString();
                    _alcance = Convert.ToInt16(dr["alcance"].ToString());
                    _tipo = Convert.ToInt16(dr["tipo"].ToString());
                    _valor = dr["valor"].ToString();
                    _observaciones = dr["observaciones"].ToString();
                    _fecharegistro = dr["f_reg"].ToString();
                    _usuarioregistro = dr["u_reg"].ToString();
                    _numsecusuarioregistroapp = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
                    _usuarioregistroapp = dr["usuarios_app"].ToString();
                }
                dt.Dispose();
            }
            if (!blEncontrado)
            {
                _numsecparametro = 0;
                _numsecmodulo = 0;
                _codigo = 0;
                _descripcion = string.Empty;
                _tipo = 0;
                _alcance = 0;
                _valor = string.Empty;
                _observaciones = string.Empty;
                _fecharegistro = string.Empty;
                _usuarioregistro = string.Empty;
                _numsecusuarioregistroapp = 0;
                _usuarioregistroapp = string.Empty;
            }
            return blEncontrado;
        }

        public bool ActualizarValor()
        {
            // requiere _numsecparametro, _tipo, _valor
            bool blOperacionCorrecta = false;
            blOperacionCorrecta = Validar_Campos(3);
            if (blOperacionCorrecta)
            {
                strSql = Query_Actualizar_Valor(_numsecparametro.ToString(), _valor.Trim());
                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.EjecutarSqlTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla SAM_PARAMETROS_MODULOS. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        public string Query_Actualizar_Valor(string strNSParametro, string strValor)
        {
            string strSql1 = string.Empty;
            strSql1 = "update sam_parametros_modulos set ";
            strSql1 += " valor = '" + strValor.Trim() + "'";
            //strSql += " , usuario_registro = user";
            //strSql += " , fecha_registro = sysdate";
            //strSql1 += " , num_sec_usuario_reg = " + _numsecusuarioregistroapp.ToString();
            strSql1 += " where num_sec_parametro = " + strNSParametro;
            strSql1 += " and valor <> '" + strValor + "'";
            return strSql1;
        }

        public string Query_Grid_ABM1(string strNSModulo)
        {
            string strSql = string.Empty;

            strSql = "select a.num_sec_parametro, a.num_sec_modulo, a.codigo, a.descripcion, a.valor, a.alcance, a.tipo";
            strSql += " , b.descripcion tipo_str, c.descripcion alcance_str";
            strSql += " , 'Seleccionar' seleccionar";
            strSql += " from sam_parametros_modulos a, dominios b, dominios c";
            strSql += " where a.num_sec_modulo = " + strNSModulo;
            strSql += " and b.dominio = 'SAM_TIPO_PARAM'";
            strSql += " and a.tipo = b.valor";
            strSql += " and c.dominio = 'SAM_ALCANCE_PARAM'";
            strSql += " and a.alcance = c.valor";
            strSql += " order by a.codigo";

            return strSql;
        }

        private string Query_DropDownList1(string strNSModulo)
        {
            string strSql = string.Empty;
            strSql = " select num_sec_parametro, codigo, descripcion, codigo||'-'||descripcion descrip ";
            strSql += " from sam_parametros_modulos where num_sec_modulo = " + strNSModulo;
            strSql += " order by descrip";
            return strSql;
        }
        

        
        #endregion

        #region Procedimientos y Funciones Locales
        private bool Validar_Campos(int axTipo)
        {
            if (!(_tipo > 0 || _tipo < 10))
            {
                _mensaje = "El tipo debe ser un número entre 1 y 9.";
                return false;
            }
            if (_valor.Trim().Length < 1 || _valor.Trim().Length > 150)
            {
                _mensaje = "El valor debe contener entre 1 y 150 caracteres.";
                return false;
            }

            switch (_tipo)
            {
                case 1:     //Numérico entero
                    if (!libCadenas.Cadena_Es_Numero(_valor.Trim(), 1))
                    {
                        _mensaje = "El valor debe ser numérico.";
                        return false;
                    }
                    break;
                case 2:     //Numérico decimal
                    if (!libCadenas.Cadena_Es_Numero(_valor.Trim(), 2))
                    {
                        _mensaje = "El valor debe ser numérico.";
                        return false;
                    }
                    break;
                case 3:     //Caracter sin especiales
                    if (libCadenas.Texto_Contiene_Caracteres_Especiales(_valor.Trim(), 6, 1))
                    {
                        _mensaje = "El valor no debe contener caracteres epeciales.";
                        return false;
                    }
                    break;
                case 4:     //Caracter con especiales
                    if (libCadenas.Texto_Contiene_Caracteres_Especiales(_valor.Trim(), 1, 1))
                    {
                        _mensaje = "El valor es inválido.";
                        return false;
                    }
                    break;

                case 5:     //Fecha solo
                    if (!libCadenas.Validar_Fecha_Hora(_valor.Trim(), 1))
                    {
                        _mensaje = "La valor debe estar en formato de fecha.";
                        return false;
                    }
                    break;

                
                case 6:     //Fecha y hora
                    if (!libCadenas.Validar_Fecha_Hora(_valor.Trim(), 2))
                    {
                        _mensaje = "La valor debe estar en formato de fecha.";
                        return false;
                    }
                    break;

                default:
                    _mensaje = "El tipo de parámetro no está definido correctamente.";
                    return false;
            }



            if (axTipo != 3)
            {
                if (!(_codigo > 0 || _codigo < 10000000000))
                {
                    _mensaje = "El codigo debe ser un número de máximo 10 dígitos.";
                    return false;
                }

                if (_descripcion.Trim().Length < 5 || _descripcion.Trim().Length > 100)
                {
                    _mensaje = "La descripción debe contener entre 5 y 100 caracteres.";
                    return false;
                }
                if (libCadenas.Texto_Contiene_Caracteres_Especiales(_descripcion.Trim(), 2, 1))
                {
                    _mensaje = "La descripción no debe contener caracteres epeciales.";
                    return false;
                }
                if (!(_alcance > 0 || _alcance < 10))
                {
                    _mensaje = "El alcance debe ser un número entre 1 y 9.";
                    return false;
                }

                if (libCadenas.Texto_Contiene_Caracteres_Especiales(_observaciones.Trim(), 1, 1))
                {
                    _mensaje = "Las observaciones no deben contener caracteres epeciales.";
                    return false;
                }

                if (!Revisar_Repetido(axTipo))
                {
                    return false;
                }
            }

            return true;
        }

        private bool Revisar_Repetido(int axModoPantalla)
        {
            strSql = " select * from sam_parametros_modulos";
            strSql += " where num_sec_modulo = " + _numsecmodulo.ToString();
            strSql += " and (codigo = " + _codigo.ToString();
            strSql += " or descripcion = '" + _descripcion.Trim() + "')";
            if (axModoPantalla == 2)
            {
                strSql += " and num_sec_parametro <> " + _numsecparametro.ToString();
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