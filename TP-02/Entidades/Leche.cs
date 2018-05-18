using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2017
{
    public class Leche : Producto
    {
        public enum ETipo { Entera, Descremada }

        ETipo _tipo;

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="codbar"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string codbar, ConsoleColor color, ETipo tipo)
            : base(codbar, marca, color)
        {
            this._tipo = tipo;
        }
        public Leche(EMarca marca, string codbar, ConsoleColor color)
            : base(codbar, marca, color)
        {
            this._tipo = ETipo.Entera;
        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("\nTIPO : " + this._tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");
            

            return sb.ToString();
        }
    }
}
