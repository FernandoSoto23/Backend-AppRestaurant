using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ServicioRestaurante.Models
{
    public class Menu
    {

        #region Atributos
        private string codigo;
        private string titulo;
        private string imagen;
        private double precio;
        private string descripcion;
        private int tipoMenu;
        #endregion

        #region Propiedades

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }
        public double Precio
        {
            get { return precio; }
            set { if (Precio > -1) precio = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public int TipoMenu
        {
            get { return tipoMenu; }
            set { tipoMenu = value; }
        }


        #endregion

        #region Metodos
        public static ListaMenu ListarMenu()
        {
            Datos.Conectar();
            string Cadena = $"select * from platillo";
            SqlCommand cmd = new SqlCommand(Cadena, Datos.conx);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            ListaMenu lista = new ListaMenu();
            try
            {
                while (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        Menu menu = new Menu();
                        menu.Codigo = dr["codigo"].ToString() ?? "vacio";
                        menu.Titulo = dr["Titulo"].ToString() ?? "vacio";
                        menu.Imagen = dr["imagen"].ToString() ?? "vacio";
                        menu.Precio = double.Parse(dr["precio"].ToString() ?? "0");
                        menu.Descripcion = dr["descripcion"].ToString() ?? "vacio";
                        menu.TipoMenu = int.Parse(dr["tipoMenu"].ToString() ?? "0");

                        Console.WriteLine(menu);

                        lista.Add(menu);
                    }
                    else
                    {
                        dr.NextResult();
                    }
                }
            }
            catch (Exception e)
            {
                Datos.Desconectar();
                throw e;
            }

            Datos.Desconectar();
            return lista;
        }
        public static ListaMenu ListarMenu(int TipoMenu)
        {
            Datos.Conectar();
            SqlCommand cmd = new SqlCommand("SELECT * FROM platillo WHERE tipoMenu = @TipoMenu", Datos.conx);
            cmd.Parameters.AddWithValue("@TipoMenu", TipoMenu);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            ListaMenu lista = new ListaMenu();

            while (dr.HasRows)
            {
                if (dr.Read())
                {
                    Menu menu = new Menu();
                    menu.Codigo = dr["codigo"].ToString();
                    menu.Titulo = dr["Titulo"].ToString();
                    menu.Imagen = dr["imagen"].ToString();
                    menu.Precio = double.Parse(dr["precio"].ToString());
                    menu.Descripcion = dr["descripcion"].ToString();
                    menu.TipoMenu = int.Parse(dr["tipoMenu"].ToString());


                    lista.Add(menu);
                }
                else
                {
                    dr.NextResult();
                }
            }

            Datos.Desconectar();
            return lista;
        }
        public static Menu Orden(int codigo)
        {
            Datos.Conectar();
            SqlCommand cmd = new SqlCommand("SELECT * FROM platillo WHERE codigo = @codigo", Datos.conx);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            ListaMenu lista = new ListaMenu();

            Menu orden = new Menu();
            if (dr.Read())
            {

                orden.Codigo = dr["codigo"].ToString() ?? "";
                orden.Titulo = dr["Titulo"].ToString() ?? "";
                orden.Imagen = dr["imagen"].ToString() ?? "";
                orden.Precio = double.Parse(dr["precio"].ToString() ?? "0");
                orden.Descripcion = dr["descripcion"].ToString() ?? "";
                orden.TipoMenu = int.Parse(dr["tipoMenu"].ToString() ?? "0");



            }

            Datos.Desconectar();
            return orden;
        }
        public static void Guardar(Menu entidad)
        {
            Datos.Conectar();
            string cadena = "INSERT INTO platillo(codigo,titulo,imagen,precio,descripcion,tipomenu)";
            cadena += "VALUES(@codigo,@titulo,@imagen,@precio,@descripcion,@tipomenu)";
            SqlCommand cmd = new SqlCommand(cadena, Datos.conx);
            cmd.Parameters.AddWithValue("@codigo", entidad.Codigo);
            cmd.Parameters.AddWithValue("@titulo", entidad.Titulo);
            cmd.Parameters.AddWithValue("@imagen", entidad.Imagen);
            cmd.Parameters.AddWithValue("@precio", entidad.Precio);
            cmd.Parameters.AddWithValue("@descripcion", entidad.Descripcion);
            cmd.Parameters.AddWithValue("@tipomenu", entidad.TipoMenu);

            try
            {
                cmd.ExecuteNonQuery();
                Datos.Desconectar();
            }
            catch (Exception error)
            {

                throw error;
                Datos.Desconectar();
            }



        }
        public static void Actualizar(Menu entidad)
        {
            Datos.Conectar();
            string cadena = "UPDATE platillo SET titulo = @titulo,imagen = @imagen,precio = @precio,descripcion = @descripcion,tipomenu = @tipomenu ";
            cadena += "WHERE codigo = @codigo";

            SqlCommand cmd = new SqlCommand(cadena, Datos.conx);
            cmd.Parameters.AddWithValue("@codigo", entidad.Codigo);
            cmd.Parameters.AddWithValue("@titulo", entidad.Titulo);
            cmd.Parameters.AddWithValue("@imagen", entidad.Imagen);
            cmd.Parameters.AddWithValue("@precio", entidad.Precio);
            cmd.Parameters.AddWithValue("@descripcion", entidad.Descripcion);
            cmd.Parameters.AddWithValue("@tipomenu", entidad.TipoMenu);

            try
            {
                cmd.ExecuteNonQuery();
                Datos.Desconectar();
            }
            catch (Exception error)
            {

                throw error;
                Datos.Desconectar();
            }



        }
        #endregion


    }


    public class ListaMenu : List<Menu>
    {

    }
}
