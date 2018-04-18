using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        public  double Operar(Numero num1, Numero num2, string operador)
        {
            string rec = ValidarOperador(operador);
            double result = 0;
            switch (rec)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                default:
                    break;
            }
            return result;
 
        }

        private static string ValidarOperador(string operador)
        {
            string devuelve="+";
            switch (operador)
            {
                case "+":
                    devuelve = "+";
                    break;
                case "-":
                    devuelve = "-";
                    break;
                case "/":
                    devuelve = "/";
                    break;
                case "*":
                    devuelve = "*";
                    break;
                default:
                    devuelve = "+";
                    break;
            }
            return devuelve;
        }
    }
}
