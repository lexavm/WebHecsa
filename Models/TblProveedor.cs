using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebHecsa.Models
{
    public partial class TblProveedor
    {
        public TblProveedor()
        {
            CatMarcas = new HashSet<CatMarca>();
            TblProveedorContactos = new HashSet<TblProveedorContacto>();
            TblProveedorDirecciones = new HashSet<TblProveedorDireccion>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string Rfc { get; set; }
        public string GiroComercial { get; set; }
        public Guid IdEmpresa { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }
        public Guid? IdEmpresaNavigationIdEmpresa { get; set; }

        public virtual TblEmpresa IdEmpresaNavigationIdEmpresaNavigation { get; set; }
        public virtual ICollection<CatMarca> CatMarcas { get; set; }
        public virtual ICollection<TblProveedorContacto> TblProveedorContactos { get; set; }
        public virtual ICollection<TblProveedorDireccion> TblProveedorDirecciones { get; set; }
    }
}
