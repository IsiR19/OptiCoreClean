using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OptiCore.API.Controllers
{
    public class CPController : Controller
    {
        // GET: CPController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CPController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CPController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CPController/Create
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

        // GET: CPController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CPController/Edit/5
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

        // GET: CPController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CPController/Delete/5
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
