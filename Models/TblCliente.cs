using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebHecsa.Models
{
    public partial class TblCliente
    {
        public TblCliente()
        {
            TblClienteContactos = new HashSet<TblClienteContacto>();
            TblClienteDireccion = new HashSet<TblClienteDireccion>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdCliente { get; set; }
        [Display(Name = "Nombre Cliente")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string NombreCliente { get; set; }
        [Display(Name = "RFC")]

        public string Rfc { get; set; }
        [Display(Name = "Giro Comercial")]

        public string GiroComercial { get; set; }
        [Display(Name = "Empresa")]
        public Guid IdEmpresa { get; set; }
        [Column("Fecha Registro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Estatus")]
        public int IdEstatusRegistro { get; set; }
        public Guid? IdEmpresaNavigationIdEmpresa { get; set; }

        public virtual TblEmpresa IdEmpresaNavigationIdEmpresaNavigation { get; set; }
        public virtual ICollection<TblClienteContacto> TblClienteContactos { get; set; }
        public virtual ICollection<TblClienteDireccion> TblClienteDireccion { get; set; }
    }
}
