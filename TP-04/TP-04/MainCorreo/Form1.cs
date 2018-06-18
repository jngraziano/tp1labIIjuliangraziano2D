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

namespace MainCorreo
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            //Paquete paquete1 = new Paquete();
            //paquete1 = PaqueteDAO.ObtenerPaquete();

            //try
            //{
            //    label1.Text = paquete1.MostrarDatos();
            //}
            //catch (Exception ex)
            //{
                
            //    throw ex;
            //}
           

            /*FIJARSE COMO MOSTRAR LOS DATOS DE LA BASE EN UN RICHTEXTBOX
             * 
             * ACTUALIZADO: FIJARSE SI NO HAY QUE MOSTRARLOS DESDE EL TXT
            */
            //rtbMostrar.Clear();


            //rtbMostrar.Document.Blocks.Clear();
            //richTextBox1.Document.Blocks.Add(new Paragraph(new Run("Text")));



            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {

        }

        private void mtxtTrackingID_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void rtbMostrar_TextChanged(object sender, EventArgs e)
        { }
       
       

      
       
    }
}
