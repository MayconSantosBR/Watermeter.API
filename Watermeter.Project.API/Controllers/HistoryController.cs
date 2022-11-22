using Microsoft.AspNetCore.Mvc;

namespace Watermeter.Project.API.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
