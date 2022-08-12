using Microsoft.AspNetCore.Mvc;

namespace SampleMvc.Controllers
{
    public class SimpleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
