using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    #region Explicación usar Settings
    /*
     * Como predefinir Properties.Settings.Default.Loquesea y usarlo de default: 
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

    #endregion


    public static class PaqueteDAO
    {
        #region Atributos y Constructor 
        private static SqlConnection Conexion;
        private static SqlCommand Comando;
        private static string TablaNombre = "Paquetes";

        static PaqueteDAO()
        {
            Conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);

            Comando = new SqlCommand();
            
            Comando.CommandType = System.Data.CommandType.Text;// tipo de comando

            Comando.Connection = Conexion; 
        }

        #endregion

        #region Metodos

        public static bool Insertar(Paquete p)
        {
            bool flag = false;

            //Creo el string query
            string query = "INSERT INTO "+ TablaNombre +" (direccionEntrega,trackingID,alumno) VALUES(";
            query += "'" + p.DireccionEntrega + "','" + p.TrackingID + "', 'JulianGraziano')";

            try
            {
                Comando.CommandText = query;// le paso la query

                Conexion.Open();//abro la conexion

                int data = Comando.ExecuteNonQuery();
                if (data == 1)
                {
                    flag = true;
                }
                Conexion.Close();

                flag = true;


            }
            catch (SqlException excep)
            {
                flag = false;
                throw excep;
            }
            finally
            {
                    Conexion.Close();
 
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
