using Microsoft.AspNetCore.Mvc;

namespace OptiCore.API.Controllers
{
    public class LeadsController : Controller
    {
        // GET: LeadsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LeadsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LeadsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeadsController/Create
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

        // GET: LeadsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeadsController/Edit/5
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

        // GET: LeadsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeadsController/Delete/5
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