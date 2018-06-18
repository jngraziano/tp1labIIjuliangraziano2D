using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /*Comentario escuchado profesor:
     * GetMessage
        
     * se accede con base. en los contructores. ahi esta la clave,
     * mandarlo en el constructor a la base :base(variable)
     * dsp llamo a messaghe
     * 
     * Lo siguiente es el default (tab,tab) editado por mi ->
     */

    public class TrackingIdRepetidoException : Exception
    {
               
        public TrackingIdRepetidoException(string message) 
            : base(message) 
        {
           
        }

        public TrackingIdRepetidoException(string message, Exception inner) 
            : base(message, inner) 
        {
           
         
        }
        
        
    }
}
