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
    public class TblEmpresaFiscalesController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;

        public TblEmpresaFiscalesController(nDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: TblEmpresaFiscales
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
            return View(await _context.TblEmpresaFiscales.ToListAsync());
        }

        [HttpGet]
        public ActionResult FiltroEmpresaFiscales(Guid id)
        {
            var fEmpresaFiscales = (from ta in _context.TblEmpresaFiscales
                                    where ta.IdEmpresaFiscales == id
                                    select ta).Distinct().ToList();

            return Json(fEmpresaFiscales);
        }

        // GET: TblEmpresaFiscales/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmpresaFiscales = await _context.TblEmpresaFiscales
                .FirstOrDefaultAsync(m => m.IdEmpresaFiscales == id);
            if (tblEmpresaFiscales == null)
            {
                return NotFound();
            }

            return View(tblEmpresaFiscales);
        }

        // GET: TblEmpresaFiscales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblEmpresaFiscales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpresaFiscales,NombreFiscal,RFC,RegimenFiscal,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,CorreoElectronico,Telefono")] TblEmpresaFiscal tblEmpresaFiscales)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.TblEmpresaFiscales
                       .Where(s => s.NombreFiscal == tblEmpresaFiscales.NombreFiscal)
                       .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    var idEmpresa = _context.TblEmpresas.FirstOrDefault();
                    tblEmpresaFiscales.FechaRegistro = DateTime.Now;
                    tblEmpresaFiscales.NombreFiscal = tblEmpresaFiscales.NombreFiscal.ToString().ToUpper();
                    tblEmpresaFiscales.Rfc = !string.IsNullOrEmpty(tblEmpresaFiscales.Rfc) ? tblEmpresaFiscales.Rfc.ToUpper() : tblEmpresaFiscales.Rfc;
                    tblEmpresaFiscales.RegimenFiscal = !string.IsNullOrEmpty(tblEmpresaFiscales.RegimenFiscal) ? tblEmpresaFiscales.RegimenFiscal.ToUpper() : tblEmpresaFiscales.RegimenFiscal;
                    tblEmpresaFiscales.IdEstatusRegistro = 1;
                    var strColonia = _context.CatCodigosPostales.Where(s => s.IdAsentaCpcons == tblEmpresaFiscales.Colonia).FirstOrDefault();
                    tblEmpresaFiscales.IdColonia = !string.IsNullOrEmpty(tblEmpresaFiscales.Colonia) ? tblEmpresaFiscales.Colonia : tblEmpresaFiscales.Colonia;
                    tblEmpresaFiscales.Colonia = !string.IsNullOrEmpty(tblEmpresaFiscales.Colonia) ? strColonia.Dasenta.ToUpper() : tblEmpresaFiscales.Colonia;
                    tblEmpresaFiscales.Calle = !string.IsNullOrEmpty(tblEmpresaFiscales.Calle) ? tblEmpresaFiscales.Calle.ToUpper() : tblEmpresaFiscales.Calle;
                    tblEmpresaFiscales.LocalidadMunicipio = !string.IsNullOrEmpty(tblEmpresaFiscales.LocalidadMunicipio) ? tblEmpresaFiscales.LocalidadMunicipio.ToUpper() : tblEmpresaFiscales.LocalidadMunicipio;
                    tblEmpresaFiscales.Ciudad = !string.IsNullOrEmpty(tblEmpresaFiscales.Ciudad) ? tblEmpresaFiscales.Ciudad.ToUpper() : tblEmpresaFiscales.Ciudad;
                    tblEmpresaFiscales.Estado = !string.IsNullOrEmpty(tblEmpresaFiscales.Estado) ? tblEmpresaFiscales.Estado.ToUpper() : tblEmpresaFiscales.Estado;
                    tblEmpresaFiscales.IdEmpresa = idEmpresa.IdEmpresa;
                    _context.SaveChanges();
                    _context.Add(tblEmpresaFiscales);
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
            return View(tblEmpresaFiscales);
        }

        // GET: TblEmpresaFiscales/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var tblEmpresaFiscales = await _context.TblEmpresaFiscales.FindAsync(id);
            if (tblEmpresaFiscales == null)
            {
                return NotFound();
            }
            return View(tblEmpresaFiscales);
        }

        // POST: TblEmpresaFiscales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdEmpresaFiscales,NombreFiscal,RFC,RegimenFiscal,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,CorreoElectronico,Telefono,IdEstatusRegistro,IdEmpresa")] TblEmpresaFiscal tblEmpresaFiscales)
        {
            if (id != tblEmpresaFiscales.IdEmpresaFiscales)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tblEmpresaFiscales.FechaRegistro = DateTime.Now;
                    tblEmpresaFiscales.NombreFiscal = tblEmpresaFiscales.NombreFiscal.ToString().ToUpper();
                    tblEmpresaFiscales.Rfc = !string.IsNullOrEmpty(tblEmpresaFiscales.Rfc) ? tblEmpresaFiscales.Rfc.ToUpper() : tblEmpresaFiscales.Rfc;
                    tblEmpresaFiscales.RegimenFiscal = !string.IsNullOrEmpty(tblEmpresaFiscales.RegimenFiscal) ? tblEmpresaFiscales.RegimenFiscal.ToUpper() : tblEmpresaFiscales.RegimenFiscal;
                    tblEmpresaFiscales.IdEstatusRegistro = 1;
                    var strColonia = _context.CatCodigosPostales.Where(s => s.IdAsentaCpcons == tblEmpresaFiscales.Colonia).FirstOrDefault();
                    tblEmpresaFiscales.IdColonia = !string.IsNullOrEmpty(tblEmpresaFiscales.Colonia) ? tblEmpresaFiscales.Colonia : tblEmpresaFiscales.Colonia;
                    tblEmpresaFiscales.Colonia = !string.IsNullOrEmpty(tblEmpresaFiscales.Colonia) ? strColonia.Dasenta.ToUpper() : tblEmpresaFiscales.Colonia;
                    tblEmpresaFiscales.Calle = !string.IsNullOrEmpty(tblEmpresaFiscales.Calle) ? tblEmpresaFiscales.Calle.ToUpper() : tblEmpresaFiscales.Calle;
                    tblEmpresaFiscales.LocalidadMunicipio = !string.IsNullOrEmpty(tblEmpresaFiscales.LocalidadMunicipio) ? tblEmpresaFiscales.LocalidadMunicipio.ToUpper() : tblEmpresaFiscales.LocalidadMunicipio;
                    tblEmpresaFiscales.Ciudad = !string.IsNullOrEmpty(tblEmpresaFiscales.Ciudad) ? tblEmpresaFiscales.Ciudad.ToUpper() : tblEmpresaFiscales.Ciudad;
                    tblEmpresaFiscales.Estado = !string.IsNullOrEmpty(tblEmpresaFiscales.Estado) ? tblEmpresaFiscales.Estado.ToUpper() : tblEmpresaFiscales.Estado;
                    _context.Update(tblEmpresaFiscales);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblEmpresaFiscalesExists(tblEmpresaFiscales.IdEmpresaFiscales))
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
            return View(tblEmpresaFiscales);
        }

        // GET: TblEmpresaFiscales/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmpresaFiscales = await _context.TblEmpresaFiscales
                .FirstOrDefaultAsync(m => m.IdEmpresaFiscales == id);
            if (tblEmpresaFiscales == null)
            {
                return NotFound();
            }

            return View(tblEmpresaFiscales);
        }

        // POST: TblEmpresaFiscales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblEmpresaFiscales = await _context.TblEmpresaFiscales.FindAsync(id);
            tblEmpresaFiscales.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblEmpresaFiscalesExists(Guid id)
        {
            return _context.TblEmpresaFiscales.Any(e => e.IdEmpresaFiscales == id);
        }
    }
}