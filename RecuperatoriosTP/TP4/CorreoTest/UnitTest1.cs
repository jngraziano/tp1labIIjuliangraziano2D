using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using MainCorreo;

namespace CorreoTest
{
    [TestClass]
    public class UnitTest1
    {
       
        public void InicializacionCorreoListPaquetes()
        {
            // arrange
            Correo c = new Correo();

            //act
            object lista = c.Paquetes;

            //assert
            Assert.IsNotNull(lista);
        }


        /// <summary>
        /// Testeo la utilizacion de la exepcion creada en el proyecto para evitar elementos iguales.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException), "Falla el test")]
        public void TestPaquetesNoRepetidos()
        {
            // arrange
            Correo c = new Correo();

            Paquete p1 = new Paquete("Jujuy", "111111");
            Paquete p2 = new Paquete("Quilmes", "222222");

            //act
            c += p1;
            c += p2;            
        }
        
    }
}
