using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    public class Dulce : Producto
    {
        public Dulce(EMarca marca, string codbar, ConsoleColor color)
        {
            base._codigoDeBarras = codbar;
            base._marca = marca;
            base._colorPrimarioEmpaque = color;
        }
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}" , this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
