using Microsoft.AspNetCore.Mvc;
using ServiceLifetime.Models;
using ServiceLifetime.Services;
using System.Diagnostics;
using System.Text;

namespace ServiceLifetime.Controllers
{



    public class HomeController : Controller
    {

        private readonly IScopedGuidService _scoped1;
        private readonly IScopedGuidService _scoped2;

        private readonly ISingeltonGuidService _singelton1;
        private readonly ISingeltonGuidService _singelton2;

        private readonly ITransientGuidService _transient1;
        private readonly ITransientGuidService _transient2;



        /*   private readonly ILogger<HomeController> _logger;*/

        public HomeController(IScopedGuidService scopedGuiid1, IScopedGuidService scopedGuiid2,
            ISingeltonGuidService singeltonGuid1, ISingeltonGuidService singeltonGuid2, ITransientGuidService transientGuid1, ITransientGuidService transientGuid2)
        {
            _scoped1 = scopedGuiid1;
            _scoped2 = scopedGuiid2;
            _transient1 = transientGuid1;
            _transient2 = transientGuid2;
            _singelton1 = singeltonGuid1;
            _singelton2 = singeltonGuid2;

        }




        public IActionResult Index()
        {
            StringBuilder messages = new StringBuilder();
            messages.Append($"Transient1: {_transient1.GetGuid()}\n");
            messages.Append($"Transient2: {_transient2.GetGuid()}\n");
            messages.Append($"Scoped1: {_scoped1.GetGuid()}\n");
            messages.Append($"Scoped2: {_scoped2.GetGuid()} \n");
            messages.Append($"Singleton1: {_singelton1.GetGuid()} \n");
            messages.Append($"Signleton2: {_singelton2.GetGuid()} \n");
            return Ok(messages.ToString());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}