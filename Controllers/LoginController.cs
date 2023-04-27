using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioRestaurante.Models;

namespace ServicioRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        [HttpGet]
        [Route("Loguear")]
        public RespuestaJson<Usuario> Loguear(string email,string pwd)
        {
            pwd = Encrypt.GetSHA256(pwd);
            var usuario = Usuario.Loguear(email,pwd);
            var JSON = new RespuestaJson<Usuario>();
            if (usuario.Token != null)
            {
                 
                JSON.Status = true;
                JSON.Msg= "ok";
                JSON.Dato = usuario;
            }
            else
            {
                JSON.Status = false;
                JSON.Msg = "error";
            }

            return JSON;


        }

        [HttpGet]
        [Route("validar")]
        public bool Validar(string token)
        {
            bool validacion;
            validacion = Models.Usuario.CheckToken(token);
            return validacion;
        }
    }
}
