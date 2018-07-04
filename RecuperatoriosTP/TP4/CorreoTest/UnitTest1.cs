using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using MainCorreo;

namespace CorreoTest
{
    [TestClass]
    
    public class UnitTest1
    {
        /// <summary>
        /// Prueba con instaciar listapaquetes
        /// </summary>
        [TestMethod]
        public void InicializacionCorreoListPaquetes()
        {
            // arrange
            Correo correo = new Correo();

            //act
            object lista = correo.Paquetes;

            //assert
            Assert.IsNotNull(lista);
        }


        /// <summary>
        /// Prueba con el tema de los repetidos
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException), "Falla en el test ID repetido")]
        public void TestPaquetesNoRepetidos()
        {
            // arrange
            Correo c = new Correo();

            Paquete p1 = new Paquete("Jujuy", "111111");
            Paquete p2 = new Paquete("Usuhaia", "111111");

            //act
            c += p1;
            c += p2;            
        }
        
    }
}
