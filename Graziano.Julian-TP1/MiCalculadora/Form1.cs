using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        #region Iniciadores Windows Form

        public LaCalculadora()
        {
            InitializeComponent();
        }

 
        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
        #endregion 

        #region Eventos de los Botones
        private void btnOperar_click(object sender, EventArgs e)
        {
           
            Calculadora calcu1 = new Calculadora();
            string valor="+";
           
            if (object.ReferenceEquals(cmbOperador.SelectedItem, null))
            {
                string resultado = Operar(text_Numero1.Text, text_Numero2.Text, valor).ToString();
                lblResultado.Text = resultado;
               
            }
            else
            {
                valor = cmbOperador.SelectedItem.ToString();
                string resultado = Operar(text_Numero1.Text, text_Numero2.Text, valor).ToString();
                lblResultado.Text = resultado;
                
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnCerrar_click(object sender, EventArgs e)
        {
            const string mensaje = "Desea Salir?";
            const string titulo = "CERRAR";
            var result = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numresult = new Numero();
            if (this.lblResultado.Text == "")
            {
                const string mensaje = "Se necesita realizar una operación.";
                const string titulo = "ERROR";
                var result = MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK);

            }
            else
            {
                this.lblResultado.Text = numresult.DecimalBinario(this.lblResultado.Text);
            }


        }

        private void btnConvertirADecimal_click(object sender, EventArgs e)
        {
            Numero numresult = new Numero();

            if (this.lblResultado.Text == "")
            {
                const string mensaje = "Se necesita realizar una operación.";
                const string titulo = "ERROR";
                var result = MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK);

            }
            else
            {
                this.lblResultado.Text = numresult.BinarioDecimal(this.lblResultado.Text);
            }

        }



        private void cmb_keypress(object sender, KeyPressEventArgs e)
        {
            //MEJORA: para que el usuario no pueda ingresar txt en el operador. 
            //también funciona el validador de operadores
            e.Handled = true;
        }

        #endregion

        #region Metodos nuevos
        private void Limpiar()
        {
           //   El método Limpiar será llamado por el evento click del botón btnLimpiar y borrará
           //    los datos de los TextBox, ComboBox y Label de la pantalla.
            this.text_Numero1.Text = "";
            this.text_Numero2.Text = "";
            this.lblResultado.Text = "";
            this.cmbOperador.Text = "";


        }
        
        private static double Operar(string numero1, string numero2, string operador)
        {
            //El método Operar será estático recibirá los dos números y el operador para luego
            //llamar al método Operar de Calculadora y retornar el resultado al método de evento
            //del botón btnOperar que reflejará el resultado en el Label txtResultado.
           
            Entidades.Calculadora calcu = new Calculadora();
                                 
            Numero num1 = new Numero();
            Numero num2 = new Numero();

            num1.SetNumero= numero1;
            num2.SetNumero = numero2;
          

            return calcu.Operar(num1, num2, operador);


        }

        #endregion

    }
}
