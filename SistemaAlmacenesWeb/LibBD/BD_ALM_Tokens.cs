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
using System.Text;
using System.Security.Cryptography;

namespace SistemaAlmacenesWeb
{
    // Creado por: Ignacio Rios; Fecha: 09/01/2019
    // Ultima modificación: Ignacio Rios; Fecha: 09/01/2019
    // Descripción: Clase referente a la tabla alm_tokens
    public class BD_ALM_Tokens
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
        private long _num_sec_token = 0;
        private long _num_sec_subdepartamento = 0;
        private short _activo = 0;
        private string _token = string.Empty;
        private string _fecharegistro = string.Empty;
        private string _usuarioregistro = string.Empty;
        private long _numsecusuarioregistro = 0;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecToken
        {
            get { return _num_sec_token; }
            set { _num_sec_token = value; }
        }

        public long NumSecSubdepartamento
        {
            get { return _num_sec_subdepartamento; }
            set { _num_sec_subdepartamento = value; }
        }

        public string Token
        {
            get { return _token; }
            set { _token = value; }
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
        public BD_ALM_Tokens()
        {
            _num_sec_token = 0;
            _num_sec_subdepartamento = 0;
            _token = string.Empty;
            _activo = 0;
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
            strSql = GenerarCadenaInsert();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();
            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla alm_token. " + _mensaje;
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
            strSql = "select * from alm_tokens where token='"+_token+"' and activo=1";
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
                _num_sec_token = Convert.ToInt64(dr["num_sec_token"].ToString());
                _num_sec_subdepartamento = Convert.ToInt64(dr["num_sec_subdepartamento"].ToString());
                _token = dr["_token"].ToString();
                _activo = Convert.ToInt16(dr["activo"].ToString());
                _fecharegistro = dr["fecha_registro"].ToString();
                _usuarioregistro = dr["usuario_registro"].ToString();
                _numsecusuarioregistro = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
            }
            dt.Dispose();
            if (!blEncontrado)
            {
                _num_sec_token = 0;
                _num_sec_subdepartamento = 0;
                _token = string.Empty;
                _activo = 0;
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
        public string GenerarCadenaInsert()
        {
            string usuario = axVarSes.Lee<string>("UsuarioNumSec");
            _activo = 1;
            strSql = "insert into alm_tokens (num_sec_token, num_sec_subdepartamento, token, activo, num_sec_usuario_registro) values" +
                " (alm_tokens_sec.nextval," + _num_sec_subdepartamento + ", '" + _token + "'," + _activo + "," + usuario + " )";
            return strSql;
        }

        public bool AnularTokenDepto()
        {
            bool blOperacionCorrecta = false;
            strSql = "update alm_tokens set activo=0 where num_sec_subdepartamento="+_num_sec_subdepartamento;
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

        public string GenerarToken()
        {
            string token = string.Empty;
            string aleatorio = GenerarAleatorio().ToString();
            do
            {
            using (MD5 md5Hash = MD5.Create())
            {
                token = GetMd5Hash(md5Hash, aleatorio).ToUpper().Substring(0, 10);
            }
            } while (VerSiExisteToken(token));
            return token;
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // convierte la entrada en una cadena de bytes.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder para almacenar los bytes y generar una cadena
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // retorna una cadena hexadecimal
            return sBuilder.ToString();
        }

        public int GenerarAleatorio()
        {
            Random rnd = new Random();
            int numeroConDosCotas = rnd.Next(0, 999999999);
            //Console.WriteLine("Número entre 4 y 10: {0}", numeroConDosCotas);
            return numeroConDosCotas;
        }

        public bool VerSiExisteToken(string token)
        {
            bool existe = false;
            DataTable dt = new DataTable();
            strSql = "SELECT * from alm_tokens where token ='" + token + "'";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count > 0)
            {
                existe = true;
            }
            dt.Dispose();
            return existe;
        }

        public bool VerificarTokenDepto()
        {
            bool existe = false;
            DataTable dt = new DataTable();
            strSql = "SELECT * from alm_tokens where token ='" + _token + "'"+ " and num_sec_subdepartamento="+_num_sec_subdepartamento ;
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count > 0)
            {
                existe = true;
            }
            dt.Dispose();
            return existe;
        }
        #endregion

    }


}