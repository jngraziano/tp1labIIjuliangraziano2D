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
    public partial class FrmPpal : Form
    {
        #region Atributos y Constructor

        private Correo correo;

        public FrmPpal()
        {
                      
            InitializeComponent();

            //Bloquear que el usuario modifique el tamaño del formulario.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //Cargar el formulario en el centro de la pantalla.
            this.StartPosition = FormStartPosition.CenterScreen;


           // lstEstadoEntregado.ContextMenuStrip = cmsListas;

            correo = new Correo();
        }

        #endregion

        #region Metodos y Eventos

        #region Boton/Click
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                Paquete PaqueteAux = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
                         
                PaqueteAux.InformaEstado += paq_InformaEstado;

                //Agrego PaqueteAux a correo usando la sobrecarga del + y del ==
                this.correo += PaqueteAux;
                
            }
            catch (Exception excep)
            {
                //Lanzo la excepcion en un MessageBox
                MessageBox.Show(excep.Message);
            }

            //Actualizo los estados
            ActualizarEstados();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            //limpio el rtb
            rtbMostrar.Text = "";

            //Muestro lo que hay en tiempo de ejecucion en la lista
           
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Cierro los hilos.
            this.correo.FinEntregas();
        }

        #endregion

        #region Metodos

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }

        private void ActualizarEstados()
        {
            //Limpio los listbox
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            //Verifico que no sea null
            if (this.correo != null)
            {
                foreach (var item in this.correo.Paquetes)
                {
                    switch (item.Estado)
                    {
                        //USO .ITEMS.ADD 
                        case Paquete.EEstado.Ingresado:
                            //Limpio para el facil ingreso de otro paquete nuevo.
                            txtDireccion.Clear();
                            mtxtTrackingID.Clear();

                            lstEstadoIngresado.Items.Add(item);
                            break;
                        case Paquete.EEstado.EnViaje:
                            lstEstadoEnViaje.Items.Add(item);
                            break;
                        case Paquete.EEstado.Entregado:
                            lstEstadoEntregado.Items.Add(item);
                            break;
                        default:
                            break;
                    }
                }
                
            }  
            
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            rtbMostrar.Text = "";
           
            if (elemento != null)
            {
                rtbMostrar.Text = (elemento.MostrarDatos(elemento)).ToString();
     
            }
            try
            {
                string texto = rtbMostrar.Text;
                string nombreTxt = "InfodeCorreo.txt";
                
                                
                texto.Guardar(nombreTxt);
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }


        #endregion

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }



        #endregion


    }
}
