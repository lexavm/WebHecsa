using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebHecsa.Data;
using WebHecsa.Models;

namespace WebAdminHecsa.Controllers
{
    public class CatCategoriasController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;

        public CatCategoriasController(nDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: CatCategorias
        public async Task<IActionResult> Index()
        {
            var ValidaEstatus = _context.CatEstatus.ToList();

            if (ValidaEstatus.Count == 2)
            {
                ViewBag.EstatusFlag = 1;
                var ValidaEmpresa = _context.TblEmpresas.ToList();

                if (ValidaEmpresa.Count == 1)
                {
                    ViewBag.EmpresaFlag = 1;
                    var ValidaProveedor = _context.TblProveedores.ToList();

                    if (ValidaProveedor.Count >= 1)
                    {
                        ViewBag.ProveedorFlag = 1;
                        var ValidaMarca = _context.CatMarcas.ToList();

                        if (ValidaMarca.Count >= 1)
                        {
                            ViewBag.MarcaFlag = 1;
                        }
                        else
                        {
                            ViewBag.MarcaFlag = 0;
                            _notyf.Information("Favor de registrar los datos de Marcas para la Aplicación", 5);
                        }
                    }
                    else
                    {
                        ViewBag.ProveedorFlag = 0;
                        _notyf.Information("Favor de registrar los datos de Proveedores para la Aplicación", 5);
                    }
                }
                else
                {
                    ViewBag.EmpresaFlag = 0;
                    _notyf.Information("Favor de registrar los datos de la Empresa para la Aplicación", 5);
                }
            }
            else
            {
                ViewBag.EstatusFlag = 0;
                _notyf.Information("Favor de registrar los Estatus para la Aplicación", 5);
            }
            var fCatCategoria = from a in _context.CatCategorias
                                join b in _context.CatMarcas on a.IdMarca equals b.IdMarca
                                select new CatCategoria
                                {
                                    IdCategoria = a.IdCategoria,
                                    CategoriaDesc = a.CategoriaDesc,
                                    MarcaDesc = b.MarcaDesc,
                                    FechaRegistro = a.FechaRegistro,
                                    IdEstatusRegistro = a.IdEstatusRegistro
                                };

            return View(await fCatCategoria.ToListAsync());
        }

        // GET: CatCategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catCategoria = await _context.CatCategorias
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (catCategoria == null)
            {
                return NotFound();
            }

            return View(catCategoria);
        }

        // GET: CatCategorias/Create
        public IActionResult Create()
        {
            List<CatMarca> ListaMarca = new List<CatMarca>();
            ListaMarca = (from c in _context.CatMarcas select c).Distinct().ToList();
            ViewBag.ListaMarca = ListaMarca;
            ViewData["IdMarca"] = new SelectList(_context.CatMarcas, "IdMarca", "MarcaDesc");
            return View();
        }

        // POST: CatCategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategoria,CategoriaDesc,IdMarca,FechaRegistro,IdEstatusRegistro")] CatCategoria catCategoria)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.CatCategorias
               .Where(s => s.CategoriaDesc == catCategoria.CategoriaDesc)
               .ToList();

                if (DuplicadosEstatus.Count == 0)
                {

                    //var fMarca = (from c in _context.CatMarca where c.IdMarca == catCategoria.IdMarca select c).Distinct().ToList();
                    catCategoria.FechaRegistro = DateTime.Now;
                    catCategoria.IdEstatusRegistro = 1;
                    //catCategoria.MarcaDesc = fMarca[0].MarcaDesc;
                    catCategoria.CategoriaDesc = !string.IsNullOrEmpty(catCategoria.CategoriaDesc) ? catCategoria.CategoriaDesc.ToUpper() : catCategoria.CategoriaDesc;

                    _context.SaveChanges();
                    _context.Add(catCategoria);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    //_notifyService.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
                    _notyf.Warning("Favor de validar, existe una Categoria con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_context.CatMarcas, "IdMarca", "MarcaDesc", catCategoria.IdCategoria);
            return View(catCategoria);
        }

        // GET: CatCategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatMarca> ListaMarca = new List<CatMarca>();
            ListaMarca = (from c in _context.CatMarcas select c).Distinct().ToList();
            ViewBag.ListaMarca = ListaMarca;

            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var catCategoria = await _context.CatCategorias.FindAsync(id);
            if (catCategoria == null)
            {
                return NotFound();
            }
            return View(catCategoria);
        }

        // POST: CatCategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCategoria,CategoriaDesc,IdMarca,MarcaDesc,FechaRegistro,IdEstatusRegistro")] CatCategoria catCategoria)
        {
            if (id != catCategoria.IdCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //var fMarca = (from c in _context.CatMarca where c.IdMarca == catCategoria.IdMarca select c).Distinct().ToList();
                    catCategoria.FechaRegistro = DateTime.Now;
                    catCategoria.IdEstatusRegistro = 1;
                    //catCategoria.MarcaDesc = fMarca[0].MarcaDesc;
                    catCategoria.CategoriaDesc = !string.IsNullOrEmpty(catCategoria.CategoriaDesc) ? catCategoria.CategoriaDesc.ToUpper() : catCategoria.CategoriaDesc;

                    _context.SaveChanges();
                    _context.Add(catCategoria);
                    _context.Update(catCategoria);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatCategoriaExists(catCategoria.IdCategoria))
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
            return View(catCategoria);
        }

        // GET: CatCategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catCategoria = await _context.CatCategorias
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (catCategoria == null)
            {
                return NotFound();
            }

            return View(catCategoria);
        }

        // POST: CatCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catCategoria = await _context.CatCategorias.FindAsync(id);
            catCategoria.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatCategoriaExists(int id)
        {
            return _context.CatCategorias.Any(e => e.IdCategoria == id);
        }
    }
}
