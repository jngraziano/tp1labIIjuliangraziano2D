using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Correo
    {
        #region Variables Propiedades Constructor
        private List<Paquete> paquetes;

        
        public List<Paquete> Paquetes { get { return this.paquetes; } set { this.paquetes = value; } }

        public Correo()
        { this.paquetes = new List<Paquete>(); }

        #endregion

        #region Metodos

        public void FinEntregas()
        { }

        public string MostrarDatos(IMostrar<List<Paquete>>elementos)
        {}

        public static Correo operator +(Correo c, Paquete p)
        { }


        #endregion

    }
}
