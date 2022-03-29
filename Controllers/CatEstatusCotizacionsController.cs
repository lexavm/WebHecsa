using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHecsa.Data;
using WebHecsa.Models;

namespace WebHecsa.Controllers
{
    public class CatEstatusCotizacionsController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;

        public CatEstatusCotizacionsController(nDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: CatEstatusCotizacions
        public async Task<IActionResult> Index()
        {
            var ValidaEstatus = _context.CatEstatus.ToList();

            if (ValidaEstatus.Count == 2)
            {
                ViewBag.EstatusFlag = 1;
            }
            else
            {
                ViewBag.EstatusFlag = 0;
                _notyf.Information("Favor de registrar los Estatus para la Aplicación", 5);
            }
            return View(await _context.CatEstatusCotizacion.ToListAsync());
        }

        // GET: CatEstatusCotizacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catEstatusCotizacion = await _context.CatEstatusCotizacion
                .FirstOrDefaultAsync(m => m.IdEstatusCotizacion == id);
            if (catEstatusCotizacion == null)
            {
                return NotFound();
            }

            return View(catEstatusCotizacion);
        }

        // GET: CatEstatusCotizacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatEstatusCotizacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstatusCotizacion,EstatusDesc")] CatEstatusCotizacion catEstatusCotizacion)
        {
            if (ModelState.IsValid)
            {
                var vDuplicados = _context.CatEstatusCotizacion
                       .Where(s => s.EstatusDesc == catEstatusCotizacion.EstatusDesc)
                       .ToList();

                if (vDuplicados.Count == 0)
                {
                    catEstatusCotizacion.FechaRegistro = DateTime.Now;
                    catEstatusCotizacion.EstatusDesc = catEstatusCotizacion.EstatusDesc.ToString().ToUpper();
                    catEstatusCotizacion.IdEstatusRegistro = 1;
                    _context.SaveChanges();

                    _context.Add(catEstatusCotizacion);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    //_notifyService.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
                    _notyf.Warning("Favor de validar, existe una Estatus con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catEstatusCotizacion);
        }

        // GET: CatEstatusCotizacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var catEstatusCotizacion = await _context.CatEstatusCotizacion.FindAsync(id);
            if (catEstatusCotizacion == null)
            {
                return NotFound();
            }
            return View(catEstatusCotizacion);
        }

        // POST: CatEstatusCotizacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstatusCotizacion,EstatusDesc")] CatEstatusCotizacion catEstatusCotizacion)
        {
            if (id != catEstatusCotizacion.IdEstatusCotizacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    catEstatusCotizacion.FechaRegistro = DateTime.Now;
                    catEstatusCotizacion.EstatusDesc = catEstatusCotizacion.EstatusDesc.ToString().ToUpper();
                    catEstatusCotizacion.IdEstatusRegistro = catEstatusCotizacion.IdEstatusRegistro;
                    _context.SaveChanges();
                    _context.Update(catEstatusCotizacion);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatEstatusCotizacionExists(catEstatusCotizacion.IdEstatusCotizacion))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catEstatusCotizacion);
        }

        // GET: CatEstatusCotizacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catEstatusCotizacion = await _context.CatEstatusCotizacion
                .FirstOrDefaultAsync(m => m.IdEstatusCotizacion == id);
            if (catEstatusCotizacion == null)
            {
                return NotFound();
            }

            return View(catEstatusCotizacion);
        }

        // POST: CatEstatusCotizacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catEstatusCotizacion = await _context.CatEstatusCotizacion.FindAsync(id);
            catEstatusCotizacion.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatEstatusCotizacionExists(int id)
        {
            return _context.CatEstatusCotizacion.Any(e => e.IdEstatusCotizacion == id);
        }
    }
}