using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    /*
     * Settings - tp4 
     * Click derecho 
     * Propiedades
     * Settings
     * Cadena Sting User loquequiera 
     * Accedo:
     * Properties.Settings.Default.Cadena
     * 
     *  EJEMPLO EN GIT MOSTRADOENCLASE
       
     * Si quiero conectar por variable:
        private static string Conector = "Data Source=.\\SQLEXPRESS;Initial Catalog=correo-sp-2017;Integrated Security=True";
        
     */

    /*CONSIGNA DE LA CLASE:
     * 
     *  De surgir cualquier error con la carga de datos, se deberá lanzar una excepción tantas veces como sea
        necesario hasta llegar a la vista (formulario). A través de un MessageBox informar lo ocurrido al
        usuario de forma clara.
     * 
     * 
     * 
     */
    public static class PaqueteDAO
    {
        #region Variables y Constructor 
        private static SqlConnection Conexion;
        private static SqlCommand Comando;
        private static string TablaNombre = "dbo.Paquetes";

       

        static PaqueteDAO()
        {
            PaqueteDAO.Conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);

            PaqueteDAO.Comando = new SqlCommand();

            PaqueteDAO.Comando.CommandType = System.Data.CommandType.Text;

            PaqueteDAO.Comando.Connection = PaqueteDAO.Conexion;
        }

        #endregion

        #region Metodos

        public static bool Insertar(Paquete p)
        {
            bool flag = false;
            try
            {
                string query = "INSERT INTO " + TablaNombre + "(direccionEntrega,trackingID,alumno) VALUES(";
                query = query + "'" + p.DireccionEntrega + "','" + p.TrackingID + "'," + "Julian Graziano" + ")";

                PaqueteDAO.Comando.CommandText = query;

                PaqueteDAO.Conexion.Open();

                PaqueteDAO.Comando.ExecuteNonQuery();

                flag = true;


            }
            catch (Exception)
            {
                flag = false;
                //throw e;
            }
            finally
            {
                if (flag)
                {
                    PaqueteDAO.Conexion.Close();
                }
 
            }
            
            return flag;

        }

        #region Otras querys

        #region ObtenerPaquete
        //public static Paquete ObtenerPaquete(int ID)
        //{
        //    bool flag = false;
        //    Paquete paque1 = null;


        //    try
        //    {
        //      PaqueteDAO.Comando.CommandText = "select * from " + TablaNombre + " where (id = " + ID.toString() + ");";
        //      PaqueteDAO.Conexion.Open();

        //        SqlDataReader oDr = PaqueteDAO.Comando.ExecuteReader();

        //        if (oDr.Read())
        //        {
        //            paque1 = new Paquete(oDr["DireccionEntrega"].ToString(), oDr["TrackingID"].ToString());
                    
        //        }
        //        oDr.Close();
        //        flag = true;

        //    }
        //    catch (Exception e)
        //    {
                
        //        throw e;
        //    }

        //    return paque1;
        //}

        #endregion

        #region Para updatear un campo
        //EJEMPLO EN ESTE CASO:
        //update dbo.Paquetes SET alumno= 'JulianGraziano' where id = 1;

        #endregion


        #endregion


        #endregion


    }
}
