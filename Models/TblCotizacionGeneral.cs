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
        [Display(Name = "Numero Cotizacion")]

        public string NumeroCotizacion { get; set; }

        [Display(Name = "Fiscales")]
        [Required(ErrorMessage = "Campo Requerido")]
        public Guid IdEmpresaFiscales { get; set; }
        [NotMapped]
        [Display(Name = "Nombre Fiscal")]

        public string NombreFiscal { get; set; }
        [NotMapped]
        [Display(Name = "RFC")]
        public string Rfc { get; set; }
        [NotMapped]
        [Display(Name = "Regimen Fiscal")]
        public string RegimenFiscal { get; set; }
        [NotMapped]
        [Display(Name = "Calle")]

        public string Calle { get; set; }
        [NotMapped]
        [Display(Name = "Codigo Postal")]

        public string CodigoPostal { get; set; }
        [NotMapped]
        [Display(Name = "Colonia")]
        public string IdColonia { get; set; }
        [NotMapped]
        [Display(Name = "Colonia")]

        public string Colonia { get; set; }
        [NotMapped]
        [Display(Name = "Localidad / Municipio")]

        public string LocalidadMunicipio { get; set; }
        [NotMapped]

        [Display(Name = "Ciudad")]

        public string Ciudad { get; set; }
        [NotMapped]

        [Display(Name = "Estado")]

        public string Estado { get; set; }
        [NotMapped]

        [Display(Name = "Correo Electronico")]

        public string CorreoElectronicoFiscal { get; set; }
        [NotMapped]

        [Display(Name = "Telefono")]

        public string TelefonoFiscal { get; set; }

        [Display(Name = "Contacto Cliente")]
        public int IdClienteContacto { get; set; }
        [NotMapped]
        [Display(Name = "Perfil")]

        public int IdPerfil { get; set; }
        [NotMapped]
        [Display(Name = "Perfil")]
        public string PerfilDesc { get; set; }
        [NotMapped]
        [Display(Name = "Nombre Contacto")]

        public string NombreClienteContacto { get; set; }
        [NotMapped]
        [Display(Name = "Correo Electronico Contacto")]


        public string CorreoElectronicoContacto { get; set; }
        [NotMapped]
        [Display(Name = "Telefono Contacto")]

        public string TelefonoContacto { get; set; }
        [NotMapped]
        [Display(Name = "Telefono Movil Contacto")]
        public string TelefonoMovilContacto { get; set; }
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Campo Requerido")]
        public Guid IdCliente { get; set; }
        [NotMapped]
        [Display(Name = "Nombre Cliente")]
        public string NombreCliente { get; set; }
        [Display(Name = "Tipo Envio")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdTiposEnvio { get; set; }
        [Display(Name = "Divisa")]

        public int IdDivisa { get; set; }
        [NotMapped]
        [Display(Name = "Divisa")]

        public string DivisaDesc { get; set; }
        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Estatus")]
        public int IdEstatusRegistro { get; set; }
        [Display(Name = "Estatus Cotizacion")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdEstatusCotizacion { get; set; }
        [NotMapped]
        [Display(Name = "Estatus Cotizacion")]

        public string EstatusCotizacionDesc { get; set; }
        public int? IdDivisaNavigationIdDivisa { get; set; }
        public Guid? IdEmpresaFiscalesNavigationIdEmpresaFiscales { get; set; }
        public int? IdTiposEnvioNavigationIdTiposEnvio { get; set; }

        public virtual CatDivisa IdDivisaNavigationIdDivisaNavigation { get; set; }
        public virtual TblEmpresaFiscal IdEmpresaFiscalesNavigationIdEmpresaFiscalesNavigation { get; set; }
        public virtual CatTipoEnvio IdTiposEnvioNavigationIdTiposEnvioNavigation { get; set; }
    }
}
