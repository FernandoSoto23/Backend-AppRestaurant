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
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public string Imagen { get; set; }
        public double Precio { get; set; }
        public string Descripcion { get; set; }
        public int TipoMenu { get; set; }


    
    public static ListaMenu ListarMenu()
        {
            Datos.Conectar();
            string Cadena = $"select * from platillo";
            SqlCommand cmd = new SqlCommand(Cadena,Datos.conx);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            ListaMenu lista = new ListaMenu();
            try
            {
                while(dr.HasRows)
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
            string Cadena = $"select * from platillo where tipoMenu = {TipoMenu}";
            SqlCommand cmd = new SqlCommand(Cadena, Datos.conx);
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
            string Cadena = $"select * from platillo where codigo = {codigo}";
            SqlCommand cmd = new SqlCommand(Cadena, Datos.conx);
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


    }


    public class ListaMenu : List<Menu>
    {

    }
}
