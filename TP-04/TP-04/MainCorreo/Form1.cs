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
            correo = new Correo();
        }

        #endregion

        #region Metodos

        #region Boton/Click
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                Paquete PaqueteAux = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
                PaqueteAux.EventoGenerado += new DelegadoEstado(this.paq_InformaEstado);

                //Agrego PaqueteAux a correo usando la sobrecarga del + y del ==
                this.correo += PaqueteAux;
                
            }
            catch (Exception excep)
            {
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

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        #endregion

        #region Otros Metodos

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                DelegadoEstado d = new DelegadoEstado(paq_InformaEstado);
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

            //USO .ITEMS.ADD
            if (this.correo != null)
            {
                foreach (var item in this.correo.Paquetes)
                {
                    switch (item.Estado)
                    {
                        case EEstado.Ingresado:
                            lstEstadoIngresado.Items.Add(item);
                            break;
                        case EEstado.EnViaje:
                            lstEstadoEnViaje.Items.Add(item);
                            break;
                        case EEstado.Entregado:
                            lstEstadoEntregado.Items.Add(item);
                            
                            //limpio txtbox y lst
                            txtDireccion.Clear();
                            mtxtTrackingID.Clear();
                            lstEstadoEntregado.Items.Clear();

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
                string nombreTxt = "txtInfo.txt";
                
                                
                texto.Guardar(nombreTxt);
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }




        #endregion

        private void FrmPpal_Load(object sender, EventArgs e)
        {

        }
        
        #endregion


    }
}
