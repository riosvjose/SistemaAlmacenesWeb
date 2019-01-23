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
    // Creado por: Alvaro Mamani            ; Fecha: 02/01/2019
    // Ultima modificación: Alvaro Mamani   ; Fecha: 02/01/2018
    // Descripción: Clase referente a la tabla ALM_Pasos_Subdepto_usu
    public class BD_ALM_Pasos_Subdepto_usu
    {
        #region librerias externas
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        GEN_VarSession axVarSes = new GEN_VarSession();
        #endregion

        #region Variables Locales
        private string strSql = string.Empty;
        #endregion

        #region Atributos
        // Campos de la tabla ALM_Pasos_Subdepto_usu
        private long _num_sec_paso_usu = 0;
        private long _num_sec_paso = 0;
        private long _num_sec_subdepartamento = 0;
        private long _num_sec_usuario = 0;
        private short _activo = 0;
        private string _fecha_registro = string.Empty;
        private string _usuario_registro = string.Empty;
        private long _num_sec_usuario_registro = 0;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecPaso_Usu
        {
            get { return _num_sec_paso_usu; }
            set { _num_sec_paso_usu = value; }
        }

        public long NumSecPaso
        {
            get { return _num_sec_paso; }
            set { _num_sec_paso = value; }
        }

        public long NumSecSubdepto
        {
            get { return _num_sec_subdepartamento; }
            set { _num_sec_subdepartamento = value; }
        }

        public long NumSecUsuario
        {
            get { return _num_sec_usuario; }
            set { _num_sec_usuario = value; }
        }

        public short Activo
        {
            get { return _activo; }
            set { _activo = value; }
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
        public BD_ALM_Pasos_Subdepto_usu()
        {
            _num_sec_paso_usu = 0;
            _num_sec_paso = 0;
            _num_sec_subdepartamento = 0;
            _num_sec_usuario = 0;
            _activo = 0;
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
            string login = axVarSes.Lee<string>("UsuarioLogin");
            strSql = "insert into alm_paso_subdepto_usu (num_sec_paso_usu, num_sec_paso, num_sec_subdepartamento"+
                    ", num_sec_usuario, activo, usuario_registro, fecha_registro, num_sec_usuario_reg) values" +
                    "(ALM_PASO_SUBD_USU_SEC.NEXTVAL, "+_num_sec_paso+", "+_num_sec_subdepartamento+
                    ", "+_num_sec_usuario+",1,'"+login+"',SYSDATE,"+usuario+")";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();
            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla alm_paso_subdepto_usu. " + _mensaje;
            return blOperacionCorrecta;
        }

        public void Modificar()
        {
           
        }

        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            return blOperacionCorrecta;
        }

        public void Ver()
        {
            
        }

        #endregion

        #region Procedimientos y Funciones Locales
       public bool VerPermisosPasos(int paso)
       {
            bool blEncontrado = false;
            string usuario = (axVarSes.Lee<string>("UsuarioNumSec")).ToString();
            string strSql = string.Empty;
            strSql = "select * from alm_paso_subdepto_usu " +
                    "where num_sec_paso= " + _num_sec_paso.ToString().Trim()+
                    " and num_sec_usuario="+usuario;
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            _mensaje = OracleBD.Mensaje;
            if (dt.Rows.Count > 0)
            {
                blEncontrado = true;
                DataRow dr = dt.Rows[0];
                _num_sec_paso_usu = Convert.ToInt64(dr["num_sec_paso_usu"].ToString());
                _num_sec_paso = Convert.ToInt64(dr["num_sec_paso"].ToString());
                _num_sec_subdepartamento = Convert.ToInt64(dr["num_sec_subdepartamento"].ToString());
                _num_sec_usuario = Convert.ToInt64(dr["num_sec_usuario"].ToString());
                _activo = Convert.ToInt16(dr["activo"].ToString());
                _fecha_registro = dr["fecha_registro"].ToString();
                _usuario_registro = dr["usuario_registro"].ToString();
                _num_sec_usuario_registro = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
            }
            dt.Dispose();
            return blEncontrado;
        }

        public int[] VerPasosTramiteUsuario(int ingreso, int salida) // obtiene todos los pasos de tramite en los que interviene un usuario en una plantilla
        {
            string usuario = (axVarSes.Lee<string>("UsuarioNumSec")).ToString();
            string strSql = string.Empty;
            strSql = "select a.num_sec_paso"+
                    " from alm_paso_subdepto_usu a, alm_pasos b, alm_plantillas c" +
                    " where a.num_sec_usuario=" + usuario +
                    " and c.activo=1"+
                    " and b.num_sec_paso_ant <> 0" + //no valorara el primer paso de la plantilla
                    " and a.num_sec_paso=b.num_sec_paso" +
                    " and b.num_sec_plantilla=c.num_sec_plantilla "+
                    " and b.tipo =3";
            if (salida == 0)
            {
                strSql += " and c.tipo_egreso=0";
            }
            if (salida==1)
            {
                strSql+= " and c.tipo_egreso=1";
            }
            if (salida == 2)
            {
                strSql += " and c.tipo_egreso=2";
            }
            if (salida == 3)
            {
                strSql += " and c.tipo_egreso=3";
            }
            if (salida == 4)
            {
                strSql += " and c.tipo_egreso=4";
            }
            if (ingreso == 0)
            {
                strSql += " and c.tipo_ingreso=0";
            }
            if (ingreso == 1)
            {
                strSql += " and c.tipo_ingreso=1";
            }
            if (ingreso == 2)
            {
                strSql += " and c.tipo_ingreso=2";
            }
            if (ingreso == 3)
            {
                strSql += " and c.tipo_ingreso=3";
            }
            if (ingreso == 4)
            {
                strSql += " and c.tipo_ingreso=4";
            }
            strSql += " order by a.num_sec_paso asc";
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            _mensaje = OracleBD.Mensaje;
            int[] pasos = new int [dt.Rows.Count];
            if (dt.Rows.Count > 0)
            {
                for(int i=0; i< dt.Rows.Count;i++)
                {
                    DataRow dr = dt.Rows[i];
                    pasos[i] = Convert.ToInt32(dr["num_sec_paso"].ToString());
                }
            }
            dt.Dispose();
            return pasos;
        }

        public int[] VerPasosSalidaUsuario() // obtiene todos los pasos de tramite en los que interviene un usuario en uplantillas de salida
        {
            string usuario = (axVarSes.Lee<string>("UsuarioNumSec")).ToString();
            string strSql = string.Empty;
            strSql = "select a.num_sec_paso" +
                    " from alm_paso_subdepto_usu a, alm_pasos b, alm_plantillas c" +
                    " where a.num_sec_usuario=" + usuario +
                    " and c.activo=1" +
                    " and a.num_sec_paso=b.num_sec_paso" +
                    " and b.num_sec_plantilla=c.num_sec_plantilla " +
                    " and b.tipo =2"+
                    " and c.tipo_egreso <>0"+
                    " and c.tipo_egreso <>1"+
                    " and c.tipo_ingreso=0"+
                    " order by a.num_sec_paso asc";
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            _mensaje = OracleBD.Mensaje;
            dt = OracleBD.DataTable;
            int[] pasos = new int[dt.Rows.Count];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    pasos[i] = Convert.ToInt32(dr["num_sec_paso"].ToString());
                }
            }
            dt.Dispose();
            return pasos;
        }

        public int[] VerDeptosPasoUsuario(int paso) // obtiene todos los departamentos en los que el usuario realiza un paso
        {
            string usuario = (axVarSes.Lee<string>("UsuarioNumSec")).ToString();
            string strSql = string.Empty;
            strSql = "select num_sec_subdepartamento from alm_paso_subdepto_usu " +
                    " where num_sec_usuario=" + usuario +
                    " and num_sec_paso=" + paso.ToString(); ;
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            _mensaje = OracleBD.Mensaje;
            int[] pasos = new int[dt.Rows.Count];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    pasos[i] = Convert.ToInt32(dr["num_sec_subdepartamento"].ToString());
                }
            }
            dt.Dispose();
            return pasos;
        }

        public int[] VerPasosSalidaUsuario(int salida) // obtiene todos los pasos de salida de almacen en los que interviene un usuario en una plantilla
        {
            string usuario = (axVarSes.Lee<string>("UsuarioNumSec")).ToString();
            string strSql = string.Empty;
            strSql = "select a.num_sec_paso" +
                    " from alm_paso_subdepto_usu a, alm_pasos b, alm_plantillas c" +
                    " where a.num_sec_usuario=" + usuario +
                    " and b.num_sec_paso_ant <> 0" + //no valorara el primer paso de la plantilla
                    " and a.num_sec_paso=b.num_sec_paso" +
                    " and b.num_sec_plantilla=c.num_sec_plantilla " +
                    " and b.tipo =2 " +
                    " and c.activo=1 " +
                    " and c.tipo_ingreso=0" +
                    " and c.tipo_egreso="+salida+
                    " order by a.num_sec_paso asc";
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            _mensaje = OracleBD.Mensaje;
            int[] pasos = new int[dt.Rows.Count];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    pasos[i] = Convert.ToInt32(dr["num_sec_paso"].ToString());
                }
            }
            dt.Dispose();
            return pasos;
        }

        public DataTable VerUsuariosPaso() 
        {
            string strSql = string.Empty;
            strSql =" select distinct p.num_sec_paso, p.nombre as nombre_paso, pu.num_sec_usuario, u.num_sec_persona, u.login, "+
                " s.nombre as nombre_subdepto, s.num_sec_subdepartamento"+
                " from alm_paso_subdepto_usu pu, alm_pasos p, sam_usuarios u, gen_subdeptos_personas sp, gen_subdepartamentos s"+
                " where pu.num_sec_paso = "+_num_sec_paso+
                " AND pu.activo = 1"+
                " and pu.num_sec_usuario = u.num_sec_usuario "+
                " and pu.num_sec_paso = p.num_sec_paso "+
                " AND pu.num_sec_subdepartamento = s.num_sec_subdepartamento "+
                " order by s.nombre, u.login ASC";
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            _mensaje = OracleBD.Mensaje;
            return dt;
        }

        public bool VolverInactivo()
        {
            bool blOperacionCorrecta = false;
            string usuario = axVarSes.Lee<string>("UsuarioNumSec");
            strSql = "update alm_paso_subdepto_usu " +
                    " set activo = 0" +
                    " where num_sec_paso=" + _num_sec_paso +
                    " and num_sec_subdepartamento=" + _num_sec_subdepartamento +
                    " and num_sec_usuario=" + _num_sec_usuario;
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();
            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla alm_paso_subdepto_usu. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool VolverActivo()
        {
            bool blOperacionCorrecta = false;
            string usuario = axVarSes.Lee<string>("UsuarioNumSec");
            strSql = "update alm_paso_subdepto_usu " +
                    " set activo = 1" +
                   " where num_sec_paso=" + _num_sec_paso +
                    " and num_sec_subdepartamento=" + _num_sec_subdepartamento +
                    " and num_sec_usuario=" + _num_sec_usuario;
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();
            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla alm_paso_subdepto_usu. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool VerExistente()
        {
            bool blOperacionCorrecta = false;
            strSql = "select num_sec_alm_usuario" +
                     " from alm_paso_subdepto_usu" +
                    " where num_sec_paso=" + _num_sec_paso +
                    " and num_sec_subdepartamento=" + _num_sec_subdepartamento +
                    " and num_sec_usuario=" + _num_sec_usuario;
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count > 0)
            {
                blOperacionCorrecta = true;
            }
            dt.Dispose();
            return blOperacionCorrecta;
        }

        public DataTable DTVerSubdeptosTodosPasosUsu()
        {
            string strSql = string.Empty;
            strSql = " SELECT DISTINCT ps.num_sec_subdepartamento, s.nombre "+
                    " FROM alm_paso_subdepto_usu ps, gen_subdepartamentos s "+
                    " WHERE ps.num_sec_usuario = "+_num_sec_usuario +
                    " and ps.activo =1 "+
                    " AND ps.num_sec_subdepartamento = s.num_sec_subdepartamento"+
                    " ORDER BY s.nombre";
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            _mensaje = OracleBD.Mensaje;
            return dt;
        }

        #endregion
    }
}