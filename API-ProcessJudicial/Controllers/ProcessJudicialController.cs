using Microsoft.AspNetCore.Mvc;

namespace API_ProcessJudicial.Controllers
{
    public class ProcessJudicialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
