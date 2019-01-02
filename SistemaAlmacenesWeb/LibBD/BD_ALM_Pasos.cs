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
    // Creado por: Alvaro Mamani            ; Fecha: 12/12/2018
    // Ultima modificación: Ignacio Rios  ; Fecha: 02/01/2019
    // Descripción: Clase referente a la tabla ALM_PASOS
    public class BD_ALM_Pasos
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
        private long _num_sec_paso = 0;
        private string _nombre = string.Empty;
        private string _abreviatura = string.Empty;
        private long _num_sec_paso_ant = 0;
        private short _tipo = 0;
        private long _num_sec_plantilla = 0;
        private string _fecha_registro = string.Empty;
        private string _usuario_registro = string.Empty;
        private long _num_sec_usuario_registro = 0;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecPaso
        {
            get { return _num_sec_paso; }
            set { _num_sec_paso = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Abreviatura
        {
            get { return _abreviatura; }
            set { _abreviatura = value; }
        }
        public long NucSecPasoAnt
        {
            get { return _num_sec_paso_ant; }
            set { _num_sec_paso_ant = value; }
        }

        public long NumSecPlantilla
        {
            get { return _num_sec_plantilla; }
            set { _num_sec_plantilla= value; }
        }

        public short Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
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
        public BD_ALM_Pasos()
        {
            _num_sec_paso = 0;
            _nombre = string.Empty;
            _abreviatura = string.Empty;
            _num_sec_paso_ant = 0;
            _tipo = 0;
            _num_sec_plantilla = 0;
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
            strSql = "insert into alm_pasos (num_sec_paso, nombre, abreviatura, num_sec_paso_ant"+
                    ", tipo, num_sec_plantilla, num_sec_usuario_reg) values " +
                    "(alm_pasos_sec.nextval, " + _nombre + ", " + _abreviatura + ", " + _num_sec_paso_ant + 
                    ", " + _tipo + ", " + _num_sec_plantilla + ", " + usuario + " )";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();
            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla alm_pasos. " + _mensaje;
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

        public bool Ver()
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            strSql = "select * from alm_pasos " +
                    "where num_sec_paso= " + _num_sec_paso.ToString().Trim();
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
                _num_sec_paso = Convert.ToInt64(dr["num_sec_paso"].ToString());
                _nombre = dr["nombre"].ToString();
                _abreviatura = dr["abreviatura"].ToString();
                _num_sec_paso_ant = Convert.ToInt64(dr["num_sec_paso_ant"].ToString());
                _num_sec_plantilla = Convert.ToInt64(dr["num_sec_plantilla"].ToString());
                _tipo = Convert.ToInt16(dr["tipo"].ToString());
                _fecha_registro = dr["fecha_registro"].ToString();
                _usuario_registro = dr["usuario_registro"].ToString();
                _num_sec_usuario_registro = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
            }
            dt.Dispose();
            if (!blEncontrado)
            {
                _num_sec_paso = 0;
                _nombre = string.Empty;
                _abreviatura = string.Empty;
                _num_sec_paso_ant = 0;
                _num_sec_plantilla = 0;
                _tipo = 0;
                _fecha_registro = string.Empty;
                _usuario_registro = string.Empty;
                _num_sec_usuario_registro = 0;

                _mensaje = string.Empty;
                _strconexion = string.Empty;
            }
            return blEncontrado;
        }

        #endregion

        #region Procedimientos y Funciones Locales
        public bool VerPrimeroPlantilla()
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            strSql = "select * from alm_pasos " +
                    " where num_sec_plantilla= " + _num_sec_plantilla.ToString().Trim() +
                    " and num_sec_paso_ant=0";                    
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
                _num_sec_paso = Convert.ToInt64(dr["num_sec_paso"].ToString());
                _nombre = dr["nombre"].ToString();
                _abreviatura = dr["abreviatura"].ToString();
                _num_sec_paso_ant = Convert.ToInt64(dr["num_sec_paso_ant"].ToString());
                _num_sec_plantilla = Convert.ToInt64(dr["num_sec_plantilla"].ToString());
                _tipo = Convert.ToInt16(dr["tipo"].ToString());
                _fecha_registro = dr["fecha_registro"].ToString();
                _usuario_registro = dr["usuario_registro"].ToString();
                _num_sec_usuario_registro = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
            }
            dt.Dispose();
            if (!blEncontrado)
            {
                _num_sec_paso = 0;
                _nombre = string.Empty;
                _abreviatura = string.Empty;
                _num_sec_paso_ant = 0;
                _num_sec_plantilla = 0;
                _tipo = 0;
                _fecha_registro = string.Empty;
                _usuario_registro = string.Empty;
                _num_sec_usuario_registro = 0;

                _mensaje = string.Empty;
                _strconexion = string.Empty;
            }
            return blEncontrado;
        }
        #endregion
    }
}