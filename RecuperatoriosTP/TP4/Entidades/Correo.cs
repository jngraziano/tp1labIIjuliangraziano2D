using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos y Propiedades

        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        
        
        public List<Paquete> Paquetes 
        { 
            get { return this.paquetes; }
            set
            {
                //Verifico que value no sea null antes de asignar
                if (value != null)
                {
                    this.paquetes = value; 
                }
            } 
        }
        #endregion

        #region Constructor
        public Correo()
        { 
            //Instancio las dos listas
            this.Paquetes = new List<Paquete>();

            mockPaquetes = new List<Thread>();
        }

        #endregion

        #region Metodos
       
        /// <summary>
        /// Implemento el MostrarDatos de la interfaz
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in ((Correo)elemento).Paquetes)
            {
                sb.AppendLine(string.Format("{0} para {1} ({2})", item.TrackingID, item.DireccionEntrega, item.Estado.ToString()));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Cierro los hilos.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                item.Abort();
            }
        }

   

        #endregion

        #region Operador +
        public static Correo operator +(Correo c, Paquete p)
        {
            bool flag = false;

            //Verifico primero que no sea nulo el Paquete
            if (p != null)
            {
                foreach (var item in c.Paquetes)
                {
                    if (item == p)
                    {
                        flag = true;
                        string mensajeException = "El paquete con tracking ID: " + p.TrackingID + " ya fue enviado previamente.";
                        
                        TrackingIdRepetidoException excep = new TrackingIdRepetidoException(mensajeException);
                        throw excep; 
                    }
                }

                if (flag == false)
                {
                    c.Paquetes.Add(p);
                    try
                    {
                        Thread hiloMock = new Thread(p.MockClicloDeVida);
                        c.mockPaquetes.Add(hiloMock);
                        hiloMock.Start();
                    }
                    catch (Exception excep)
                    {
                        throw excep;
                    }
                }
            }
            return c;
        }

        #endregion

    }
}
