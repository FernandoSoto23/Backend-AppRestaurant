﻿using Microsoft.AspNetCore.Mvc;
using ServicioRestaurante.Models;
using System.Text.Json;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServicioRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {

        [HttpGet]
        public ListaMenu GetMenus()
        {
            ListaMenu lista = new ListaMenu();
            lista = Menu.ListarMenu();
            return lista;
        }

        [HttpGet]
        [Route("ListarxTipo")]
        public ListaMenu Cargar(int TipoMenu)
        {
            ListaMenu lista = new ListaMenu();
            lista = Menu.ListarMenu(TipoMenu);
            return lista;
        }

        [HttpGet]
        [Route("Platillo")]
        public Menu Orden(int codigo)
        {
            Menu orden = new Menu();
            orden = Menu.Orden(codigo);
            return orden;
        }
    }
}
