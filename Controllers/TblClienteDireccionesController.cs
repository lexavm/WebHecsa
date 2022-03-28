﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebHecsa.Data;
using WebHecsa.Models;

namespace WebHecsa.Controllers
{
    public class TblClienteDireccionesController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;

        public TblClienteDireccionesController(nDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: TblClienteDirecciones
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
                    var ValidaCliente = _context.TblClientes.ToList();

                    if (ValidaCliente.Count >= 1)
                    {
                        ViewBag.ClienteFlag = 1;
                    }
                    else
                    {
                        ViewBag.ClienteFlag = 0;
                        _notyf.Information("Favor de registrar los datos de la Proveedor para la Aplicación", 5);
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
            return View(await _context.TblClienteDirecciones.ToListAsync());
        }

        // GET: TblClienteDirecciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClienteDirecciones = await _context.TblClienteDirecciones
                .FirstOrDefaultAsync(m => m.IdClienteDirecciones == id);
            if (tblClienteDirecciones == null)
            {
                return NotFound();
            }

            return View(tblClienteDirecciones);
        }

        // GET: TblClienteDirecciones/Create
        public IActionResult Create()
        {
            List<TblCliente> ListaCliente = new List<TblCliente>();
            ListaCliente = (from c in _context.TblClientes select c).Distinct().ToList();
            ViewBag.ListaCliente = ListaCliente;

            List<CatTipoDireccion> ListaTipoDireccion = new List<CatTipoDireccion>();
            ListaTipoDireccion = (from c in _context.CatTipoDirecciones select c).Distinct().ToList();
            ViewBag.ListaTipoDireccion = ListaTipoDireccion;

            return View();
        }

        // POST: TblClienteDirecciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdClienteDirecciones,IdTipoDireccion,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,CorreoElectronico,Telefono,IdCliente")] TblClienteDireccion tblClienteDirecciones)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.TblClienteDirecciones
                        .Where(s => s.Calle == tblClienteDirecciones.Calle && s.CodigoPostal == tblClienteDirecciones.CodigoPostal)
                        .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    var fCliente = (from c in _context.TblClientes where c.IdCliente == tblClienteDirecciones.IdCliente select c).Distinct().ToList();
                    var fTipoDireccion = (from c in _context.CatTipoDirecciones where c.IdTipoDireccion == tblClienteDirecciones.IdTipoDireccion select c).Distinct().ToList();
                    tblClienteDirecciones.FechaRegistro = DateTime.Now;
                    tblClienteDirecciones.IdEstatusRegistro = 1;
         
                    var strColonia = _context.CatCodigosPostales.Where(s => s.IdAsentaCpcons == tblClienteDirecciones.Colonia).FirstOrDefault();
                    tblClienteDirecciones.IdColonia = !string.IsNullOrEmpty(tblClienteDirecciones.Colonia) ? tblClienteDirecciones.Colonia : tblClienteDirecciones.Colonia;
                    tblClienteDirecciones.Colonia = !string.IsNullOrEmpty(tblClienteDirecciones.Colonia) ? strColonia.Dasenta.ToUpper() : tblClienteDirecciones.Colonia;
                    tblClienteDirecciones.Calle = !string.IsNullOrEmpty(tblClienteDirecciones.Calle) ? tblClienteDirecciones.Calle.ToUpper() : tblClienteDirecciones.Calle;
                    tblClienteDirecciones.LocalidadMunicipio = !string.IsNullOrEmpty(tblClienteDirecciones.LocalidadMunicipio) ? tblClienteDirecciones.LocalidadMunicipio.ToUpper() : tblClienteDirecciones.LocalidadMunicipio;
                    tblClienteDirecciones.Ciudad = !string.IsNullOrEmpty(tblClienteDirecciones.Ciudad) ? tblClienteDirecciones.Ciudad.ToUpper() : tblClienteDirecciones.Ciudad;
                    tblClienteDirecciones.Estado = !string.IsNullOrEmpty(tblClienteDirecciones.Estado) ? tblClienteDirecciones.Estado.ToUpper() : tblClienteDirecciones.Estado;

                    _context.SaveChanges();
                    _context.Add(tblClienteDirecciones);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    //_notifyService.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
                    _notyf.Warning("Favor de validar, existe una Direccion con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblClienteDirecciones);
        }

        // GET: TblClienteDirecciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<TblCliente> ListaCliente = new List<TblCliente>();
            ListaCliente = (from c in _context.TblClientes select c).Distinct().ToList();
            ViewBag.ListaCliente = ListaCliente;

            List<CatTipoDireccion> ListaTipoDireccion = new List<CatTipoDireccion>();
            ListaTipoDireccion = (from c in _context.CatTipoDirecciones select c).Distinct().ToList();
            ViewBag.ListaTipoDireccion = ListaTipoDireccion;

            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var tblClienteDirecciones = await _context.TblClienteDirecciones.FindAsync(id);
            if (tblClienteDirecciones == null)
            {
                return NotFound();
            }
            return View(tblClienteDirecciones);
        }

        // POST: TblClienteDirecciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdClienteDirecciones,IdTipoDireccion,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,CorreoElectronico,Telefono,IdCliente,IdEstatusRegistro")] TblClienteDireccion tblClienteDirecciones)
        {
            if (id != tblClienteDirecciones.IdClienteDirecciones)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fCliente = (from c in _context.TblClientes where c.IdCliente == tblClienteDirecciones.IdCliente select c).Distinct().ToList();
                    var fTipoDireccion = (from c in _context.CatTipoDirecciones where c.IdTipoDireccion == tblClienteDirecciones.IdTipoDireccion select c).Distinct().ToList();
                    tblClienteDirecciones.FechaRegistro = DateTime.Now;
                    tblClienteDirecciones.IdEstatusRegistro = 1;

                    var strColonia = _context.CatCodigosPostales.Where(s => s.IdAsentaCpcons == tblClienteDirecciones.Colonia).FirstOrDefault();
                    tblClienteDirecciones.IdColonia = !string.IsNullOrEmpty(tblClienteDirecciones.Colonia) ? tblClienteDirecciones.Colonia : tblClienteDirecciones.Colonia;
                    tblClienteDirecciones.Colonia = !string.IsNullOrEmpty(tblClienteDirecciones.Colonia) ? strColonia.Dasenta.ToUpper() : tblClienteDirecciones.Colonia;
                    tblClienteDirecciones.Calle = !string.IsNullOrEmpty(tblClienteDirecciones.Calle) ? tblClienteDirecciones.Calle.ToUpper() : tblClienteDirecciones.Calle;
                    tblClienteDirecciones.LocalidadMunicipio = !string.IsNullOrEmpty(tblClienteDirecciones.LocalidadMunicipio) ? tblClienteDirecciones.LocalidadMunicipio.ToUpper() : tblClienteDirecciones.LocalidadMunicipio;
                    tblClienteDirecciones.Ciudad = !string.IsNullOrEmpty(tblClienteDirecciones.Ciudad) ? tblClienteDirecciones.Ciudad.ToUpper() : tblClienteDirecciones.Ciudad;
                    tblClienteDirecciones.Estado = !string.IsNullOrEmpty(tblClienteDirecciones.Estado) ? tblClienteDirecciones.Estado.ToUpper() : tblClienteDirecciones.Estado;

                    _context.Update(tblClienteDirecciones);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblClienteDireccionesExists(tblClienteDirecciones.IdClienteDirecciones))
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
            return View(tblClienteDirecciones);
        }

        // GET: TblClienteDirecciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClienteDirecciones = await _context.TblClienteDirecciones
                .FirstOrDefaultAsync(m => m.IdClienteDirecciones == id);
            if (tblClienteDirecciones == null)
            {
                return NotFound();
            }

            return View(tblClienteDirecciones);
        }

        // POST: TblClienteDirecciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblClienteDirecciones = await _context.TblClienteDirecciones.FindAsync(id);
            tblClienteDirecciones.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblClienteDireccionesExists(int id)
        {
            return _context.TblClienteDirecciones.Any(e => e.IdClienteDirecciones == id);
        }
    }
}
