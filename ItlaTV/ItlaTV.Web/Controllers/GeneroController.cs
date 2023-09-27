using ItlaTV.Application.Contract;
using ItlaTV.Application.Dtos.Genero;
using ItlaTV.Domain.Entities;
using ItlaTV.Web.Models.Genero;
using Microsoft.AspNetCore.Mvc;

namespace ItlaTV.Web.Controllers
{
    public class GeneroController : Controller
    {
        private IGeneroService generoService;

        public GeneroController(IGeneroService generoService)
        {
            this.generoService = generoService;
        }

        // GET: GeneroController
        public async Task<ActionResult> Index()
        {
            List<GeneroViewModel> generos = new List<GeneroViewModel>();

            try
            {
                var result = await generoService.Get();

                if (!result.Success)
                    throw new Exception(result.Message);

                var data = result.Data as List<Genero>;

                generos = data.Select(g => new GeneroViewModel
                        {
                            GeneroId = g.GeneroId,
                            Nombre = g.Nombre
                        }).ToList();

                return View(generos);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: GeneroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GeneroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GeneroViewModel g)
        {
            try
            {
                var genero = new GeneroAddDto()
                {
                    Nombre = g.Nombre
                };

                var result = await generoService.Save(genero);

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

        // GET: GeneroController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var result = await generoService.GetById(id);

                if (!result.Success)
                    throw new Exception(result.Message);

                var data = result.Data as Genero;

                GeneroViewModel genero = new GeneroViewModel()
                {
                    GeneroId = data.GeneroId,
                    Nombre = data.Nombre
                };

                return View(genero);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: GeneroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, GeneroViewModel g)
        {
            try
            {
                var genero = new GeneroUpdateDto()
                {
                    GeneroId = g.GeneroId,
                    Nombre = g.Nombre
                };

                var result = await generoService.Update(genero);

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

        // GET: GeneroController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await generoService.GetById(id);

                if (!result.Success)
                    throw new Exception(result.Message);

                var data = result.Data as Genero;

                GeneroViewModel genero = new GeneroViewModel()
                {
                    GeneroId = data.GeneroId,
                    Nombre = data.Nombre
                };

                return View(genero);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: GeneroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, GeneroViewModel g)
        {
            try
            {
                var genero = new GeneroRemoveDto()
                {
                    GeneroId = id
                };

                var result = await generoService.Remove(genero);

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
