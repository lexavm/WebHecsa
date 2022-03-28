using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebHecsa.Data;
using WebHecsa.Models;

namespace WebHecsa.Controllers
{
    public class CatProductoesController : Controller
    {
        private readonly nDbContext _context;

        public CatProductoesController(nDbContext context)
        {
            _context = context;
        }

        // GET: CatProductoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatProductos.ToListAsync());
        }

        // GET: CatProductoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catProducto = await _context.CatProductos
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (catProducto == null)
            {
                return NotFound();
            }

            return View(catProducto);
        }

        // GET: CatProductoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProducto,CodigoInterno,CodigoExterno,IdMarca,IdCategoria,DescProducto,CantidadMinima,Cantidad,ProductoPrecioUno,PorcentajePrecioUno,SubCosto,Costo,FechaRegistro,IdEstatusRegistro,IdCategoriaNavigationIdCategoria")] CatProducto catProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catProducto);
        }

        // GET: CatProductoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catProducto = await _context.CatProductos.FindAsync(id);
            if (catProducto == null)
            {
                return NotFound();
            }
            return View(catProducto);
        }

        // POST: CatProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProducto,CodigoInterno,CodigoExterno,IdMarca,IdCategoria,DescProducto,CantidadMinima,Cantidad,ProductoPrecioUno,PorcentajePrecioUno,SubCosto,Costo,FechaRegistro,IdEstatusRegistro,IdCategoriaNavigationIdCategoria")] CatProducto catProducto)
        {
            if (id != catProducto.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatProductoExists(catProducto.IdProducto))
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
            return View(catProducto);
        }

        // GET: CatProductoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catProducto = await _context.CatProductos
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (catProducto == null)
            {
                return NotFound();
            }

            return View(catProducto);
        }

        // POST: CatProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catProducto = await _context.CatProductos.FindAsync(id);
            _context.CatProductos.Remove(catProducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatProductoExists(int id)
        {
            return _context.CatProductos.Any(e => e.IdProducto == id);
        }
    }
}
