using juguetoys_erp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using X.PagedList;

namespace juguetoys_erp.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly JuguetoysDbContext _context;
        public ProveedorController(JuguetoysDbContext context)
        {
            this._context = context;
        }
        // GET: PClienteController
        public async Task<IActionResult> Index(string searchString, int? page)
        {
            var pageNumber = page ?? 1;

            ViewBag.CurrentFilter = searchString;

            IEnumerable<Proveedor> Provee = new List<Proveedor>();

            Provee = await _context.Proveedors.ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                Provee = Provee.Where(c => c.FldNombre.Contains(searchString));
            }

            bool isAjax = HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            if (isAjax)
            {
                return PartialView("_ListProveedor", Provee.ToList().OrderByDescending(c => c.IdProveedor).ToPagedList(pageNumber, 10));
            }
            else
            {
                return PartialView(Provee.ToList().OrderByDescending(c => c.IdProveedor).ToPagedList(pageNumber, 10));
            }
            
        }

        // GET: PClienteController/Details/5
        public ActionResult Details(int IdProveedor)
        {
            return View();
        }

        // GET: PClienteController/Create
        public IActionResult Create(int IdProveedor)
        {

            ViewBag.IdProveedor = IdProveedor;

            if(IdProveedor == 0)
            {
                return PartialView();
            }
            else
            {
                IEnumerable<Proveedor> provee = new List<Proveedor>();
                provee = _context.Proveedors.ToList().Where(c => c.IdProveedor == IdProveedor);

                if (provee == null)
                {
                    return NotFound();
                }

                return PartialView(provee.First());
            }            
        }

        // POST: PClienteController/Create
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

        // GET: PClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PClienteController/Edit/5
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

        // GET: PClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PClienteController/Delete/5
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
