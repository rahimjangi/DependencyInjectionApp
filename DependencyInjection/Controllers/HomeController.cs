using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ServiceContracts;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesService _cities;
        private readonly IWebHostEnvironment _webHost;
        private readonly IConfiguration _config;
        private readonly IOptions<MyApiOptions> _dd;

   

        public HomeController(ICitiesService cities, IWebHostEnvironment webHost,
            IConfiguration config,
            IOptions<MyApiOptions> dd)
        {
            _cities = cities;
            _webHost = webHost;
            _config = config;
            _dd = dd;

        }

        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.Environment = _webHost.EnvironmentName;
            ViewBag.Project_Path = _webHost.WebRootPath;
            ViewBag.Current_Root_Path = _webHost.ContentRootPath;
            ViewBag.ApplicationName = _webHost.ApplicationName;
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

        [Route("/read-configration")]
        public IActionResult ReadConfiguration(/*[FromServices]IConfiguration _config*/)
        {
            ViewBag.MyKey=_config.GetSection("MyKey").Value;
            ViewBag.MashRahim = _config.GetValue<string>("MashRahim");
            ViewBag.X = _config["x"];
            ViewBag.myConnectionsDefault = _config.GetValue<string>("myConnections:default", "Not found");
            ViewBag.myConnectionsOther = _config.GetValue<string>("myConnections:other", "Not found");

            //var dd=_config.GetSection("MyApi").Get<MyApiOptions>();
            var dd=new MyApiOptions();
            _config.GetSection("MyApi").Bind(dd);

            ViewBag.ClientId= dd.ClientId;
            ViewBag.ClientSecret= dd.ClientSecret;
            return View();
        }
    }
}
