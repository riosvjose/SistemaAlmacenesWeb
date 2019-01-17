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
    // Creado por: Alvaro Mamani   ; Fecha: 12/12/2018
    // Ultima modificación: IGNACIO RIOS   ; Fecha: 03/01/2019
    // Descripción: Clase referente a la tabla ALM_MOVIMIENTOS
    public class BD_ALM_Movimientos
    {
        #region Variables Locales
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        GEN_VarSession axVarSes = new GEN_VarSession();
        
        private string strSql = string.Empty;
        #endregion

        #region clases de las tablas de la base de datos
        BD_ALM_Items libItem = new BD_ALM_Items();
        BD_ALM_Pasos libpasos = new BD_ALM_Pasos();
        #endregion

        #region Atributos
        // Campos de la tabla alm_movimientos
        private long _num_sec_movimiento = 0;
        private long _num_sec_transaccion = 0;
        private long _num_sec_item = 0;
        private long _num_sec_persona = 0;
        private long _num_sec_usuario = 0;
        private long _num_sec_paso = 0;
        private double _precio_unitario = 0;
        private long _ingreso = 0;
        private long _egreso = 0;
        private string _fecha_registro = string.Empty;
        private string _usuario_registro = string.Empty;
        private long _num_sec_usuario_registro = 0;


        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecMovimiento
        {
            get { return _num_sec_movimiento; }
            set { _num_sec_movimiento = value; }
        }

        public long CodTransaccion
        {
            get { return _num_sec_transaccion; }
            set { _num_sec_transaccion = value; }
        }
        public long NumSecItem
        {
            get { return _num_sec_item; }
            set { _num_sec_item = value; }
        }
        public long NumSecPersona
        {
            get { return _num_sec_persona; }
            set { _num_sec_persona = value; }
        }
        public long NumSecUsuario
        {
            get { return _num_sec_usuario; }
            set { _num_sec_usuario = value; }
        }
        public long NumSecPaso
        {
            get { return _num_sec_paso; }
            set { _num_sec_paso = value; }
        }
        public double PrecioUnitario
        {
            get { return _precio_unitario; }
            set { _precio_unitario = value; }
        }
        public long Ingreso
        {
            get { return _ingreso; }
            set { _ingreso = value; }
        }
        public long Egreso
        {
            get { return _egreso; }
            set { _egreso = value; }
        }
        public string FechaRegistro
        {
            get { return _fecha_registro; }
        }
        public string UsuarioRegistro
        {
            get { return _usuario_registro; }
        }
        public long NumSecUsuarioRegistro
        {
            get { return _num_sec_usuario_registro; }
            set { _num_sec_usuario_registro = value; }
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
        public BD_ALM_Movimientos()
        {
            _num_sec_movimiento = 0;
            _num_sec_transaccion = 0;
            _num_sec_item = 0;
            _num_sec_persona = 0;
            _num_sec_usuario = 0;
            _num_sec_paso = 0;
            _precio_unitario = 0;
            _ingreso = 0;
            _egreso = 0;
            _fecha_registro = string.Empty;
            _usuario_registro = string.Empty;
            _num_sec_usuario_registro = 0;

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }
        #endregion

        #region Metodos
        public bool Insertar()
        {
            bool blOperacionCorrecta = false;
            string usuario = axVarSes.Lee<string>("UsuarioNumSec");
            strSql = CadInsertar();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();
            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla alm_movimientos. " + _mensaje;
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
            strSql = "select num_sec_movimiento, num_sec_transaccion, num_sec_item, num_sec_persona, num_sec_usuario, num_sec_mov_tipo, precio_unitario, ingreso, egreso " +
                "from alm_movimientos " +
                "where num_sec_movimiento = " + _num_sec_movimiento.ToString().Trim();
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
                _num_sec_movimiento = Convert.ToInt64(dr["num_sec_movimiento"].ToString());
                _num_sec_transaccion = Convert.ToInt64(dr["num_sec_transaccion"].ToString());
                _num_sec_item = Convert.ToInt64(dr["num_sec_item"].ToString());
                _num_sec_persona = Convert.ToInt64(dr["num_sec_persona"].ToString());
                _num_sec_usuario = Convert.ToInt64(dr["num_sec_usuario"].ToString());
                _num_sec_paso = Convert.ToInt64(dr["num_sec_paso"].ToString());
                _precio_unitario = Convert.ToDouble(dr["precio_unitario"].ToString());
                _ingreso = Convert.ToInt64(dr["ingreso"].ToString());
                _egreso = Convert.ToInt64(dr["egreso"].ToString());
                _fecha_registro = dr["fecha_registro"].ToString();
                _usuario_registro = dr["usuario_registro"].ToString();
                _num_sec_usuario_registro = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
            }
            dt.Dispose();
            if (!blEncontrado)
            {
                _num_sec_movimiento = 0;
                _num_sec_transaccion = 0;
                _num_sec_item = 0;
                _num_sec_persona = 0;
                _num_sec_usuario = 0;
                _num_sec_paso = 0;
                _precio_unitario = 0;
                _ingreso = 0;
                _egreso = 0;
                _fecha_registro = string.Empty;
                _usuario_registro = string.Empty;
                _num_sec_usuario_registro = 0;

                _mensaje = string.Empty;
                _strconexion = string.Empty;
            }
            return blEncontrado;
        }
        public bool InsertarVarios(string[] strSql, int cant)
        {
            bool blOperacionCorrecta = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.ListaSqls = strSql;
            OracleBD.NumSqls = cant;
            OracleBD.EjecutarSqlsTrans();
            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar los datos. Se encontró un error al insertaren la tabla alm_movimientos. " + _mensaje;
            return blOperacionCorrecta;
        }
        #endregion

        #region Procedimientos y Funciones Locales
        public string SQLCadenaMovimiento(bool Bing, bool Bsal) 
        {
            libItem = new BD_ALM_Items();
            libItem.StrConexion = StrConexion;
            libItem.NumSecItem = _num_sec_item;
            if (libItem.Ver() &&(Bsal))
            {
                _precio_unitario = libItem.PrecioMov;// actualiza el precio_mov al de la tabla items si es salida
            }  
            strSql = "INSERT INTO alm_movimientos (num_sec_movimiento, num_sec_transaccion, num_sec_item," +
                     " num_sec_persona, num_sec_usuario, num_sec_paso, precio_unitario, ingreso, egreso," +
                     " num_sec_usuario_reg) VALUES " +
                     " (" + _num_sec_movimiento +
                     ", alm_mov_trans_sec.NEXTVAL" +
                     ", " + _num_sec_item +
                     ", " + _num_sec_persona +
                     ", " + _num_sec_usuario +
                     ", " + _num_sec_paso +
                     ", " + _precio_unitario +
                     ", " + _ingreso +
                     ", " + _egreso +
                     ", " + _num_sec_usuario_registro + ")";
            return strSql;
        }
        public long ObtenerNSMov()
        {
            long num_sec=0;
            string strSql = string.Empty;
            strSql = "select alm_movimientos_sec.NEXTVAL as valor from dual";
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                num_sec = Convert.ToInt64(dr["valor"].ToString());
            }
            dt.Dispose();
            return num_sec;
        }

        public int ObtenerExistenciasItem(long num_sec_item)
        {
            string strSql = string.Empty;
            int existencias = 0;
            strSql = "select num_sec_item, (sum(ingreso) - sum(egreso)) as existencias from alm_movimientos"+
                     " where num_sec_item="+num_sec_item+" group by num_sec_item";
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                existencias = Convert.ToInt32(dr["existencias"].ToString());
            }
            dt.Dispose();
            return existencias;
        }

        public DataTable DTTransaccionesPasoAnterior(int paso, int [] deptos) //obtiene transacciones en el paso anterior a un paso específico
        {
            string usuario = (axVarSes.Lee<string>("UsuarioNumSec")).ToString();
            string strSql = string.Empty;
            string cadenaDeptos = string.Empty;
            for (int i=0; i<deptos.Length; i++)
            {
                cadenaDeptos += deptos[i];
                if (i!= deptos.Length-1)
                {
                    cadenaDeptos += ", ";
                }
            }
            strSql = "select distinct m.num_sec_transaccion, i.nombre as num_sec_item, m.num_sec_paso, ps.nombre as paso, m.egreso as cantidad"+
                    ", d.descripcion, per.ap_paterno||' '||per.nombres as persona " +
                    " from alm_movimientos m, alm_movimientos mov, alm_pasos pa, alm_pasos p, alm_pasos ps, personas per, alm_items i "+
                    ", alm_plantillas plant, dominios d" +
                    " where p.num_sec_paso=" + paso+
                    " AND p.num_sec_plantilla = plant.num_sec_plantilla "+
                    " AND plant.tipo_egreso = d.valor"+
                    " AND d.dominio = 'ALM_TIPO_EGRESO'"+
                    " and m.num_sec_paso=p.num_sec_paso_ant"+
                    " and m.num_sec_paso=ps.num_sec_paso"+
                    " and  m.num_sec_transaccion = mov.num_sec_transaccion"+
                    " and mov.num_sec_paso = pa.num_sec_paso"+
                    " and pa.num_sec_paso_ant = 0"+
                    " and m.num_sec_transaccion not in (select a.num_sec_transaccion from alm_movimientos a" +
                                            " where a.num_sec_paso="+paso+")"+
                    " and m.num_sec_transaccion not in (select a.num_sec_transaccion from alm_movimientos a, alm_pasos b" +
                                            " where b.tipo=4 and a.num_sec_paso=b.num_sec_paso)"+
                    " and per.num_sec=mov.num_sec_persona"+
                    " and m.num_sec_item=i.num_sec_item"+
                    " and m.num_sec_usuario in(select a.num_sec_usuario from alm_paso_subdepto_usu a"+
                                                " where a.num_sec_subdepartamento in("+cadenaDeptos+"))"+
                    " order by m.num_sec_transaccion";   
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            //dt.Dispose();
            return dt;
        }

        public bool autorizarSalida(long num_sec_transaccion, int paso, int cant)
        {
            bool blOperacionCorrecta = false;
            string strSql = string.Empty;
            strSql = "select * " +
                    "from alm_movimientos " +
                    " where num_sec_transaccion = " +num_sec_transaccion.ToString().Trim()+
                    " and num_sec_paso = "+paso;
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                _num_sec_transaccion = Convert.ToInt64(dr["num_sec_transaccion"].ToString());
                _num_sec_item = Convert.ToInt64(dr["num_sec_item"].ToString());
                _num_sec_persona = Convert.ToInt64(dr["num_sec_persona"].ToString());
                _num_sec_usuario = Convert.ToInt64(dr["num_sec_usuario"].ToString());
                _num_sec_paso = Convert.ToInt64(dr["num_sec_paso"].ToString());
                _precio_unitario = Convert.ToDouble(dr["precio_unitario"].ToString());
                _egreso = Convert.ToInt64(dr["ingreso"].ToString());  //se invierten ingreso y egreso para anular las cantidades
                _ingreso = Convert.ToInt64(dr["egreso"].ToString());
                blOperacionCorrecta = true;
            }
            if (blOperacionCorrecta)
            {
                int numsqls = 0;
                string[] strSqls = new string[10];
                strSqls[0] = CadInsertar();
                numsqls++;
                _num_sec_persona = Convert.ToInt64(axVarSes.Lee<string>("UsuarioPersonaNumSec"));
                _num_sec_usuario = Convert.ToInt64(axVarSes.Lee<string>("UsuarioNumSec"));
                libpasos = new BD_ALM_Pasos();
                libpasos.StrConexion = _strconexion;
                libpasos.NumSecPaso = _num_sec_paso;
                _num_sec_paso = libpasos.ObtenerPasoSgte();
                _egreso = cant;
                _ingreso = 0;
                strSqls[1] = CadInsertar();
                numsqls++;
                OracleBD.StrConexion = _strconexion;
                OracleBD.ListaSqls = strSqls;
                OracleBD.NumSqls = numsqls;
                OracleBD.EjecutarSqlsTrans();
                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible insertar los datos. Se encontró un error al insertar en la tabla alm_movimientos. " + _mensaje;
            }
            else
            {
                if (OracleBD.Error)
                    _mensaje = "No fue posible encontrar los datos. Se encontró un error al buscar en la tabla alm_movimientos. " + _mensaje;
            }
           

            return blOperacionCorrecta;
        }

        public bool RechazarSalida(long num_sec_transaccion, int paso, int cant)
        {
            bool blOperacionCorrecta = false;
            string strSql = string.Empty;
            strSql = "select * " +
                    "from alm_movimientos " +
                    " where num_sec_transaccion = " + num_sec_transaccion.ToString().Trim() +
                    " and num_sec_paso = " + paso;
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                _num_sec_transaccion = Convert.ToInt64(dr["num_sec_transaccion"].ToString());
                _num_sec_item = Convert.ToInt64(dr["num_sec_item"].ToString());
                _num_sec_persona = Convert.ToInt64(dr["num_sec_persona"].ToString());
                _num_sec_usuario = Convert.ToInt64(dr["num_sec_usuario"].ToString());
                _num_sec_paso = Convert.ToInt64(dr["num_sec_paso"].ToString());
                _precio_unitario = Convert.ToDouble(dr["precio_unitario"].ToString());
                _egreso = Convert.ToInt64(dr["ingreso"].ToString());  //se invierten ingreso y egreso para anular las cantidades
                _ingreso = Convert.ToInt64(dr["egreso"].ToString());
                blOperacionCorrecta = true;
            }
            if (blOperacionCorrecta)
            {
                int numsqls = 0;
                string[] strSqls = new string[10];
                strSqls[0] = CadInsertar();
                numsqls++;
                _num_sec_persona = Convert.ToInt64(axVarSes.Lee<string>("UsuarioPersonaNumSec"));
                _num_sec_usuario = Convert.ToInt64(axVarSes.Lee<string>("UsuarioNumSec"));
                libpasos = new BD_ALM_Pasos();
                libpasos.StrConexion = _strconexion;
                libpasos.NumSecPaso = _num_sec_paso;
                libpasos.Ver();
                _num_sec_paso = libpasos.ObtenerPasoRechazo();
                _egreso = cant;
                _ingreso = cant;
                strSqls[1] = CadInsertar();
                numsqls++;
                OracleBD.StrConexion = _strconexion;
                OracleBD.ListaSqls = strSqls;
                OracleBD.NumSqls = numsqls;
                OracleBD.EjecutarSqlsTrans();
                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible insertar los datos. Se encontró un error al insertar en la tabla alm_movimientos. " + _mensaje;
            }
            else
            {
                if (OracleBD.Error)
                    _mensaje = "No fue posible encontrar los datos. Se encontró un error al buscar en la tabla alm_movimientos. " + _mensaje;
            }


            return blOperacionCorrecta;
        }

        public string CadInsertar()
        {
            string usuario = axVarSes.Lee<string>("UsuarioNumSec");
            strSql = "insert into alm_movimientos (num_sec_movimiento, num_sec_transaccion, num_sec_item" +
                    ", num_sec_persona, num_sec_usuario, num_sec_paso, precio_unitario, ingreso, egreso" +
                    ", num_sec_usuario_reg) values " +
                    "(alm_movimientos_sec.nextval, " + _num_sec_transaccion + ", " + _num_sec_item + ", " +
                    _num_sec_persona + ", " + _num_sec_usuario + ", " + _num_sec_paso + ", " + _precio_unitario +
                    ", " + _ingreso + ", " + _egreso + ", " + usuario + " )";
            return strSql;
        }

        public string CadInsertarTodo()
        {
            string usuario = axVarSes.Lee<string>("UsuarioNumSec");
            strSql = "insert into alm_movimientos (num_sec_movimiento, num_sec_transaccion, num_sec_item" +
                    ", num_sec_persona, num_sec_usuario, num_sec_paso, precio_unitario, ingreso, egreso" +
                    ", num_sec_usuario_reg) values " +
                    "("+_num_sec_movimiento+", " + _num_sec_transaccion + ", " + _num_sec_item + ", " +
                    _num_sec_persona + ", " + _num_sec_usuario + ", " + _num_sec_paso + ", " + _precio_unitario +
                    ", " + _ingreso + ", " + _egreso + ", " + usuario + " )";
            return strSql;
        }

        public bool EntregarVariasSalidas(DataTable DTpedidos, string token)
        {
            bool blOperacionCorrecta = false;
            string[] strSqls = new string[(DTpedidos.Rows.Count*4)];
            int numsqls = 0;
            for (int i=0;i< DTpedidos.Rows.Count;i++)
            {
                DataRow dr = DTpedidos.Rows[i];
                blOperacionCorrecta = false;
                long num_sec_transaccion = Convert.ToInt64(dr["num_sec_transaccion"].ToString());
                int paso = Convert.ToInt32(dr["num_sec_paso"].ToString());
                int cant = Convert.ToInt32(dr["cantidad"].ToString());
                string strSql = string.Empty;
                strSql = "select * " +
                        "from alm_movimientos " +
                        " where num_sec_transaccion = " + num_sec_transaccion.ToString().Trim() +
                        " and num_sec_paso = " + paso;
                DataTable dt = new DataTable();
                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.sqlDataTable();
                dt = OracleBD.DataTable;
                if (dt.Rows.Count > 0)
                {
                    DataRow dr1 = dt.Rows[0];
                    _num_sec_transaccion = Convert.ToInt64(dr1["num_sec_transaccion"].ToString());
                    _num_sec_item = Convert.ToInt64(dr1["num_sec_item"].ToString());
                    _num_sec_persona = Convert.ToInt64(dr1["num_sec_persona"].ToString());
                    _num_sec_usuario = Convert.ToInt64(dr1["num_sec_usuario"].ToString());
                    _num_sec_paso = Convert.ToInt64(dr1["num_sec_paso"].ToString());
                    _precio_unitario = Convert.ToDouble(dr1["precio_unitario"].ToString());
                    _egreso = Convert.ToInt64(dr1["ingreso"].ToString());  //se invierten ingreso y egreso para anular las cantidades
                    _ingreso = Convert.ToInt64(dr1["egreso"].ToString());
                    blOperacionCorrecta = true;
                }
                if (blOperacionCorrecta)
                {
                    strSqls[numsqls] = CadInsertar();
                    numsqls++;
                    _num_sec_persona = Convert.ToInt64(axVarSes.Lee<string>("UsuarioPersonaNumSec"));
                    _num_sec_usuario = Convert.ToInt64(axVarSes.Lee<string>("UsuarioNumSec"));
                    libpasos = new BD_ALM_Pasos();
                    libpasos.StrConexion = _strconexion;
                    libpasos.NumSecPaso = _num_sec_paso;
                    _num_sec_paso = libpasos.ObtenerPasoSgte();
                    _num_sec_movimiento = ObtenerNSMov();
                    _egreso = cant;
                    _ingreso = 0;
                    strSqls[numsqls] = CadInsertarTodo();
                    numsqls++;
                    ////// insertar en alm_entregas
                    BD_ALM_Entregas libEntregas = new BD_ALM_Entregas();
                    BD_ALM_Tokens libtokens = new BD_ALM_Tokens();
                    libEntregas.StrConexion = _strconexion;
                    libEntregas.NumSecMovimiento = _num_sec_movimiento;
                    libEntregas.NumSecPersona= Convert.ToInt64(axVarSes.Lee<string>("NumSecUsuarioPersonaSolicitante"));
                    libEntregas.NumSecUsuarioRegistro = Convert.ToInt64(axVarSes.Lee<string>("UsuarioNumSec")); 
                    libtokens.StrConexion = StrConexion;
                    libtokens.Token = axVarSes.Lee<string>("TokenSolicitante");
                    libtokens.Ver();
                    libEntregas.NumSecToken = libtokens.NumSecToken;
                    strSqls[numsqls] = libEntregas.CadenaInsertar();
                    numsqls++;
                    
                }
               
            }
            OracleBD.StrConexion = _strconexion;
            OracleBD.ListaSqls = strSqls;
            OracleBD.NumSqls = numsqls;
            OracleBD.EjecutarSqlsTrans();
            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar los datos. Se encontró un error al insertar en la tabla alm_movimientos. " + _mensaje;
            return blOperacionCorrecta;
        }
        #endregion
    }
}