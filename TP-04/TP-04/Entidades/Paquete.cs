using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #region Variables, Propiedades y Constructor
        private string direccionEntrega;
        private EEstado estado;
        private string trackID;


        public string DireccionEntrega { get { return this.direccionEntrega; } set { this.direccionEntrega = value; } }
        public EEstado Estado { get { return this.estado; } set { this.estado = value; } }
        public string TrackingID { get { return this.trackID; } set { this.trackID = value; } }

        public Paquete()
        { }
        public Paquete(string direccionEntregatrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntregatrega;
            this.TrackingID = trackingID;
        }

        #endregion

        //VER TEMA DELEGADOESTADO ????

        #region Metodos
        public void MockClicloDeVida()
        { }
        public string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.DireccionEntrega);
            sb.AppendLine(this.TrackingID);
            sb.AppendLine(this.Estado.ToString());


            return sb.ToString();
        }
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            StringBuilder sb = new StringBuilder();



            return sb.ToString();
        }
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool rta = false;
            if (p1.TrackingID == p2.TrackingID)
            {
                rta = true;
            }

            return rta;
        }
        public static bool operator !=(Paquete p1, Paquete p2)
        { return (p1 == p2); }
        


        #endregion


    }
}
