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
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo;

                StreamWriter txt = new StreamWriter(ruta, true);
                txt.WriteLine(texto);
                txt.Close();               
                               
                flag = true;
            }
            catch (Exception excep)
            {
                throw excep;

            }

            return flag; 
           
        }

      
    }
}
