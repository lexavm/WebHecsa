﻿using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHecsa.Data;
using WebHecsa.Models;

namespace WebAdminHecsa.Controllers
{
    public class CatProductosController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;

        public CatProductosController(nDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: CatProductos
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
                            var ValidaCategoria = _context.CatCategorias.ToList();

                            if (ValidaCategoria.Count >= 1)
                            {
                                ViewBag.CategoriaFlag = 1;
                            }
                            else
                            {
                                ViewBag.CategoriaFlag = 0;
                                _notyf.Information("Favor de registrar los datos de Categoria para la Aplicación", 5);
                            }
                        }
                        else
                        {
                            ViewBag.MarcaFlag = 0;
                            _notyf.Information("Favor de registrar los datos de Marca para la Aplicación", 5);
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
            var fProductos = from a in _context.CatProductos
                             join b in _context.CatCategorias on a.IdCategoria equals b.IdCategoria
                             join c in _context.CatMarcas on a.IdMarca equals c.IdMarca
                             select new CatProducto
                             {
                                 IdProducto = a.IdProducto,
                                 CodigoInterno = a.CodigoInterno,
                                 CodigoExterno = a.CodigoExterno,
                                 CategoriaDesc = b.CategoriaDesc,
                                 MarcaDesc = c.MarcaDesc,
                                 DescProducto = a.DescProducto,
                                 FechaRegistro = a.FechaRegistro,
                                 IdEstatusRegistro = a.IdEstatusRegistro
                             };

            return View(await fProductos.ToListAsync());
        }

        // GET: CatProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catProductos = await _context.CatProductos
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (catProductos == null)
            {
                return NotFound();
            }

            return View(catProductos);
        }

        // GET: CatProductos/Create
        public IActionResult Create()
        {
            List<CatMarca> ListaMarca = new List<CatMarca>();
            ListaMarca = (from c in _context.CatMarcas select c).Distinct().ToList();
            ViewBag.ListaMarca = ListaMarca;

            List<CatCategoria> ListaCategoria = new List<CatCategoria>();
            ListaCategoria = (from c in _context.CatCategorias select c).Distinct().ToList();
            ViewBag.ListaCategoria = ListaCategoria;

            return View();
        }

        // POST: CatProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProducto,CodigoExterno,IdMarca,IdCategoria,DescProducto")] CatProducto catProductos)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.CatProductos
               .Where(s => s.IdCategoria == catProductos.IdMarca && s.IdCategoria == catProductos.IdCategoria && s.DescProducto == catProductos.DescProducto)
               .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    var fMarca = (from c in _context.CatMarcas where c.IdMarca == catProductos.IdMarca select c).Distinct().ToList();
                    var fCategoria = (from c in _context.CatCategorias where c.IdCategoria == catProductos.IdCategoria select c).Distinct().ToList();
                    catProductos.FechaRegistro = DateTime.Now;
                    catProductos.IdEstatusRegistro = 1;
                    catProductos.MarcaDesc = fMarca[0].MarcaDesc;
                    catProductos.CategoriaDesc = fCategoria[0].CategoriaDesc;
                    catProductos.DescProducto = !string.IsNullOrEmpty(catProductos.DescProducto) ? catProductos.DescProducto.ToUpper() : catProductos.DescProducto;
                    catProductos.CodigoInterno = GeneraCodigoInterno();
                    catProductos.SubCosto = catProductos.ProductoPrecioUno * (catProductos.PorcentajePrecioUno / 100);

                    _context.SaveChanges();
                    _context.Add(catProductos);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    //_notifyService.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
                    _notyf.Warning("Favor de validar, existe una Producto con la misma marca y misma categoria", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catProductos);
        }

        // GET: CatProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatMarca> ListaMarca = new List<CatMarca>();
            ListaMarca = (from c in _context.CatMarcas select c).Distinct().ToList();
            ViewBag.ListaMarca = ListaMarca;

            List<CatCategoria> ListaCategoria = new List<CatCategoria>();
            ListaCategoria = (from c in _context.CatCategorias select c).Distinct().ToList();
            ViewBag.ListaCategoria = ListaCategoria;

            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var catProductos = await _context.CatProductos.FindAsync(id);
            if (catProductos == null)
            {
                return NotFound();
            }
            return View(catProductos);
        }

        // POST: CatProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProducto,CodigoInterno,CodigoExterno,IdMarca,IdCategoria,DescProducto,CantidadMinima,Cantidad,ProductoPrecioUno,PorcentajePrecioUno,ProductoPrecioDos,PorcentajePrecioDos,ProductoPrecioTres,PorcentajePrecioTres,ProductoPrecioCuatro,PorcentajePrecioCuatro,SubCosto,Costo,IdEstatusRegistro")] CatProducto catProductos)
        {
            if (id != catProductos.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fMarca = (from c in _context.CatMarcas where c.IdMarca == catProductos.IdMarca select c).Distinct().ToList();
                    var fCategoria = (from c in _context.CatCategorias where c.IdCategoria == catProductos.IdCategoria select c).Distinct().ToList();
                    catProductos.FechaRegistro = DateTime.Now;
                    catProductos.IdEstatusRegistro = 1;
                    catProductos.MarcaDesc = fMarca[0].MarcaDesc;
                    catProductos.CategoriaDesc = fCategoria[0].CategoriaDesc;
                    catProductos.DescProducto = !string.IsNullOrEmpty(catProductos.DescProducto) ? catProductos.DescProducto.ToUpper() : catProductos.DescProducto;
                    catProductos.SubCosto = catProductos.ProductoPrecioUno * (1 + (catProductos.PorcentajePrecioUno / 100));

                    _context.SaveChanges();
                    _context.Update(catProductos);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatProductosExists(catProductos.IdProducto))
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
            return View(catProductos);
        }

        // GET: CatProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catProductos = await _context.CatProductos
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (catProductos == null)
            {
                return NotFound();
            }

            return View(catProductos);
        }

        // POST: CatProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catProductos = await _context.CatProductos.FindAsync(id);
            catProductos.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatProductosExists(int id)
        {
            return _context.CatProductos.Any(e => e.IdProducto == id);
        }

        private string GeneraCodigoInterno()
        {
            string fmt = "00000000.##";
            int Cuenta = 0;
            string strCodigoInterno = string.Empty;
            int lProductos = _context.CatProductos.Count();

            if (lProductos == 0)
            {
                Cuenta = 1;
                strCodigoInterno = "H-p" + Cuenta.ToString(fmt);
            }
            else
            {
                Cuenta = lProductos + 1;
                strCodigoInterno = "H-p" + Cuenta.ToString(fmt);
            }

            return strCodigoInterno;
        }
    }
}