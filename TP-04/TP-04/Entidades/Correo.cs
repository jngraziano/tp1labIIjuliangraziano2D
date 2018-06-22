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
            this.Paquetes = new List<Paquete>();

            this.mockPaquetes = new List<Thread>();
        }

        #endregion

        #region Metodos

        public void FinEntregas()
        {
            for (int i = 0; i < mockPaquetes.Count; i++)
            {
                mockPaquetes[i].Abort();
                mockPaquetes.RemoveAt(i);
            }
        }

        //llamo al mostrar datos de la interfaz
        string IMostrar<List<Paquete>>.MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            string devuelve = "";
            foreach (Paquete item in ((Correo)elemento).Paquetes)
            {
                devuelve += string.Format("{0} para {1} (Estado: {2})\n", item.TrackingID, item.DireccionEntrega, item.Estado.ToString());
            }

            return devuelve;
        }


   

        #endregion

        #region Operador +
        public static Correo operator +(Correo c, Paquete p)
        {
            bool flag = false;

            //no es nulo
            if (p != null)
            {
                foreach (Paquete item in c.Paquetes)
                {
                    if (item == p)
                    {
                        flag = true;
                        string mensajeException = "El paquete con tracking ID:" + p.TrackingID + " ya fue enviado previamente.";
                        
                        TrackingIdRepetidoException excep = new TrackingIdRepetidoException(mensajeException);
                        throw excep; 
                    }
                }

                if (flag == false)
                {
                    c.Paquetes.Add(p);
                    try
                    {
                        Thread hiloParaPaquete = new Thread(p.MockClicloDeVida);
                        c.mockPaquetes.Add(hiloParaPaquete);
                        hiloParaPaquete.Start();
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
