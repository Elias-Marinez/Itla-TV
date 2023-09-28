using ItlaTV.Application.Contract;
using ItlaTV.Application.Dtos.Productora;
using ItlaTV.Domain.Entities;
using ItlaTV.Web.Models.Productora;
using Microsoft.AspNetCore.Mvc;

namespace ItlaTV.Web.Controllers
{
    public class ProductoraController : Controller
    {
        private IProductoraService productoraService;

        public ProductoraController(IProductoraService productoraService)
        {
            this.productoraService = productoraService;
        }
        // GET: ProductoraController
        public async Task<ActionResult> Index()
        {
            List<ProductoraViewModel> productoras = new List<ProductoraViewModel>();

            try
            {
                var result = await productoraService.Get();

                if (!result.Success)
                    throw new Exception(result.Message);

                var data = result.Data as List<Productora>;

                productoras = data.Select(p => new ProductoraViewModel
                {
                    ProductoraId = p.ProductoraId,
                    Nombre = p.Nombre
                }).ToList();

                return View(productoras);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: ProductoraController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductoraViewModel p)
        {
            try
            {
                var productora = new ProductoraAddDto()
                {
                    Nombre = p.Nombre
                };

                var result = await productoraService.Save(productora);

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

        // GET: ProductoraController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var result = await productoraService.GetById(id);

                if (!result.Success)
                    throw new Exception(result.Message);

                var data = result.Data as Productora;

                ProductoraViewModel productora = new ProductoraViewModel()
                {
                    ProductoraId = data.ProductoraId,
                    Nombre = data.Nombre
                };

                return View(productora);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: ProductoraController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ProductoraViewModel p)
        {
            try
            {
                var productora = new ProductoraUpdateDto()
                {
                    ProductoraId = p.ProductoraId,
                    Nombre = p.Nombre
                };

                var result = await productoraService.Update(productora);

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

        // GET: ProductoraController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await productoraService.GetById(id);

                if (!result.Success)
                    throw new Exception(result.Message);

                var data = result.Data as Productora;

                ProductoraViewModel productora = new ProductoraViewModel()
                {
                    ProductoraId = data.ProductoraId,
                    Nombre = data.Nombre
                };

                return View(productora);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: ProductoraController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ProductoraViewModel p)
        {
            try
            {
                var productora = new ProductoraRemoveDto()
                {
                    ProductoraId = id
                };

                var result = await productoraService.Remove(productora);

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
