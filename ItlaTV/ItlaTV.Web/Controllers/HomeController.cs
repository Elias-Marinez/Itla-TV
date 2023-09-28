using ItlaTV.Application.Contract;
using ItlaTV.Application.Service;
using ItlaTV.Domain.Entities;
using ItlaTV.Web.Models;
using ItlaTV.Web.Models.Home;
using ItlaTV.Web.Models.Productora;
using ItlaTV.Web.Models.Serie;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ItlaTV.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ISerieService _serieService;
        private IProductoraService _productoraService;
        public HomeController(ILogger<HomeController> logger, 
                                ISerieService serieService,
                                IProductoraService productoraService)
        {
            _logger = logger;
            _serieService = serieService;
            _productoraService = productoraService;
        }

        public async Task<ActionResult> Index()
        {
            HomeViewModel home = new HomeViewModel();

            try
            {
                #region Series
                List<SerieViewModel> series = new List<SerieViewModel>();

                var result = await _serieService.Get();

                if (!result.Success)
                    throw new Exception(result.Message);

                var data = result.Data as List<Serie>;

                series = data.Select(s => new SerieViewModel
                {
                    SerieId = s.SerieId,
                    Nombre = s.Nombre,
                    NombreProductora = s.Productora.Nombre,
                    NGenero = s.Genero.Nombre,
                    SNGenero = s.SGenero.Nombre,
                    ImagePath = s.ImagePath
                }).ToList();
                #endregion

                #region Productoras
                List<ProductoraViewModel> productoras = new List<ProductoraViewModel>();

                var rproductoras = await _productoraService.Get();

                var dproductoras = rproductoras.Data as List<Productora>;

                productoras = dproductoras.Select(p => new ProductoraViewModel
                {
                    ProductoraId = p.ProductoraId,
                    Nombre = p.Nombre
                }).ToList();
                #endregion

                home.Series = series;
                home.Productoras = productoras;
                return View(home);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var result = await _serieService.GetById(id);

                if (!result.Success)
                    throw new Exception(result.Message);

                var s = result.Data as Serie;

                SerieViewModel serie = new SerieViewModel()
                {
                    SerieId = s.SerieId,
                    Nombre = s.Nombre,
                    NombreProductora = s.Productora.Nombre,
                    NGenero = s.Genero.Nombre,
                    SNGenero = s.SGenero.Nombre,
                    ImagePath = s.ImagePath,
                    Enlace = s.Enlace
                };
;
                return View(serie);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}