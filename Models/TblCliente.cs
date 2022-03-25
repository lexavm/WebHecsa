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
            TblClienteDirecciones = new HashSet<TblClienteDireccion>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Rfc { get; set; }
        public string GiroComercial { get; set; }
        public Guid IdEmpresa { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }
        public Guid? IdEmpresaNavigationIdEmpresa { get; set; }

        public virtual TblEmpresa IdEmpresaNavigationIdEmpresaNavigation { get; set; }
        public virtual ICollection<TblClienteContacto> TblClienteContactos { get; set; }
        public virtual ICollection<TblClienteDireccion> TblClienteDirecciones { get; set; }
    }
}
