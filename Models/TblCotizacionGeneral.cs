using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebHecsa.Models
{
    public partial class TblCotizacionGeneral
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdCotizacionGeneral { get; set; }
        public string NumeroCotizacion { get; set; }
        public Guid IdEmpresaFiscales { get; set; }
        public string NombreFiscal { get; set; }
        public string EmpresaGeneral { get; set; }
        public string EmpresaContacto { get; set; }
        public Guid IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Rfccliente { get; set; }
        public string MediosCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string DireccionContacto { get; set; }
        public string ClienteContacto { get; set; }
        public int IdTiposEnvio { get; set; }
        public int IdDivisa { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }
        public int? IdDivisaNavigationIdDivisa { get; set; }
        public Guid? IdEmpresaFiscalesNavigationIdEmpresaFiscales { get; set; }
        public int? IdTiposEnvioNavigationIdTiposEnvio { get; set; }

        public virtual CatDivisa IdDivisaNavigationIdDivisaNavigation { get; set; }
        public virtual TblEmpresaFiscal IdEmpresaFiscalesNavigationIdEmpresaFiscalesNavigation { get; set; }
        public virtual CatTipoEnvio IdTiposEnvioNavigationIdTiposEnvioNavigation { get; set; }
    }
}
