using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace nsGEN_Numeros
{
    // Creado por: Milco Cortez; Fecha: 12/08/2015
    // Ultima modificación: Milco Cortez;  Fecha:12/08/2015
    // Descripción: Permite diversas funciones sobre números
    public class GEN_Numeros
    {
        #region Variables Locales
        #endregion

        #region Atributos
        #endregion

        #region Constructores
        public GEN_Numeros()
        { }
        #endregion

        #region Metodos

        public string fl_literal(double p_numero)
        {
            int vli_contador = 1;
            long vll_valor = Convert.ToInt64(Math.Truncate(p_numero));
            string vls_primero = string.Empty;
            string vls_aux = string.Empty;

            string strValor = vll_valor.ToString().Trim();

            if (strValor.Length == 1 || strValor.Length == 4 || strValor.Length == 7)
            {
                switch (Convert.ToInt16(strValor.Substring(0,1)))
	            {
                    case 1:
                        if (strValor.Length > 1)
                            vls_primero = "un ";
                        else
                            vls_primero = "uno ";
                        break;
                    case 2:
                        vls_primero = "dos ";
                        break;
                    case 3:
                        vls_primero = "tres ";
                        break;
                    case 4:
                        vls_primero = "cuatro ";
                        break;
                    case 5:
                        vls_primero = "cinco ";
                        break;
                    case 6:
                        vls_primero = "seis ";
                        break;
                    case 7:
                        vls_primero = "siete ";
                        break;
                    case 8:
                        vls_primero = "ocho ";
                        break;
                    case 9:
                        vls_primero = "nueve ";
                        break;
                }
                vli_contador = 1;
            }
            if (strValor.Length == 2 || strValor.Length == 5)
            {
                if (Convert.ToInt16(strValor.Substring(0,1)) == 1)
                {
                    switch (Convert.ToInt16(strValor.Substring(0,2)))
                    {
                        case 10:
                            vls_primero = "diez ";
                            break;
                        case 11:
                            vls_primero = "once ";
                            break;
                        case 12:
                            vls_primero = "doce ";
                            break;
                        case 13:
                            vls_primero = "trece ";
                            break;
                        case 14:
                            vls_primero = "catorce ";
                            break;
                        case 15:
                            vls_primero = "quince ";
                            break;
                        case 16:
                            vls_primero = "dieciseis ";
                            break;
                        case 17:
                            vls_primero = "diecisiete ";
                            break;
                        case 18:
                            vls_primero = "dieciocho ";
                            break;
                        case 19:
                            vls_primero = "diecinueve ";
                            break;
                    }
                    vli_contador = 2;
                }
                else
                {
                    if (Convert.ToInt16(strValor.Substring(1, 1)) == 0)
                    {
                        vli_contador = 2;
                    }
                    else
                    {
                        vli_contador = 1;
                    }
                    switch (Convert.ToInt16(strValor.Substring(0, 1)))
                    {
                        case 2:
                            if (Convert.ToInt16(strValor.Substring(1,1)) == 0)
                            {
                                vls_primero = "veinte ";
                            }
                            else
                            {
                                vls_primero = "veinti ";
                            }
                            break;
                        case 3:
                            vls_primero = "treinta ";
                            break;
                        case 4:
                            vls_primero = "cuarenta ";
                            break;
                        case 5:
                            vls_primero = "cincuenta ";
                            break;
                        case 6:
                            vls_primero = "sesenta ";
                            break;
                        case 7:
                            vls_primero = "setenta ";
                            break;
                        case 8:
                            vls_primero = "ochenta ";
                            break;
                        case 9:
                            vls_primero = "noventa ";
                            break;
                    }
                }
            }

            if (strValor.Length == 3 || strValor.Length == 6)
            {
                vli_contador = 1;
                switch (Convert.ToInt16(strValor.Substring(0, 1)))
                {
                    case 1:
                        if (Convert.ToInt16(strValor.Substring(1,2)) == 0)
                            vls_primero = "cien ";
                        else
                            vls_primero = "ciento ";
                        break;
                    case 2:
                        vls_primero = "doscientos ";
                        break;
                    case 3:
                        vls_primero = "trescientos ";
                        break;
                    case 4:
                        vls_primero = "cuatrocientos ";
                        break;
                    case 5:
                        vls_primero = "quinientos ";
                        break;
                    case 6:
                        vls_primero = "seiscientos ";
                        break;
                    case 7:
                        vls_primero = "setecientos ";
                        break;
                    case 8:
                        vls_primero = "ochocientos ";
                        break;
                    case 9:
                        vls_primero = "novecientos ";
                        break;
                }

            }

            vli_contador++;
            if (strValor.Length > 3 && strValor.Substring(vli_contador--,20).Length < 4)
                vls_primero += "mil ";
            if (strValor.Length == 6 && strValor.Substring(1, 2) == "00")
                vls_primero += "mil ";

            if (strValor.Length > 6)
            {
                if (strValor.Substring(0, 1) == "1")
                {
                    vls_primero += "millon ";
                }
                else
                {
                    vls_primero += "millones ";
                }

            }

            if ((strValor.Length == 2 && strValor.Substring(vli_contador--,20).Length == 1) || (strValor.Length == 5 && strValor.Substring(vli_contador--,20).Length == 4))
            {
                if (strValor.Substring(0,1) != "2" && strValor.Substring(1,1) != "0")
                {
                    vls_primero += "y ";
                }
            }

            string strNumero = p_numero.ToString().Trim();
            string strNumeroRedondeado = Math.Round(p_numero,2).ToString().Trim();
            string strDosUltimosDigitos = strNumeroRedondeado.Substring(strNumeroRedondeado.Length-3,2);

            double dblNumeroNuevo = 0;
            double dblNumeroAux = 0;

            if (strNumero.Substring(vli_contador--,10) != "")
            {
                dblNumeroNuevo = Convert.ToDouble(strNumero.Substring(vli_contador--,10));
                if (Math.Truncate(dblNumeroNuevo) > 0)
                {
                    return vls_primero + fl_literal(dblNumeroNuevo);
                }
                else
                {
                    if (Math.Round(Convert.ToDouble(strNumero.Substring(vli_contador--,10)),2) == 0)
                    {
                        vls_primero += "con 00/100";
                    }
                    else
                    {
                        if (strDosUltimosDigitos.Substring(0,1) == ".")
                        {
                            vls_aux = strNumeroRedondeado + "0";
                            vls_aux = vls_aux.Substring(vls_aux.Length-3,2);
                        }
                        else
                        {
                            vls_aux = strNumeroRedondeado.Substring(strNumeroRedondeado.Length-3,2);
                        }
                        dblNumeroAux = Math.Round(Convert.ToDouble(vls_aux),2);
                        if (Math.Truncate(dblNumeroAux) < 10)
                        {
                            vls_primero += "con 0" + Convert.ToInt16(dblNumeroAux).ToString().Trim() + "/100";
                        }
                        else
                        {
                            vls_primero += "con " + Convert.ToInt16(dblNumeroAux).ToString().Trim() + "/100";
                        }
                    }
                    return vls_primero;
                }
            }
            else
            {
                if (strNumero.Substring(vli_contador--,10) != "")
                {
                    if (Math.Round(Convert.ToDouble(strNumero.Substring(vli_contador--, 10)), 2) == 0)
                    {
                        vls_primero += "con 00/100";
                    }
                    else
                    {
                        if (strDosUltimosDigitos.Substring(0, 1) == ".")
                        {
                            vls_aux = strNumeroRedondeado + "0";
                            vls_aux = vls_aux.Substring(vls_aux.Length - 3, 2);
                        }
                        else
                        {
                            vls_aux = strNumeroRedondeado.Substring(strNumeroRedondeado.Length - 3, 2);
                        }
                        dblNumeroAux = Math.Round(Convert.ToDouble(vls_aux), 2);
                        if (Math.Truncate(dblNumeroAux) < 10)
                        {
                            vls_primero += "con 0" + Convert.ToInt16(dblNumeroAux).ToString().Trim() + "/100";
                        }
                        else
                        {
                            vls_primero += "con " + Convert.ToInt16(dblNumeroAux).ToString().Trim() + "/100";
                        }
                    }
                }
                else
                {
                    if (strNumero.Substring(vli_contador--, 10) == "")
                    {
                        vls_primero += "con 00/100";
                    }
                    else
                    {
                        dblNumeroAux = Math.Round(Convert.ToDouble(strDosUltimosDigitos), 2);
                        if (Math.Truncate(dblNumeroAux) < 10)
                        {
                            vls_primero += "con 0" + Convert.ToInt16(dblNumeroAux).ToString().Trim() + "/100";
                        }
                        else
                        {
                            vls_primero += "con " + Convert.ToInt16(dblNumeroAux).ToString().Trim() + "/100";
                        }
                    }
                }
                return vls_primero;
            }
        }

        #endregion
    }
}