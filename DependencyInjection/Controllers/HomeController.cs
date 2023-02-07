using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesService _cities;

        public HomeController(ICitiesService cities)
        {
            _cities = cities;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View(_cities.GetCities());
        }

        [Route("add")]
        public IActionResult Add()
        {
            return View();
        }
        [Route("add")]
        [HttpPost]
        public IActionResult Add( [FromForm] string city)
        {
            _cities.AddCity(city);
            return RedirectToAction("Index");
        }
    }
}
