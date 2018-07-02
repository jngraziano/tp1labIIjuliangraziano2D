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
        }

        #endregion

        #region Metodos

        public static bool Insertar(Paquete p)
        {
            //Creo la query
            string query = "INSERT INTO "+ TablaNombre +" (direccionEntrega,trackingID,alumno) VALUES(";
            query += "'" + p.DireccionEntrega + "','" + p.TrackingID + "', 'JulianGraziano')";

            return EjecutarNonQuery(query);

        }

        private static bool EjecutarNonQuery(string sql)
        {
            bool flag = false;
            try
            {
                // LE PASO LA INSTRUCCION SQL
                PaqueteDAO.Comando.CommandText = sql;

                // ABRO LA CONEXION A LA BD
                PaqueteDAO.Conexion.Open();

                // EJECUTO EL COMMAND
                PaqueteDAO.Comando.ExecuteNonQuery();

                flag = true;
            }
            catch (SqlException)
            {
                flag = false;
            }
            finally
            {
                if (flag)
                { PaqueteDAO.Conexion.Close(); }
                   
            }
            return flag;
        }
      

        #endregion


    }
}
