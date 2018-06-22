﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
        #region Eventos
        // Creo delegado del evento
        public delegate void DelegadoEstado(object sender, EventArgs e);

        #endregion

        #region Enumerado
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado

        }
        #endregion

    public class Paquete:IMostrar<Paquete>
    {


        #region Atributos y Propiedades
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        public event DelegadoEstado EventoGenerado;
        public Exception HayExcepcion = null;


        public string DireccionEntrega { get { return this.direccionEntrega; } set { this.direccionEntrega = value; } }
        public EEstado Estado { get { return this.estado; } set { this.estado = value; } }
        public string TrackingID { get { return this.trackingID; } set { this.trackingID = value; } }
        #endregion

        #region Constructor
        
        public Paquete(string direccionEntregatrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntregatrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }

        #endregion

        #region Metodos
        public void MockClicloDeVida()
        {
            //Cambio de Ingresado a EnViaje
            Thread.Sleep(10000);
            this.Estado = EEstado.EnViaje;

            //informo estado mediante evento.
            EventArgs a = new EventArgs();
            this.EventoGenerado.Invoke(this, a);

            //Cambio de EnViaje a Entregado
            Thread.Sleep(10000);
            this.Estado = EEstado.Entregado;
            
            //informo estado mediante evento.
            this.EventoGenerado.Invoke(this, a);


            //Guardo en BD
            bool rta = PaqueteDAO.Insertar(this);
            if (rta == false)
            {
                Exception excep = new Exception("ERROR. No se pudo guardar en base de datos");
                throw excep;
            }
        }


        string IMostrar<Paquete>.MostrarDatos(IMostrar<Paquete> elemento)
        {
            string devuelve = "";
            //si no es nulo.
            if (elemento != null)
            {
                devuelve = string.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
            }
            return devuelve;
        }

       
        #endregion

        #region Operadores y Sobrecargas
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            
            bool rta = false;

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
            return ((IMostrar<Paquete>)this).MostrarDatos(this);
           
        }


        #endregion


    }
}
