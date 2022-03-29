﻿using AspNetCoreHero.ToastNotification.Abstractions;
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
    public class CatAreasController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;

        public CatAreasController(nDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: CatAreas
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
            return View(await _context.CatAreas.ToListAsync());
        }

        // GET: CatAreas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catArea = await _context.CatAreas
                .FirstOrDefaultAsync(m => m.IdArea == id);
            if (catArea == null)
            {
                return NotFound();
            }

            return View(catArea);
        }

        // GET: CatAreas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatAreas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArea,AreaDesc")] CatArea catArea)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.CatAreas
                       .Where(s => s.AreaDesc == catArea.AreaDesc)
                       .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    var idEmpresa = _context.TblEmpresas.FirstOrDefault();
                    catArea.IdEmpresa = idEmpresa.IdEmpresa;
                    catArea.FechaRegistro = DateTime.Now;
                    catArea.AreaDesc = catArea.AreaDesc.ToString().ToUpper();
                    catArea.IdEstatusRegistro = 1;
                    _context.SaveChanges();

                    _context.Add(catArea);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    //_notifyService.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
                    _notyf.Information("Favor de validar, existe una Estatus con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catArea);
        }

        // GET: CatAreas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var catArea = await _context.CatAreas.FindAsync(id);
            if (catArea == null)
            {
                return NotFound();
            }
            return View(catArea);
        }

        // POST: CatAreas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArea,AreaDesc,IdEstatusRegistro")] CatArea catArea)
        {
            if (id != catArea.IdArea)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    catArea.FechaRegistro = DateTime.Now;
                    catArea.AreaDesc = catArea.AreaDesc.ToString().ToUpper();
                    catArea.IdEstatusRegistro = catArea.IdEstatusRegistro;
                    _context.SaveChanges();
                    _context.Update(catArea);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatAreaExists(catArea.IdArea))
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
            return View(catArea);
        }

        // GET: CatAreas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catArea = await _context.CatAreas
                .FirstOrDefaultAsync(m => m.IdArea == id);
            if (catArea == null)
            {
                return NotFound();
            }

            return View(catArea);
        }

        // POST: CatAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catArea = await _context.CatAreas.FindAsync(id);
            catArea.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatAreaExists(int id)
        {
            return _context.CatAreas.Any(e => e.IdArea == id);
        }
    }
}