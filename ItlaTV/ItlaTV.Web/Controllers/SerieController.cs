using ItlaTV.Application.Contract;
using ItlaTV.Application.Dtos.Genero;
using ItlaTV.Application.Dtos.Productora;
using ItlaTV.Application.Dtos.Serie;
using ItlaTV.Domain.Entities;
using ItlaTV.Web.Models.Genero;
using ItlaTV.Web.Models.Productora;
using ItlaTV.Web.Models.Serie;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ItlaTV.Web.Controllers
{
    public class SerieController : Controller
    {
        private ISerieService serieService;
        private IProductoraService productoraService;
        private IGeneroService generoService;

        public SerieController(ISerieService serieService,
                                IProductoraService productoraService,
                                IGeneroService generoService)
        {
            this.serieService = serieService;
            this.productoraService = productoraService;
            this.generoService = generoService;
        }

        private async Task<List<ProductoraViewModel>> GetProductoras()
        {
            List<ProductoraViewModel> productoras = new List<ProductoraViewModel>();

            var rproductoras = await productoraService.Get();

            var dproductoras = rproductoras.Data as List<Productora>;

            return productoras = dproductoras.Select(p => new ProductoraViewModel
            {
                ProductoraId = p.ProductoraId,
                Nombre = p.Nombre
            }).ToList();
        }
        private async Task<List<GeneroViewModel>> GetGeneros()
        {
            List<GeneroViewModel> generos = new List<GeneroViewModel>();

            var rgeneros = await generoService.Get();

            var dgeneros = rgeneros.Data as List<Genero>;

            return generos = dgeneros.Select(g => new GeneroViewModel
            {
                GeneroId = g.GeneroId,
                Nombre = g.Nombre
            }).ToList();
        }

        // GET: SerieController
        public async Task<ActionResult> Index()
        {
            List<SerieViewModel> series = new List<SerieViewModel>();

            try
            {
                var result = await serieService.Get();

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

                return View(series);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: SerieController/Create
        public async Task<ActionResult> Create()
        {
            SerieCreateViewModel serieCreate = new SerieCreateViewModel()
            {
                Generos = await this.GetGeneros(),
                Productoras = await this.GetProductoras()
            };

            return View(serieCreate);
        }

        // POST: SerieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SerieCreateViewModel s)
        {
            try
            {
                SerieAddDto serie = new SerieAddDto()
                {
                    Nombre = s.Nombre,
                    Imagen = s.Imagen,
                    ProductoraId = s.ProductoraId,
                    GeneroId = s.GeneroId,
                    SGeneroId = s.SGeneroId,
                    Enlace = s.Enlace
                };

                var result = await serieService.Save(serie);

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SerieController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var result = await serieService.GetById(id);

                if (!result.Success)
                    throw new Exception(result.Message);

                var data = result.Data as Serie;

                SerieUpdateViewModel serieUpdate = new SerieUpdateViewModel()
                {
                    SerieId = data.SerieId,
                    Nombre = data.Nombre,
                    ImagenPath = data.ImagePath,
                    Enlace = data.Enlace,
                    ProductoraId = data.ProductoraId,
                    GeneroId = data.GeneroId,
                    SGeneroId = data.SGeneroId,
                    Generos = await this.GetGeneros(),
                    Productoras = await this.GetProductoras()
                };

                return View(serieUpdate);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: SerieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, SerieUpdateViewModel s)
        {
            try
            {
                SerieUpdateDto serieUpdate = new SerieUpdateDto()
                {
                    SerieId = s.SerieId,
                    Nombre = s.Nombre,
                    ImagenPath = s.ImagenPath,
                    Imagen = s.Imagen,
                    Enlace = s.Enlace,
                    ProductoraId = s.ProductoraId,
                    GeneroId = s.GeneroId,
                    SGeneroId = s.SGeneroId
                };

                var result = await serieService.Update(serieUpdate);

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SerieController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await serieService.GetById(id);

                if (!result.Success)
                    throw new Exception(result.Message);

                var data = result.Data as Serie;

                SerieRemoveViewModel serieRemove = new SerieRemoveViewModel()
                {
                    SerieId = data.SerieId,
                    Nombre = data.Nombre
                };

                return View(serieRemove);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: SerieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, SerieRemoveViewModel s)
        {
            try
            {
                var serie = new SerieRemoveDto()
                {
                    SerieId = id
                };

                var result = await serieService.Remove(serie);

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
