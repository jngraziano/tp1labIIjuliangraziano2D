using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
        

        

    public class Paquete:IMostrar<Paquete>
    {
        #region Enumerado
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado

        }
        #endregion

        #region Eventos
        // Creo delegado del evento
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;

        #endregion

        #region Atributos y Propiedades
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        
        public string DireccionEntrega { get { return this.direccionEntrega; } set { this.direccionEntrega = value; } }
        public EEstado Estado { get { return this.estado; } set { this.estado = value; } }
        public string TrackingID { get { return this.trackingID; } set { this.trackingID = value; } }
        #endregion

        #region Constructor
        /// <summary>
        /// El estado lo asigno como Ingresado.
        /// </summary>
        /// <param name="direccionEntregatrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntregatrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntregatrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado; 
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Repito el ciclo y lo corto -> Estado=entregado
        /// </summary>
        public void MockClicloDeVida()
        {


            while (true)
            {
                InformaEstado.Invoke(this, EventArgs.Empty);



                Thread.Sleep(10000);
                if (this.Estado == EEstado.Entregado)
                {
                    break;
                }
                this.Estado++;
            }

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                throw e;
            }           

            
        }


        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("{0} para {1}\n", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega));

            return sb.ToString();
        }

       
        #endregion

        #region Operadores y Sobrecargas
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            
            bool rta = false;
            //Verifico que no sea null primero
            if ((object)p1 != null && (object)p2 != null)
            {
                if (p1.TrackingID == p2.TrackingID)
                {
                    rta = true;
                }
            }
                
            return rta;
        }


        public static bool operator !=(Paquete p1, Paquete p2)
        { return !(p1 == p2); }

       

        public override string ToString()
        {
            //return ((IMostrar<Paquete>)this).MostrarDatos(this);
            return this.MostrarDatos(this);
           
        }


        #endregion


    }
}
