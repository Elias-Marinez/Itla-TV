using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItlaTV.Web.Controllers
{
    public class ProductoraController : Controller
    {
        // GET: ProductoraController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductoraController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductoraController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoraController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductoraController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoraController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductoraController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
