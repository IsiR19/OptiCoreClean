using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OptiCore.API.Controllers
{
    public class AgentsController : Controller
    {
        // GET: AgentsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AgentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AgentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgentsController/Create
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

        // GET: AgentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AgentsController/Edit/5
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

        // GET: AgentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AgentsController/Delete/5
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
