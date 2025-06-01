using System.Threading.Channels;
using Microsoft.Data.SqlClient;

namespace capa_Datos
{
    public class ConexionDB
    {

        private static ConexionDB instance;

        private string cadenaConexion = "Server=localhost;database=usuario;" +
                                        "user id=usuarioSQL; password=root;" +
                                        "TrustServerCertificate = True;";

        private SqlConnection? connection;

        // constructor privado aplicando singlenton
        private ConexionDB() { }


        public static ConexionDB getInstance()
        {

            if (instance == null)
            {
                instance = new ConexionDB();
            }

            return instance;

        }

        //metodo para establecer la conexion a la BD
        public SqlConnection establecerConexionDB()
        {
            connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                Console.WriteLine("Conexion a BD exitosa");
            }
            catch (ThreadInterruptedException ex)
            {

                Console.WriteLine("Hubo un error en la conexion  BD" + ex.Message);

            }

            return connection; // retorna una conexion abierta

        }


        public void cerrarConexionDB()
        {

            if (connection != null)
            {
                connection.Close();
                Console.WriteLine("Conexion a BD cerrada");
            }
            else
            {
                Console.WriteLine("La conexion se encuentra cerrada");
            }

        }

    }
}
