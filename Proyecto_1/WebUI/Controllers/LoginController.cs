using BLL;
using ENTITES;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {

        private readonly loginBLL _loginBLL;
        private readonly IConfiguration _Configuration;
        public LoginController(loginBLL loginBLL, IConfiguration configuration)
        {
            _loginBLL = loginBLL;
            _Configuration = configuration;
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public Reply IniciarSesionUsuarios(String Usuario, String Contrasena)
        {
            Reply reply = new Reply();

            try
            {
                Credenciales credencial = new Credenciales { 
                    Usuario = Usuario, 
                    Contrasena = Contrasena
                };



                var Conexion = _Configuration.GetConnectionString("ConexionBD");

                var respusta = _loginBLL.IniciarSesion(credencial,Conexion);

                if (respusta.ok) 
                {
                    reply = respusta;
                }
                else 
                {
                    reply.ok = false;
                    reply.Message = respusta.Message;
                }   
            }
            catch (Exception ex)
            {
                reply.ok = false;
                reply.Message = string.Format("Ha ocurrido un error en el controladore, en la capa LoginController", ex.Message);
            }
            return reply;
        }
    }
}

