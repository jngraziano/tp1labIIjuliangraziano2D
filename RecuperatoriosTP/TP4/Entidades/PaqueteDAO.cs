using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    

    public static class PaqueteDAO
    {
        #region Atributos y Constructor 
        private static SqlConnection Conexion;
        private static SqlCommand Comando;
        private static string TablaNombre = "Paquetes";

        static PaqueteDAO()
        {
            PaqueteDAO.Conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);

            PaqueteDAO.Comando = new SqlCommand();

            PaqueteDAO.Comando.CommandType = System.Data.CommandType.Text;

            PaqueteDAO.Comando.Connection = Conexion;

            PaqueteDAO.Conexion.Open();
        }

        #endregion

        #region Metodos

        public static bool Insertar(Paquete p)
        {
            bool flag = false;

            //Creo la query
            string query = "INSERT INTO "+ TablaNombre +" (direccionEntrega,trackingID,alumno) VALUES(";
            query += "'" + p.DireccionEntrega + "','" + p.TrackingID + "', 'JulianGraziano')";

            try
            {
                //Comando.CommandText = query;

                //Conexion.Open();

                //int data = Comando.ExecuteNonQuery();
                //if (data == 1)
                //{
                //    flag = true;
                //}
                //Conexion.Close();
                
                EjecutarNonQuery(query);
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

        private static bool EjecutarNonQuery(string sql)
        {
            try
            {
                // LE PASO LA INSTRUCCION SQL
                PaqueteDAO.Comando.CommandText = sql;

                // EJECUTO EL COMMAND
                PaqueteDAO.Comando.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

      

        #endregion


    }
}
