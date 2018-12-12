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
    // Creado por: Ignacio Rios; Fecha: 10/12/2018
    // Ultima modificación: Ignacio Rios; Fecha: 12/12/2018
    // Descripción: Clase referente a la tabla alm_items
    public class BD_ALM_Items
    {
        #region Variables Locales
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        GEN_VarSession axVarSes = new GEN_VarSession();
        private string strSql = string.Empty;
        #endregion

        #region Atributos
        // Campos de la tabla alm_items
        private long _num_sec_item = 0;
        private string _cod = string.Empty;
        private string _nombre = string.Empty;
        private double _precio_mov = 0;
        private long _num_sec_cat_items = 0;
        private long _num_sec_marca = 0;
        private long _num_sec_medida = 0;
        private short _estado = 0;
        private long _stock_min = 0;
        
        private string _fecharegistro = string.Empty;
        private string _usuarioregistro = string.Empty;
        private long _numsecusuarioregistro = 0;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecItem
        {
            get { return _num_sec_item; }
            set { _num_sec_item = value; }
        }

        public string Cod
        {
            get { return _cod; }
            set { _cod = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public long NumSecCat
        {
            get { return _num_sec_cat_items; }
            set { _num_sec_cat_items = value; }
        }

        public long NumSecMedida
        {
            get { return _num_sec_medida; }
            set { _num_sec_medida= value; }
        }

        public long NumSecMarca
        {
            get { return _num_sec_marca; }
            set { _num_sec_marca = value; }
        }

        public short Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public long StockMin
        {
            get { return _stock_min; }
            set { _stock_min = value; }
        }
        public double PrecioMov
        {
            get { return _precio_mov; }
            set { _precio_mov = value; }
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
        public BD_ALM_Items()
        {
            _num_sec_item = 0;
            _cod = string.Empty;
            _nombre = string.Empty;
            _num_sec_cat_items = 0;
            _num_sec_marca = 0;
            _num_sec_medida = 0;
            _estado = 0;
            _stock_min = 0;
            _precio_mov = 0;
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
            strSql = "insert into alm_items (num_sec_item, cod, nombre, num_sec_cat_items, num_sec_marca, num_sec_medida"+
                     ", estado, precio, stock_min, num_sec_usuario_reg) values" +
                    " (alm_items_sec.nextval,"+ _cod+","+_nombre+","+ _num_sec_cat_items + ","+_num_sec_marca
                    + "," + _num_sec_medida + "," +_estado + "," +_precio_mov + "," +_stock_min+ ","+usuario +" )";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();
            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla alm_items. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool ModificarNombre()
        {
            bool blOperacionCorrecta = false;
            strSql = "update alm_items set "+
                " nombre = " + _nombre+
                " where num_sec_item = " + _num_sec_item.ToString();

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla alm_items. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool ModificarPrecio()
        {
            bool blOperacionCorrecta = false;
            strSql = "update alm_items set " +
                " precio = " + _precio_mov +
                " where num_sec_item = " + _num_sec_item.ToString();

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla alm_items. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            strSql = "update alm_items set " +
                " estado = 0 " +
                " where num_sec_item = " + _num_sec_item.ToString();

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible borrar el dato. Se encontró un error al eliminar en la tabla alm_items. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool Ver()
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            strSql = "select a.num_sec_usuario, a.num_sec_persona, a.usuario, a.login, a.activo";
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
                _num_sec_item = Convert.ToInt64(dr["num_sec_item"].ToString());
                _cod= dr["cod"].ToString();
                _num_sec_cat_items = Convert.ToInt64(dr["num_sec_cat_items"].ToString());
                _nombre = dr["nombre"].ToString();
                _num_sec_marca= Convert.ToInt64(dr["num_sec_cat_items"].ToString());
                _num_sec_medida = Convert.ToInt64(dr["num_sec_cat_items"].ToString());
                _precio_mov = Convert.ToDouble(dr["precio"].ToString());
                _estado = Convert.ToInt16(dr["num_sec_cat_items"].ToString());
                _stock_min = Convert.ToInt64(dr["num_sec_cat_items"].ToString());
                _fecharegistro = dr["fecha_registro"].ToString();
                _usuarioregistro = dr["usuario_registro"].ToString();
                _numsecusuarioregistro = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
            }
            dt.Dispose();
            if (!blEncontrado)
            {
                _num_sec_item = 0;
                _cod = string.Empty;
                _nombre = string.Empty;
                _num_sec_cat_items = 0;
                _num_sec_marca = 0;
                _num_sec_medida = 0;
                _precio_mov = 0;
                _estado = 0;
                _stock_min = 0;
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
        
        #endregion

    }


}