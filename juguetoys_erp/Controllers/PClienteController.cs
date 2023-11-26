using juguetoys_erp.Models;
using juguetoys_erp.Models.ViewModels;
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
        public async Task<IActionResult> Create([Bind("FldNombre, FldTelefono, FldDireccion")] ClienteViewModel model)
        {
            
            var cliente = new PCliente
            {
                FldNombre = model.FldNombre,
                FldTelefono = model.FldTelefono,
                FldDireccion = model.FldDireccion
            };

            this._context.PClientes.Add(cliente);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        // GET: PClienteController/Edit/5
        public ActionResult Edit(int idCliente)
        {
            IEnumerable<PCliente> cliente = new List<PCliente>();
            cliente =  _context.PClientes.ToList().Where(c => c.IdCliente == idCliente);

            if (cliente == null)
            {
                return NotFound();
            }

            ViewBag.idCliente = idCliente;

            var clienteVw = new ClienteViewModel
            {                
                IdCliente = cliente.First().IdCliente,
                FldNombre = cliente.First().FldNombre,
                FldTelefono = cliente.First().FldTelefono,
                FldDireccion = cliente.First().FldDireccion
            };

            return PartialView(clienteVw);
        }

        // POST: PClienteController/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("IdCliente, FldNombre, FldTelefono, FldDireccion")] ClienteViewModel model)
        {
            

            var cliente = await _context.PClientes.FindAsync(model.IdCliente);

            if (cliente == null)
                return NotFound();
            
            cliente.FldNombre = model.FldNombre;
            cliente.FldTelefono = model.FldTelefono;
            cliente.FldDireccion = model.FldDireccion;

            _context.Update(cliente);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: PClienteController/Delete/5
        public async Task<IActionResult> Delete(int idCliente)
        {
            var cliente = await _context.PClientes.FindAsync(idCliente);

            if(cliente == null)
                return NotFound();

            var clienteVw = new ClienteViewModel
            {
                IdCliente = cliente.IdCliente,
                FldNombre = cliente.FldNombre
            };

            return PartialView(clienteVw);
        }

        // POST: PClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeletePost(int IdCliente)
        {
            var cliente = await _context.PClientes.FindAsync(IdCliente);
            
            if(cliente == null) return NotFound();

            _context.PClientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
