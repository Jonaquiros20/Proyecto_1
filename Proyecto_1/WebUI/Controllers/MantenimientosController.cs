using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class MantenimientosController : Controller
    {
        public IActionResult MantenimientoGeneral()
        {
            return View();
        }
    }
}
