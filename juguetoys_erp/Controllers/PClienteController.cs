using juguetoys_erp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using X.PagedList;

namespace juguetoys_erp.Controllers
{
    public class PClienteController : Controller
    {
        private readonly JuguetoysDbContext _context;
        public PClienteController(JuguetoysDbContext context)
        {
            this._context = context;
        }
        // GET: PClienteController
        public async Task<IActionResult> Index(string searchString, int? page)
        {
            var pageNumber = page ?? 1;

            ViewBag.CurrentFilter = searchString;

            IEnumerable<PCliente> cliente = new List<PCliente>();

            cliente = await _context.PClientes.ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                cliente = cliente.Where(c => c.FldNombre.Contains(searchString));
            }

            ViewBag.TotalRows = cliente.Count();

            bool isAjax = HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            if (isAjax)
            {
                return PartialView("_ListClientes", cliente.ToList().OrderByDescending(c => c.IdCliente).ToPagedList(pageNumber, 10));
            }
            else
            {
                return PartialView(cliente.ToList().OrderByDescending(c => c.IdCliente).ToPagedList(pageNumber, 10));
            }
            
        }

        // GET: PClienteController/Details/5
        public ActionResult Details(int IdCliente)
        {
            return View();
        }

        // GET: PClienteController/Create
        public IActionResult Create(int IdCliente)
        {
            //ViewBag.IdCliente = IdCliente;                        
            return PartialView();
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
        public ActionResult Edit(int idCliente)
        {
            IEnumerable<PCliente> cliente = new List<PCliente>();
            cliente = _context.PClientes.ToList().Where(c => c.IdCliente == idCliente);

            if (cliente == null)
            {
                return NotFound();
            }

            ViewBag.idCliente = idCliente;

            return PartialView(cliente.First());
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
