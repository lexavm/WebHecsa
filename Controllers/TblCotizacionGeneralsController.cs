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
    public class TblCotizacionGeneralsController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;

        public TblCotizacionGeneralsController(nDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: TblCotizacionGenerals
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
                    var ValidaEmpresaFiscales = _context.TblEmpresaFiscales.ToList();

                    if (ValidaEmpresaFiscales.Count >= 1)
                    {
                        ViewBag.EmpresaFiscalesFlag = 1;
                        var ValidaCliente = _context.TblClientes.ToList();

                        if (ValidaCliente.Count >= 1)
                        {
                            ViewBag.ClienteFlag = 1;
                            var ValidaGenero = _context.CatGeneros.ToList();

                            if (ValidaGenero.Count >= 1)
                            {
                                ViewBag.GeneroFlag = 1;
                                var ValidaArea = _context.CatAreas.ToList();

                                if (ValidaArea.Count >= 1)
                                {
                                    ViewBag.AreaFlag = 1;
                                    var ValidaPerfil = _context.CatPerfiles.ToList();

                                    if (ValidaPerfil.Count >= 1)
                                    {
                                        ViewBag.PerfilFlag = 1;
                                        var ValidaRol = _context.CatRoles.ToList();

                                        if (ValidaRol.Count >= 1)
                                        {
                                            ViewBag.RolFlag = 1;
                                        }
                                        else
                                        {
                                            ViewBag.RolFlag = 0;
                                            _notyf.Information("Favor de registrar los datos de Rol para la Aplicación", 5);
                                        }
                                    }
                                    else
                                    {
                                        ViewBag.PerfilFlag = 0;
                                        _notyf.Information("Favor de registrar los datos de Perfil para la Aplicación", 5);
                                    }
                                }
                                else
                                {
                                    ViewBag.AreaFlag = 0;
                                    _notyf.Information("Favor de registrar los datos de Area para la Aplicación", 5);
                                }
                            }
                            else
                            {
                                ViewBag.vGeneroFlag = 0;
                                _notyf.Information("Favor de registrar los datos de Genero para la Aplicación", 5);
                            }
                        }
                        else
                        {
                            ViewBag.ClienteFlag = 0;
                            _notyf.Information("Favor de registrar los datos de la Cliente para la Aplicación", 5);
                        }
                    }
                    else
                    {
                        ViewBag.EmpresaFiscalesFlag = 0;
                        _notyf.Information("Favor de registrar los datos Empresa Fiscales para la Aplicación", 5);
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
            return View(await _context.TblCotizacionGenerales.ToListAsync());
        }

        // GET: TblCotizacionGenerals/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCotizacionGeneral = await _context.TblCotizacionGenerales
                .FirstOrDefaultAsync(m => m.IdCotizacionGeneral == id);
            if (tblCotizacionGeneral == null)
            {
                return NotFound();
            }

            return View(tblCotizacionGeneral);
        }

        // GET: TblCotizacionGenerals/Create
        public IActionResult Create()
        {
            List<CatTipoEnvio> ListaTiposEnvio = new List<CatTipoEnvio>();
            ListaTiposEnvio = (from c in _context.CatTipoEnvios select c).Distinct().ToList();
            ViewBag.ListaTiposEnvio = ListaTiposEnvio;

            List<CatDivisa> ListaDivisa = new List<CatDivisa>();
            ListaDivisa = (from c in _context.CatDivisas select c).Distinct().ToList();
            ViewBag.ListaDivisa = ListaDivisa;

            List<CatEstatusCotizacion> ListaEstatusCotizacion = new List<CatEstatusCotizacion>();
            ListaEstatusCotizacion = (from c in _context.CatEstatusCotizacion select c).Distinct().ToList();
            ViewBag.ListaEstatusCotizacion = ListaEstatusCotizacion;

            List<TblEmpresaFiscal> ListaEfiscales = new List<TblEmpresaFiscal>();
            ListaEfiscales = (from c in _context.TblEmpresaFiscales select c).Distinct().ToList();
            ViewBag.ListaEfiscales = ListaEfiscales;

            List<TblCliente> ListaCliente = new List<TblCliente>();
            ListaCliente = (from c in _context.TblClientes select c).Distinct().ToList();
            ViewBag.ListaCliente = ListaCliente;

            return View();
        }

        private string GeneraCotizacion()
        {
            string fmt = "00000000.##";
            int Cuenta = 0;
            string strCodigoInterno = string.Empty;
            int lProductos = _context.CatProductos.Count();

            if (lProductos == 0)
            {
                Cuenta = 1;
                strCodigoInterno = "H-c" + Cuenta.ToString(fmt);
            }
            else
            {
                Cuenta = lProductos + 1;
                strCodigoInterno = "H-c" + Cuenta.ToString(fmt);
            }

            return strCodigoInterno;
        }

        // POST: TblCotizacionGenerals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCotizacionGeneral,IdEmpresaFiscales,IdCliente,IdTiposEnvio")] TblCotizacionGeneral tblCotizacionGeneral)
        {
            if (ModelState.IsValid)
            {
                var vDuplicados = _context.TblCotizacionGenerales
              .Where(s => s.IdCotizacionGeneral == tblCotizacionGeneral.IdCotizacionGeneral)
              .ToList();

                if (vDuplicados.Count == 0)
                {
                    var fDivisa = _context.CatDivisas.FirstOrDefault();
                    var fContactoCliente = (from c in _context.TblClienteContactos where c.IdCliente == tblCotizacionGeneral.IdCliente select c).Distinct().ToList();
                    tblCotizacionGeneral.IdCotizacionGeneral = Guid.NewGuid();
                    tblCotizacionGeneral.NumeroCotizacion = GeneraCotizacion();
                    tblCotizacionGeneral.IdDivisa = fDivisa.IdDivisa;
                    tblCotizacionGeneral.IdClienteContacto = fContactoCliente[0].IdClienteContacto;
                    tblCotizacionGeneral.FechaRegistro = DateTime.Now;
                    tblCotizacionGeneral.IdEstatusRegistro = 1;
                    tblCotizacionGeneral.IdEstatusCotizacion = 1;
                    _context.Add(tblCotizacionGeneral);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //_notifyService.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
                    _notyf.Warning("Favor de validar, existe una Producto con la misma marca y misma categoria", 5);
                }
            }
            return View(tblCotizacionGeneral);
        }

        // GET: TblCotizacionGenerals/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCotizacionGeneral = await _context.TblCotizacionGenerales.FindAsync(id);
            if (tblCotizacionGeneral == null)
            {
                return NotFound();
            }
            return View(tblCotizacionGeneral);
        }

        // POST: TblCotizacionGenerals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdCotizacionGeneral,NumeroCotizacion,IdEmpresaFiscales,NombreFiscal,EmpresaGeneral,EmpresaContacto,IdCliente,NombreCliente,RFCCliente,MediosCliente,DireccionCliente,DireccionContacto,ClienteContacto")] TblCotizacionGeneral tblCotizacionGeneral)
        {
            if (id != tblCotizacionGeneral.IdCotizacionGeneral)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCotizacionGeneral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCotizacionGeneralExists(tblCotizacionGeneral.IdCotizacionGeneral))
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
            return View(tblCotizacionGeneral);
        }

        // GET: TblCotizacionGenerals/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCotizacionGeneral = await _context.TblCotizacionGenerales
                .FirstOrDefaultAsync(m => m.IdCotizacionGeneral == id);
            if (tblCotizacionGeneral == null)
            {
                return NotFound();
            }

            return View(tblCotizacionGeneral);
        }

        // POST: TblCotizacionGenerals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblCotizacionGeneral = await _context.TblCotizacionGenerales.FindAsync(id);
            _context.TblCotizacionGenerales.Remove(tblCotizacionGeneral);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblCotizacionGeneralExists(Guid id)
        {
            return _context.TblCotizacionGenerales.Any(e => e.IdCotizacionGeneral == id);
        }
    }
}