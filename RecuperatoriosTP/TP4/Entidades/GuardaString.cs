using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {

        public static bool Guardar(this String texto, string archivo)
        {
            bool flag = false;
            try
            {
                //guardo la ruta y le doy al archivo el nombre que recibo
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo;

                StreamWriter txt = new StreamWriter(ruta, true);
                txt.WriteLine(texto);
                txt.Close();               
                               
                flag = true;
            }
            catch (ArgumentException)
            {
                string fallo = "Error en la ruta";
                throw new ArgumentException(fallo);

            }

            return flag; 
           
        }

      
    }
}
