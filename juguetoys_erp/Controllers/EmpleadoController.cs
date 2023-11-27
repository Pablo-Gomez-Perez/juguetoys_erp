using juguetoys_erp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace juguetoys_erp.Controllers
{
    public class EmpleadoController : Controller
    {

        private readonly JuguetoysDbContext _context;

        public EmpleadoController(JuguetoysDbContext context)
        {
            this._context = context;
        }
        // GET: EmpleadoController
        public async Task<IActionResult> Index(string searchString, int? page)
        {
            var pagenumbers = page ?? 1;

            ViewBag.CurrentFilter = searchString;

            IEnumerable<Empleado> empleado = new List<Empleado>();

            empleado = await _context.Empleados.Include(p => p.IdRolNavigation).ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                empleado = empleado.Where(p => p.FldNombre.Contains(searchString));
            }

            ViewBag.TotalRows = empleado.Count();

            bool isAjax = HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            if (isAjax)
            {
                return PartialView("_ListEmpleados", empleado.ToList().OrderByDescending(p => p.IdEmpleado).ToPagedList(pagenumbers, 10));
            }
            else
            {
                return View(empleado.ToList().OrderByDescending(p => p.IdEmpleado).ToPagedList(pagenumbers,10));
            }
            
        }

        // GET: EmpleadoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpleadoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoController/Create
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

        // GET: EmpleadoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpleadoController/Edit/5
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

        // GET: EmpleadoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpleadoController/Delete/5
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
