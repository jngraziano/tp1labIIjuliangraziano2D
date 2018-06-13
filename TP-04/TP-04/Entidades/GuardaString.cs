using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardaString
    {
       
        public static bool Guardar(this string text, string archivo)
        {
            //(archivosTexto.Guardar(rutaArchivoTexto, new Item("Olga", 32, 1.5f).ToString())

            try
            {
                //text
                //Si el archivo existe agregarà informaciòn en el.
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(archivo, true))
                {
                    file.WriteLine(text);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
           
        }

        public override string String()
        {
            return "asd";
        }
    }
}
