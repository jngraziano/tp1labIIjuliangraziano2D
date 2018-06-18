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
        #region Eventos
        // Delegado del evento
        public delegate void DelegadoEstado(); //ver parametros
        // Evento del tipo del delegado
        public event DelegadoEstado EventoQueGenera;

        #endregion

        #region Enumerado
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado

        }
        #endregion

        #region Variables, Propiedades y Constructor
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;


        public string DireccionEntrega { get { return this.direccionEntrega; } set { this.direccionEntrega = value; } }
        public EEstado Estado { get { return this.estado; } set { this.estado = value; } }
        public string TrackingID { get { return this.trackingID; } set { this.trackingID = value; } }

        public Paquete()
        { }
        public Paquete(string direccionEntregatrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntregatrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;
            this.EventoQueGenera += InformaEstado;
        }

        #endregion

       

        #region Metodos
        public void MockClicloDeVida()
        {
            do
            {
                Thread.Sleep(10000);

                this.Estado = EEstado.EnViaje;
                this.InformaEstado();




                this.Estado = (this.Estado == EEstado.Ingresado) ? EEstado.EnViaje : EEstado.Entregado;
                EventoQueGenera();

            } while (Estado != EEstado.Entregado);
            //falta guardar paquete en base de datos con evento

            //???
        }       
        
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
            //ver esto

        }

        /// <summary>
        /// Generará un evento en el tiempo dado en el constructor
        /// </summary>
        public void InformaEstado()
        {

        }

        #endregion

        #region Operadores y Sobrecargas
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            
            //bool rta = false;
            //if (p1.TrackingID == p2.TrackingID)
            //{
            //    rta = true;
            //}

            //return rta;



            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
            { return false; }
                
            return (p1.TrackingID == p2.TrackingID);
        }


        public static bool operator !=(Paquete p1, Paquete p2)
        { return !(p1 == p2); }

        public override bool Equals(object obj)
        {
            return this == (Paquete)obj;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }


        #endregion


    }
}
