using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using nsGEN_OracleBD;

namespace nsGEN_AccesoModulo
{

    // Creado por: Milco Cortes; Fecha: 17/03/2015
    // Ultima modificación: Milco Cortes;  Fecha:07/10/2015
    // Descripción: Inluye diversos métodos para controlar el acceso a un módulo y a sus respectivos objetos

    public class GEN_AccesoModulo
    {
        #region Variables Locales
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        #endregion

        #region Atributos
        private string _strconexion = string.Empty;
        private string _mensaje = string.Empty;
        private long _numsecmodulo = 0;
        private long _numsecunidad = 0;
        private long _numsecsubunidad = 0;
        private long _numsecusuario = 0;
        private int _nummodulo = 0;
        private string _nombremodulo = "";

        public string StrConexion
        {
            get { return _strconexion; }
            set { _strconexion = value; }
        }
        public string Mensaje
        {
            get { return _mensaje; }
        }
        public long NumSecModulo
        {
            get { return _numsecmodulo; }
            set { _numsecmodulo = value; }
        }
        public long NumSecUnidad
        {
            get { return _numsecunidad; }
            set { _numsecunidad = value; }
        }
        public long NumSecSubunidad 
        { 
            get { return _numsecsubunidad; }
            set { _numsecsubunidad = value; } 
        }
        public long NumSecUsuario
        {
            get { return _numsecusuario; }
            set { _numsecusuario = value; }
        }
        public int NumModulo
        {
            get { return _nummodulo; }
            set { _nummodulo = value; }
        }
        public string NombreModulo
        {
            get { return _nombremodulo; }
            set { _nombremodulo = value; }
        }
        #endregion

        #region Constructores
        public GEN_AccesoModulo()
        { }
        #endregion

        #region Metodos
        public void Revisar_NS_Modulo()
        { 
            string strSql = string.Empty;
            _numsecmodulo = 0;
            
            strSql = " select distinct a.num_sec_modulo";
            strSql += " from sam_modulos a, gen_subunidades b";
            strSql += " where a.numero_modulo = " + _nummodulo.ToString();
            strSql += " and a.num_sec_subunidad = " + _numsecsubunidad.ToString();
            strSql += " and a.num_sec_subunidad = b.num_sec_subunidad";

            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count > 0)
                _numsecmodulo = Convert.ToInt64(dt.Rows[0]["num_sec_modulo"].ToString());
            dt.Dispose();
        }

        public void Recuperar_Datos_SubUnidad_Vars_Sesion(string strCon, long ax_Subunidad_ns, ref long ax_Unidad_ns, ref string str_Unidad_nombre, ref string str_Unidad_depto, ref string str_Subunidad_nombre, ref string str_SubUnidad_ciudad)
        {
            string strSql = string.Empty;

            strSql = " select distinct e.nombre||' - '||d.nombre nombres_unidos";
            strSql += " , e.num_sec_unidad unidad_ns, e.nombre unidad_nombre, e.departamento unidad_departamento";
            strSql += " , d.num_sec_subunidad subunidad_ns, d.nombre subunidad_nombre, d.ciudad subunidad_ciudad";
            strSql += " from ";
            strSql += " gen_subunidades d, gen_unidades e";
            strSql += " where d.num_sec_subunidad = " + ax_Subunidad_ns.ToString();
            strSql += " and d.num_sec_unidad = e.num_sec_unidad";
            strSql += " order by nombres_unidos";

            DataTable dt = new DataTable();
            OracleBD.MostrarError = false; 
            OracleBD.StrConexion = strCon;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            //dt = OracleBD.sqlDataTable();
            //dt = libOracle.sqlDataTable(strCon, strSql, ref axNumFilas, ref strMensaje);
            if (dt.Rows.Count > 0)
            {
                ax_Unidad_ns = (long)dt.Rows[0]["unidad_ns"];
                str_Unidad_nombre = (string)dt.Rows[0]["unidad_nombre"];
                str_Unidad_depto = (string)dt.Rows[0]["unidad_departamento"];
                str_Subunidad_nombre = (string)dt.Rows[0]["subunidad_nombre"];
                str_SubUnidad_ciudad = (string)dt.Rows[0]["subunidad_ciudad"];
            }
            else
            {
                ax_Unidad_ns = 0;
                str_Unidad_nombre = string.Empty;
                str_Unidad_depto = string.Empty;
                str_Subunidad_nombre = string.Empty;
                str_SubUnidad_ciudad = string.Empty;
            }
            dt.Dispose();
        }

        public void Revisar_Funciones_Usuario_Modulo(ref string strFuncionesMod)
        {
            string strSql = string.Empty;

            strSql = " select distinct a.num_sec_funcion";
            strSql += " from sam_funciones a, sam_usuarios_funciones b";
            strSql += " where a.num_sec_modulo = " + _numsecmodulo.ToString();
            strSql += " and a.num_sec_funcion = b.num_sec_funcion";
            strSql += " and b.num_sec_usuario = " + _numsecusuario.ToString();

            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            //dt = OracleBD.sqlDataTable();
            //dt = libOracle.sqlDataTable(strCon, strSql, ref axNumFilas, ref strMensaje);
            if (dt.Rows.Count > 0)
            {
                for (int axConta = 0; axConta < dt.Rows.Count; axConta++)
                {
                    if (strFuncionesMod != string.Empty)
                        strFuncionesMod += ",";

                    strFuncionesMod += dt.Rows[axConta]["num_sec_funcion"];
                }
            }
            else
                strFuncionesMod = string.Empty;

            dt.Dispose();
        }

        public void Revisar_Usuario_Acceso_Modulo(string strIP, ref int axAcceso, ref string strMensaje1, ref string strFuncionesMod)
        {
            string strSql = string.Empty;

            axAcceso = 0;
            strFuncionesMod = string.Empty;
            strMensaje1 = "Usted no tiene permisos de acceso a este sistema.";

            if (_numsecmodulo > 0 && _numsecusuario > 0)
            {
                strSql = " select ip from sam_usuarios_modulos";
                strSql += " where num_sec_usuario = " + _numsecusuario.ToString();
                strSql += " and num_sec_modulo = " + _numsecmodulo.ToString();
                if (strIP != string.Empty)
                {
                    strSql += " and (ip = '255.255.255.255'";
                    strSql += " or ip = '" + strIP + "')";
                }
                else
                {
                    strSql += " and ip = '255.255.255.255'";
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
                    axAcceso = 1;
                    strMensaje1 = string.Empty;
                    Revisar_Funciones_Usuario_Modulo(ref strFuncionesMod);
                }
                else
                    dt.Dispose();
            }
        }

        public int Numero_Registros_CambioPWD_Obligado()
        {
            int intNumRegistros = 0;
            if (string.IsNullOrEmpty(_strconexion.Trim()) || _numsecusuario > 0)
            {
                string strSql = string.Empty;

                strSql = " select count(0) num_regs";
                strSql += " from sam_usuarios_cambiospwd";
                strSql += " where num_sec_usuario = " + _numsecusuario.ToString();
                strSql += " and fecha_cambio is null";

                DataTable dt = new DataTable();
                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.sqlDataTable();
                dt = OracleBD.DataTable;
                if (dt.Rows.Count > 0)
                    intNumRegistros = Convert.ToInt16(dt.Rows[0]["num_regs"].ToString());
                dt.Dispose();
            }
            return intNumRegistros;
        }

        public void RevisarPermisosObjeto(string strConexion, string strNSUsuario, string strNSModulo, string strNombreObjeto, ref int[] intPermisos)
        {
            string strSql = string.Empty;
            intPermisos[0] = 0; // acceso
            intPermisos[1] = 0; // adicionar
            intPermisos[2] = 0; // editar
            intPermisos[3] = 0; // eliminar
            if (!string.IsNullOrEmpty(strConexion) && !string.IsNullOrEmpty(strNSUsuario) && !string.IsNullOrEmpty(strNSModulo) && !string.IsNullOrEmpty(strNombreObjeto))
            {
                strSql = "select e.num_sec_objeto, sum(e.acceso) acceso, sum(e.adicionar) adicionar";
                strSql += " , sum(e.editar) editar, sum(e.eliminar) eliminar";
                strSql += " from sam_objetos a, sam_funciones b, sam_usuarios_funciones c, sam_accesos e";
                strSql += " where a.num_sec_modulo = " + strNSModulo;
                strSql += " and a.nombre = '" + strNombreObjeto + "'";
                strSql += " and b.num_sec_modulo = " + strNSModulo;
                strSql += " and c.num_sec_usuario = " + strNSUsuario;
                strSql += " and c.num_sec_funcion = b.num_sec_funcion";
                strSql += " and e.num_sec_funcion = b.num_sec_funcion";
                strSql += " and e.num_sec_objeto = a.num_sec_objeto";
                strSql += " group by e.num_sec_objeto";

                DataTable dt = new DataTable();
                OracleBD.MostrarError = false;
                OracleBD.StrConexion = strConexion;
                OracleBD.Sql = strSql;
                OracleBD.sqlDataTable();
                dt = OracleBD.DataTable;
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    intPermisos[0] = Convert.ToInt16(dr["acceso"].ToString());
                    intPermisos[1] = Convert.ToInt16(dr["adicionar"].ToString());
                    intPermisos[2] = Convert.ToInt16(dr["editar"].ToString());
                    intPermisos[3] = Convert.ToInt16(dr["eliminar"].ToString());
                }
                dt.Dispose();
            }
        }

        public bool RevisarPermitirObjeto(string strConexion, string strNSUsuario, string strNSModulo, string strNombreObjeto)
        {
            bool blPermitir = false;
            //string strConexion = axVarSes.Lee<string>("StrConexion");
            //string strNSUsuario = axVarSes.Lee<string>("UsuarioNumSec");
            //string strNSModulo = axVarSes.Lee<string>("modulo_ns");
            //string strNombreObjeto = "Permitir_administrar_solicitudes_todas";
            int[] intPermisos = { 0, 0, 0, 0 };

            RevisarPermisosObjeto(strConexion, strNSUsuario, strNSModulo, strNombreObjeto, ref intPermisos);
            if (intPermisos[0] > 0)
                blPermitir = true;

            return blPermitir;
        }

        public string Query_Permisos_Modulo_Usuario_(string strNSModulo, string strNSUsuario, int intTipo)
        {
            // intTipo: 0: todos, 1: Menu, -1:otros que no sean menu
            string strSql1 = string.Empty;
            strSql1 = " select d.num_sec_objeto, b.nombre objeto, b.tipo, sum(acceso) sacceso, sum(adicionar) sinsertar";
            strSql1 += " , sum(editar) smodificar, sum(eliminar) sborrar";
            strSql1 += " from sam_modulos a, sam_objetos b, sam_funciones c, sam_accesos d";
            strSql1 += " , sam_usuarios_funciones e";
            strSql1 += " where a.num_sec_modulo = " + strNSModulo;
            switch (intTipo)
            {
                case -1:
                    strSql1 += " and b.tipo <> 1";
                    break;
                case 1:
                    strSql1 += " and b.tipo = 1";
                    break;
                default:
                    break;
            }
            strSql1 += " and a.num_sec_modulo = b.num_sec_modulo";
            strSql1 += " and a.num_sec_modulo = c.num_sec_modulo";
            strSql1 += " and e.num_sec_usuario = " + strNSUsuario;
            strSql1 += " and e.num_sec_funcion = c.num_sec_funcion";
            strSql1 += " and d.num_sec_funcion = c.num_sec_funcion";
            strSql1 += " and d.num_sec_objeto = b.num_sec_objeto";
            strSql1 += " group by d.num_sec_objeto, b.nombre, b.tipo";
            strSql1 += " order by b.tipo, b.nombre";
            return strSql1;
        }

        public string Query_Parametros_Modulo(string strNSModulo)
        {
            string strSql1 = string.Empty;
            strSql1 = "select num_sec_parametro, codigo, descripcion, tipo, alcance, valor";
            strSql1 += " from sam_parametros_modulos";
            strSql1 += " where num_sec_modulo = " + strNSModulo;
            strSql1 += " order by descripcion";
            return strSql1;
        }

        public bool RevisarParametroPersona(string strConexion, string strNSPersona, string strNSModulo, string strCodigoParam, ref string[] strValores)
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            strValores[0] = string.Empty; // valor por defecto
            strValores[1] = string.Empty; // valor para la persona

            if (!string.IsNullOrEmpty(strConexion) && !string.IsNullOrEmpty(strNSPersona) && !string.IsNullOrEmpty(strNSModulo) && !string.IsNullOrEmpty(strCodigoParam))
            {
                strSql = "select a.num_sec_parametro, a.valor valor_def, e.num_sec_persona, nvl(e.valor,a.valor) valor_per";
                strSql += " from sam_parametros_modulos a, sam_parametros_personas e";
                strSql += " where a.num_sec_modulo = " + strNSModulo;
                strSql += " and a.codigo = " + strCodigoParam;
                strSql += " and e.num_sec_persona(+) = " + strNSPersona;
                strSql += " and a.num_sec_parametro = e.num_sec_parametro(+)";

                DataTable dt = new DataTable();
                OracleBD.MostrarError = false;
                OracleBD.StrConexion = strConexion;
                OracleBD.Sql = strSql;
                OracleBD.sqlDataTable();
                dt = OracleBD.DataTable;
                if (dt.Rows.Count > 0)
                {
                    blEncontrado = true;
                    DataRow dr = dt.Rows[0];
                    strValores[0] = dr["valor_def"].ToString();
                    strValores[1] = dr["valor_per"].ToString();
                }
                dt.Dispose();
            }
            return blEncontrado;
        }


        #endregion

    }
}