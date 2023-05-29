using System.Data.SqlClient;

namespace ServicioRestaurante.Models
{
    public class Usuario
    {
      
        #region Atributos 

        private int id;
        private string nombre;
        private string nombreUsuario;
        private string email;
        private string pwd;
        private string telefono;
        private string token;


        #endregion

        #region Propiedades/Getters y Setters
        public int Id {
            get { return id; }
            set {  id = value; } 
        }
        
        public string Nombre {
            get { return nombre; }
            set { nombre = value; }
        }
        public string NombreUsuario {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }
        public string Email {
            get { return email; }
            set { email = value; }
        }
        public string Pwd {
            get { return pwd; }
            set { pwd = value; }
        }
        public string Telefono {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Token {
            get { return token; }
            set { token = value; }
        }
        #endregion

        #region Metodos de la clase
       
        public static bool CheckToken(string token)
        {
            bool verificar = false;
            Datos.Conectar();
            Usuario usuario = new Usuario();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("select * from usuario where token = @token", Datos.conx);
            cmd.Parameters.AddWithValue("@token", token);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                verificar = true;
            }
            Datos.Desconectar();
            return verificar;
        }

        #endregion

    }


    public class UsuarioStandard : Usuario
    {
        #region Atributos
        private bool activo;

        #endregion

        #region Propiedades
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        #endregion

        #region Metodos de la Clase
        public static UsuarioStandard Loguear(string email, string pwd)
        {
            UsuarioStandard u = new UsuarioStandard();
            Datos.Conectar();
            SqlCommand cmd = new SqlCommand("select * from usuario where email = @email and pwd = @pwd and [Admin] = 'n'", Datos.conx);
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
        public static void CrearNuevoUsuario(UsuarioStandard Entidad)
        {
            UsuarioStandard u = new UsuarioStandard();
            Datos.Conectar();
            string query = "spAddUser @nombreCompleto,@nombreUsuario,@email,@pwd,@telefono";
            SqlCommand cmd = new SqlCommand(query, Datos.conx);
            cmd.Parameters.AddWithValue("@nombreCompleto", Entidad.Nombre);
            cmd.Parameters.AddWithValue("@nombreUsuario", Entidad.NombreUsuario);
            cmd.Parameters.AddWithValue("@email", Entidad.Email);
            cmd.Parameters.AddWithValue("@pwd", Entidad.Pwd);
            cmd.Parameters.AddWithValue("@telefono", Entidad.Telefono);


            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Datos.Desconectar();
                throw;
            }
            Datos.Desconectar();

        }
        #endregion

    }

    public class Administrador : Usuario
    {
        #region Atributos
        private bool admin;
        #endregion

        #region Propiedades
        public bool Admin
        {
            get { return admin; }
            set { admin = value; }
        }
        #endregion

        #region Metodos de la Clase
        public static Usuario LoguearAdmin(string email, string pwd)
        {
            Datos.Conectar();
            Administrador admin = new Administrador();
            string query = "SELECT * FROM usuario WHERE email = @email and pwd = @pwd and [Admin] = 's'";
            SqlCommand cmd = new SqlCommand(query, Datos.conx);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@Pwd", pwd);
            SqlDataReader dr;
            try
            {
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    admin.Id = int.Parse(dr["id"].ToString());
                    admin.Nombre = dr["nombreCompleto"].ToString();
                    admin.NombreUsuario = dr["nombreUsuario"].ToString();
                    admin.Email = dr["email"].ToString();
                    admin.Pwd = dr["pwd"].ToString();
                    admin.Telefono = dr["telefono"].ToString();
                    admin.Token = dr["token"].ToString();
                    admin.Admin = dr["admin"].ToString() == "s";
                }
            }
            catch (Exception)
            {
                Datos.Desconectar();
                throw;
            }
            Datos.Desconectar();
            return admin;
        }

        public static Usuario AutentificarAdministrador(string token)
        {
            Datos.Conectar();
            Administrador admin = new Administrador();
            string query = "SELECT * FROM usuario WHERE token = @token and [Admin] = 's'";
            SqlCommand cmd = new SqlCommand(query, Datos.conx);
            cmd.Parameters.AddWithValue("@token", token);
            SqlDataReader dr;
            try
            {
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    admin.Id = int.Parse(dr["id"].ToString());
                    admin.Nombre = dr["nombreCompleto"].ToString();
                    admin.NombreUsuario = dr["nombreUsuario"].ToString();
                    admin.Email = dr["email"].ToString();
                    admin.Pwd = dr["pwd"].ToString();
                    admin.Telefono = dr["telefono"].ToString();
                    admin.Token = dr["token"].ToString();
                    admin.Admin = dr["admin"].ToString() == "s";
                }
            }
            catch (Exception)
            {
                Datos.Desconectar();
                throw;
            }
            Datos.Desconectar();
            return admin;
        }
        #endregion

    }
}

