using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Globalization;

// **************** PEMNDIENTE ******************

namespace nsGEN_Fechas
{
    // Creado por: Milco Cortes; Fecha: 04/09/2015
    // Ultima modificación: Milco Cortes;  Fecha:04/09/2015
    // Descripción: Permite diversas funciones sobre datos de tipo fecha
    public class GEN_Fechas
    {
        #region Variables Locales
        #endregion

        #region Atributos
        #endregion

        #region Constructores
        public GEN_Fechas()
        { }
        #endregion

        #region Metodos

        public bool Validar_Fecha_Hora(string strFecha, int intTipo)
        {
            // intTipo = 1:solo fecha; 2:fecha y hora; 3:fecha, hora y segundos

            bool blCumpleFormato = false;
            bool blCumpleTamanio = false;
            DateTime dtFecha1;
            string strFecha1 = string.Empty;
            string strHora1 = string.Empty;

            try
            {
                strFecha1 = strFecha.Trim().Substring(0, 10);
                switch (intTipo)
                {
                    case 1:
                        if (strFecha.Trim().Length == 10)
                        {
                            blCumpleTamanio = true;
                        }
                        break;
                    case 2:
                        if (strFecha.Trim().Length == 16)
                        {
                            blCumpleTamanio = true;
                            strHora1 = strFecha.Trim().Substring(11, 5);
                        }
                        break;
                    case 3:
                        if (strFecha.Trim().Length == 19)
                        {
                            blCumpleTamanio = true;
                            strHora1 = strFecha.Trim().Substring(11, 8);
                        }
                        break;
                    default:
                        break;
                }

                if (blCumpleTamanio && strFecha1.Length == 10)
                {
                    dtFecha1 = Convert.ToDateTime(strFecha1);

                    string strSeparadorF1 = strFecha1.Substring(2, 1).Trim();
                    string strSeparadorF2 = strFecha1.Substring(5, 1).Trim();
                    if (strSeparadorF1 == "/" && strSeparadorF2 == "/")
                    {
                        string strAnio = strFecha1.Substring(6, 4).Trim();
                        int intAnio = Convert.ToInt32(strAnio);
                        if (strAnio.Length == 4 && intAnio > 1900 && intAnio < 2200)
                        {
                            string strMes = strFecha1.Substring(3, 2).Trim();
                            int intMes = Convert.ToInt32(strMes);
                            if (strMes.Length == 2 && intMes > 0 && intMes < 13)
                            {
                                string strDia = strFecha1.Substring(0, 2).Trim();
                                int intDia = Convert.ToInt32(strDia);
                                if (strDia.Length == 2 && intDia > 0 && intDia <= 31)
                                {
                                    if (intTipo >= 2)
                                    {
                                        string strSeparadorH = strHora1.Substring(2, 1).Trim();
                                        if (strSeparadorH == ":")
                                        {
                                            string strHora = strHora1.Substring(0, 2).Trim();
                                            int intHora = Convert.ToInt32(strHora);
                                            if (strHora.Length == 2 && intHora >= 0 && intHora < 24)
                                            {
                                                string strMinutos = strHora1.Substring(3, 2).Trim();
                                                int intMinutos = Convert.ToInt32(strMinutos);
                                                if (strMinutos.Length == 2 && intMinutos >= 0 && intMinutos < 60)
                                                {
                                                    if (intTipo == 3)
                                                    {
                                                        string strSeparadorS = strHora1.Substring(5, 1).Trim();
                                                        if (strSeparadorS == ":")
                                                        {
                                                            string strSegundos = strHora1.Substring(6, 2).Trim();
                                                            int intSegundos = Convert.ToInt32(strSegundos);
                                                            if (strSegundos.Length == 2 && intSegundos >= 0 && intSegundos < 60)
                                                            {
                                                                blCumpleFormato = true;
                                                            }
                                                        }
                                                    }
                                                    else
                                                        blCumpleFormato = true;
                                                }
                                            }
                                        }
                                    }
                                    else
                                        blCumpleFormato = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                blCumpleFormato = false;
            }

            return blCumpleFormato;
        }


        public string Query_Anios()
        {
            return "";
        }


        #endregion
    }
}