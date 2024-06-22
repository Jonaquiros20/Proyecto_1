using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult RegistroUsuarios()
        {
            return View();
        }
    }
}
