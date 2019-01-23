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
    // Creado por: Ignacio Rios; Fecha: 08/01/2019
    // Ultima modificación: Ignacio Rios; Fecha: 08/01/2019
    // Descripción: Clase referente a la tabla gen_subdepartamentos
    public class BD_GEN_Subdeptos
    {
        #region Variables Locales
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        GEN_VarSession axVarSes = new GEN_VarSession();
        private string strSql = string.Empty;
        #endregion

        #region Atributos
        // Campos de la tabla gen_subdepartamentos

        private long _num_sec_subdepartamento = 0;
        private long _num_sec_departamento = 0;
        private short _tipo = 0;
        private string _nombre = string.Empty;
        private string _fecharegistro = string.Empty;
        private string _usuarioregistro = string.Empty;
        private long _numsecusuarioregistro = 0;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecSubdepto
        {
            get { return _num_sec_subdepartamento; }
            set { _num_sec_subdepartamento = value; }
        }

        public long NumSecDepartamento
        {
            get { return _num_sec_departamento; }
            set { _num_sec_departamento = value; }
        }

        public short Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
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
        public BD_GEN_Subdeptos()
        {
            _num_sec_subdepartamento = 0;
            _num_sec_departamento = 0;
            _tipo = 0;
            _nombre = string.Empty;
            _fecharegistro = string.Empty;
            _usuarioregistro = string.Empty;
            _numsecusuarioregistro = 0;

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }
        #endregion

        #region Metodos
        public void Insertar()
        {

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
            strSql = "select * from gen_subdepartamentos where num_sec_subdepartamento=" + _num_sec_subdepartamento;
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
                _num_sec_subdepartamento = Convert.ToInt64(dr["num_sec_subdepartamento"].ToString());
                _num_sec_departamento = Convert.ToInt64(dr["num_sec_departamento"].ToString());
                _nombre = dr["nombre"].ToString();
                _tipo = Convert.ToInt16(dr["tipo"].ToString());
                _fecharegistro = dr["fecha_registro"].ToString();
                _usuarioregistro = dr["usuario_registro"].ToString();
                _numsecusuarioregistro = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
            }
            dt.Dispose();
            if (!blEncontrado)
            {
                _num_sec_subdepartamento = 0;
                _num_sec_departamento = 0;
                _tipo = 0;
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

        public DataTable DTBuscarSubdeptos(string cad)
        {
            string strSql = string.Empty;
            string subunidad = axVarSes.Lee<string>("SubUnidad");
            strSql = "select s.num_sec_subdepartamento, s.nombre"+
                     " from gen_subdepartamentos s, gen_departamentos d, gen_facultades f"+
                     " where Upper(s.nombre) like '%" + cad.ToUpper().Trim()+"%'"+
                     " and s.activo=1"+
                     " and f.num_sec_subunidad="+subunidad +
                     " and s.tipo IN (1,2,3,4,5,7)" +
                     " and s.num_sec_departamento= d.num_sec_departamento"+
                     " and d.num_sec_facultad=f.num_sec_facultad" +
                     " ORDER BY s.nombre ASC";
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            return dt;
        }


        public DataTable DTVerSubdeptos()
        {
            string strSql = string.Empty;
            string subunidad = axVarSes.Lee<string>("SubUnidad");
            strSql = "select s.num_sec_subdepartamento, s.nombre" +
                     " from gen_subdepartamentos s, gen_departamentos d, gen_facultades f" +
                     " where s.activo=1" +
                     " and f.num_sec_subunidad=" + subunidad +
                     " and s.tipo IN (1,2,3,4,5,7)" +
                     " and s.num_sec_departamento= d.num_sec_departamento" +
                     " and d.num_sec_facultad=f.num_sec_facultad";
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            return dt;
        }
        #endregion

    }


}