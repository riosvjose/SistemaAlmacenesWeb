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
    // Ultima modificación: Alvaro Mamani; Fecha: 19/12/2018
    // Descripción: Clase referente a la tabla alm_grupos_items
    public class BD_ALM_Grupos_Items
    {
        #region Variables Locales
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        GEN_VarSession axVarSes = new GEN_VarSession();
        private string strSql = string.Empty;
        #endregion

        #region Atributos
        // Campos de la tabla alm_grupos_items
        private long _num_sec_grupo_items = 0;
        private long _num_sec_almacen = 0;
        private string _nombre = string.Empty;
        private string _descripcion= string.Empty;
        private string _fecharegistro = string.Empty;
        private string _usuarioregistro = string.Empty;
        private long _numsecusuarioregistro = 0;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecGrupoItem
        {
            get { return _num_sec_grupo_items; }
            set { _num_sec_grupo_items = value; }
        }

        public long NumSecAlmacen
        {
            get { return _num_sec_almacen; }
            set { _num_sec_almacen = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
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
        public BD_ALM_Grupos_Items()
        {
            _num_sec_grupo_items = 0;
            _num_sec_almacen = 0;
            _nombre = string.Empty;
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
            strSql = "insert into alm_grupos_items (num_sec_grupo, nombre, num_sec_almacen, num_sec_usuario_reg) values " +
                    " (alm_grupos_items_sec.nextval, '" + _nombre + "', " + _num_sec_almacen + ", " + usuario + " )";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();
            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla alm_grupos_items. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool Modificar()
        {
            bool blOperacionCorrecta = false;
            strSql = "update alm_grupos_items set "+
                "nombre = '" + _nombre + "' " +
                "where num_sec_grupo = " + _num_sec_grupo_items.ToString();

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla alm_grupos_items. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            strSql = "delete alm_almacenes ";
            strSql += " where num_sec_grupo = " + _num_sec_grupo_items.ToString();

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
            strSql = "select * from alm_grupos_items where num_sec_grupo="+_num_sec_grupo_items.ToString();
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
                _num_sec_grupo_items = Convert.ToInt64(dr["num_sec_grupo"].ToString());
                _num_sec_almacen = Convert.ToInt64(dr["num_sec_almacen"].ToString());
                _nombre = dr["nombre"].ToString();
                _fecharegistro = dr["fecha_registro"].ToString();
                _usuarioregistro = dr["usuario_registro"].ToString();
                _numsecusuarioregistro = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
            }
            dt.Dispose();
            if (!blEncontrado)
            {
                _num_sec_grupo_items = 0;
                _num_sec_almacen = 0;
                _nombre = string.Empty;
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
        //Lista de Grupos Items a los que una persona tiene permisos segun el almacen
        public DataTable DTListaGrupos()
        {
            string usuario = axVarSes.Lee<string>("UsuarioNumSec");
            strSql = "SELECT DISTINCT a.num_sec_grupo, a.nombre " +
                        "FROM alm_grupos_items a, alm_almacenes b, alm_almacenes_usuarios c " +
                        "WHERE a.num_sec_almacen = b.num_sec_almacen " +
                            "AND b.num_sec_almacen = c.num_sec_almacen " +
                            "AND c.num_sec_usuario = " + usuario + " " +
                            "AND c.activo = 1 " +
                        "ORDER BY a.nombre ASC";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public DataTable DTListaGruposVariosAlmacen(string [] strsqlalm)
        {
            strSql = string.Empty;//"(select 0 as num_sec_grupo '-----------' as nombre from dual)";
            strSql += "Select * from (";
            for (int i=0; i<strsqlalm.Length;i++)
            {
                if (i != 0)
                {
                    strSql += " UNION ";
                }
                strSql += "(select num_sec_grupo, nombre from alm_grupos_items where num_sec_almacen =" + strsqlalm[i]+")";
            }
            strSql += ") Order By nombre";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public DataTable DTListaGruposPorDepto()
        {
            string subdepto = axVarSes.Lee<string>("strDeptoUsuario");
            strSql = "SELECT * FROM ( " +
                        "(select 0 as num_sec_grupo, '-----------' as nombre from dual)"+
                        " UNION "+
                        "(select g.num_sec_grupo, g.nombre from alm_grupos_items g, ALM_GRUPOS_ITEMS_SUBDEPTOS s"+
                        " where s.num_sec_subdepartamento=" + subdepto + 
                        " and g.num_sec_grupo=s.num_sec_grupo) " +
                    ") ORDER BY nombre";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public DataTable DTListaGruposUnAlmacen()
        {
            strSql = string.Empty;//"(select 0 as num_sec_grupo '-----------' as nombre from dual)";
            strSql ="select num_sec_grupo, nombre from alm_grupos_items "+
                    " where num_sec_almacen =" +_num_sec_almacen + "order By nombre";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }
        #endregion

    }


}