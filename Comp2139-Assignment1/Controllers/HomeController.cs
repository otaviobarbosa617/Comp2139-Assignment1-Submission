using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace GBCSporting_OJO.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [Route("About")]
        public IActionResult About()
        {
            return View();
        }
    }

}


