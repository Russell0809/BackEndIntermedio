using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros
{
    public class VG
    {
        public static string CXN_Libros;

        public static class FILES
        {
            private static System.Random RNDobj = new System.Random();

            public static string GeneraCadenaAleatoria(int piLong)
            {
                string sCadena = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_";
                string strNombreAleatorio = string.Empty;
                for (int i = 0; i < piLong; i++)
                {
                    strNombreAleatorio += sCadena[RNDobj.Next(sCadena.Length)].ToString();
                }

                return strNombreAleatorio;
            }
        }
    }
}
