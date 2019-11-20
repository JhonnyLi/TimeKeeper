using Microsoft.AspNetCore.Mvc;

namespace TimeKeeper.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {



        }
        public IActionResult Index()
        {
            return View();
        }
    }
}