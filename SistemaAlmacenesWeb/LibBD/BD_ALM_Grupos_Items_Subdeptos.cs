﻿using System;
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
    // Ultima modificación: Ignacio Rios; Fecha: 10/12/2018
    // Descripción: Clase referente a la tabla alm_grupos_items_subdeptos
    public class BD_ALM_Grupos_Items_Subdeptos
    {
        #region Variables Locales
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        GEN_VarSession axVarSes = new GEN_VarSession();
        private string strSql = string.Empty;
        #endregion

        #region Atributos
        // Campos de la tabla alm_grupos_items_subdeptos

        private long _num_sec_grupo_subdepto = 0;
        private long _num_sec_grupo_items = 0;
        private long _num_sec_subdepto = 0;
        private short _estado = 0;
        private string _fecharegistro = string.Empty;
        private string _usuarioregistro = string.Empty;
        private long _numsecusuarioregistro = 0;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecGrupoSubdepto
        {
            get { return _num_sec_grupo_subdepto; }
            set { _num_sec_grupo_subdepto= value; }
        }

        public long NumSecGrupoItem
        {
            get { return _num_sec_grupo_items; }
            set { _num_sec_grupo_items = value; }
        }

        public long NumSecSubdepto
        {
            get { return _num_sec_subdepto; }
            set { _num_sec_subdepto= value; }
        }

        public short Estado
        {
            get { return _estado; }
            set { _estado = value; }
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
        public BD_ALM_Grupos_Items_Subdeptos()
        {
            _num_sec_grupo_subdepto = 0;
            _num_sec_grupo_items = 0;
            _num_sec_subdepto= 0;
            _estado = 0;
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
            strSql = "insert into alm_grupos_items_subdeptos (num_sec_grupo_subdepto, num_sec_subdepto, "+
                      " num_sec_grupo_items, estado, num_sec_usuario_reg) values"+
                      " (alm_grupo_item_sec.nextval,"+ _num_sec_subdepto+", "+ _num_sec_grupo_items + 
                      ", " + _estado + ", " +usuario +" )";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();
            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla alm_grupo_items. " + _mensaje;
            return blOperacionCorrecta;
        }

        public void  Modificar()
        {

        }

        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            strSql = "delete alm_almacenes ";
            strSql += " where num_sec_grupo_items = " + _num_sec_grupo_items.ToString();

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible borrar el dato. Se encontró un error al eliminar en la tabla alm_grupos_items. " + _mensaje;
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
                _num_sec_grupo_subdepto = Convert.ToInt64(dr["num_sec_grupo_subdepto"].ToString());
                _num_sec_grupo_items = Convert.ToInt64(dr["num_sec_grupo_items"].ToString());
                _num_sec_subdepto = Convert.ToInt64(dr["num_sec_subdepto"].ToString());
                _estado = Convert.ToInt16(dr["estado"].ToString());
                _fecharegistro = dr["fecha_registro"].ToString();
                _usuarioregistro = dr["usuario_registro"].ToString();
                _numsecusuarioregistro = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
            }
            dt.Dispose();
            if (!blEncontrado)
            {
                _num_sec_grupo_subdepto = 0;
                _num_sec_grupo_items = 0;
                _num_sec_subdepto = 0;
                _estado = 0;
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