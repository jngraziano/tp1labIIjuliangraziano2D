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
        #region Variables y Constructor 
        private static SqlConnection Conexion;
        private static SqlCommand Comando;

        private static string Conector = "Data Source=.\\SQLEXPRESS;Initial Catalog=correo-sp-2017;Integrated Security=True";
        private static string TablaNombre = "dbo.Paquetes";

        static PaqueteDAO()
        {
            PaqueteDAO.Conexion = new SqlConnection(Conector);

            PaqueteDAO.Comando = new SqlCommand();

            PaqueteDAO.Comando.CommandType = System.Data.CommandType.Text;

            PaqueteDAO.Comando.Connection = PaqueteDAO.Conexion;
        }

        #endregion

        #region Metodos

        public static bool Insertar(Paquete p)
        {
            string sql = "INSERT INTO " + TablaNombre + "(direccionEntrega,trackingID,alumno) VALUES(";
            sql = sql + "'" + p.DireccionEntrega + "','" + p.TrackingID + "'," + "Julian Graziano" + ")";



            return PaqueteDAO.EjecutarNonQuery(sql);
 
        }

        public static Paquete ObtenerPaquete()
        {
            bool flag = false;
            Paquete paque1 = null;


            try
            {
                PaqueteDAO.Comando.CommandText = "select * from " + TablaNombre + " where (id = 1);";
                PaqueteDAO.Conexion.Open();

                SqlDataReader oDr = PaqueteDAO.Comando.ExecuteReader();

                if (oDr.Read())
                {
                    paque1 = new Paquete(oDr["DireccionEntrega"].ToString(), oDr["TrackingID"].ToString());
                    
                }
                oDr.Close();
                flag = true;

            }
            catch (Exception e)
            {
                
                throw e;
            }

            return paque1;
        }

        public static bool EjecutarNonQuery(string consulta)
        {
            bool flag = false;

            try
            {
                PaqueteDAO.Comando.CommandText = consulta;

                PaqueteDAO.Conexion.Open();

                PaqueteDAO.Comando.ExecuteNonQuery();

                flag = true;

            }
            catch (Exception)
            {
                flag = false;

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



        #endregion
    }
}
