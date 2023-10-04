using Microsoft.AspNetCore.Mvc;

namespace API_ProcessJudicial.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
