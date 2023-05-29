using System.Data.SqlClient;


namespace ServicioRestaurante.Models
{
    public class Datos
    {
        static public SqlConnection conx = new SqlConnection();

        public static void Conectar()
        {
            conx.ConnectionString = "server=fernandodevdb.database.windows.net;database=SekyhRestaurant;user id = FernandoDev;password=Fernando#23;";
            conx.Open();
        }

        public static void Desconectar()
        {
            if(conx != null && conx.State == System.Data.ConnectionState.Open)
                conx.Close();
        }
    }
}
