using System.Data.SqlClient;

namespace ServicioRestaurante.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }
        public string Telefono { get; set; }
        public bool Admin { get; set; }
        public bool Activo { get; set; }

        public string Token { get; set; }

        public static Usuario Loguear(string email, string pwd)
        {
            Usuario u = new Usuario();
            Datos.Conectar();
            SqlCommand cmd = new SqlCommand("select * from usuario where email = @email and pwd = @pwd", Datos.conx);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@Pwd", pwd);
            SqlDataReader dr;
            try
            {
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    u.Id = int.Parse(dr["id"].ToString());
                    u.Nombre = dr["nombreCompleto"].ToString();
                    u.NombreUsuario = dr["nombreUsuario"].ToString();
                    u.Email = dr["email"].ToString();
                    u.Pwd = dr["pwd"].ToString();
                    u.Telefono = dr["telefono"].ToString();
                    u.Activo = dr["activo"].ToString() == "s";
                    u.Token = dr["token"].ToString();
                }
            }
            catch (Exception)
            {
                Datos.Desconectar();
                throw;
            }
            Datos.Desconectar();
            return u;
        }
    }
}

