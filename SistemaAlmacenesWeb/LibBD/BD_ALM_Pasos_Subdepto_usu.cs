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
        // Campos de la tabla alm_movimientos_tipos
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
            string usuario = axVarSes.Lee<string>("UsuarioPersonaNumSec");
            string login = axVarSes.Lee<string>("UsuarioPersonaNumSec");
            strSql = "insert into alm_paso_subdepto_usu (num_sec_paso_usu, num_sec_paso, num_sec_subdepartamento"+
                    ", num_sec_usuario, activo, usuario_registro, fecha_registro, num_sec_usuario_reg) values" +
                    "(ALM_PASO_SUBD_USU_SEC.NEXTVAL, "+_num_sec_paso+", "+_num_sec_subdepartamento+
                    ", "+_num_sec_usuario+",1,'"+login+"',SYSDATE,usuario)";
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

        public bool VerPasosUsuario(bool ingreso, bool salida)
        {
            bool blEncontrado = false;
            string usuario = (axVarSes.Lee<string>("UsuarioNumSec")).ToString();
            string strSql = string.Empty;
            strSql = "select a.num_sec_paso, b.nombre, b.num_sec_plantilla " +
                    " from alm_paso_subdepto_usu a, alm_pasos b, alm_plantillas c" +
                    "where a.num_sec_usuario=" + usuario +
                    " and b.num_sec_paso_ant <> 0" +
                    " and a.num_sec_paso=b.num_sec_paso" +
                    " and b.num_sec_plantilla=c.num_sec_plantilla";
            if (salida)
            {
                strSql+=" and c.tipo_ingreso=0";
            }    
            if (ingreso)
            {
                strSql += " and c.tipo_egreso=0";
            } 
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
        #endregion
    }
}