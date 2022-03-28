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
            TblProveedorDireccion = new HashSet<TblProveedorDireccion>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdProveedor { get; set; }
        [Display(Name = "Nombre Proveedor")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string NombreProveedor { get; set; }
        [Display(Name = "RFC")]

        public string Rfc { get; set; }
        [Display(Name = "Giro Comercial")]

        public string GiroComercial { get; set; }
        [Display(Name = "Empresa")]

        public Guid IdEmpresa { get; set; }
        [Column("Fecha Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Estatus")]
        public int IdEstatusRegistro { get; set; }
        public Guid? IdEmpresaNavigationIdEmpresa { get; set; }

        public virtual TblEmpresa IdEmpresaNavigationIdEmpresaNavigation { get; set; }
        public virtual ICollection<CatMarca> CatMarcas { get; set; }
        public virtual ICollection<TblProveedorContacto> TblProveedorContactos { get; set; }
        public virtual ICollection<TblProveedorDireccion> TblProveedorDireccion { get; set; }
    }
}
