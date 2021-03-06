using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebHecsa.Models;

#nullable disable

namespace WebHecsa.Data
{
    public partial class nDbContext : DbContext
    {
        public nDbContext()
        {
        }

        public nDbContext(DbContextOptions<nDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatArea> CatAreas { get; set; }
        public virtual DbSet<CatCategoria> CatCategorias { get; set; }
        public virtual DbSet<CatCodigosPostale> CatCodigosPostales { get; set; }
        public virtual DbSet<CatDivisa> CatDivisas { get; set; }
        public virtual DbSet<CatEstatus> CatEstatus { get; set; }
        public virtual DbSet<CatGenero> CatGeneros { get; set; }
        public virtual DbSet<CatMarca> CatMarcas { get; set; }
        public virtual DbSet<CatPerfil> CatPerfiles { get; set; }
        public virtual DbSet<CatProducto> CatProductos { get; set; }
        public virtual DbSet<CatRole> CatRoles { get; set; }
        public virtual DbSet<CatTipoDireccion> CatTipoDirecciones { get; set; }
        public virtual DbSet<CatTipoEnvio> CatTipoEnvios { get; set; }
        public virtual DbSet<CatTiposEstatus> CatTiposEstatus { get; set; }
        public virtual DbSet<TblCliente> TblClientes { get; set; }
        public virtual DbSet<TblClienteContacto> TblClienteContactos { get; set; }
        public virtual DbSet<TblClienteDireccion> TblClienteDirecciones { get; set; }
        public virtual DbSet<TblCotizacionGeneral> TblCotizacionGenerales { get; set; }
        public virtual DbSet<TblEmpresa> TblEmpresas { get; set; }
        public virtual DbSet<TblEmpresaFiscal> TblEmpresaFiscales { get; set; }
        public virtual DbSet<TblProveedor> TblProveedores { get; set; }
        public virtual DbSet<TblProveedorContacto> TblProveedorContactos { get; set; }
        public virtual DbSet<TblProveedorDireccion> TblProveedorDirecciones { get; set; }
        public virtual DbSet<TblUsuario> TblUsuarios { get; set; }

        public virtual DbSet<TblProductoPromocion> TblProductoPromociones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "server=iides.tech;user=iidestec_usr;database=iidestec_hecsa;port=3306;password=AX%B3#XqX@2q;";
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
                optionsBuilder.UseMySql(connectionString, serverVersion);
            }
        }

  
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

  
        public DbSet<WebHecsa.Models.CatEstatusCotizacion> CatEstatusCotizacion { get; set; }
    }
}
