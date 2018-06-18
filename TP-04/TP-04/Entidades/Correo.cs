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
        #region Variables Propiedades Constructor

        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        
        
        public List<Paquete> Paquetes { get { return this.paquetes; } set { this.paquetes = value; } }

        public Correo()
        { 
            this.Paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }

        #endregion

        #region Metodos

        public void FinEntregas()
        {
            foreach (Thread aux in this.mockPaquetes)
            {
                if (aux.IsAlive)
                    aux.Abort();
            }
            //Environment.Exit(Environment.ExitCode);

            //WTF
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete aux in (List<Paquete>)elementos)
            {
                sb.AppendFormat("{0} para {1} ({2})", aux.TrackingID, aux.DireccionEntrega,
                aux.Estado.ToString());
            }
            return sb.ToString();
        }

        #endregion

        #region Operadores
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete item in c.Paquetes)
            {
                if (item == p)
                {
                    throw new TrackingIdRepetidoException("El paquete se encuentra repetido.");
                }
                   
            }
            c.Paquetes.Add(p);
            Thread hiloMock = new Thread(p.MockClicloDeVida);
            c.mockPaquetes.Add(hiloMock);
            hiloMock.Start();
            return c;
        }

        #endregion

    }
}
