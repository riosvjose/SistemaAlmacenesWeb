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
    // Creado por: Ignacio Rios; Fecha: 09/01/2019
    // Ultima modificación: Ignacio Rios; Fecha: 09/01/2019
    // Descripción: Clase referente a la tabla alm_entregas
    public class BD_ALM_Entregas
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
        private long _num_sec_entrega = 0;
        private long _num_sec_movimiento = 0;
        private long _num_sec_token = 0;
        private long _num_sec_usuario = 0;
        private string _fecharegistro = string.Empty;
        private string _usuarioregistro = string.Empty;
        private long _numsecusuarioregistro = 0;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecEntrega
        {
            get { return _num_sec_entrega; }
            set { _num_sec_entrega = value; }
        }

        public long NumSecMovimiento
        {
            get { return _num_sec_movimiento; }
            set { _num_sec_movimiento = value; }
        }

        public long NumSecToken
        {
            get { return _num_sec_token; }
            set { _num_sec_token = value; }
        }

        public long NumSecUsuario
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
        public BD_ALM_Entregas()
        { 
            _num_sec_entrega= 0;
            _num_sec_movimiento = 0;
            _num_sec_token = 0;
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
            strSql = "insert into alm_entregas (num_sec_entrega, num_sec_movimiento, num_sec_token, num_sec_usuario, num_sec_usuario_reg) values";
            strSql += " (alm_entregas_sec.nextval,"+ _num_sec_movimiento+","+_num_sec_token+","+_num_sec_usuario+"," + usuario +" )";
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

        public void Borrar()
        {
           
        }

        public bool Ver()
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            strSql = "select * from alm_entregas where num_sec_entrega="+_num_sec_entrega;
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
                _num_sec_entrega = Convert.ToInt64(dr["num_sec_entrega"].ToString());
                _num_sec_movimiento = Convert.ToInt64(dr["num_sec_movimiento"].ToString());
                _num_sec_token = Convert.ToInt64(dr["num_sec_token"].ToString());
                _num_sec_usuario = Convert.ToInt64(dr["num_sec_usuario"].ToString());
                _fecharegistro = dr["fecha_registro"].ToString();
                _usuarioregistro = dr["usuario_registro"].ToString();
                _numsecusuarioregistro = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
            }
            dt.Dispose();
            if (!blEncontrado)
            {
                _num_sec_entrega = 0;
                _num_sec_movimiento = 0;
                _num_sec_token = 0;
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

        public DataTable dtListarEntregasToken(string paso, string token)
        {
            string subdepto = string.Empty;

            string usuario = axVarSes.Lee<string>("UsuarioNumSec");
            strSql = "select distinct m.num_sec_transaccion, i.nombre as num_sec_item, m.num_sec_paso, ps.nombre as paso, m.egreso as cantidad" +
                    ", d.descripcion, per.ap_paterno||' '||per.nombres as persona " +
                    " from alm_movimientos m, alm_movimientos mov, alm_pasos pa, alm_pasos p, alm_pasos ps, personas per, alm_items i " +
                    ", alm_plantillas plant, dominios d" +
                    " where p.num_sec_paso=" + paso +
                    " AND p.num_sec_plantilla = plant.num_sec_plantilla " +
                    " AND plant.tipo_egreso = d.valor" +
                    " AND d.dominio = 'ALM_TIPO_EGRESO'" +
                    " and m.num_sec_paso=p.num_sec_paso_ant" +
                    " and m.num_sec_paso=ps.num_sec_paso" +
                    " and  m.num_sec_transaccion = mov.num_sec_transaccion" +
                    " and mov.num_sec_paso = pa.num_sec_paso" +
                    " and pa.num_sec_paso_ant = 0" +
                    " and m.num_sec_transaccion not in (select a.num_sec_transaccion from alm_movimientos a" +
                                            " where a.num_sec_paso=" + paso + ")" +
                    " and m.num_sec_transaccion not in (select a.num_sec_transaccion from alm_movimientos a, alm_pasos b" +
                                            " where b.tipo=4 and a.num_sec_paso=b.num_sec_paso)" +
                    " and per.num_sec=mov.num_sec_persona" +
                    " and m.num_sec_item=i.num_sec_item" +
                    " and m.num_sec_usuario in(select a.num_sec_usuario from alm_paso_subdepto_usu a" +
                                                " where a.num_sec_subdepartamento ="+subdepto+")" +
                    " order by i.nombre, m.num_sec_transaccion";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public DataTable dtListarTodosAlmacenes()
        {
            strSql = "SELECT DISTINCT a.num_sec_almacen, a.nombre FROM alm_almacenes a " +
                        "ORDER BY a.nombre ASC";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }
        #endregion

    }


}