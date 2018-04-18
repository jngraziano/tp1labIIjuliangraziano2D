using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region MAIN echo con Consola
        //Console.Title = "Fecha de entrega viernes 20 abril.";
        //Calculadora calcu = new Calculadora();
        ////Colocar numeros a operar
        //Numero num1 = new Numero("2");
        //Numero num2 = new Numero(3);
        //Numero num3 = new Numero(8);
        ////Colocar operador:
        //string op="*";
        //double result = calcu.Operar(num1, num2, op);

        //Console.WriteLine("CALCULADORA");
        //Console.WriteLine("El resultado {0} {1} {2} es: {3}.",num1.GetNumero,op,num2.GetNumero,result);
        //Console.ReadKey();

        //Console.WriteLine("\n");

        //string result2 = num3.DecimalBinario(result);
        //string result3 = num3.DecimalBinario(result.ToString());


        //Console.WriteLine("\nConvertido de decimal a binario: {0}",result2);
        //Console.WriteLine("Convertido de decimal a binario pero siendo string: {0}",result3);

        //string result4 = num3.BinarioDecimal(result2);
        //Console.WriteLine("\nConvertido devuelta de binario a decimal: {0}", result4);



        //Console.ReadKey();
        #endregion
        
        #region Variables, Getter y Constructor
        private double numero;

        public string SetNumero { set { this.numero = ValidarNumero(value); } }
        
        //Getter agregado solo para mostrar en main.
        public double GetNumero { get { return this.numero; } }

        public Numero()
        { }
        
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        public Numero(double numero)
        {
            this.SetNumero = numero.ToString();
        }

        #endregion

        #region Metodos
        public double ValidarNumero(string strNumero)
        {
            double devuelve=0;
            int num;
            if (int.TryParse(strNumero, out num))
            {
                //ValidarNumero comprobará que el valor recibido sea numérico,
                //y lo retornará en formato double. Caso contrario, 
                //retornará 0.
               
               
                
                devuelve = Convert.ToDouble(strNumero);
            }
            
            return devuelve;
        }

        public string BinarioDecimal(string binario)
        {
            string devuelve = "Valor invalido.";
          
            devuelve = Convert.ToInt32(binario, 2).ToString();
           
            return devuelve;

        }

        public string DecimalBinario(double numero)
        {
            string binario = "";
            string valores_bin = "";
            string rta = "Valor inválido";

            int n = int.Parse(numero.ToString());
            int l;
            if (n != 1)
            {
                for (l = n; l != 0 && l != 1; l = l / 2)
                {
                    binario = (l % 2) + binario;
                }
                if (l == 0)
                {
                    valores_bin += "0";
                    rta = valores_bin;
                }
                else
                {
                    binario = 1 + binario;
                    valores_bin += binario;
                    rta = valores_bin;
                }
            }
            else
            {
                valores_bin += "1";
                rta = valores_bin;
            }

           return rta;
        }

        public string DecimalBinario(string numero)
        {
            double retorno;
            //aca verificar si dentro del string num, hay numeros antes de usar el ToDouble porque sino
            //si recibe un string con letras, rompe.
            retorno = Convert.ToDouble(numero);
            return this.DecimalBinario(retorno); 
        }

        #region Sobrecargas

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }

        #endregion

        #endregion
    }
}
