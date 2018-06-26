using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainCorreo
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 
        /*
         * Comentario en clase - hilos - tp04
         * -simular que esta entrando un paciente
         * -demora que tiene le tp esta adentro del hilo y va a salir.
         * -para hacer el sleep adentro de ese hilo vas a tener que frenarlo, el mismo metodo va a tener un sleep para que veas el paquete en cada estado
         * -ese metodo es el que va a tener el hilo y va a quedando iterando ese mock, va a pasar de estado al paquete va a esperar 10 seg y va a re ejecutarse, 
         * (espera 10 seg entre cada cambio de estado).
         * 
         * El hilo va aestar asociado a ese metodo, para que cada uno puede cargar paquetes y eso no se frene
         * 
         * 
         * Comentario:
         * verificar variable que indica cuando un formulario existe o no
         * te aseguras eso y asocias el evento con el metodo: frmdatos.actualizardatos += el nombre del evento
         * asignacion basica
         */
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmPpal());
        }


    }
}
