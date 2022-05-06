using Microsoft.AspNetCore.Mvc;

namespace LearnCore.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
